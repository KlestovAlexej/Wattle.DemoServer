using System;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;
using ShtrihM.Wattle3.DomainObjects.AsyncTasks;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

public interface IDemoDelayTaskProcessor : IAsyncTaskService
{
    ValueTask<long> AddAsync(DemoDelayTaskScenario scenario, DateTimeOffset? startDate, bool skipValidationMaxActiveTasks, CancellationToken cancellationToken = default);
}