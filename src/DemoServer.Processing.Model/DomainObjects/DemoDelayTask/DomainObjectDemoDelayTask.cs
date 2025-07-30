using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;
using Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.ScenarioStates;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.CodeGeneration.Generators;
using Acme.Wattle.Common.Exceptions;
using Acme.Wattle.DomainObjects.DomainObjects;
using Acme.Wattle.DomainObjects.DomainObjects.BaseDomainObjects;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.DomainObjects.Serializers;
using Acme.Wattle.DomainObjects.Serializers.Json;
using Acme.Wattle.DomainObjects.UnitOfWorkLocks;
using Acme.Wattle.Mappers.Primitives.MutableFields;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask;

[DomainObjectDataMapper]
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DomainObjectDemoDelayTask : BaseDomainObjectMutableWithUpdateLock<DomainObjectDemoDelayTask, IEntryPointContext<ICustomEntryPoint>>, IDomainObjectDemoDelayTask
{
    #region Template - шаблон создания объекта

    /// <summary>
    /// Шаблон создания объекта <see cref="DomainObjectDemoDelayTask"/>.
    /// </summary>
    public class Template : IDomainObjectTemplate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // ReSharper disable once ConvertToPrimaryConstructor
        public Template(
            string scenario, 
            DateTimeOffset? startDate)
        {
            Scenario = scenario;
            StartDate = startDate;
        }

        /// <summary>
        /// <seealso cref="DemoDelayTaskScenario"/>.
        /// </summary>
        public readonly string Scenario;

        public readonly DateTimeOffset? StartDate;
    }

    #endregion

    #region Изменяемы поля

    [DomainObjectFieldValue]
    private readonly MutableField<bool> m_available;

    [DomainObjectFieldValue]
    private readonly MutableFieldNullable<DateTimeOffset> m_startDate;

    [DomainObjectFieldValue]
    private readonly StringFieldWithModel<DemoCycleTaskScenarioState> m_scenarioState;

    #endregion

    #region Конструкторы

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoDelayTask(
        DemoDelayTaskDtoActual data,
        IEntryPointContext<ICustomEntryPoint> entryPointContext,
        IDomainObjectUnitOfWorkLockService lockUpdate)
        : base(entryPointContext, data, lockUpdate, false)
    {
        m_available = new MutableField<bool>(data.Available);
        CreateDate = data.CreateDate;
        ModificationDate = data.ModificationDate;
        Scenario = data.Scenario;

        m_startDate = 
            new MutableFieldNullable<DateTimeOffset>(
                // Дата-время в БД хранится с ограниченной точность.
                DbTypesCorrector.DateTimeOffset(data.StartDate));

        m_scenarioState =
            new StringFieldWithModel<DemoCycleTaskScenarioState>(
                m_entryPointContext.EntryPoint.JsonDeserializer,
                data.ScenarioState);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoDelayTask(
        long identity,
        Template template,
        IEntryPointContext<ICustomEntryPoint> entryPointContext,
        IDomainObjectUnitOfWorkLockService lockUpdate)
        : base(entryPointContext, identity, lockUpdate, true)
    {
        m_available = new MutableField<bool>(true);
        CreateDate = m_entryPointContext.TimeService.Now;
        ModificationDate = CreateDate;
        Scenario = template.Scenario;
        m_startDate = new MutableFieldNullable<DateTimeOffset>(template.StartDate);

        var scenario = m_entryPointContext.EntryPoint.JsonDeserializer.DeserializeReadOnly<DemoDelayTaskScenario, DemoDelayTaskScenario>(Scenario);

        m_scenarioState =
            new StringFieldWithModel<DemoCycleTaskScenarioState>(
                m_entryPointContext.EntryPoint.JsonDeserializer,
                string.Empty);

        switch (scenario.Type)
        {
            case DemoDelayTaskScenariosType.Empty:
            case DemoDelayTaskScenariosType.Poisoned:
            case DemoDelayTaskScenariosType.Delay:
                /* NONE */

                break;

            case DemoDelayTaskScenariosType.Cycle:
            {
                var scenarioStateAsCycle =
                    new DemoCycleTaskScenarioStateAsCycle
                    {
                        Index = 0,
                        RunDate = [],
                    };
                m_scenarioState.SetValue(scenarioStateAsCycle, ModelUseMode.ReadOnly);

                break;
            }

            default:
                throw new InternalException($"Неизвестный тип сценария '{scenario.GetType().Assembly}'.");
        }
    }

    #endregion

    public override Guid TypeId => WellknownDomainObjects.DemoDelayTask;

    [DomainObjectFieldValue]
    public DateTimeOffset CreateDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    [DomainObjectFieldValue]
    public DateTimeOffset ModificationDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private set;
    }

    [DomainObjectFieldValue]
    public string Scenario
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    public string ScenarioState
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_scenarioState.Value;
    }

    public DateTimeOffset? StartDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => m_startDate.Value;
    }

    public async ValueTask<(bool IsCompleted, CancellationToken? CommitCancellationToken)> ProcessAsync(bool isRemoved, long count, CancellationToken cancellationToken)
    {
        m_lockUpdate.Has(Identity);

        if (isRemoved)
        {
            Console.WriteLine($"[{m_entryPointContext.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} - Удалена.");

            m_available.SetValue(false);
        }
        else
        {
            await DoRunScenarioAsync(count, cancellationToken).ConfigureAwait(false);
        }

        await DoUpdateAsync(cancellationToken).ConfigureAwait(false);

        if (m_available.Value)
        {
            return (false, null);
        }

        // Явная очистка памяти. Это не обязательно т.к. данные по времени будут удаленны из кэша.
        m_entryPointContext.EntryPoint.JsonDeserializer.Release<DemoDelayTaskScenario>(Scenario);
        m_scenarioState.ReleaseSmartDeserializer();

        return (true, null);
    }

    protected override ValueTask DoUpdateAsync(CancellationToken cancellationToken = default)
    {
        ModificationDate = m_entryPointContext.TimeService.Now;

        return base.DoUpdateAsync(cancellationToken);
    }

    private async ValueTask DoRunScenarioAsync(long count, CancellationToken cancellationToken)
    {
        var scenario = m_entryPointContext.EntryPoint.JsonDeserializer.DeserializeReadOnly<DemoDelayTaskScenario, DemoDelayTaskScenario>(Scenario);

        if (scenario is DemoDelayTaskScenarioAsDelay scenarioAsDelay)
        {
            if (count > 1)
            {
                throw new InternalException("Что-то сломалось, задача исполняется несколько раз.");
            }

            Console.WriteLine($"[{m_entryPointContext.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} ({scenarioAsDelay.Type}) - Начало ожидания '{scenarioAsDelay.Delay}' ...");
            await Task.Delay(scenarioAsDelay.Delay, cancellationToken).ConfigureAwait(false);
            Console.WriteLine($"[{m_entryPointContext.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} ({scenarioAsDelay.Type}) - Конец ожидания.");

            m_available.SetValue(false);
        }
        else if (scenario is DemoDelayTaskScenarioAsEmpty scenarioAsEmpty)
        {
            if (count > 1)
            {
                throw new InternalException("Что-то сломалось, задача исполняется несколько раз.");
            }

            Console.WriteLine($"[{m_entryPointContext.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} ({scenarioAsEmpty.Type}) - Исполнена.");

            m_available.SetValue(false);
        }
        else if (scenario is DemoDelayTaskScenarioAsPoisoned scenarioAsPoisoned)
        {
            if (count > 1)
            {
                throw new InternalException("Что-то сломалось, задача исполняется несколько раз.");
            }

            Console.WriteLine($"[{m_entryPointContext.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} ({scenarioAsPoisoned.Type}) - Начало исполнения 'IsSuspended: {m_entryPointContext.EntryPoint.DemoDelayTaskProcessor.IsSuspended}' ...");
            m_entryPointContext.EntryPoint.DemoDelayTaskProcessor.Suspend();
            Console.WriteLine($"[{m_entryPointContext.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} ({scenarioAsPoisoned.Type}) - Конец исполнения 'IsSuspended: {m_entryPointContext.EntryPoint.DemoDelayTaskProcessor.IsSuspended}'.");

            m_available.SetValue(false);
        }
        else if (scenario is DemoDelayTaskScenarioAsCycle scenarioAsCycle)
        {
            if (count > scenarioAsCycle.Count)
            {
                throw new InternalException("Что-то сломалось, задача исполняется слишком много раз.");
            }

            var scenariostate = m_scenarioState.GetAsWrite<DemoCycleTaskScenarioStateAsCycle>();

            Console.WriteLine($"[{m_entryPointContext.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} ({scenarioAsCycle.Type}) - Начало исполнения '{scenariostate.Index}' ...");

            if (scenariostate.Index < scenarioAsCycle.Count)
            {
                scenariostate.Index++;

                var now = m_entryPointContext.TimeService.Now;
                scenariostate.RunDate.Add(now);

                if (scenarioAsCycle.NextRunTimeout.HasValue)
                {
                    m_startDate.SetValue(
                        // Дата-время в БД хранится с ограниченной точность.
                        DbTypesCorrector.DateTimeOffset(now + scenarioAsCycle.NextRunTimeout.Value));
                }
                else
                {
                    m_startDate.SetValue(null);
                }
            }

            Console.WriteLine($"[{m_entryPointContext.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} ({scenarioAsCycle.Type}) - Конец исполнения '{scenariostate.Index}' [{(m_startDate.Value?.ToString("O") ?? "НЕТ ДАТЫ")}].");

            m_available.SetValue(scenariostate.Index < scenarioAsCycle.Count);
        }
        else
        {
            throw new InternalException($"Неизвестный тип сценария '{scenario.GetType().Assembly}'.");
        }
    }
}
