using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using Unity;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public class DomainObjectIntergratorDemoObjectX : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var dataMapper =
            new DomainObjectDataMapperFullDefault
            <IMapperDemoObjectX, DemoObjectXDtoNew, DemoObjectXDtoActual, DemoObjectXDtoChanged,
                DemoObjectXDtoDeleted>(
                entryPoint.Context,
                entryPoint.SystemSettings.IdentityCachesSettings.Value.DemoObjectX.Value);
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterDemoObjectX(
                entryPoint.Context,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<DemoObjectXDtoActual, DomainObjectDemoObjectX>(entryPoint),
                new DomainObjectActivatorDefault<DomainObjectDemoObjectX.Template, DomainObjectDemoObjectX>(entryPoint.UnitOfWorkProvider, entryPoint.UnitOfWorkLocks.DemoObjectX, entryPoint)
                    .SetPreCreate(
                        template =>
                        {
                            var key = template.GetKey();
                            if (false == entryPoint.UnitOfWorkLocks.UnitOfWorkLocksActions.CreateDemoObjectX.TryEnter(key))
                            {
                                var workflowException = entryPoint.WorkflowExceptionPolicy.CreateTooBusy();

                                throw workflowException;
                            }

                            var register = (DomainObjectRegisterDemoObjectX)entryPoint.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
                            if (register.ExistsByKey(key))
                            {
                                var workflowException = entryPoint.WorkflowExceptionPolicy.CreateDemoObjectXKeyAlreadyExists();

                                throw workflowException;
                            }
                        },
                        async (template, cancellationToken) =>
                        {
                            var key = template.GetKey();
                            if (false == await entryPoint.UnitOfWorkLocks.UnitOfWorkLocksActions.CreateDemoObjectX.TryEnterAsync(key, cancellationToken).ConfigureAwait(false))
                            {
                                var workflowException = entryPoint.WorkflowExceptionPolicy.CreateTooBusy();

                                throw workflowException;
                            }

                            var register = (DomainObjectRegisterDemoObjectX)entryPoint.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
                            if (await register.ExistsByKeyAsync(key, cancellationToken).ConfigureAwait(false))
                            {
                                var workflowException = entryPoint.WorkflowExceptionPolicy.CreateDemoObjectXKeyAlreadyExists();

                                throw workflowException;
                            }
                        })));
    }
}