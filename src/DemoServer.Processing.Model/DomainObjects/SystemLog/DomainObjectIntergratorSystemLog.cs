using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using Unity;

#pragma warning disable IDE0290

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.SystemLog;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public class DomainObjectIntergratorSystemLog : BaseDomainObjectIntergrator<IUnityContainer>
{
    #region Activator

    private class DomainObjectActivatorSystemLog : BaseDomainObjectActivator<DomainObjectTemplateSystemLog>
    {
        private readonly ITimeService m_timeService;

        public DomainObjectActivatorSystemLog(
            ITimeService timeService,
            IUnitOfWorkProvider unitOfWorkProvider)
            : base(WellknownDomainObjects.SystemLog,
                unitOfWorkProvider: unitOfWorkProvider)
        {
            m_timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
        }

        protected override IDomainObject DoCreate(IDomainObjectIdentityGenerator identityGenerator, DomainObjectTemplateSystemLog template)
        {
            var identity = identityGenerator.GetNextIdentity();
            var result = new DomainObjectSystemLog(identity, template, m_timeService.NowDateTime);

            return (result);
        }

        protected override async ValueTask<IDomainObject> DoCreateAsync(IDomainObjectIdentityGenerator identityGenerator, DomainObjectTemplateSystemLog template, CancellationToken cancellationToken = default)
        {
            var identity = await identityGenerator.GetNextIdentityAsync(cancellationToken).ConfigureAwait(false);
            var result = new DomainObjectSystemLog(identity, template, m_timeService.NowDateTime);

            return (result);
        }
    }

    #endregion

    #region DataActivator

    private class DomainObjectDataActivatorSystemLog : BaseDomainObjectDataActivatorForActualStateDto<SystemLogDtoActual>
    {
        public DomainObjectDataActivatorSystemLog()
            : base(WellknownDomainObjects.SystemLog)
        {
        }

        protected override IDomainObject DoLoadObject(SystemLogDtoActual dataDto)
        {
            var result = new DomainObjectSystemLog(dataDto);

            return (result);
        }
    }

    #endregion

    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var mapper = entryPoint.Mappers.GetMapper<IMapperSystemLog>();
        var identityCache =
            new IdentityCache<IMapperSystemLog>(
                GuidGenerator.New($"{mapper.MapperId} {nameof(IMapperSystemLog)}"),
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                entryPoint.TimeService,
                entryPoint.ExceptionPolicy,
                entryPoint.WorkflowExceptionPolicy,
                entryPoint.SystemSettings.TimeStatisticsStep.Value,
                mapper,
                entryPoint.SystemSettings.IdentityCachesSettings.Value.SystemLog.Value,
                entryPoint.LoggerFactory.CreateLogger<IdentityCache<IMapperSystemLog>>());

        var partitionsLevel = mapper.Partitions.Level;
        var partitionsDay = entryPoint.PartitionsDay;
        var dataMapper =
            new DomainObjectDataMapperNoDeleteUpdateDefault
                <IMapperSystemLog, SystemLogDtoNew, SystemLogDtoActual>(
                    entryPoint.UnitOfWorkProvider,
                    entryPoint.TimeService,
                    mapper,
                    identityCache,
                    identityPrepare:
                    identity =>
                    {
                        var nowDayIndex = partitionsDay.NowDayIndex;
                        identity = ComplexIdentity.Build(partitionsLevel, nowDayIndex, identity);

                        return identity;
                    });
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterStateless(
                WellknownDomainObjects.SystemLog,
                WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.SystemLog),
                dataMapper,
                new DomainObjectDataActivatorSystemLog(),
                new DomainObjectActivatorSystemLog(entryPoint.TimeService, entryPoint.UnitOfWorkProvider),
                entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.InitializeEmergencyTimeout.Value,
                null,
                entryPoint.Mappers,
                entryPoint.TimeService,
                entryPoint.WorkflowExceptionPolicy,
                entryPoint.ExceptionPolicy,
                entryPoint.UnitOfWorkProvider,
                entryPoint.LoggerFactory.CreateLogger<DomainObjectRegisterStateless>()));
    }
}