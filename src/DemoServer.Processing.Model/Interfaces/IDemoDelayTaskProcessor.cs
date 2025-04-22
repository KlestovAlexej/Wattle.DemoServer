using System;
using System.Threading;
using System.Threading.Tasks;
using Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;
using Acme.Wattle.DomainObjects.AsyncTasks;

namespace Acme.DemoServer.Processing.Model.Interfaces;

public interface IDemoDelayTaskProcessor : IAsyncTaskService
{
    ValueTask<long> AddAsync(DemoDelayTaskScenario scenario, DateTimeOffset? startDate = null, bool skipValidationMaxActiveTasks = false, CancellationToken cancellationToken = default);
}