using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.DomainObjectDataMappers;
using Acme.Wattle.DomainObjects.DomainObjectIntergrators;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.Wattle.DomainObjects.DomainObjectActivators;
using Unity;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoObject;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public sealed class DomainObjectIntergratorDemoObject : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var dataMapper =
            DomainObjectDataMapperNoDeleteDefaultFactory.Create<IMapperDemoObject>(
                    entryPoint.Context,
                    entryPoint.SystemSettings.IdentityCachesSettings.Value.DemoObject.Value,
                    identityGroupId: entryPoint.PartitionsDay);
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        var lockUpdate = entryPoint.UnitOfWorkLocks.GetLockService<IDomainObjectDemoObject>();
        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterStateless(
                entryPoint.Context,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<DemoObjectDtoActual, DomainObjectDemoObject>(
                    entryPoint.Context, lockUpdate),
                new DomainObjectActivatorDefault<DomainObjectDemoObject.Template, DomainObjectDemoObject>(
                    entryPoint.UnitOfWorkProvider, lockUpdate, entryPoint.Context, lockUpdate)));
    }
}