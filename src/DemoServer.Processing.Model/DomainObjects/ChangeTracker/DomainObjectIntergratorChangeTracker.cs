using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using Unity;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.ChangeTracker;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public class DomainObjectIntergratorChangeTracker : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var mapper = entryPoint.Mappers.GetMapper<IMapperChangeTracker>();
        var partitionsLevel = mapper.Partitions.Level;
        var partitionsDay = entryPoint.PartitionsDay;
        var dataMapper =
            new DomainObjectDataMapperNoDeleteUpdateDefault
                <IMapperChangeTracker, ChangeTrackerDtoNew, ChangeTrackerDtoActual>(
                    entryPoint.Context,
                    new IdentityCache<IMapperChangeTracker>(
                        entryPoint.Context,
                        entryPoint.SystemSettings.IdentityCachesSettings.Value.ChangeTracker.Value),
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
                entryPoint.Context,
                WellknownDomainObjects.ChangeTracker,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<ChangeTrackerDtoActual,
                    DomainObjectChangeTracker>(),
                new DomainObjectActivatorDefault<DomainObjectTemplateChangeTracker, DomainObjectChangeTracker>(
                    entryPoint.UnitOfWorkProvider),
                initializeThreadEmergencyTimeout: entryPoint.SystemSettings.DomainObjectRegistersSettings.Value
                    .InitializeEmergencyTimeout.Value));
    }
}