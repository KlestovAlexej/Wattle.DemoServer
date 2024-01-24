using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Mappers.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.Common;

/// <summary>
/// Базовая реализация доменного объекта с поддержкой изменения и блокировкой на изменение и ключом контроля обновления.
/// </summary>
public abstract class BaseDomainObjectMutableWithUpdateLockWithUpdateKey<TDomainObject> : BaseDomainObjectMutableWithUpdateLock<TDomainObject>, IDomainObjectUpdateKey
    where TDomainObject : BaseDomainObject<TDomainObject>
{
    [DomainObjectFieldValue]
    private byte[]? m_updateKey;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectMutableWithUpdateLockWithUpdateKey(
        ICustomEntryPoint entryPoint,
        IMapperDtoVersion data,
        IDomainObjectUnitOfWorkLockService lockUpdate,
        bool defineCommitVerifying = true)
        : base(entryPoint, data, lockUpdate, defineCommitVerifying)
    {
        // ReSharper disable once SuspiciousTypeConversion.Global
        m_updateKey = ((IMapperDtoUpdateKey)data).UpdateKey;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectMutableWithUpdateLockWithUpdateKey(
        ICustomEntryPoint entryPoint,
        long identity,
        IDomainObjectUnitOfWorkLockService lockUpdate,
        byte[]? updateKey = null,
        bool defineCommitVerifying = true)
        : base(entryPoint, identity, lockUpdate, defineCommitVerifying)
    {
        m_updateKey = updateKey;
    }

    public (List<Guid> Keys, DateTimeOffset LastUpdateDateTime)? UpdateKey
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => OptimisticUnitOfWorkCommitVerifyingHelpers.GetKeys(m_updateKey);
    }

    protected override IUnitOfWorkCommitVerifying? DoCreateUnitOfWorkCommitVerifying()
    {
        var expectedUpdateKey = Guid.NewGuid();
        m_updateKey =
            OptimisticUnitOfWorkCommitVerifyingHelpers
                .Append(
                    m_updateKey,
                    expectedUpdateKey,
                    m_entryPoint.TimeService.Now,
                    m_entryPoint.SystemSettings.UpdateKeyExpirationTimeout.Value);
        var result = m_entryPoint.CommitVerifyingFactory.Create(TypeId, Identity, expectedUpdateKey);

        return result;
    }
}
