using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.DomainObjectDataMappers;
using Acme.Wattle.DomainObjects.DomainObjectIntergrators;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.Wattle.DomainObjects.DomainObjectActivators;
using Unity;

namespace Acme.DemoServer.Processing.Model.DomainObjects.ChangeTracker;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public sealed class DomainObjectIntergratorChangeTracker : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var dataMapper =
            DomainObjectDataMapperNoDeleteUpdateDefaultFactory.Create<IMapperChangeTracker>(
                    entryPoint.Context,
                    entryPoint.SystemSettings.IdentityCaches.Value.ChangeTracker.Value,
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