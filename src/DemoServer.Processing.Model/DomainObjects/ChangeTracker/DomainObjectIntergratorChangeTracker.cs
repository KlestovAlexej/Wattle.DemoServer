using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using Unity;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.ChangeTracker;

[DomainObjectIntergrator]
// ReSharper disable once UnusedMember.Global
public class DomainObjectIntergratorChangeTracker : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var dataMapper =
            DomainObjectDataMapperNoDeleteUpdateDefaultFactory.Create<IMapperChangeTracker>(
                    entryPoint.Context,
                    entryPoint.SystemSettings.IdentityCachesSettings.Value.ChangeTracker.Value,
                    identityGroupId: entryPoint.PartitionsDay);
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterStateless(
                entryPoint.Context,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<ChangeTrackerDtoActual,
                    DomainObjectChangeTracker>(),
                new DomainObjectActivatorDefault<DomainObjectChangeTracker.Template, DomainObjectChangeTracker>(
                    entryPoint.UnitOfWorkProvider)));
    }
}