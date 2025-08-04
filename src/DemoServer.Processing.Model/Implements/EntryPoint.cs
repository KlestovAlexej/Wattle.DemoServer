using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.DataAccess.Interface;
using Acme.DemoServer.Processing.DataAccess.PostgreSql;
using Acme.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.DemoServer.Processing.Generated.PostgreSql.Implements;
using Acme.DemoServer.Processing.Model.DomainObjects.ChangeTracker;
using Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask;
using Acme.DemoServer.Processing.Model.Implements.SystemSettings;
using Acme.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.Common.Exceptions;
using Acme.Wattle.Common.Interfaces;
using Acme.Wattle.DomainObjects;
using Acme.Wattle.DomainObjects.Common;
using Acme.Wattle.DomainObjects.DomainObjectDataMappers;
using Acme.Wattle.DomainObjects.DomainObjectIntergrators;
using Acme.Wattle.DomainObjects.DomainObjects;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters;
using Acme.Wattle.DomainObjects.EntryPoints;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.DomainObjects.Serializers.Binary;
using Acme.Wattle.DomainObjects.Serializers.Json;
using Acme.Wattle.DomainObjects.UnitOfWorks;
using Acme.Wattle.Infrastructures.Interfaces.Monitors;
using Acme.Wattle.Infrastructures.Monitors;
using Acme.Wattle.Json.ValueData;
using Acme.Wattle.Mappers;
using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.Mappers.PostgreSql;
using Acme.Wattle.OpenTelemetry;
using Acme.Wattle.Primitives;
using Acme.Wattle.QueueProcessors;
using Acme.Wattle.QueueProcessors.Interfaces;
using Acme.Wattle.Triggers;
using Acme.Wattle.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;

[assembly: SchemaModelResource("DbMappers.Schema.xml")]

namespace Acme.DemoServer.Processing.Model.Implements;

public sealed class EntryPoint : BaseEntryPointEx, ICustomEntryPoint
{
    #region Private Class EntryPointContext

    private class EntryPointContext : IEntryPointContext<ICustomEntryPoint>
    {
        private readonly EntryPoint m_entryPoint;

        // ReSharper disable once ConvertToPrimaryConstructor
        public EntryPointContext(EntryPoint entryPoint)
        {
            m_entryPoint = entryPoint;
        }

        public IEntryPoint EntryPoint => m_entryPoint;
        public ITimeService TimeService => m_entryPoint.TimeService;
        public IExceptionPolicy ExceptionPolicy => m_entryPoint.ExceptionPolicy;
        public IWorkflowExceptionPolicy WorkflowExceptionPolicy => m_entryPoint.WorkflowExceptionPolicy;
        public ILoggerFactory LoggerFactory => m_entryPoint.LoggerFactory;
        public IMappers Mappers => m_entryPoint.Mappers;
        public IUnitOfWorkCommitVerifyingFactory UnitOfWorkCommitVerifyingFactory => m_entryPoint.m_unitOfWorkCommitVerifyingFactory;
        ICustomEntryPoint IEntryPointContext<ICustomEntryPoint>.EntryPoint => m_entryPoint;

        public string GetDisplayNameDomainObject(Guid typeId) => WellknownDomainObjectDisplayNames.DisplayNamesProvider!(typeId);
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

