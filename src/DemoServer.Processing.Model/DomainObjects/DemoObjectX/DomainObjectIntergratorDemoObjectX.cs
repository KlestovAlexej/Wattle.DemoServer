using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using Unity;

#pragma warning disable IDE0290

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public class DomainObjectIntergratorDemoObjectX : BaseDomainObjectIntergrator<IUnityContainer>
{
    #region Activator

    private class DomainObjectActivatorDemoObjectX : BaseDomainObjectActivator<DomainObjectTemplateDemoObjectX>
    {
        private readonly ICustomEntryPoint m_entryPoint;

        public DomainObjectActivatorDemoObjectX(ICustomEntryPoint entryPoint)
            : base(WellknownDomainObjects.DemoObjectX,
                entryPoint.UnitOfWorkLocks.DemoObjectX,
                entryPoint.UnitOfWorkProvider)
        {
            m_entryPoint = entryPoint;
        }

        protected override IDomainObject DoCreate(
            IDomainObjectIdentityGenerator identityGenerator,
            DomainObjectTemplateDemoObjectX template)
        {
            var key = template.GetKey();
            if (false == m_entryPoint.UnitOfWorkLocks.UnitOfWorkLocksActions.CreateDemoObjectX.TryEnter(key))
            {
                var workflowException = m_entryPoint.WorkflowExceptionPolicy.CreateTooBusy();

                throw workflowException;
            }

            var register = (DomainObjectRegisterDemoObjectX)m_entryPoint.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            if (register.ExistsByKey(key))
            {
                var workflowException = m_entryPoint.WorkflowExceptionPolicy.CreateDemoObjectXKeyAlreadyExists();

                throw workflowException;
            }

            var identity = identityGenerator.GetNextIdentity();
            var result = new DomainObjectDemoObjectX(m_entryPoint, identity, template);

            return (result);
        }

        protected override async ValueTask<IDomainObject> DoCreateAsync(
            IDomainObjectIdentityGenerator identityGenerator,
            DomainObjectTemplateDemoObjectX template,
            CancellationToken cancellationToken = default)
        {
            var key = template.GetKey();
            if (false == await m_entryPoint.UnitOfWorkLocks.UnitOfWorkLocksActions.CreateDemoObjectX.TryEnterAsync(key, cancellationToken).ConfigureAwait(false))
            {
                var workflowException = m_entryPoint.WorkflowExceptionPolicy.CreateTooBusy();

                throw workflowException;
            }

            var register = (DomainObjectRegisterDemoObjectX)m_entryPoint.Registers.GetRegister<IDomainObjectRegisterDemoObjectX>();
            if (await register.ExistsByKeyAsync(key, cancellationToken).ConfigureAwait(false))
            {
                var workflowException = m_entryPoint.WorkflowExceptionPolicy.CreateDemoObjectXKeyAlreadyExists();

                throw workflowException;
            }

            var identity = await identityGenerator.GetNextIdentityAsync(cancellationToken).ConfigureAwait(false);
            var result = new DomainObjectDemoObjectX(m_entryPoint, identity, template);

            return (result);
        }
    }

    #endregion

    #region DataActivator

    private class DomainObjectDataActivatorDemoObjectX : BaseDomainObjectDataActivatorForActualStateDto<DemoObjectXDtoActual>
    {
        private readonly ICustomEntryPoint m_entryPoint;

        public DomainObjectDataActivatorDemoObjectX(
            ICustomEntryPoint entryPoint)
            : base(WellknownDomainObjects.DemoObjectX)
        {
            m_entryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));
        }

        protected override IDomainObject DoLoadObject(DemoObjectXDtoActual dataDto)
        {
            var result = new DomainObjectDemoObjectX(m_entryPoint, dataDto);

            return (result);
        }
    }

    #endregion

    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var mapper = entryPoint.Mappers.GetMapper<IMapperDemoObjectX>();
        var identityCache =
            new IdentityCache<IMapperDemoObjectX>(
                GuidGenerator.New($"{mapper.MapperId} {nameof(IMapperDemoObjectX)}"),
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                entryPoint.TimeService,
                entryPoint.ExceptionPolicy,
                entryPoint.WorkflowExceptionPolicy,
                entryPoint.SystemSettings.TimeStatisticsStep.Value,
                mapper,
                entryPoint.SystemSettings.IdentityCachesSettings.Value.DemoObjectX.Value,
                entryPoint.LoggerFactory.CreateLogger<IdentityCache<IMapperDemoObjectX>>());
        var dataMapper =
            new DomainObjectDataMapperFullDefault
            <IMapperDemoObjectX, DemoObjectXDtoNew, DemoObjectXDtoActual, DemoObjectXDtoChanged,
                DemoObjectXDtoDeleted>(
                entryPoint.UnitOfWorkProvider,
                entryPoint.TimeService,
                mapper,
                identityCache);
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterDemoObjectX(
                dataMapper,
                new DomainObjectDataActivatorDemoObjectX(entryPoint),
                new DomainObjectActivatorDemoObjectX(entryPoint),
                entryPoint));
    }
}