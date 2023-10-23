using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.DomainBehaviours;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using System;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocksHub : AbstractUnitOfWorkLocksHub
{
    private readonly ICustomEntryPoint m_entryPoint;

    public UnitOfWorkLocksHub(ICustomEntryPoint entryPoint)
        : base(
            entryPoint.UnitOfWorkProvider,
#if DEBUG
            true
#else
            false
#endif
        )
    {
        m_entryPoint = entryPoint;

        AddDomainObject(
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObject,
            entryPoint.SystemSettings.LocksPoolSettings.Value.UpdateDemoObject.Value,
            WellknownDomainObjects.DemoObject);

        AddDomainObject(
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObjectX,
            entryPoint.SystemSettings.LocksPoolSettings.Value.UpdateDemoObjectX.Value,
            WellknownDomainObjects.DemoObjectX);

        Add(NewLocksPool<DemoObjectXIdentitiesService.AlternativeKeyEntry>(
            WellknownCommonInfrastructureMonitors.LocksCreateDemoObjectX,
            m_entryPoint.SystemSettings.LocksPoolSettings.Value.CreateDemoObjectX.Value));
    }

    private void AddDomainObject(Guid id, TimeSpan? lockWait, Guid typeId)
    {
        Add(NewLocksPool<long>(id, lockWait), typeId);
    }

    private ILocksPoolAsync<T> NewLocksPool<T>(Guid id, TimeSpan? lockWait)
    {
        var result =
            new LocksPoolAsync<T>(
                id,
                WellknownCommonInfrastructureMonitors.GetDisplayName(id),
                WellknownCommonInfrastructureMonitors.GetDisplayName(id),
                m_entryPoint.TimeService,
                lockWait);

        return result;
    }

    protected override DomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation()
        => m_entryPoint.CreateDomainBehaviourWithСonfirmation();
}