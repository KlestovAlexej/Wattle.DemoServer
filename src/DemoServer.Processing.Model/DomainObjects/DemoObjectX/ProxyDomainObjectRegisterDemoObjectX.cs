using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters.IdentitiesServices;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

public class ProxyDomainObjectRegisterDemoObjectX : AltProxyDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXAlternativeKey, long /* Group */>, IDomainObjectRegisterDemoObjectX
{
    protected override void GetKey(IDomainObjectDemoObjectX domainObject, out DemoObjectXAlternativeKey key)
    {
        key = domainObject.GetKey();
    }
}