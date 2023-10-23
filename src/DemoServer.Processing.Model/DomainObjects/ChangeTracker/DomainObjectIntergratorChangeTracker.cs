using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
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
        var dataMapper =
            new DomainObjectDataMapperNoDeleteUpdateDefault
                <IMapperChangeTracker, ChangeTrackerDtoNew, ChangeTrackerDtoActual>(
                    entryPoint.Context,
                    entryPoint.SystemSettings.IdentityCachesSettings.Value.ChangeTracker.Value,
                    identityPrepare:
                    (mapper, identity) =>
                    {
                        var nowDayIndex = entryPoint.PartitionsDay.NowDayIndex;
                        identity = ComplexIdentity.Build(mapper.Partitions.Level, nowDayIndex, identity);

                        return identity;
                    });
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterStateless(
                entryPoint.Context,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<ChangeTrackerDtoActual,
                    DomainObjectChangeTracker>(),
                new DomainObjectActivatorDefault<DomainObjectChangeTracker.Template, DomainObjectChangeTracker>(
                    entryPoint.UnitOfWorkProvider),
                initializeThreadEmergencyTimeout: entryPoint.SystemSettings.DomainObjectRegistersSettings.Value
                    .InitializeEmergencyTimeout.Value));
    }
}