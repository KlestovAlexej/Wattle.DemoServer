using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocksHub : BaseUnitOfWorkLocksHub<UnitOfWorkLocksHub>
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public UnitOfWorkLocksHub(IEntryPointContext entryPointContext)
        : base(
            entryPointContext,
            true,
            ((ICustomEntryPoint)entryPointContext.EntryPoint).SystemSettings.LocksPoolSettings.Value.Update.Value,
            ((ICustomEntryPoint)entryPointContext.EntryPoint).SystemSettings.LocksPoolSettings.Value.Any.Value,
            typeof(WellknownDomainObjectFields))
    {
    }

    protected override IDomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation()
    {
        var result = ((UnitOfWork)m_entryPointContext.EntryPoint.UnitOfWorkProvider.Instance).CreateDomainBehaviourWithСonfirmation(false);

        return result;
    }
}
