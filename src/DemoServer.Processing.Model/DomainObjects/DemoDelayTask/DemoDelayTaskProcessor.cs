using System;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.AsyncTasks;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask;

public class DemoDelayTaskProcessor : BaseAsyncTaskServiceDefault<UnitOfWork, ICustomEntryPoint, WorkflowExceptionPolicy, DomainObjectDemoDelayTask.Template, IDomainObjectDemoDelayTask, DemoDelayTaskDtoActual>, IDemoDelayTaskProcessor
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoDelayTaskProcessor(IEntryPointContext entryPointContext)
        : base(
            entryPointContext,
            new Guid("29512D08-8971-4455-957C-96B4BCB6D362"),
            "Служба обработки задач с отложенным запуском",
            ((ICustomEntryPoint)entryPointContext.EntryPoint).SystemSettings.DemoDelayTaskProcessorSettings.Value,
            tracer: ((ICustomEntryPoint)entryPointContext.EntryPoint).Tracer)
    {
    }

    public async ValueTask<long> AddAsync(
        DemoDelayTaskScenario scenario,
        DateTimeOffset? startDate,
        bool skipValidationMaxActiveTasks,
        CancellationToken cancellationToken = default)
    {
        DoCheckIsReady();

        var template = new DomainObjectDemoDelayTask.Template(scenario, startDate);
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