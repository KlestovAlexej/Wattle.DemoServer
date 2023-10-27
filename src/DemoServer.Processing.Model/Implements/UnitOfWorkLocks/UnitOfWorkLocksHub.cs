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
        EntryPoint = entryPoint;

        AddDomainObject(
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObject,
            EntryPoint.SystemSettings.LocksPoolSettings.Value.UpdateDemoObject.Value,
            WellknownDomainObjects.DemoObject);

        AddDomainObject(
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObjectX,
            EntryPoint.SystemSettings.LocksPoolSettings.Value.UpdateDemoObjectX.Value,
            WellknownDomainObjects.DemoObjectX);

        AddLock<DemoObjectXIdentitiesService.AlternativeKeyEntry>(
            WellknownCommonInfrastructureMonitors.LocksCreateDemoObjectX,
            EntryPoint.SystemSettings.LocksPoolSettings.Value.CreateDemoObjectX.Value);
    }

    public readonly ICustomEntryPoint EntryPoint;

    private void AddLock<T>(Guid id, TimeSpan? lockWait)
        where T : IEquatable<T>
    {
        Add(NewLocksPool<T>(id, lockWait));
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
                EntryPoint.TimeService,
                lockWait);

        return result;
    }

    protected override DomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation()
        => EntryPoint.CreateDomainBehaviourWithСonfirmation();
}