            AddValue(new SnapShotInfrastructureMonitorValue
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

        // ReSharper disable once ConvertToPrimaryConstructor
        public InfrastructureMonitorCustomEntryPoint(
            TimeSpan timeStatisticsStep,
            ITimeService timeService,
            Guid serviceInstanceId)
            : base(
                null!,
                timeStatisticsStep,
                timeService)
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

    #region Private Class TemplateMetaServerDescription

    private class TemplateMetaServerDescription
    {
        public Guid ProductId;
        public Guid InstallationId;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Version ProductVersion;
        public Version ProductBuildVersion;
        public string InstallationName;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }

    #endregion

    private static readonly SpanAttributes SpanAttributes;

    private readonly TemplateMetaServerDescription m_templateServerDescription;
    private readonly ILogger m_logger;
    private PartitionsSponsor m_partitionsSponsor;
    private IQueueItemProcessor m_queueEmergencyDomainBehaviour;
    private readonly UnitOfWorkCommitVerifyingFactory m_unitOfWorkCommitVerifyingFactory;

    static EntryPoint()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<EntryPoint>();
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private EntryPoint(
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        TemplateMetaServerDescription templateServerDescription,
        SystemSettings.SystemSettings systemSettings,
        ExceptionPolicy exceptionPolicy,
        ITimeService timeService,
        TimeSpan timeStatisticsStep,
        ILoggerFactory loggerFactory,
        Tracer? tracer,
        SystemSettingsLocal systemSettingsLocal,
        Metrics? metrics,
        IServiceProvider serviceProvider)
        : base(
            new UnitOfWorkProviderCallContext(),
            new InfrastructureMonitorCustomEntryPoint(timeStatisticsStep, timeService, systemSettings.InstanceId.Value),
            new DomainObjectDataMappers(timeService),
            new DomainObjectRegisters(timeService),
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
                    systemSettings.MappersCacheActualStateDto.Value,
                    systemSettings.TimeStatisticsStep.Value,
                    exceptionPolicy)),
            exceptionPolicy,
            exceptionPolicy.WorkflowExceptionPolicy,
            timeService,
            false,
            loggerFactory)
    {
        ((InfrastructureMonitorCustomEntryPoint)InfrastructureMonitor).Owner = this;

        exceptionPolicy.EntryPoint = this;
        m_logger = loggerFactory.CreateLogger(GetType());
        SystemSettings = systemSettings;
        m_templateServerDescription = templateServerDescription;
        LoggerFactory = loggerFactory;
        Tracer = tracer;
        SystemSettingsLocal = systemSettingsLocal;
        Metrics = metrics;
        ServiceProvider = serviceProvider;
        m_unitOfWorkCommitVerifyingFactory = new UnitOfWorkCommitVerifyingFactory(m_mappers);
        m_proxyDomainObjectRegisterFactories.AddFactories(GetType().Assembly);
        InfrastructureMonitorRegisters = new InfrastructureMonitorRegisters();
        PartitionsDay = new PartitionsDay(timeService, new DateTime(2024, 1, 1));
        AutoMapper = serviceProvider.GetRequiredService<AutoMapper.IMapper>();
        Context = new EntryPointContext(this);
        m_queueEmergencyDomainBehaviour =
            new QueueItemProcessor(
                SystemSettings.QueueThreadsSizeEmergencyDomainBehaviour.Value,
                SystemSettings.QueueEmergencyTimeoutEmergencyDomainBehaviour.Value,
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.QueueEmergencyDomainBehaviour),
                ExceptionPolicy,
                TimeService,
                WellknownCommonInfrastructureMonitors.QueueEmergencyDomainBehaviour,
                loggerFactory.CreateLogger<QueueItemProcessor>(),
                SystemSettings.TimeStatisticsStep.Value);
        UnitOfWorkLocks = new UnitOfWorkLocksHubTyped(Context);

        m_unitOfWorkContext =
            new UnitOfWorkFullContext<ProcessingDbContext, IMapperChangeTracker>(
                this,
                m_dataMappers,
                m_mappers,
                m_exceptionPolicy,
                (WorkflowExceptionPolicy)m_workflowExceptionPolicy,
                loggerFactory.CreateLogger<UnitOfWorkContext>(),
                false,
                m_unitOfWorkProvider,
                serviceProvider.GetService<IDbContextFactory<ProcessingDbContext>>()!,
                serviceProvider,
                UnitOfWorkLocks.Hub,
                m_queueEmergencyDomainBehaviour,
                Context.UnitOfWorkCommitVerifyingFactory,
                () => DomainObjectChangeTracker.Template.Instance);

        JsonDeserializer =
            new SmartJsonDeserializer(
                Context,
                SystemSettings.SmartJsonDeserializer.Value,
                SystemSettings.DebugMode.Value);

        BinaryDeserializer =
            new SmartBinaryDeserializer(
                Context,
                SystemSettings.SmartBinaryDeserializer.Value);

        var partitionsSponsorTrigger =
            new ScheduledService(
                SystemSettings.PartitionsSponsor.Value.ActivateTimeout.Value,
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.ActivatePartitionsSponsor),
                ExceptionPolicy,
                TimeService,
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.ActivatePartitionsSponsor),
                WellknownCommonInfrastructureMonitors.ActivatePartitionsSponsor,
                loggerFactory.CreateLogger<ScheduledService>());

        m_partitionsSponsor =
            new PartitionsSponsor(
                this,
                partitionsSponsorTrigger);

        DemoDelayTaskProcessor = new DemoDelayTaskProcessor(this);
    }

