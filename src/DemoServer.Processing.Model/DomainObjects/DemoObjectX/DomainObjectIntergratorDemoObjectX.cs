using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;
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
                new DomainObjectDataActivatorForActualStateDtoDefault<DemoObjectXDtoActual, DomainObjectDemoObjectX>(entryPoint),
                new DomainObjectActivatorDefault<DomainObjectTemplateDemoObjectX, DomainObjectDemoObjectX>(entryPoint.UnitOfWorkProvider, entryPoint.UnitOfWorkLocks.DemoObjectX, entryPoint)
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
                        }),
                entryPoint));
    }
}