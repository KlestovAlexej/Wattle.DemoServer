using System;
using System.Collections.Generic;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using System.Reflection;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocksHubTyped : IDisposable
{
    #region Public Class UnitOfWorkLocksHub

    public sealed class UnitOfWorkLocksHub : BaseUnitOfWorkLocksHub
    {
        private readonly IUnitOfWorkProvider m_unitOfWorkProvider;

        public UnitOfWorkLocksHub(IEntryPointContext entryPointContext)
            : base(
                entryPointContext,
#if DEBUG
                true,
#else
                false,
#endif
                ((ICustomEntryPoint)entryPointContext.EntryPoint).SystemSettings.LocksPoolSettings.Value.Update.Value,
                ((ICustomEntryPoint)entryPointContext.EntryPoint).SystemSettings.LocksPoolSettings.Value.AlternativeKey.Value,
                typeof(WellknownDomainObjectFields).GetNestedTypes(BindingFlags.Public))
        {
            m_unitOfWorkProvider = entryPointContext.EntryPoint.UnitOfWorkProvider;
        }

        protected override IDomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation()
        {
            var result = ((UnitOfWork)m_unitOfWorkProvider.Instance).CreateDomainBehaviourWithСonfirmation(false);

            return result;
        }
    }

    #endregion

    private readonly Dictionary<Guid, IDomainObjectUnitOfWorkLockService> m_locks;
    private readonly IUnitOfWorkProvider m_unitOfWorkProvider;

    public UnitOfWorkLocksHubTyped(IEntryPointContext entryPointContext)
    {
        m_unitOfWorkProvider = entryPointContext.EntryPoint.UnitOfWorkProvider;
        Hub = new UnitOfWorkLocksHub(entryPointContext);
        Actions = new UnitOfWorkLocksActions(Hub);
        m_locks = new Dictionary<Guid, IDomainObjectUnitOfWorkLockService>();

        foreach (var updateLock in Hub.UpdateLocks)
        {
            DoCreate(updateLock.LockId, updateLock.TypeId);
        }
    }

    public UnitOfWorkLocksHub Hub { get; private set; }
    public readonly UnitOfWorkLocksActions Actions;

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
        var temp = Hub;
        Hub = null!;
        temp.SilentDispose();
    }

    private void DoCreate(Guid lockId, Guid typeId)
    {
        var result =
            new DomainObjectUnitOfWorkLockServiceDefault(
                Hub,
                lockId,
                typeId,
                () => ((UnitOfWork)m_unitOfWorkProvider.Instance).CurrentLocksGetOrCreate);

        if (false == m_locks.TryAdd(typeId, result))
        {
            throw new InternalException($"Уже существуют сервисы лок-объекта для доменного объекта с типом '{typeId}'.");
        }
    }
}
