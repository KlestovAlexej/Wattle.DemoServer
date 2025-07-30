using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using Acme.DemoServer.Processing.DataAccess.Interface;
using Acme.DemoServer.Processing.Model.Implements;
using Acme.DemoServer.Processing.Model.Implements.SystemSettings;
using Acme.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;
using Acme.Wattle.Common.Interfaces;
using Acme.Wattle.DomainObjects.Interfaces;
using System;
using Acme.Wattle.DomainObjects.Serializers.Binary;
using Acme.Wattle.DomainObjects.Serializers.Json;
using Acme.Wattle.Mappers.Interfaces;
using IMapper = AutoMapper.IMapper;

namespace Acme.DemoServer.Processing.Model.Interfaces;

public interface ICustomEntryPoint : IEntryPoint
{
    // ReSharper disable once UnusedMemberInSuper.Global
    new IInfrastructureMonitorCustomEntryPoint InfrastructureMonitor { get; }

    // ReSharper disable once UnusedMemberInSuper.Global
    IServiceProvider ServiceProvider { get; }

    SystemSettingsLocal SystemSettingsLocal { get; }
    UnitOfWork CurrentUnitOfWork { get; }
    ITimeService TimeService { get; }
    WorkflowExceptionPolicy WorkflowExceptionPolicy { get; }
    MetaServerDescription ServerDescription { get; }
    SystemSettings SystemSettings { get; }
    ICustomMappers Mappers { get; }
    IExceptionPolicy ExceptionPolicy { get; }
    IPartitionsDay PartitionsDay { get; }
    IEntryPointFacade Facade { get; }
    Metrics? Metrics { get; }
    Tracer? Tracer { get; }
    ILoggerFactory LoggerFactory { get; }
    UnitOfWorkLocksHubTyped UnitOfWorkLocks { get; }
    IEntryPointContext<ICustomEntryPoint> Context { get; }
    IMapper AutoMapper { get; }
    IDemoDelayTaskProcessor DemoDelayTaskProcessor { get; }
    ISmartJsonDeserializer JsonDeserializer { get; }
    ISmartBinaryDeserializer BinaryDeserializer { get; }
}
