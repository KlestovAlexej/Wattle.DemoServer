using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Caching;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters.IdentitiesServices;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

#pragma warning disable IDE0290

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public class DomainObjectRegisterDemoObjectX : DomainObjectRegisterWithContextWithAlternativeKeyStatelessDefault<IDomainObjectDemoObjectX, DemoObjectXAlternativeKey, long /* Group */, DemoObjectXDtoActual, IMapperDemoObjectX>, IDomainObjectRegisterDemoObjectX
{
    public DomainObjectRegisterDemoObjectX(
        IEntryPointContext entryPointContext,
        IDomainObjectDataMapper dataMapper,
        IDomainObjectDataActivator dataActivator,
        IDomainObjectActivator activator,
        ICustomEntryPoint entryPoint)
        : base(
            entryPointContext,
            dataMapper,
            dataActivator,
            activator,
            new DefaultMemoryCacheSlim<long, DemoObjectXAlternativeKey>(
                entryPoint.Context,
                entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.MemoryCacheDemoObjectX.Value,
                $"Кэш реестра доменных объектов '{entryPoint.Context.GetDisplayNameDomainObject(WellknownDomainObjects.DemoObjectX)}' по ключу"),
            entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.UseIdentitiesServices.Value
                ? new DemoObjectXIdentitiesService(entryPoint)
                : null,
            DemoObjectXAlternativeKey.AlternativeKeyName,
            WellknownDomainObjectFields.DemoObjectX.NameCollection,
            DemoObjectXAlternativeKey.AlternativeKeyDecode,
            entryPoint.SystemSettings.DomainObjectRegistersSettings.Value.InitializeEmergencyTimeout.Value,
            logger: entryPoint.LoggerFactory.CreateLogger<DomainObjectRegisterDemoObjectX>())
    {
    }

    protected override AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXAlternativeKey, long> 
        DoCreateProxy()
    {
        var result = new ProxyDomainObjectRegisterDemoObjectX();

        return result;
    }
}