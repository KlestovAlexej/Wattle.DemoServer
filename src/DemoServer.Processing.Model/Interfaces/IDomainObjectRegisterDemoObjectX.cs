using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

[DomainObjectRegistersInterface(WellknownDomainObjects.Text.DemoObjectX)]
public interface IDomainObjectRegisterDemoObjectX : IDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DemoObjectXIdentitiesService.AlternativeKeyEntry, long /* Group */>
{
    IEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroup(long group);
    IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroupAsync(long group, CancellationToken cancellationToken = default);

    IDomainObjectDemoObjectX FindByDemoAlternativeKey(DemoObjectXIdentitiesService.AlternativeKeyEntry alternativeKey);
    ValueTask<IDomainObjectDemoObjectX> FindByDemoAlternativeKeyAsync(DemoObjectXIdentitiesService.AlternativeKeyEntry alternativeKey, CancellationToken cancellationToken = default);
}