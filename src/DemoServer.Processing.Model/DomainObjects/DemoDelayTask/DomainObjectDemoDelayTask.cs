using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.Common;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Mappers.Primitives.MutableFields;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask;

[DomainObjectDataMapper]
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DomainObjectDemoDelayTask : BaseDomainObjectMutable<DomainObjectDemoDelayTask>, IDomainObjectDemoDelayTask
{
    #region Template - шаблон создания объекта DemoDelayTask

    /// <summary>
    /// Шаблон создания объекта <see cref="DomainObjectDemoDelayTask"/>.
    /// </summary>
    public class Template : IDomainObjectTemplate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // ReSharper disable once ConvertToPrimaryConstructor
        public Template(
            DemoDelayTaskScenario scenario, 
            DateTimeOffset? startDate)
        {
            Scenario = scenario;
            StartDate = startDate;
        }

        public readonly DemoDelayTaskScenario Scenario;
        public readonly DateTimeOffset? StartDate;
    }

    #endregion

    #region Изменяемы поля

    [DomainObjectFieldValue]
    private MutableField<bool> m_available;

    #endregion

    #region Конструкторы

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoDelayTask(
        DemoDelayTaskDtoActual data,
        ICustomEntryPoint entryPoint)
        : base(entryPoint, data)
    {
        m_available = new MutableField<bool>(data.Available);
        CreateDate = data.CreateDate;
        ModificationDate = data.ModificationDate;
        Scenario = data.Scenario;
        StartDate = data.StartDate;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once UnusedMember.Global
    public DomainObjectDemoDelayTask(
        long identity,
        Template template,
        ICustomEntryPoint entryPoint)
        : base(entryPoint, identity)
    {
        m_available = new MutableField<bool>(true);
        CreateDate = entryPoint.TimeService.Now;
        ModificationDate = CreateDate;
        Scenario = template.Scenario.ToJsonText();
        StartDate = template.StartDate;
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

    [DomainObjectFieldValue]
    public DateTimeOffset? StartDate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    public async ValueTask<(bool IsCompleted, CancellationToken? CommitCancellationToken)> ProcessAsync(bool isRemoved, CancellationToken cancellationToken)
    {
        var scenario = Scenario.FromJson<DemoDelayTaskScenario>();

        if (scenario is DemoDelayTaskScenarioAsDelay scenarioAsDelay)
        {
            Console.WriteLine($"[{m_entryPoint.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} - Начало ожидания '{scenarioAsDelay.Delay}' ...");
            await Task.Delay(scenarioAsDelay.Delay, cancellationToken).ConfigureAwait(false);
            Console.WriteLine($"[{m_entryPoint.TimeService.NowDateTime:O}] DemoDelayTask.Id:{Identity} - Конец ожидания.");
        }
        else
        {
            throw new InternalException($"Неизвестный тип сценария '{scenario.GetType().Assembly}'.");
        }

        m_available.SetValue(false);

        await DoUpdateAsync(cancellationToken).ConfigureAwait(false);

        return (true, null);
    }

    protected override ValueTask DoUpdateAsync(CancellationToken cancellationToken = default)
    {
        ModificationDate = m_entryPoint.TimeService.NowDateTime;

        return base.DoUpdateAsync(cancellationToken);
    }
}
