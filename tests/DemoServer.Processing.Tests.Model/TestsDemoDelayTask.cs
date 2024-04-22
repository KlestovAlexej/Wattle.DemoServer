using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Tests.Model.Environment;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Testing;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Utils;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.ScenarioStates;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using System.Threading;

namespace ShtrihM.DemoServer.Processing.Tests.Model;

[TestFixture]
[SuppressMessage("ReSharper", "AccessToDisposedClosure")]
[SuppressMessage("ReSharper", "MethodSupportsCancellation")]
public class TestsDemoDelayTask : BaseTestsDomainObjects
{
    private static readonly TimeSpan Magic = TimeSpan.FromSeconds(2);

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Ожидание конца исполнения задачи. Задача запускается немедленно с повторением 3 раза с интервалом 4 секунды.")]
    public async Task Test_TaskWaitEnd_Cycle()
    {
        var taskId =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, _) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsCycle
                        {
                            Count = 3,
                            NextRunTimeout = TimeSpan.FromSeconds(4),
                        },
                        null,
                        false),
                autoCommit: true);

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId, out var taskWaitHandler));

        WaitHelpers.TimeOut(
            () => taskWaitHandler!.WaitAsync().SafeGetResult(),
            WaitTimeout);

        Assert.IsFalse(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));

        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            async (unitOfWork, _) =>
            {
                var task = await m_entryPoint.FindAsync<IDomainObjectDemoDelayTask>(taskId);
                Assert.IsNull(task);

                var mapper = m_entryPoint.Mappers.GetMapper<IMapperDemoDelayTask>();
                var dto = await mapper.GetRawAsync(unitOfWork.MappersSession, taskId);
                Assert.IsNotNull(dto);
                var scenarioState =
                    (DemoCycleTaskScenarioStateAsCycle)m_entryPoint.JsonDeserializer
                        .DeserializeReadOnly<DemoCycleTaskScenarioState>(dto.ScenarioState);
                Assert.AreEqual(3, scenarioState.Index);
                Assert.AreEqual(3, scenarioState.RunDate.Count);
                foreach (var runDate in scenarioState.RunDate)
                {
                    Console.WriteLine($"RunDate {runDate:O}");
                }
            },
            autoCommit: true);
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Ожидание конца исполнения задачи. Задача запускается немедленно.")]
    public async Task Test_TaskWaitEnd_RunNow()
    {
        var scenarioDelay = TimeSpan.FromSeconds(5);
        var taskId =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        null,
                        false,
                        cancellationToken),
                autoCommit: true);

        var sw = Stopwatch.StartNew();

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId, out var taskWaitHandler));
        Assert.IsTrue(await taskWaitHandler!.WaitAsync(scenarioDelay + Magic));

        sw.Stop();
        Assert.Less(scenarioDelay - Magic, sw.Elapsed);
        Assert.Greater(scenarioDelay + Magic, sw.Elapsed);

        Assert.IsFalse(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Немедленная остановка задания в БД в момент исполнения задачи.")]
    public async Task Test_StopNow_Running()
    {
        var scenarioDelay = TimeSpan.FromSeconds(30);
        var runDelay = TimeSpan.FromSeconds(4);
        var fullDelay = scenarioDelay + runDelay;
        var taskId =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        m_entryPoint.TimeService.Now + runDelay,
                        false,
                        cancellationToken),
                autoCommit: true);

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId, out var taskWaitHandler));

        // Ждём начала запуска задачи - исполнение задачи происходит в монопольной критической секции.
        Thread.Sleep(runDelay * 2);

        Console.WriteLine($"[{m_entryPoint.TimeService.NowDateTime:O}] DemoDelayTask.Id:{taskId} - До удаления.");

        var sw = Stopwatch.StartNew();

        // Удаление исполняемой задачи происходит в критической секции.
        // Но секция уже занята (есть ожидание входя в секций, сконфигурированное время), поэтому удаления в БД не будет, но задача пометится на удаление.
        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            async (_, cancellationToken) =>
                await m_entryPoint.DemoDelayTaskProcessor
                    // Попытка немедленной остановки задания в БД при подтверждении UnitOfWork.
                    .RemoveAsync(taskId, cancellationToken),
            autoCommit: true);

        sw.Stop();

        // Проверяем что ожидание входа в критическую секцию соответствует сконфигурированному времени.
        Assert.Less(sw.Elapsed, m_entryPoint.SystemSettings.UnitOfWorkLocksSettings.Value.UpdateTimeout.Value + Magic);
        Assert.Greater(sw.Elapsed, m_entryPoint.SystemSettings.UnitOfWorkLocksSettings.Value.UpdateTimeout.Value - Magic);

        Console.WriteLine($"[{m_entryPoint.TimeService.NowDateTime:O}] DemoDelayTask.Id:{taskId} - После удаления.");

        // Проверка что задача в БД не остановлена.
        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            async (unitOfWork, cancellationToken) =>
            {
                var mapper = unitOfWork.MappersSession.Mappers.GetMapper<IMapperDemoDelayTask>();
                var dto = await mapper.GetRawAsync(unitOfWork.MappersSession, taskId, cancellationToken);
                Assert.IsNotNull(dto);
                Assert.IsTrue(dto.Available);
            },
            autoCommit: true);

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));
        Assert.IsTrue(await taskWaitHandler!.WaitAsync(fullDelay + Magic));
        Assert.IsFalse(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));

        // Проверка что задача в БД остановлена.
        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            async (unitOfWork, cancellationToken) =>
            {
                var mapper = unitOfWork.MappersSession.Mappers.GetMapper<IMapperDemoDelayTask>();
                var dto = await mapper.GetRawAsync(unitOfWork.MappersSession, taskId, cancellationToken);
                Assert.IsNotNull(dto);
                Assert.IsFalse(dto.Available);
            },
            autoCommit: true);
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Немедленная остановка задания в БД.")]
    public async Task Test_StopNow()
    {
        var scenarioDelay = TimeSpan.FromSeconds(5);
        var runDelay = TimeSpan.FromSeconds(20);
        var fullDelay = scenarioDelay + runDelay;
        var taskId =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        m_entryPoint.TimeService.Now + runDelay,
                        false,
                        cancellationToken),
                autoCommit: true);

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId, out var taskWaitHandler));

        Console.WriteLine($"[{m_entryPoint.TimeService.NowDateTime:O}] DemoDelayTask.Id:{taskId} - До удаления.");

        var sw = Stopwatch.StartNew();

        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            async (_, cancellationToken) =>
                await m_entryPoint.DemoDelayTaskProcessor
                    // Немедленная остановка задания в БД при подтверждении UnitOfWork.
                    .RemoveAsync(taskId, cancellationToken),
            autoCommit: true);

        sw.Stop();
        Assert.Less(sw.Elapsed, TimeSpan.FromSeconds(2));

        Console.WriteLine($"[{m_entryPoint.TimeService.NowDateTime:O}] DemoDelayTask.Id:{taskId} - После удаления.");

        // Проверка что задача в БД остановлена.
        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            async (unitOfWork, cancellationToken) =>
            {
                var mapper = unitOfWork.MappersSession.Mappers.GetMapper<IMapperDemoDelayTask>();
                var dto = await mapper.GetRawAsync(unitOfWork.MappersSession, taskId, cancellationToken);
                Assert.IsNotNull(dto);
                Assert.IsFalse(dto.Available);
            },
            autoCommit: true);

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));

        sw = Stopwatch.StartNew();

        Assert.IsTrue(await taskWaitHandler!.WaitAsync(fullDelay + Magic));

        sw.Stop();
        Assert.LessOrEqual(runDelay, sw.Elapsed);
        Assert.Greater(fullDelay + Magic, sw.Elapsed);

        Assert.IsFalse(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Остановка задания в БД в момент её исполнения.")]
    public async Task Test_StopLazy()
    {
        var scenarioDelay = TimeSpan.FromSeconds(5);
        var runDelay = TimeSpan.FromSeconds(20);
        var fullDelay = scenarioDelay + runDelay;
        var taskId =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        m_entryPoint.TimeService.Now + runDelay,
                        false,
                        cancellationToken),
                autoCommit: true);

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId, out var taskWaitHandler));

        // Пометить задание для остановки в БД в момент её исполнения.
        // ReSharper disable once MethodHasAsyncOverload
        m_entryPoint.DemoDelayTaskProcessor.Remove(taskId);

        // Проверка что задача в БД не остановлена.
        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            async (unitOfWork, cancellationToken) =>
            {
                var mapper = unitOfWork.MappersSession.Mappers.GetMapper<IMapperDemoDelayTask>();
                var dto = await mapper.GetRawAsync(unitOfWork.MappersSession, taskId, cancellationToken);
                Assert.IsNotNull(dto);
                Assert.IsTrue(dto.Available);
            },
        autoCommit: true);

        Console.WriteLine($"[{m_entryPoint.TimeService.NowDateTime:O}] DemoDelayTask.Id:{taskId} - После удаления.");

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));

        var sw = Stopwatch.StartNew();

        Assert.IsTrue(await taskWaitHandler!.WaitAsync(fullDelay + Magic));

        sw.Stop();
        Assert.LessOrEqual(runDelay, sw.Elapsed);
        Assert.Greater(fullDelay + Magic, sw.Elapsed);

        Assert.IsFalse(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));

        // Проверка что задача в БД остановлена.
        await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
            async (unitOfWork, cancellationToken) =>
            {
                var mapper = unitOfWork.MappersSession.Mappers.GetMapper<IMapperDemoDelayTask>();
                var dto = await mapper.GetRawAsync(unitOfWork.MappersSession, taskId, cancellationToken);
                Assert.IsNotNull(dto);
                Assert.IsFalse(dto.Available);
            },
            autoCommit: true);
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Ожидание конца исполнения задачи. Задача запускается отложеннно.")]
    public async Task Test_TaskWaitEnd_RunDelay()
    {
        var scenarioDelay = TimeSpan.FromSeconds(5);
        var runDelay = TimeSpan.FromSeconds(20);
        var fullDelay = scenarioDelay + runDelay;
        var taskId =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        m_entryPoint.TimeService.Now + runDelay,
                        false,
                        cancellationToken),
                autoCommit: true);

        var sw = Stopwatch.StartNew();

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId, out var taskWaitHandler));
        Assert.IsFalse(await taskWaitHandler!.WaitAsync(scenarioDelay + Magic));
        Assert.IsTrue(await taskWaitHandler.WaitAsync(fullDelay + Magic));

        sw.Stop();
        Assert.Less(fullDelay - Magic, sw.Elapsed);
        Assert.Greater(fullDelay + Magic, sw.Elapsed);

        Assert.IsFalse(m_entryPoint.DemoDelayTaskProcessor.Exists(taskId));
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Создание задачь с контролем количества активных задач.")]
    public async Task Test_MaxTasks()
    {
        var scenarioDelay = TimeSpan.FromSeconds(10);

        var taskId1 =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        null,
                        false,
                        cancellationToken),
                autoCommit: true);
        var taskId2 =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        null,
                        false,
                        cancellationToken),
                autoCommit: true);
        var taskId3 =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        null,
                        false,
                        cancellationToken),
                autoCommit: true);

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId1, out var taskWaitHandler1));
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId2, out var taskWaitHandler2));
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId3, out var taskWaitHandler3));

        // Контроль внутреннего состояния.
        var snapShot = m_entryPoint.DemoDelayTaskProcessor.InfrastructureMonitor.GetSnapShot();
        Assert.AreEqual(3, snapShot.CountActive);
        Assert.AreEqual(0, snapShot.CountEnd);
        Assert.AreEqual(3, snapShot.CountAdd);
        Assert.AreEqual(3, snapShot.CountAdded);
        Assert.AreEqual(0, snapShot.CountRejectAdd);

        var workflowException =
            Assert.ThrowsAsync<WorkflowException>(
                async () => await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                    async (_, cancellationToken) =>
                        await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                            new DemoDelayTaskScenarioAsDelay
                            {
                                Delay = scenarioDelay,
                            },
                            null,
                            false,
                            cancellationToken),
                    autoCommit: true));
        Assert.AreEqual(CommonWorkflowExceptionErrorCodes.ServiceTemporarilyUnavailable, workflowException!.Code, workflowException.ToJsonText());
        Assert.AreEqual("Слишком много активных задач.", workflowException.Message, workflowException.ToJsonText());
        Assert.AreEqual("Количество активных задач '3'.", workflowException.Details, workflowException.ToJsonText());

        // Контроль внутреннего состояния.
        snapShot = m_entryPoint.DemoDelayTaskProcessor.InfrastructureMonitor.GetSnapShot();
        Assert.AreEqual(3, snapShot.CountActive);
        Assert.AreEqual(0, snapShot.CountEnd);
        Assert.AreEqual(4, snapShot.CountAdd);
        Assert.AreEqual(3, snapShot.CountAdded);
        Assert.AreEqual(1, snapShot.CountRejectAdd);

        Assert.IsTrue(await taskWaitHandler1!.WaitAsync(scenarioDelay + Magic));
        Assert.IsTrue(await taskWaitHandler2!.WaitAsync(scenarioDelay + Magic));
        Assert.IsTrue(await taskWaitHandler3!.WaitAsync(scenarioDelay + Magic));

        // Контроль внутреннего состояния.
        snapShot = m_entryPoint.DemoDelayTaskProcessor.InfrastructureMonitor.GetSnapShot();
        Assert.AreEqual(0, snapShot.CountActive);
        Assert.AreEqual(3, snapShot.CountEnd);
        Assert.AreEqual(4, snapShot.CountAdd);
        Assert.AreEqual(3, snapShot.CountAdded);
        Assert.AreEqual(1, snapShot.CountRejectAdd);

        var taskId4 =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        null,
                        false,
                        cancellationToken),
                autoCommit: true);

        // Контроль внутреннего состояния.
        snapShot = m_entryPoint.DemoDelayTaskProcessor.InfrastructureMonitor.GetSnapShot();
        Assert.AreEqual(1, snapShot.CountActive);
        Assert.AreEqual(3, snapShot.CountEnd);
        Assert.AreEqual(5, snapShot.CountAdd);
        Assert.AreEqual(4, snapShot.CountAdded);
        Assert.AreEqual(1, snapShot.CountRejectAdd);

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId4, out var taskWaitHandler4));
        Assert.IsTrue(await taskWaitHandler4!.WaitAsync(scenarioDelay + Magic));

        // Контроль внутреннего состояния.
        snapShot = m_entryPoint.DemoDelayTaskProcessor.InfrastructureMonitor.GetSnapShot();
        Assert.AreEqual(0, snapShot.CountActive);
        Assert.AreEqual(4, snapShot.CountEnd);
        Assert.AreEqual(5, snapShot.CountAdd);
        Assert.AreEqual(4, snapShot.CountAdded);
        Assert.AreEqual(1, snapShot.CountRejectAdd);
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    [Description("Создание задачь с контролем количества активных задач.")]
    public async Task Test_MaxTasks_SkipValidationMaxActiveTasks()
    {
        var scenarioDelay = TimeSpan.FromSeconds(10);

        var taskId1 =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        null,
                        false,
                        cancellationToken),
                autoCommit: true);
        var taskId2 =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        null,
                        false,
                        cancellationToken),
                autoCommit: true);
        var taskId3 =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        null,
                        false,
                        cancellationToken),
                autoCommit: true);

        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId1, out var taskWaitHandler1));
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId2, out var taskWaitHandler2));
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId3, out var taskWaitHandler3));

        // Контроль внутреннего состояния.
        var snapShot = m_entryPoint.DemoDelayTaskProcessor.InfrastructureMonitor.GetSnapShot();
        Assert.AreEqual(3, snapShot.CountActive);
        Assert.AreEqual(0, snapShot.CountEnd);
        Assert.AreEqual(3, snapShot.CountAdd);
        Assert.AreEqual(3, snapShot.CountAdded);
        Assert.AreEqual(0, snapShot.CountRejectAdd);

        var workflowException =
            Assert.ThrowsAsync<WorkflowException>(
                async () => await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                    async (_, cancellationToken) =>
                        await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                            new DemoDelayTaskScenarioAsDelay
                            {
                                Delay = scenarioDelay,
                            },
                            null,
                            false,
                            cancellationToken),
                    autoCommit: true));
        Assert.AreEqual(CommonWorkflowExceptionErrorCodes.ServiceTemporarilyUnavailable, workflowException!.Code, workflowException.ToJsonText());
        Assert.AreEqual("Слишком много активных задач.", workflowException.Message, workflowException.ToJsonText());
        Assert.AreEqual("Количество активных задач '3'.", workflowException.Details, workflowException.ToJsonText());

        // Создание задачи с игнорированием лимита.
        var taskId4 =
            await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                async (_, cancellationToken) =>
                    await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                        new DemoDelayTaskScenarioAsDelay
                        {
                            Delay = scenarioDelay,
                        },
                        null,
                        true, // Игнорированием лимита.
                        cancellationToken),
                autoCommit: true);
        Assert.IsTrue(m_entryPoint.DemoDelayTaskProcessor.TryGet(taskId4, out var taskWaitHandler4));

        workflowException =
            Assert.ThrowsAsync<WorkflowException>(
                async () => await m_entryPoint.CreateAndUsingUnitOfWorkAsync(
                    async (_, cancellationToken) =>
                        await m_entryPoint.DemoDelayTaskProcessor.AddAsync(
                            new DemoDelayTaskScenarioAsDelay
                            {
                                Delay = scenarioDelay,
                            },
                            null,
                            false,
                            cancellationToken),
                    autoCommit: true));
        Assert.AreEqual(CommonWorkflowExceptionErrorCodes.ServiceTemporarilyUnavailable, workflowException!.Code, workflowException.ToJsonText());
        Assert.AreEqual("Слишком много активных задач.", workflowException.Message, workflowException.ToJsonText());
        Assert.AreEqual("Количество активных задач '4'.", workflowException.Details, workflowException.ToJsonText());

        // Контроль внутреннего состояния.
        snapShot = m_entryPoint.DemoDelayTaskProcessor.InfrastructureMonitor.GetSnapShot();
        Assert.AreEqual(4, snapShot.CountActive);
        Assert.AreEqual(0, snapShot.CountEnd);
        Assert.AreEqual(6, snapShot.CountAdd);
        Assert.AreEqual(4, snapShot.CountAdded);
        Assert.AreEqual(2, snapShot.CountRejectAdd);

        Assert.IsTrue(await taskWaitHandler1!.WaitAsync(scenarioDelay + Magic));
        Assert.IsTrue(await taskWaitHandler2!.WaitAsync(scenarioDelay + Magic));
        Assert.IsTrue(await taskWaitHandler3!.WaitAsync(scenarioDelay + Magic));
        Assert.IsTrue(await taskWaitHandler4!.WaitAsync(scenarioDelay + Magic));

        // Контроль внутреннего состояния.
        snapShot = m_entryPoint.DemoDelayTaskProcessor.InfrastructureMonitor.GetSnapShot();
        Assert.AreEqual(0, snapShot.CountActive);
        Assert.AreEqual(4, snapShot.CountEnd);
        Assert.AreEqual(6, snapShot.CountAdd);
        Assert.AreEqual(4, snapShot.CountAdded);
        Assert.AreEqual(2, snapShot.CountRejectAdd);
    }
}
