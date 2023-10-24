using System;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public class UnitOfWorkLocksHubTyped
{
    public UnitOfWorkLocksHubTyped(
        IUnitOfWorkProvider unitOfWorkProvider,
        IUnitOfWorkLocksHub unitOfWorkLocksHub)
    {
        if (unitOfWorkProvider == null)
        {
            throw new ArgumentNullException(nameof(unitOfWorkProvider));
        }

        Hub = unitOfWorkLocksHub ?? throw new ArgumentNullException(nameof(unitOfWorkLocksHub));
        UnitOfWorkLocksActions = new UnitOfWorkLocksActions(unitOfWorkLocksHub);

        var unitOfWorkLocks = () => ((UnitOfWork)unitOfWorkProvider.Instance).CurrentLocks;

        DemoObject = new DomainObjectUnitOfWorkLocks(
            Hub,
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObject,
            WellknownDomainObjects.DemoObject,
            unitOfWorkLocks);

        DemoObjectX = new DomainObjectUnitOfWorkLocks(
            Hub,
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObjectX,
            WellknownDomainObjects.DemoObjectX,
            unitOfWorkLocks);
    }

    public readonly IUnitOfWorkLocksHub Hub;
    public readonly UnitOfWorkLocksActions UnitOfWorkLocksActions;
    public readonly DomainObjectUnitOfWorkLocks DemoObject;
    public readonly DomainObjectUnitOfWorkLocks DemoObjectX;
}