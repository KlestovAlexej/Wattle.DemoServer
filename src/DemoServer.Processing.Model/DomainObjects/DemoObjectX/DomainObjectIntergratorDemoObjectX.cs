using System.Threading;
using System.Threading.Tasks;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.DomainObjectDataMappers;
using Acme.Wattle.DomainObjects.DomainObjectIntergrators;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.Wattle.DomainObjects.DomainObjectActivators;
using Unity;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public sealed class DomainObjectIntergratorDemoObjectX : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var dataMapper =
            DomainObjectDataMapperFullDefaultFactory.Create<IMapperDemoObjectX>(
                entryPoint.Context,
                entryPoint.SystemSettings.IdentityCaches.Value.DemoObjectX.Value);
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        var lockUpdate = entryPoint.UnitOfWorkLocks.GetLockService<IDomainObjectDemoObjectX>();
        var domainObjectActivator = 
            new DomainObjectActivatorDefault<DomainObjectDemoObjectX.Template, DomainObjectDemoObjectX>(
                entryPoint.UnitOfWorkProvider, entryPoint.Context, lockUpdate);
        var domainObjectRegister
            = new DomainObjectRegisterDemoObjectX(
                entryPoint,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<DemoObjectXDtoActual, DomainObjectDemoObjectX>(
                    entryPoint.Context, lockUpdate),
                domainObjectActivator);
        container.Resolve<DomainObjectRegisters>().AddRegister(domainObjectRegister);

        #region Аспект создания

        var lockActionCreate = entryPoint.UnitOfWorkLocks.Actions.CreateDemoObjectX;
        domainObjectActivator.SetPreCreate(PreCreate, PreCreateAsync);

        void PreCreate(DomainObjectDemoObjectX.Template template)
        {
            var key = template.GetKey();
            if (false == lockActionCreate.TryEnter(key))
            {
                var workflowException = entryPoint.WorkflowExceptionPolicy.CreateTooBusy();

                throw workflowException;
            }

            if (domainObjectRegister.ExistsByKey(key))
            {
                var workflowException = entryPoint.WorkflowExceptionPolicy.CreateDemoObjectXKeyAlreadyExists();

                throw workflowException;
            }
        }

        async ValueTask PreCreateAsync(DomainObjectDemoObjectX.Template template, CancellationToken cancellationToken)
        {
            var key = template.GetKey();
            if (false == await lockActionCreate.TryEnterAsync(key, cancellationToken).ConfigureAwait(false))
            {
                var workflowException = entryPoint.WorkflowExceptionPolicy.CreateTooBusy();

                throw workflowException;
            }

            if (await domainObjectRegister.ExistsByKeyAsync(key, cancellationToken).ConfigureAwait(false))
            {
                var workflowException = entryPoint.WorkflowExceptionPolicy.CreateDemoObjectXKeyAlreadyExists();

                throw workflowException;
            }
        }

        #endregion
    }
}