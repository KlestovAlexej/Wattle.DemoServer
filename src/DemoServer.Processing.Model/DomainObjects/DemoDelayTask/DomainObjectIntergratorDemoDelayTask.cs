using Acme.DemoServer.Processing.Generated.Interface;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.DomainObjectActivators;
using Acme.Wattle.DomainObjects.DomainObjectDataMappers;
using Acme.Wattle.DomainObjects.DomainObjectIntergrators;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters;
using Unity;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public class DomainObjectIntergratorDemoDelayTask : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var dataMapper =
            DomainObjectDataMapperNoDeleteDefaultFactory.Create<IMapperDemoDelayTask>(
                entryPoint.Context,
                entryPoint.SystemSettings.IdentityCaches.Value.DemoDelayTask.Value,
                identityGroupId: entryPoint.PartitionsDay);
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        var lockUpdate = entryPoint.UnitOfWorkLocks.GetLockService<IDomainObjectDemoDelayTask>();
        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterStateless(
                entryPoint.Context,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<DemoDelayTaskDtoActual, DomainObjectDemoDelayTask>(
                    entryPoint.Context, lockUpdate),
                new DomainObjectActivatorDefault<DomainObjectDemoDelayTask.Template, DomainObjectDemoDelayTask>(
                    entryPoint.UnitOfWorkProvider, lockUpdate, entryPoint.Context, lockUpdate)));
    }
}