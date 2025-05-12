using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.DomainObjects.UnitOfWorkLocks;

namespace Acme.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocksHub : BaseUnitOfWorkLocksHub<UnitOfWorkLocksHub>
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public UnitOfWorkLocksHub(IEntryPointContext entryPointContext)
        : base(
            entryPointContext,
            ((ICustomEntryPoint)entryPointContext.EntryPoint).SystemSettings.UnitOfWorkLocksSettings.Value,
            typeof(WellknownDomainObjectFields))
    {
    }

    protected override IDomainBehaviourWithConfirmation CreateDomainBehaviourWithConfirmation()
    {
        var result = ((UnitOfWork)m_entryPointContext.EntryPoint.UnitOfWorkProvider.Instance).CreateDomainBehaviourWithConfirmation(false);

        return result;
    }
}
