using System;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;
using ShtrihM.Wattle3.Common.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocksActions
{
    #region Locks

    [UnitOfWorkLock(typeof(DomainObjectDemoObjectX.AlternativeKey), DomainObjectUnitOfWorkLockServiceType.Simple)]
    private static readonly Guid LocksCreateDemoObjectX = new("65E29EDB-4135-4D9A-862F-42E079266FCB");

    #endregion

    // ReSharper disable once ConvertToPrimaryConstructor
    public UnitOfWorkLocksActions(UnitOfWorkLocksHubTyped hub)
    {
        CreateDemoObjectX =
            hub.GetLock<DomainObjectDemoObjectX.AlternativeKey>(
                LocksCreateDemoObjectX);
    }

    /// <summary>
    /// Лок-объек сценария - создание объекта X.
    /// </summary>
    public readonly IDomainObjectUnitOfWorkLock<DomainObjectDemoObjectX.AlternativeKey> CreateDemoObjectX;
}