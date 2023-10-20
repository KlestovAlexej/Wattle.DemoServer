using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

/// <summary>
/// Контроль изменений.
/// </summary>
[DomainObjectInterface(WellknownDomainObjects.Text.ChangeTracker)]
public interface IDomainObjectChangeTracker : IDomainObject;
