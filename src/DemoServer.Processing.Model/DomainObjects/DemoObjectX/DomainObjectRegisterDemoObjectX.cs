using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Caching;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters.IdentitiesServices;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public class DomainObjectRegisterDemoObjectX : DomainObjectRegisterWithContextWithAlternativeKeyStatelessDefault<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKeyEntry, long /* Group */, DemoObjectXDtoActual, IMapperDemoObjectX>, IDomainObjectRegisterDemoObjectX
{
    #region ProxyDomainObjectRegister

    private class ProxyDomainObjectRegister : AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKeyEntry, long /* Group */>, IDomainObjectRegisterDemoObjectX
    {
        protected override void GetKey(IDomainObjectDemoObjectX domainObject, out DemoObjectXIdentitiesService.AlternativeKeyEntry keyEntry)
        {
            keyEntry = domainObject.GetKey();
        }
    }

    #endregion

    public DomainObjectRegisterDemoObjectX(
        IEntryPointContext entryPointContext,
        IDomainObjectDataMapper dataMapper,
        IDomainObjectDataActivator dataActivator,
        IDomainObjectActivator activator)
        : base(
            entryPointContext,
            dataMapper,
            dataActivator,
            activator,
            new DefaultMemoryCacheSlim<long, DemoObjectXIdentitiesService.AlternativeKeyEntry>(
                entryPointContext,
                ((ICustomEntryPoint)entryPointContext.EntryPoint).SystemSettings.DomainObjectRegistersSettings.Value.MemoryCacheDemoObjectX.Value,
                $"Кэш реестра доменных объектов '{entryPointContext.GetDisplayNameDomainObject(WellknownDomainObjects.DemoObjectX)}' по ключу"),
            DemoObjectXIdentitiesService.New((ICustomEntryPoint)entryPointContext.EntryPoint),
            WellknownDomainObjectFields.DemoObjectX.NameAlternateKey,
            WellknownDomainObjectFields.DemoObjectX.NameCollection)
    {
    }

    protected override AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKeyEntry, long> 
        DoCreateProxy()
    {
        var result = new ProxyDomainObjectRegister();

        return result;
    }
}