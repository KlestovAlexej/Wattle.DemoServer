using Acme.DemoServer.Processing.Common;
using Acme.Wattle.DomainObjects.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Acme.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

namespace Acme.DemoServer.Processing.Model.Interfaces;

[DomainObjectRegistersInterface(WellknownDomainObjects.Text.DemoObjectX)]
public interface IDomainObjectRegisterDemoObjectX : IDomainObjectRegisterWithContextWithAlternativeKey<IDomainObjectDemoObjectX, DomainObjectDemoObjectX.AlternativeKey, long /* Group */>
{
    IEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroup(long group);
    IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByDemoGroupAsync(long group, CancellationToken cancellationToken = default);

    IDomainObjectDemoObjectX? FindByDemoAlternativeKey(DomainObjectDemoObjectX.AlternativeKey alternativeKey);
    ValueTask<IDomainObjectDemoObjectX?> FindByDemoAlternativeKeyAsync(DomainObjectDemoObjectX.AlternativeKey alternativeKey, CancellationToken cancellationToken = default);

    IEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSize(int size);
    IAsyncEnumerable<IDomainObjectDemoObjectX> GetCollectionByNameSizeAsync(int size, CancellationToken cancellationToken = default);

    IDomainObjectDemoObjectX? GetByName(string name);
    ValueTask<IDomainObjectDemoObjectX?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}