#if DEBUG
    public IDomainObjectRegisters Registers => m_registers;
#endif

    public IEntryPointFacade Facade { get; private set; }
    public UnitOfWork CurrentUnitOfWork => (UnitOfWork)UnitOfWorkProvider.Instance;
    public ICustomMappers Mappers => (ICustomMappers)m_mappers;
    public IExceptionPolicy ExceptionPolicy => m_exceptionPolicy;
    public IPartitionsDay PartitionsDay { get; }
    public WorkflowExceptionPolicy WorkflowExceptionPolicy => ((WorkflowExceptionPolicy)m_workflowExceptionPolicy);
    public new IInfrastructureMonitorCustomEntryPoint InfrastructureMonitor => (IInfrastructureMonitorCustomEntryPoint)base.InfrastructureMonitor;
    public SystemSettings.SystemSettings SystemSettings { get; }
    public ITimeService TimeService => m_timeService;
    public InfrastructureMonitorRegisters InfrastructureMonitorRegisters { get; }
    public Metrics? Metrics { get; }
    public Tracer? Tracer { get; }
    public ILoggerFactory LoggerFactory { get; }
    public UnitOfWorkLocksHubTyped UnitOfWorkLocks { get; }
    public IEntryPointContext<ICustomEntryPoint> Context { get; }
    public IServiceProvider ServiceProvider { get; }
    public AutoMapper.IMapper AutoMapper { get; }
    public ISmartJsonDeserializer JsonDeserializer { get; }
    public ISmartBinaryDeserializer BinaryDeserializer { get; }
    public SystemSettingsLocal SystemSettingsLocal { get; }
    public IDemoDelayTaskProcessor DemoDelayTaskProcessor { get; }

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
                        new Dictionary<string, string>
                        {
                            [nameof(SystemSettingsLocal.ProductName)] = SystemSettingsLocal.ProductName,
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
        DemoDelayTaskProcessor.Start();
    }

    public override void WaitStop()
    {
        m_queueEmergencyDomainBehaviour.WaitStop();
        m_partitionsSponsor.WaitStop();
        DemoDelayTaskProcessor.WaitStop();

        base.WaitStop();
    }

    public override bool GlobalIsReady
    {
        get
        {
            var result =
                (base.GlobalIsReady
                 && m_partitionsSponsor.GlobalIsReady
                 && m_queueEmergencyDomainBehaviour.GlobalIsReady
                 && DemoDelayTaskProcessor.GlobalIsReady);

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
            DemoDelayTaskProcessor.BeginStop();
        }
        else
        {
            m_partitionsSponsor.Stop();
            m_queueEmergencyDomainBehaviour.Stop();
            DemoDelayTaskProcessor.Stop();
        }
    }

    public override async ValueTask<IUnitOfWork> CreateUnitOfWorkAsync(object? context = null, CancellationToken cancellationToken = default)
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
        object? context,
        CancellationToken cancellationToken = default)
    {
        var result = new UnitOfWork((UnitOfWorkFullContext<ProcessingDbContext, IMapperChangeTracker>)m_unitOfWorkContext, m_registersFactory, visitor);

        return ValueTask.FromResult<IUnitOfWork>(result);
    }

    public override IUnitOfWork CreateUnitOfWork(object? context = null)
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

    protected override IUnitOfWork DoCreateUnitOfWork(IUnitOfWorkVisitor visitor, object? context)
    {
        var result = new UnitOfWork((UnitOfWorkFullContext<ProcessingDbContext, IMapperChangeTracker>)m_unitOfWorkContext, m_registersFactory, visitor);

        return result;
    }

    protected override void Dispose(bool disposing)
    {
        CommonWattleExtensions.SilentDisposeAndFree(ref m_queueEmergencyDomainBehaviour!);
        CommonWattleExtensions.SilentDisposeAndFree(ref m_partitionsSponsor!);

        InfrastructureMonitorRegisters.SilentDispose();
        JsonDeserializer.SilentDispose();
        BinaryDeserializer.SilentDispose();
        UnitOfWorkLocks.SilentDispose();
        DemoDelayTaskProcessor.SilentDispose();

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

        if (false == DemoDelayTaskProcessor.IsReady)
        {
            ApplyMessage(DemoDelayTaskProcessor.InfrastructureMonitor.GetSnapShot());
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
        var serviceProvider = container.Resolve<IServiceProvider>();

        var tracer = serviceProvider.GetService<Tracer>();
        using var mainSpan = tracer?.StartActiveSpan(nameof(New), initialAttributes: SpanAttributes);

        try
        {
            var result = DoNew(
                container,
                serviceProvider,
                tracer);

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

    private void PostCreate()
    {
        var infrastructureMonitor = (InfrastructureMonitorCustomEntryPoint)InfrastructureMonitor;
        infrastructureMonitor.AddSubMonitor(m_queueEmergencyDomainBehaviour.InfrastructureMonitor);
        infrastructureMonitor.AddSubMonitor(m_partitionsSponsor.InfrastructureMonitor);
        infrastructureMonitor.AddSubMonitor(DemoDelayTaskProcessor.InfrastructureMonitor);
        infrastructureMonitor.AddSubMonitor(JsonDeserializer.InfrastructureMonitor);
        infrastructureMonitor.AddSubMonitor(BinaryDeserializer.InfrastructureMonitor);

        foreach (var iMonitor in UnitOfWorkLocks.Hub.InfrastructureMonitorLocksPools)
        {
            infrastructureMonitor.AddSubMonitor(iMonitor);
        }

        InfrastructureMonitorRegisters.AddMonitor(infrastructureMonitor);
        InfrastructureMonitorRegisters.AddFavorit(infrastructureMonitor.Id);

        m_partitionsSponsor.Create();

        SetInitialized();
    }

    private static EntryPoint DoNew(
        IUnityContainer container,
        IServiceProvider serviceProvider,
        Tracer? tracer)
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

        var exceptionPolicy =
            new ExceptionPolicy(
                systemSettings,
                new WorkflowExceptionPolicy(),
                timeService,
                loggerFactory.CreateLogger<ExceptionPolicy>(),
                tracer,
                serviceProvider.GetService<Metrics>(),
                systemSettingsLocal, 
                serviceProvider);
        var result =
            new EntryPoint(
                templateServerDescription,
                systemSettings,
                exceptionPolicy,
                timeService,
                systemSettings.TimeStatisticsStep.Value,
                loggerFactory,
                tracer,
                systemSettingsLocal,
                serviceProvider.GetService<Metrics>(), 
                serviceProvider);

        result.Facade =
            LoggingDispatchProxy<IEntryPointFacade>.CreateProxy(
                container.ResolveWithDefault<IEntryPointFacade>(() => new EntryPointFacade(result)),
                result.LoggerFactory.CreateLogger<IEntryPointFacade>(),
                result.Tracer);

        InitializeDomainObject(container, result);

        result.PostCreate();

        return (result);
    }

    private static void InitializeDomainObject(
        IUnityContainer container,
        EntryPoint entryPoint)
    {
        container.RegisterInstance((DomainObjectDataMappers)entryPoint.m_dataMappers, InstanceLifetime.External);
        container.RegisterInstance<ICustomEntryPoint>(entryPoint, InstanceLifetime.External);
        container.RegisterInstance(entryPoint.Mappers, InstanceLifetime.External);
        container.RegisterInstance((DomainObjectRegisters)entryPoint.m_registers, InstanceLifetime.External);

        if (false == container.TryResolve<IDomainObjectIntergrators<IUnityContainer>>(out var domainObjectIntergrators))
        {
            domainObjectIntergrators =
                new DefaultDomainObjectIntergrators<IUnityContainer>(entryPoint.m_logger)
                    .Add(entryPoint.GetType().Assembly);
        }
        foreach (var domainObjectIntergrator in domainObjectIntergrators!)
        {
            domainObjectIntergrator.Run(container);
        }
    }

    private static SystemSettingsLocal GetSystemSettingsLocal(string connectionString)
    {
        using var mappers = GetMappers(connectionString);
        using var mappersSession = mappers.OpenSession();
        var systemSettings = mappers.GetSystemSettings(mappersSession);
        var result = new SystemSettingsLocal(systemSettings);

        return (result);
    }

    public static ICustomMappers GetMappers(string connectionString = "")
    {
        var result =
            new Mappers(
                new MappersExceptionPolicy(),
                connectionString,
                new TimeService(),
                WellknownInfrastructureMonitors.Mappers,
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                15000);

        return result;
    }
}
