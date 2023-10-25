using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;

namespace ShtrihM.DemoServer.Processing.Model.Implements.UnitOfWorkLocks;

public sealed class UnitOfWorkLocksAction<TIdentity> where TIdentity : IEquatable<TIdentity>
{
    private readonly IUnitOfWorkLocksHub m_locksHub;
    private readonly Guid m_id;

    public UnitOfWorkLocksAction(IUnitOfWorkLocksHub unitOfWorkLocksHub, Guid id)
        // ReSharper disable once ConvertToPrimaryConstructor
    {
        m_locksHub = unitOfWorkLocksHub ?? throw new ArgumentNullException(nameof(unitOfWorkLocksHub));
        m_id = id;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<bool> TryEnterAsync(TIdentity identity, CancellationToken cancellationToken = default)
    {
        return m_locksHub.TryEnterSimpleAsync(m_id, identity, cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryEnter(TIdentity identity)
    {
        return m_locksHub.TryEnterSimple(m_id, identity);
    }
}