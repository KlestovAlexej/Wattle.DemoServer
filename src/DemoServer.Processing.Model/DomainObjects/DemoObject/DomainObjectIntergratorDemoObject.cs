using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using Unity;
using ShtrihM.DemoServer.Processing.Model.Implements;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObject;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public class DomainObjectIntergratorDemoObject : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var dataMapper =
            new DomainObjectDataMapperNoDeleteDefault
                <IMapperDemoObject, DemoObjectDtoNew, DemoObjectDtoActual, DemoObjectDtoChanged>(
                    entryPoint.Context,
                    entryPoint.SystemSettings.IdentityCachesSettings.Value.DemoObject.Value,
                    identityPrepare: DomainObjectIntergratorHelpers.GetIdentityPrepare<IMapperDemoObject>(entryPoint));
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        var lockUpdate = entryPoint.UnitOfWorkLocks.DemoObject;
        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterStateless(
                entryPoint.Context,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<DemoObjectDtoActual, DomainObjectDemoObject>(entryPoint, lockUpdate),
                new DomainObjectActivatorDefault<DomainObjectDemoObject.Template, DomainObjectDemoObject>(
                    entryPoint.UnitOfWorkProvider, lockUpdate, entryPoint, lockUpdate)));
    }
}