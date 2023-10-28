using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.DataAccess.Interface;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Generated.PostgreSql.Implements;
using ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;
using ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Common.Interfaces;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.DomainBehaviours;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
using ShtrihM.Wattle3.Infrastructures.Monitors;
using ShtrihM.Wattle3.Json.ValueData;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.OpenTelemetry;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.QueueProcessors;
using ShtrihM.Wattle3.QueueProcessors.Interfaces;
using ShtrihM.Wattle3.Triggers;
using ShtrihM.Wattle3.Utils;
using System;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using Status = OpenTelemetry.Trace.Status;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public class EntryPoint : BaseEntryPointEx, ICustomEntryPoint
{
    #region Private Class EntryPointContext

    private class EntryPointContext : IEntryPointContext
    {
        private readonly EntryPoint m_entryPoint;

        public EntryPointContext(EntryPoint entryPoint)
            // ReSharper disable once ConvertToPrimaryConstructor
        {
            m_entryPoint = entryPoint;
        }

        public IEntryPoint EntryPoint => m_entryPoint;
        public ITimeService TimeService => m_entryPoint.TimeService;
        public IExceptionPolicy ExceptionPolicy => m_entryPoint.ExceptionPolicy;
        public IWorkflowExceptionPolicy WorkflowExceptionPolicy => m_entryPoint.WorkflowExceptionPolicy;
        public ILoggerFactory LoggerFactory => m_entryPoint.LoggerFactory;
        public IMappers Mappers => m_entryPoint.Mappers;

        public string GetDisplayNameDomainObject(Guid typeId) => WellknownDomainObjectDisplayNames.DisplayNamesProvider(typeId);
    }

    #endregion

    #region Private Class SnapShotInfrastructureMonitorCustomEntryPoint

    private class SnapShotInfrastructureMonitorCustomEntryPoint : SnapShotInfrastructureMonitorEntryPoint, ISnapShotInfrastructureMonitorCustomEntryPoint
    {
        public SnapShotInfrastructureMonitorCustomEntryPoint(
            IInfrastructureMonitor monitor,
            long countUnitOfWorks,
            long activeCountUnitOfWorks,
            TimeStatistics unitOfWorksTime,
            SnapShotValues values,
            bool debugMode,
            Guid serviceInstanceId)
            : base(
                monitor,
                countUnitOfWorks,
                activeCountUnitOfWorks,
                unitOfWorksTime,
                values)
        {
            ProcessId = serviceInstanceId.ToString("D");
            DebugMode = debugMode;

            AddCustomWellknownValue(WellknownCommonSnapShotInfrastructureMonitorValues.CustomEntryPoint.ProcessId, ProcessId);
            AddCustomWellknownValue(WellknownCommonSnapShotInfrastructureMonitorValues.CustomEntryPoint.DebugMode, DebugMode);
        }

        public string ProcessId { get; }

        public bool DebugMode { get; }

        private void AddCustomWellknownValue<T>(Guid id, T value)
        {
            var description = WellknownCommonSnapShotInfrastructureMonitorValues.GetDescription(id);

            AddValue(new()
            {
                Id = id,
                Name = description.Name,
                Description = description.Description,
                Data = BaseValueData.New(value),
            });
        }
    }

    #endregion

    #region Private Class InfrastructureMonitorCustomEntryPoint

    private class InfrastructureMonitorCustomEntryPoint : InfrastructureMonitorEntryPoint, IInfrastructureMonitorCustomEntryPoint
    {
        private readonly Guid m_serviceInstanceId;

        public InfrastructureMonitorCustomEntryPoint(
            TimeSpan timeStatisticsStep,
            ITimeService timeService,
            Guid serviceInstanceId)
            : base(
                null,
                timeStatisticsStep,
                timeService)
        // ReSharper disable once ConvertToPrimaryConstructor
        {
            m_serviceInstanceId = serviceInstanceId;
        }

        protected override SnapShotInfrastructureMonitorEntryPoint NewSnapShot()
        {
            var values = GetValues();

            SetInitializeErrorMessage(((EntryPoint)Owner).GetInitializeErrorMessage());

            return new SnapShotInfrastructureMonitorCustomEntryPoint(
                this,
                m_countUnitOfWorks,
                m_activeCountUnitOfWorks,
                m_timeStatisticsCollector.GetStatistics(),
                values,
                ((EntryPoint)Owner).SystemSettings.DebugMode.Value,
                m_serviceInstanceId);
        }

        public new ISnapShotInfrastructureMonitorCustomEntryPoint GetSnapShot()
        {
            var result = (ISnapShotInfrastructureMonitorCustomEntryPoint)base.GetSnapShot();

            return (result);
        }
    }

    #endregion

    #region Private Class InfrastructureMonitorCustomEntryPoint

    private class TemplateMetaServerDescription
    {
        public Guid ProductId;
        public Version ProductVersion;
        public Version ProductBuildVersion;
        public string InstallationName;
        public Guid InstallationId;
    }

    #endregion

    private static readonly SpanAttributes SpanAttributes;

    private readonly TemplateMetaServerDescription m_templateServerDescription;
    private readonly ILogger m_logger;
    private PartitionsSponsor m_partitionsSponsor;
    private IQueueItemProcessor m_queueEmergencyDomainBehaviour;

    static EntryPoint()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<EntryPoint>();
    }

    private EntryPoint(
        TemplateMetaServerDescription templateServerDescription,
        SystemSettings.SystemSettings systemSettings,
        IDomainObjectDataMappers dataMappers,
        IDomainObjectRegisters registers,
        IMappers mappers,
        IExceptionPolicy exceptionPolicy,
        WorkflowExceptionPolicy workflowExceptionPolicy,
        ITimeService timeService,
        TimeSpan timeStatisticsStep,
        ILoggerFactory loggerFactory,
        Tracer tracer)
        : base(
            new UnitOfWorkProviderCallContext(),
            new InfrastructureMonitorCustomEntryPoint(timeStatisticsStep, timeService, systemSettings.InstanceId.Value),
            dataMappers,
            registers,
            mappers,
            exceptionPolicy,
            workflowExceptionPolicy,
            timeService,
            false,
            loggerFactory)
    {
        ((InfrastructureMonitorCustomEntryPoint)InfrastructureMonitor).Owner = this;

        m_logger = loggerFactory.CreateLogger(GetType());
        SystemSettings = systemSettings;
        m_templateServerDescription = templateServerDescription ?? throw new ArgumentNullException(nameof(templateServerDescription));
        LoggerFactory = loggerFactory;
        Context = new EntryPointContext(this);
        Tracer = tracer;

        m_proxyDomainObjectRegisterFactories.AddFactories(GetType().Assembly);
    }

    public DomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation<TMapper>(long identity)
        where TMapper : IMapper
    {
        using var mainSpan = Tracer?.StartActiveSpan(nameof(CreateDomainBehaviourWithСonfirmation), initialAttributes: SpanAttributes);

        var unitOfWork = m_unitOfWorkProvider.Instance;
        if (false == unitOfWork.IsDefinedCommitVerifying)
        {
            var commitVerifying = DomainObjectsHelpers.CreateUnitOfWorkCommitVerifyingDelegate<TMapper>(identity, Mappers);
            unitOfWork.CommitVerifying = commitVerifying;

            mainSpan?.AddEvent(OpenTelemetryConstants.EventNotDefinedCommitVerifying);
        }
        else
        {
            mainSpan?.AddEvent(OpenTelemetryConstants.EventDefinedCommitVerifying);
        }

        var result =
            new DomainBehaviourWithСonfirmation(
                ExceptionPolicy,
                Mappers,
                m_queueEmergencyDomainBehaviour,
                unitOfWork.CommitVerifying);

        return result;
    }

    public DomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation()
    {
        using var mainSpan = Tracer?.StartActiveSpan(nameof(CreateDomainBehaviourWithСonfirmation), initialAttributes: SpanAttributes);

        var unitOfWork = m_unitOfWorkProvider.Instance;
        var result =
            new DomainBehaviourWithСonfirmation(
                ExceptionPolicy,
                Mappers,
                m_queueEmergencyDomainBehaviour,
                unitOfWork.CommitVerifying);

        return result;
    }

    public UnitOfWork CurrentUnitOfWork => (UnitOfWork)UnitOfWorkProvider.Instance;
    public ICustomMappers Mappers => (ICustomMappers)m_mappers;
    public IExceptionPolicy ExceptionPolicy => m_exceptionPolicy;
    public IPartitionsDay PartitionsDay { get; private set; }
    public WorkflowExceptionPolicy WorkflowExceptionPolicy => ((WorkflowExceptionPolicy)m_workflowExceptionPolicy);
    public new IInfrastructureMonitorCustomEntryPoint InfrastructureMonitor => (IInfrastructureMonitorCustomEntryPoint)base.InfrastructureMonitor;
    public SystemSettings.SystemSettings SystemSettings { get; }
    public ITimeService TimeService => m_timeService;
    public InfrastructureMonitorRegisters InfrastructureMonitorRegisters { get; private set; }
    public IEntryPointFacade Facade { get; private set; }
    public Metrics Metrics { get; private set; }
    public Tracer Tracer { get; }
    public ILoggerFactory LoggerFactory { get; }
    public UnitOfWorkLocksHubTyped UnitOfWorkLocks { get; private set; }
    public IEntryPointContext Context { get; }
    public IServiceProvider ServiceProvider { get; private set; }

    public MetaServerDescription ServerDescription
    {
        get
        {
            var result =
                new MetaServerDescription
                {
                    ProductVersion = m_templateServerDescription.ProductVersion,
                    ProductBuildVersion = m_templateServerDescription.ProductBuildVersion,
                    InstallationId = m_templateServerDescription.InstallationId,
                    InstallationName = m_templateServerDescription.InstallationName,
                    ProductId = m_templateServerDescription.ProductId,
                    DateTime = TimeService.Now,
                    Properties =
                        new()
                        {
                            ["ProcessId"] = SystemSettings.InstanceId.Value.ToString("D"),
                        }
                };

            return (result);
        }
    }

    public override void Start()
    {
        base.Start();

        m_queueEmergencyDomainBehaviour.Start();
        m_partitionsSponsor.Start();
    }

    public override void WaitStop()
    {
        m_queueEmergencyDomainBehaviour.WaitStop();
        m_partitionsSponsor.WaitStop();

        base.WaitStop();
    }

    public override bool GlobalIsReady
    {
        get
        {
            var result =
                (base.GlobalIsReady
                 && m_partitionsSponsor.GlobalIsReady
                 && m_queueEmergencyDomainBehaviour.GlobalIsReady);

            return (result);
        }
    }

    protected override bool GetIsReady()
    {
        var result =
            (base.GetIsReady()
             && m_partitionsSponsor.IsReady
             && m_queueEmergencyDomainBehaviour.IsReady);

        return result;
    }

    protected override void DoStop(bool isBackgroundStopping)
    {
        base.DoStop(isBackgroundStopping);

        if (isBackgroundStopping)
        {
            m_partitionsSponsor.BeginStop();
            m_queueEmergencyDomainBehaviour.BeginStop();
        }
        else
        {
            m_partitionsSponsor.Stop();
            m_queueEmergencyDomainBehaviour.Stop();
        }
    }

    public override async ValueTask<IUnitOfWork> CreateUnitOfWorkAsync(object context = null, CancellationToken cancellationToken = default)
    {
        if (IsReady)
        {
            var result = await base.CreateUnitOfWorkAsync(context, cancellationToken).ConfigureAwait(false);

            return result;
        }

        {
#if DEBUG
            var exception = WorkflowExceptionPolicy.Create(CommonWorkflowException.ServiceTemporarilyUnavailable, $"Сервер в режиме инициализации.{Environment.NewLine}{GetInitializeErrorMessage()}");
#else
            var exception = WorkflowExceptionPolicy.Create(CommonWorkflowException.ServiceTemporarilyUnavailable, "Сервер в режиме инициализации.");
#endif

            throw exception;
        }
    }

    protected override ValueTask<IUnitOfWork> DoCreateUnitOfWorkAsync(
        IUnitOfWorkVisitor visitor,
        object context,
        CancellationToken cancellationToken = default)
    {
        var result = new UnitOfWork(m_unitOfWorkContext, m_registersFactory, visitor);

        return ValueTask.FromResult<IUnitOfWork>(result);
    }

    public override IUnitOfWork CreateUnitOfWork(object context = null)
    {
        if (IsReady)
        {
            var result = base.CreateUnitOfWork(context);

            return result;
        }

        {
#if DEBUG
            var exception = WorkflowExceptionPolicy.Create(CommonWorkflowException.ServiceTemporarilyUnavailable, $"Сервер в режиме инициализации.{Environment.NewLine}{GetInitializeErrorMessage()}");
#else
            var exception = WorkflowExceptionPolicy.Create(CommonWorkflowException.ServiceTemporarilyUnavailable, "Сервер в режиме инициализации.");
#endif

            throw exception;
        }
    }

    protected override IUnitOfWork DoCreateUnitOfWork(IUnitOfWorkVisitor visitor, object context)
    {
        var result = new UnitOfWork(m_unitOfWorkContext, m_registersFactory, visitor);

        return result;
    }

    protected override void Dispose(bool disposing)
    {
        {
            var temp = m_queueEmergencyDomainBehaviour;
            m_queueEmergencyDomainBehaviour = null;
            temp.SilentDispose();
        }

        {
            var temp = m_partitionsSponsor;
            m_partitionsSponsor = null;
            temp.SilentDispose();
        }

        {
            var temp = InfrastructureMonitorRegisters;
            InfrastructureMonitorRegisters = null;
            temp.SilentDispose();
        }

        {
            var temp = UnitOfWorkLocks;
            UnitOfWorkLocks = null;
            temp.SilentDispose();
        }

        base.Dispose(disposing);
    }

    protected override string GetInitializeErrorMessage()
    {
        var text = new StringBuilder(base.GetInitializeErrorMessage());

        if (false == m_queueEmergencyDomainBehaviour.IsReady)
        {
            ApplyMessage(m_queueEmergencyDomainBehaviour.InfrastructureMonitor.GetSnapShot());
        }

        if (false == m_partitionsSponsor.IsReady)
        {
            ApplyMessage(m_partitionsSponsor.InfrastructureMonitor.GetSnapShot());
        }

        void ApplyMessage(ISnapShotInfrastructureMonitorDrivenObject snapShot)
        {
            if (snapShot.IsReady == false)
            {
                text.AppendLine($"[{WellknownCommonInfrastructureMonitors.GetDisplayName(snapShot.Id)}]");

                if (snapShot.InitializeErrorMessage != null)
                {
                    text.AppendLine("Текст ошибки инициализации:");
                    text.AppendLine(snapShot.InitializeErrorMessage);
                }

                text.AppendLine();
            }
        }

        return text.ToString();
    }

    public static EntryPoint New(IUnityContainer container)
    {
        if (container == null)
        {
            throw new ArgumentNullException(nameof(container));
        }

        var serviceProvider = container.Resolve<IServiceProvider>();

        var tracer = serviceProvider.GetService<Tracer>();
        using var mainSpan = tracer?.StartActiveSpan(nameof(New), initialAttributes: SpanAttributes);

        try
        {
            var result = DoNew(
                container,
                serviceProvider,
                tracer);

            result.SetInitialized();

            return result;
        }
        catch (Exception exception)
        {
            mainSpan?.SetStatus(Status.Error);
            mainSpan?.RecordException(exception);

            ExceptionDispatchInfo.Capture(exception).Throw();

            throw;
        }
    }

    private static EntryPoint DoNew(
        IUnityContainer container,
        IServiceProvider serviceProvider,
        Tracer tracer)
    {
        var systemSettings = container.Resolve<SystemSettings.SystemSettings>();
        var systemSettingsLocal = GetSystemSettingsLocal(systemSettings.ConnectionString.Value);
        var loggerFactory = container.Resolve<ILoggerFactory>();

        var templateServerDescription =
            new TemplateMetaServerDescription
            {
                ProductVersion = DemoServer.Common.Constants.ProductVersion,
                ProductBuildVersion = DemoServer.Common.Constants.ProductBuildVersion,
                ProductId = Common.Constants.ProductId,
                InstallationId = systemSettings.InstanceId.Value,
                InstallationName = systemSettings.InstanceName.Value,
            };

        if (systemSettingsLocal.ProductId != templateServerDescription.ProductId)
        {
            WattleThrowsHelper.ThrowInternalException($"Код продукта '{systemSettingsLocal.ProductId}' в БД не совпадает с ожидаемым '{templateServerDescription.ProductId}'.");
        }

        if (systemSettingsLocal.ProductVersion.ToString(DemoServer.Common.Constants.VersionComparePrecision) != templateServerDescription.ProductVersion.ToString(DemoServer.Common.Constants.VersionComparePrecision))
        {
            WattleThrowsHelper.ThrowInternalException($"Версия продукта '{systemSettingsLocal.ProductVersion}' в БД не совпадает с ожидаемой '{templateServerDescription.ProductVersion}'.");
        }

        var timeService =
            container.ResolveWithDefault<ITimeService>(
                () => new TimeService(systemSettings.MappersFeaturesValidateUpdateResults.Value));

        var metrics = serviceProvider.GetService<Metrics>();
        var dataMappers = new DomainObjectDataMappers(timeService);
        var registers = new DomainObjectRegisters(timeService);
        var workflowExceptionPolicy = new WorkflowExceptionPolicy();
        var exceptionPolicy =
            new ExceptionPolicy(
                systemSettings,
                workflowExceptionPolicy,
                timeService,
                loggerFactory.CreateLogger<ExceptionPolicy>(),
                tracer,
                metrics);
        var result =
            new EntryPoint(
                templateServerDescription,
                systemSettings,
                dataMappers,
                registers,
                new Mappers(
                    new MappersExceptionPolicy(),
                    systemSettings.ConnectionString.Value,
                    timeService,
                    WellknownInfrastructureMonitors.Mappers,
                    WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                    WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                    systemSettings.SqlCommandTimeout.Value,
                    context:
                    new MappersContext(
                        timeService,
                        systemSettings.MappersCacheActualStateDtoSettings.Value,
                        systemSettings.TimeStatisticsStep.Value,
                        exceptionPolicy)),
                exceptionPolicy,
                new(),
                timeService,
                systemSettings.TimeStatisticsStep.Value,
                loggerFactory,
                tracer);
        exceptionPolicy.EntryPoint = result;
        result.ServiceProvider = serviceProvider;

        result.PartitionsDay = new PartitionsDay(timeService, new(2023, 8, 1));
        result.InfrastructureMonitorRegisters = new();

        {
            var partitionsSponsorTrigger =
                new ScheduledService(
                    result.SystemSettings.PartitionsSponsorSettings.Value.ActivateTimeout.Value,
                    WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.ActivatePartitionsSponsor),
                    result.ExceptionPolicy,
                    result.TimeService,
                    WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.ActivatePartitionsSponsor),
                    WellknownCommonInfrastructureMonitors.ActivatePartitionsSponsor,
                    loggerFactory.CreateLogger<ScheduledService>());

            result.m_partitionsSponsor =
                new(
                    result,
                    partitionsSponsorTrigger,
                    loggerFactory);
            container.RegisterInstance(result.m_partitionsSponsor, InstanceLifetime.External);
        }

        result.Metrics = metrics;
        result.UnitOfWorkLocks = new(result);

        result.Facade =
            container.ResolveWithDefault(
                () =>
                {
                    var entryPointFacade = new EntryPointFacade(result);
                    var proxy = LoggingDispatchProxy<IEntryPointFacade>.CreateProxy(
                        entryPointFacade,
                        result.LoggerFactory.CreateLogger<EntryPointFacade>(),
                        result.Tracer);

                    return proxy;
                });

        result.m_queueEmergencyDomainBehaviour =
            container.ResolveWithDefault<IQueueItemProcessor>(
                WellknownDomainObjectIntergratorContextObjectNames.QueueEmergencyDomainBehaviour,
                () => new QueueItemProcessor(
                    result.SystemSettings.QueueThreadsSizeEmergencyDomainBehaviour.Value,
                    result.SystemSettings.QueueEmergencyTimeoutEmergencyDomainBehaviour.Value,
                    WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.QueueEmergencyDomainBehaviour),
                    result.ExceptionPolicy,
                    result.TimeService,
                    WellknownCommonInfrastructureMonitors.QueueEmergencyDomainBehaviour,
                    loggerFactory.CreateLogger<QueueItemProcessor>(),
                    result.SystemSettings.TimeStatisticsStep.Value));

        container.RegisterInstance((DomainObjectDataMappers)result.m_dataMappers, InstanceLifetime.External);
        container.RegisterInstance<ICustomEntryPoint>(result, InstanceLifetime.External);
        container.RegisterInstance(result.Mappers, InstanceLifetime.External);
        container.RegisterInstance((DomainObjectRegisters)result.m_registers, InstanceLifetime.External);

        if (false == container.TryResolve<IDomainObjectIntergrators<IUnityContainer>>(out var domainObjectIntergrators))
        {
            domainObjectIntergrators =
                new DefaultDomainObjectIntergrators<IUnityContainer>(result.m_logger)
                    .Add(result.GetType().Assembly);
        }
        foreach (var domainObjectIntergrator in domainObjectIntergrators)
        {
            domainObjectIntergrator.Run(container);
        }

        var infrastructureMonitor = (InfrastructureMonitorCustomEntryPoint)result.InfrastructureMonitor;
        infrastructureMonitor.AddSubMonitor(result.m_queueEmergencyDomainBehaviour.InfrastructureMonitor);
        infrastructureMonitor.AddSubMonitor(result.m_partitionsSponsor.InfrastructureMonitor);

        foreach (var iMonitor in result.UnitOfWorkLocks.Hub.InfrastructureMonitorLocksPools)
        {
            infrastructureMonitor.AddSubMonitor(iMonitor);
        }

        result.InfrastructureMonitorRegisters.AddMonitor(infrastructureMonitor);
        result.InfrastructureMonitorRegisters.AddFavorit(infrastructureMonitor.Id);

        result.m_partitionsSponsor.Create(tracer);

        result.m_unitOfWorkContext =
            new CustomUnitOfWorkContext(
                result,
                result.m_dataMappers,
                result.m_mappers,
                result.m_exceptionPolicy,
                result.m_workflowExceptionPolicy,
                loggerFactory.CreateLogger<UnitOfWorkContext>(),
                false,
                result.m_unitOfWorkProvider,
                serviceProvider.GetService<IDbContextFactory<ProcessingDbContext>>(),
                serviceProvider,
                result.UnitOfWorkLocks.Hub);

        return (result);
    }

    private static SystemSettingsLocal GetSystemSettingsLocal(string connectionString)
    {
        var mappersExceptionPolicy = new MappersExceptionPolicy();
        using ICustomMappers mappers =
            new Mappers(
                mappersExceptionPolicy,
                connectionString,
                new TimeService(),
                WellknownInfrastructureMonitors.Mappers,
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                15000);
        using var mappersSession = mappers.OpenSession();
        var systemSettings = mappers.GetSystemSettings(mappersSession);
        var result = new SystemSettingsLocal(systemSettings);

        return (result);
    }
}
