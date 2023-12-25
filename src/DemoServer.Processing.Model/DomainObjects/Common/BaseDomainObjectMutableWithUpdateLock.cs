using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.Mappers.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.Common;

/// <summary>
/// Базовая реализация доменного объекта с поддержкой изменения и блокировкой на изменение.
/// </summary>
public abstract class BaseDomainObjectMutableWithUpdateLock<TDomainObject> : BaseDomainObjectMutable<TDomainObject>
    where TDomainObject : BaseDomainObject<TDomainObject>
{
    protected readonly IDomainObjectUnitOfWorkLockService m_lockUpdate;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectMutableWithUpdateLock(
        ICustomEntryPoint entryPoint, 
        IMapperDtoVersion data,
        IDomainObjectUnitOfWorkLockService lockUpdate)
        : base(entryPoint, data)
    {
        m_lockUpdate = lockUpdate;
        // ReSharper disable once VirtualMemberCallInConstructor
        Debug.Assert(m_lockUpdate.TypeId == TypeId, $"{nameof(m_lockUpdate)}.{nameof(m_lockUpdate.TypeId)} == {nameof(TypeId)}");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectMutableWithUpdateLock(
        ICustomEntryPoint entryPoint, 
        long identity,
        IDomainObjectUnitOfWorkLockService lockUpdate,
        bool defineCommitVerifying = false)
        : base(entryPoint, identity, defineCommitVerifying)
    {
        m_lockUpdate = lockUpdate;
        // ReSharper disable once VirtualMemberCallInConstructor
        Debug.Assert(m_lockUpdate.TypeId == TypeId, $"{nameof(m_lockUpdate)}.{nameof(m_lockUpdate.TypeId)} == {nameof(TypeId)}");
    }

    protected override async ValueTask DoUpdateAsync(CancellationToken cancellationToken = default)
    {
        if (false == IsGhost)
        {
            m_lockUpdate.Has(Identity);

            var unitOfWork = m_entryPoint.CurrentUnitOfWork;
            if (false == unitOfWork.IsDefinedCommitVerifying)
            {
                var commitVerifying = await DoCreateIUnitOfWorkCommitVerifyingAsync(cancellationToken).ConfigureAwait(false);
                if (commitVerifying != null)
                {
                    unitOfWork.CommitVerifying = commitVerifying;
                }
            }
        }

        await base.DoUpdateAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Создание специализированной стратегии <see cref="IUnitOfWorkCommitVerifying"/> проверки успешности завершения <see cref="IUnitOfWork" />.
    /// </summary>
    // ReSharper disable once VirtualMemberNeverOverridden.Global
    // ReSharper disable once UnusedParameter.Global
    protected virtual ValueTask<IUnitOfWorkCommitVerifying?> DoCreateIUnitOfWorkCommitVerifyingAsync(CancellationToken cancellationToken = default)
    {
        // Если маппер доменного объекта поддерживает удаление то создание стратегии IUnitOfWorkCommitVerifying по Identity не безопасно.
        if (m_entryPoint.CommitVerifyingFactory.TryCreate(TypeId, Identity, out var result))
        {
            return ValueTask.FromResult(result);
        }

        return ValueTask.FromResult<IUnitOfWorkCommitVerifying?>(null);
    }
}
