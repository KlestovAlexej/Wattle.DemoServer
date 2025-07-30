using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.DomainObjectDataMappers;
using Acme.Wattle.DomainObjects.DomainObjectIntergrators;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.Wattle.DomainObjects.DomainObjectActivators;
using Unity;

namespace Acme.DemoServer.Processing.Model.DomainObjects.SystemLog;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public sealed class DomainObjectIntergratorSystemLog : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var dataMapper =
            DomainObjectDataMapperNoDeleteUpdateDefaultFactory.Create<IMapperSystemLog>(
                    entryPoint.Context,
                    entryPoint.SystemSettings.IdentityCaches.Value.SystemLog.Value,
                    identityGroupId: entryPoint.PartitionsDay);
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterStateless(
                entryPoint.Context,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<SystemLogDtoActual, DomainObjectSystemLog>(),
                new DomainObjectActivatorDefault<DomainObjectSystemLog.Template, DomainObjectSystemLog>(
                    entryPoint.UnitOfWorkProvider, entryPoint.TimeService)));
    }
}
