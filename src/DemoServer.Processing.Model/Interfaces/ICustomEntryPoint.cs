using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Processing.DataAccess.Interface;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;
using ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;
using ShtrihM.Wattle3.Common.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainBehaviours;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using System;
using System.Collections.Concurrent;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

public interface ICustomEntryPoint : IEntryPoint
{
    DomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation<TMapper>(long identity) where TMapper : IMapper;
    DomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation();

    UnitOfWork CurrentUnitOfWork { get; }
    IDomainObjectRegisters Registers { get; }
    IDomainObjectDataMappers DataMappers { get; }
    SystemSettingsLocal SystemSettingsLocal { get; }
    ITimeService TimeService { get; }
    WorkflowExceptionPolicy WorkflowExceptionPolicy { get; }
    MetaServerDescription ServerDescription { get; }
    new IInfrastructureMonitorCustomEntryPoint InfrastructureMonitor { get; }
    SystemSettings SystemSettings { get; }
    ICustomMappers Mappers { get; }
    IExceptionPolicy ExceptionPolicy { get; }
    IPartitionsDay PartitionsDay { get; }
    IServiceProvider ServiceProvider { get; }
    IEntryPointFacade Facade { get; }
    Metrics Metrics { get; }
    Tracer Tracer { get; }
    ILoggerFactory LoggerFactory { get; }
    UnitOfWorkLocksHubTyped UnitOfWorkLocks { get; }

#if DEBUG
    ConcurrentDictionary<Guid, Action<object>> HotSpots { get; }
#endif
}
