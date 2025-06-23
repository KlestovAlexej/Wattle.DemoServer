using System;
using System.Threading;
using System.Threading.Tasks;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;
using Acme.DemoServer.Processing.Model.Implements;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.AsyncTasks;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask;

public class DemoDelayTaskProcessor : BaseAsyncTaskServiceDefault<UnitOfWork, ICustomEntryPoint, WorkflowExceptionPolicy, DomainObjectDemoDelayTask.Template, IDomainObjectDemoDelayTask, DemoDelayTaskDtoActual>, IDemoDelayTaskProcessor
{
#if DEBUG
    public bool RunTasks = true;
#endif

    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoDelayTaskProcessor(ICustomEntryPoint customEntryPoint)
        : base(
            customEntryPoint.Context,
            customEntryPoint.SystemSettings.DemoDelayTaskProcessorSettings.Value,
            supportSuspend: true,
            tracer: customEntryPoint.Tracer,
            hub: customEntryPoint.UnitOfWorkLocks)
    {
    }

#if DEBUG
    protected override void DoTaskRegisterAndRun(AsyncTaskProcessor asyncTaskProcessor, (long TaskId, DateTimeOffset? RunDateTime) task)
    {
        if (false == RunTasks)
        {
            return;
        }

        base.DoTaskRegisterAndRun(asyncTaskProcessor, task);
    }
#endif

    public async ValueTask<long> AddAsync(
        DemoDelayTaskScenario scenario,
        DateTimeOffset? startDate,
        bool skipValidationMaxActiveTasks,
        CancellationToken cancellationToken = default)
    {
        DoCheckIsReady();

        var scenarioText = m_entryPoint.JsonDeserializer.SerializeVolatile(scenario);
        var template = new DomainObjectDemoDelayTask.Template(scenarioText, startDate);
        var taskId =
            await DoAddAsync(
                    template,
                    skipValidationMaxActiveTasks,
                    cancellationToken)
                .ConfigureAwait(false);

        Console.WriteLine($"[{m_entryPoint.TimeService.NowDateTime:O}] DemoDelayTask.Id:{taskId} - Создана.");

        return taskId;
    }
}