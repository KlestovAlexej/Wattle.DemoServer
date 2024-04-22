using System;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.AsyncTasks;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask;

public class DemoDelayTaskProcessor : BaseAsyncTaskServiceDefault<UnitOfWork, ICustomEntryPoint, WorkflowExceptionPolicy, DomainObjectDemoDelayTask.Template, IDomainObjectDemoDelayTask, DemoDelayTaskDtoActual>, IDemoDelayTaskProcessor
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoDelayTaskProcessor(ICustomEntryPoint customEntryPoint)
        : base(
            customEntryPoint.Context,
            customEntryPoint.SystemSettings.DemoDelayTaskProcessorSettings.Value,
            tracer: customEntryPoint.Tracer,
            hub: customEntryPoint.UnitOfWorkLocks)
    {
    }

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