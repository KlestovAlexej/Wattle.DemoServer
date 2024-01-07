using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
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
        IDomainObjectUnitOfWorkLockService lockUpdate,
        bool defineCommitVerifying = true)
        : base(entryPoint, data, defineCommitVerifying)
    {
        m_lockUpdate = lockUpdate;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectMutableWithUpdateLock(
        ICustomEntryPoint entryPoint,
        long identity,
        IDomainObjectUnitOfWorkLockService lockUpdate,
        bool defineCommitVerifying = true)
        : base(entryPoint, identity, defineCommitVerifying)
    {
        m_lockUpdate = lockUpdate;
    }

    protected override async ValueTask DoUpdateAsync(CancellationToken cancellationToken = default)
    {
        m_lockUpdate.Has(Identity);

        await base.DoUpdateAsync(cancellationToken).ConfigureAwait(false);
    }
}