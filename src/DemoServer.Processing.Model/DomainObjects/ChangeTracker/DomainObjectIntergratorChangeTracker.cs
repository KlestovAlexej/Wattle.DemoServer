using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.DataAccess.Interface;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using Unity;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.ChangeTracker;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public class DomainObjectIntergratorChangeTracker : BaseDomainObjectIntergrator<IUnityContainer>
{
    #region Activator

    private class DomainObjectActivatorChangeTracker : BaseDomainObjectActivator<DomainObjectTemplateChangeTracker>
    {
        public DomainObjectActivatorChangeTracker(IUnitOfWorkProvider unitOfWorkProvider)
            : base(WellknownDomainObjects.ChangeTracker,
                unitOfWorkProvider: unitOfWorkProvider)
        {
        }

        protected override IDomainObject DoCreate(IDomainObjectIdentityGenerator identityGenerator, DomainObjectTemplateChangeTracker template)
        {
            var identity = identityGenerator.GetNextIdentity();
            var result = new DomainObjectChangeTracker(identity);

            return (result);
        }

        protected override async ValueTask<IDomainObject> DoCreateAsync(IDomainObjectIdentityGenerator identityGenerator, DomainObjectTemplateChangeTracker template, CancellationToken cancellationToken = default)
        {
            var identity = await identityGenerator.GetNextIdentityAsync(cancellationToken).ConfigureAwait(false);
            var result = new DomainObjectChangeTracker(identity);

            return (result);
        }
    }

    #endregion

    #region DataActivator

    private class DomainObjectDataActivatorChangeTracker : BaseDomainObjectDataActivatorForActualStateDto<ChangeTrackerDtoActual>
    {
        public DomainObjectDataActivatorChangeTracker()
            : base(WellknownDomainObjects.ChangeTracker)
        {
        }

        protected override IDomainObject DoLoadObject(ChangeTrackerDtoActual dataDto)
        {
            var result = new DomainObjectChangeTracker(dataDto);

            return (result);
        }
    }

    #endregion

    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var mappers = container.Resolve<ICustomMappers>();
        var loggerFactory = container.Resolve<ILoggerFactory>();
        var mapper = mappers.GetMapper<IMapperChangeTracker>();
        var identityCache =
            new IdentityCache<IMapperChangeTracker>(
                GuidGenerator.New($"{mapper.MapperId} {nameof(IMapperChangeTracker)}"),
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                entryPoint.TimeService,
                entryPoint.ExceptionPolicy,
                entryPoint.WorkflowExceptionPolicy,
                entryPoint.SystemSettings.TimeStatisticsStep.Value,
                mapper,
                entryPoint.SystemSettings.IdentityCachesSettings.Value.ChangeTracker.Value,
                loggerFactory.CreateLogger<IdentityCache<IMapperChangeTracker>>());

        var partitionsLevel = mapper.Partitions.Level;
        var partitionsDay = entryPoint.PartitionsDay;
        var dataMapper =
            new DomainObjectDataMapperNoDeleteUpdateDefault
                <IMapperChangeTracker, ChangeTrackerDtoNew, ChangeTrackerDtoActual>(
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
                WellknownDomainObjects.ChangeTracker,
                WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.ChangeTracker),
                dataMapper,
                new DomainObjectDataActivatorChangeTracker(),
                new DomainObjectActivatorChangeTracker(entryPoint.UnitOfWorkProvider),
                entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.InitializeEmergencyTimeout.Value,
                null,
                entryPoint.Mappers,
                entryPoint.TimeService,
                entryPoint.WorkflowExceptionPolicy,
                entryPoint.ExceptionPolicy,
                entryPoint.UnitOfWorkProvider,
                loggerFactory.CreateLogger<DomainObjectRegisterStateless>()));
    }
}