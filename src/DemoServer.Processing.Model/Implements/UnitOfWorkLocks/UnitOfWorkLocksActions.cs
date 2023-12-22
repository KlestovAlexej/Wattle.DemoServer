using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocksActions
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public UnitOfWorkLocksActions(IUnitOfWorkLocksHub unitOfWorkLocksHub)
    {
        CreateDemoObjectX = new DomainObjectUnitOfWorkLockAsSimple<DemoObjectXIdentitiesService.AlternativeKey>(unitOfWorkLocksHub, WellknownCommonInfrastructureMonitors.LocksCreateDemoObjectX);
    }

    public readonly IDomainObjectUnitOfWorkLock<DemoObjectXIdentitiesService.AlternativeKey> CreateDemoObjectX;
}