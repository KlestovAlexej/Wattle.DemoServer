using Acme.DemoServer.Processing.Common;
using Acme.Wattle.DomainObjects.Interfaces;

namespace Acme.DemoServer.Processing.Model.Interfaces;

/// <summary>
/// Контроль изменений.
/// </summary>
[DomainObjectInterface(WellknownDomainObjects.Text.ChangeTracker)]
public interface IDomainObjectChangeTracker : IDomainObject;
