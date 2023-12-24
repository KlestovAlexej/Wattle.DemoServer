using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using Unity;
using ShtrihM.DemoServer.Processing.Model.Implements;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public class DomainObjectIntergratorDemoObjectX : BaseDomainObjectIntergrator<IUnityContainer>
{
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var dataMapper =
            DomainObjectDataMapperFullDefaultFactory.Create<IMapperDemoObjectX>(
                entryPoint.Context,
                entryPoint.SystemSettings.IdentityCachesSettings.Value.DemoObjectX.Value);
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        var lockUpdate = entryPoint.GetLock<IDomainObjectDemoObjectX>();
        var domainObjectActivator = 
            new DomainObjectActivatorDefault<DomainObjectDemoObjectX.Template, DomainObjectDemoObjectX>(
                entryPoint.UnitOfWorkProvider, entryPoint, lockUpdate);
        var domainObjectRegister
            = new DomainObjectRegisterDemoObjectX(
                entryPoint,
                dataMapper,
                new DomainObjectDataActivatorForActualStateDtoDefault<DemoObjectXDtoActual, DomainObjectDemoObjectX>(
                    entryPoint, lockUpdate),
                domainObjectActivator);
        container.Resolve<DomainObjectRegisters>().AddRegister(domainObjectRegister);

        #region DomainObjectActivator + PreCreate

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