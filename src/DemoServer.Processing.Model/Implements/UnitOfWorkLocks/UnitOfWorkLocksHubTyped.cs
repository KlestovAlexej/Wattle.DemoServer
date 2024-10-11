using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.DomainObjects.UnitOfWorkLocks;

namespace Acme.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocksHubTyped : BaseUnitOfWorkLocksHubTyped<UnitOfWorkLocksHubTyped, UnitOfWorkLocksHub>
{
    public UnitOfWorkLocksHubTyped(IEntryPointContext entryPointContext)
        : base(entryPointContext, new UnitOfWorkLocksHub(entryPointContext))
    {
        Actions = new UnitOfWorkLocksActions(this);
    }

    public readonly UnitOfWorkLocksActions Actions;

    protected override AbstractUnitOfWorkLocks DoGetUnitOfWorkLocks()
    {
        var result = ((UnitOfWork)m_unitOfWorkProvider.Instance).CurrentLocksGetOrCreate;

        return result;
    }
}