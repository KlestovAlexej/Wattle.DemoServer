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

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObject;

[DomainObjectIntergrator]
// ReSharper disable once UnusedType.Global
public class DomainObjectIntergratorDemoObject : BaseDomainObjectIntergrator<IUnityContainer>
{
    #region Activator

    private class DomainObjectActivatorDemoObject : BaseDomainObjectActivator<DomainObjectTemplateDemoObject>
    {
        private readonly ICustomEntryPoint m_entryPoint;

        public DomainObjectActivatorDemoObject(ICustomEntryPoint entryPoint)
            : base(WellknownDomainObjects.DemoObject,
                entryPoint.UnitOfWorkLocks.DemoObject,
                entryPoint.UnitOfWorkProvider)
        {
            m_entryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));
        }

        protected override IDomainObject DoCreate(
            IDomainObjectIdentityGenerator identityGenerator,
            DomainObjectTemplateDemoObject template)
        {
            var identity = identityGenerator.GetNextIdentity();
            var result = new DomainObjectDemoObject(m_entryPoint, identity, template);

            return (result);
        }

        protected override async ValueTask<IDomainObject> DoCreateAsync(
            IDomainObjectIdentityGenerator identityGenerator,
            DomainObjectTemplateDemoObject template,
            CancellationToken cancellationToken = default)
        {
            var identity = await identityGenerator.GetNextIdentityAsync(cancellationToken).ConfigureAwait(false);
            var result = new DomainObjectDemoObject(m_entryPoint, identity, template);

            return (result);
        }
    }

    #endregion

    #region DataActivator

    private class DomainObjectDataActivatorDemoObject : BaseDomainObjectDataActivatorForActualStateDto<DemoObjectDtoActual>
    {
        private readonly ICustomEntryPoint m_entryPoint;

        public DomainObjectDataActivatorDemoObject(
            ICustomEntryPoint entryPoint)
            : base(WellknownDomainObjects.DemoObject)
        {
            m_entryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));
        }

        protected override IDomainObject DoLoadObject(DemoObjectDtoActual dataDto)
        {
            var result = new DomainObjectDemoObject(m_entryPoint, dataDto);

            return (result);
        }
    }

    #endregion

    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ICustomEntryPoint>();
        var mapper = entryPoint.Mappers.GetMapper<IMapperDemoObject>();
        var identityCache =
            new IdentityCache<IMapperDemoObject>(
                GuidGenerator.New($"{mapper.MapperId} {nameof(IMapperDemoObject)}"),
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                entryPoint.TimeService,
                entryPoint.ExceptionPolicy,
                entryPoint.WorkflowExceptionPolicy,
                entryPoint.SystemSettings.TimeStatisticsStep.Value,
                mapper,
                entryPoint.SystemSettings.IdentityCachesSettings.Value.DemoObject.Value,
                entryPoint.LoggerFactory.CreateLogger<IdentityCache<IMapperDemoObject>>());

        var partitionsLevel = mapper.Partitions.Level;
        var partitionsDay = entryPoint.PartitionsDay;
        var dataMapper =
            new DomainObjectDataMapperNoDeleteDefault
                <IMapperDemoObject, DemoObjectDtoNew, DemoObjectDtoActual, DemoObjectDtoChanged>(
                    entryPoint.UnitOfWorkProvider,
                    entryPoint.TimeService,
                    mapper,
                    identityCache,
                    identityPrepare:
                    identity =>
                    {
                        var nowDayIndex = partitionsDay.NowDayIndex;
                        identity = ComplexIdentity.Build(partitionsLevel, nowDayIndex, identity);

                        return identity;
                    });
        container.Resolve<DomainObjectDataMappers>().AddMapper(dataMapper);

        container.Resolve<DomainObjectRegisters>().AddRegister(
            new DomainObjectRegisterStateless(
                WellknownDomainObjects.DemoObject,
                WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObject),
                dataMapper,
                new DomainObjectDataActivatorDemoObject(entryPoint),
                new DomainObjectActivatorDemoObject(entryPoint),
                entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.InitializeEmergencyTimeout.Value,
                null,
                entryPoint.Mappers,
                entryPoint.TimeService,
                entryPoint.WorkflowExceptionPolicy,
                entryPoint.ExceptionPolicy,
                entryPoint.UnitOfWorkProvider,
                entryPoint.LoggerFactory.CreateLogger<DomainObjectRegisterStateless>()));
    }
}