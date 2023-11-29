using System;
using System.Collections.Generic;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public class UnitOfWorkLocksHubTyped : IDisposable
{
    private readonly Dictionary<Guid, IDomainObjectUnitOfWorkLockService> m_locks;

    public UnitOfWorkLocksHubTyped(ICustomEntryPoint entryPoint)
    {
        if (entryPoint == null)
        {
            throw new ArgumentNullException(nameof(entryPoint));
        }

        Hub = new UnitOfWorkLocksHub(entryPoint);
        Actions = new(Hub);

        m_locks = new Dictionary<Guid, IDomainObjectUnitOfWorkLockService>();

        UpdateDemoObject = DoCreate(
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObject,
            WellknownDomainObjects.DemoObject);

        UpdateDemoObjectX = DoCreate(
            WellknownCommonInfrastructureMonitors.LocksUpdateDemoObjectX,
            WellknownDomainObjects.DemoObjectX);
    }

    public UnitOfWorkLocksHub Hub { get; private set; }
    public readonly UnitOfWorkLocksActions Actions;
    public readonly IDomainObjectUnitOfWorkLockService UpdateDemoObject;
    public readonly IDomainObjectUnitOfWorkLockService UpdateDemoObjectX;

    public IDomainObjectUnitOfWorkLockService GetLock(Guid typeId)
    {
        if (false == m_locks.TryGetValue(typeId, out var service))
        {
            throw new InternalException($"Не найдены сервисы лок-объекта для доменного объекта с типом '{typeId}'.");
        }

        return service;
    }

    public void Dispose()
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var temp = Hub;
        Hub = null;
        temp.SilentDispose();
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        GC.SuppressFinalize(this);
    }

    private IDomainObjectUnitOfWorkLockService DoCreate(Guid lockId, Guid typeId)
    {
        var unitOfWorkProvider = Hub.EntryPoint.UnitOfWorkProvider;
        var result =
            new DomainObjectUnitOfWorkLockServiceDefault(
                Hub,
                lockId,
                typeId,
                () => ((UnitOfWork)unitOfWorkProvider.Instance).CurrentLocksGetOrCreate);

        m_locks.Add(typeId, result);

        return result;
    }
}