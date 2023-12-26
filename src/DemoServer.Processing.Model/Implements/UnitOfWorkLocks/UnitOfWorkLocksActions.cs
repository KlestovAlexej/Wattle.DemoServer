using System;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocksActions
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public UnitOfWorkLocksActions(IUnitOfWorkLocksHub unitOfWorkLocksHub)
    {
        CreateDemoObjectX =
            new DomainObjectUnitOfWorkLockAsSimple<WellknownDomainObjectFields.DemoObjectX.AlternativeKey>(
                unitOfWorkLocksHub,
                new Guid(WellknownDomainObjectFields.DemoObjectX.LockIdAlternativeKey));
    }

    public readonly IDomainObjectUnitOfWorkLock<WellknownDomainObjectFields.DemoObjectX.AlternativeKey> CreateDemoObjectX;
}