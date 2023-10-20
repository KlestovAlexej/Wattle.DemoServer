using System;
using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Caching;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters.IdentitiesServices;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

#pragma warning disable IDE0290

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public class DomainObjectRegisterDemoObjectX : DomainObjectRegisterWithContextWithAlternativeKeyStatelessDefault<IDomainObjectDemoObjectX, DemoObjectXAlternativeKey, long /* Group */, DemoObjectXDtoActual, IMapperDemoObjectX>, IDomainObjectRegisterDemoObjectX
{
    public DomainObjectRegisterDemoObjectX(
        Guid typeId,
        string name,
        IDomainObjectDataMapper dataMapper,
        IDomainObjectDataActivator dataActivator,
        IDomainObjectActivator activator,
        TimeSpan initializeThreadEmergencyTimeout,
        IReadOnlyDomainObjectsMemoryCache cache,
        ICustomEntryPoint entryPoint,
        ILoggerFactory loggerFactory)
        : base(
            typeId,
            name,
            dataMapper,
            dataActivator,
            activator,
            initializeThreadEmergencyTimeout,
            cache,
            entryPoint.Mappers,
            entryPoint.TimeService,
            entryPoint.WorkflowExceptionPolicy,
            entryPoint.ExceptionPolicy,
            entryPoint.UnitOfWorkProvider,
            loggerFactory.CreateLogger<DomainObjectRegisterDemoObjectX>(),
            new DefaultMemoryCacheSlim<long, DemoObjectXAlternativeKey>(
                entryPoint.TimeService,
                entryPoint.ExceptionPolicy,
                entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.MemoryCacheDemoObjectX.Value,
                $"Кэш реестра доменных объектов '{WellknownDomainObjects.GetDisplayName(typeId)}' по ключу",
                $"Кэш реестра доменных объектов '{WellknownDomainObjects.GetDisplayName(typeId)}' по ключу",
                new Guid("580A791B-2CF2-488B-9337-EA044202E0EC")),
            entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.UseIdentitiesServices.Value
                ? new DemoObjectXIdentitiesService(entryPoint, initializeThreadEmergencyTimeout, loggerFactory)
                : null,
            entryPoint.Mappers.GetMapper<IMapperDemoObjectX>(),
            DemoObjectXAlternativeKey.AlternativeKeyName,
            WellknownDomainObjectFields.DemoObjectX.NameCollection,
            DemoObjectXAlternativeKey.AlternativeKeyDecode)
    {
    }

    protected override AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXAlternativeKey, long> 
        DoCreateProxy()
    {
        var result = new ProxyDomainObjectRegisterDemoObjectX();

        return result;
    }
}