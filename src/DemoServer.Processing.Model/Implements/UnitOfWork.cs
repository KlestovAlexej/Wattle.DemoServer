using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using System;
using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.Common.Exceptions;
using System.Threading.Tasks;
using System.Threading;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public sealed class UnitOfWork : UnitOfWorkFull<ProcessingDbContext, IMapperChangeTracker>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    public UnitOfWork(
        UnitOfWorkFullContext<ProcessingDbContext, IMapperChangeTracker> unitOfWorkContext,
        Func<ProxyDomainObjectRegisters> registersFactory,
        IUnitOfWorkVisitor visitor)
        : base(
            unitOfWorkContext,
            registersFactory,
            visitor)
    {
    }

#if DEBUG
    /// <summary>
    /// Полезная проверка, что не используется стратегия IUnitOfWorkCommitVerifying по умолчанию.
    /// Так как стратегия IUnitOfWorkCommitVerifying по умолчанию создаёт техническую запись в БД.
    /// </summary>
    public static bool ThrowOnDefaultCommitVerifying = true;

    protected override IUnitOfWorkCommitVerifying DoCreateUnitOfWorkCommitVerifying()
    {
        // Полезная проверка, что не используется стратегия IUnitOfWorkCommitVerifying по умолчанию.
        // Так как стратегия IUnitOfWorkCommitVerifying по умолчанию создаёт техническую запись в БД.
        if (ThrowOnDefaultCommitVerifying)
        {
            WattleThrowsHelper.ThrowInternalException("Стратегия проверки успешности завершения IUnitOfWork не определена.");
        }

        return base.DoCreateUnitOfWorkCommitVerifying();
    }

    protected override ValueTask<IUnitOfWorkCommitVerifying> DoCreateUnitOfWorkCommitVerifyingAsync(CancellationToken cancellationToken = default)
    {
        // Полезная проверка, что не используется стратегия IUnitOfWorkCommitVerifying по умолчанию.
        // Так как стратегия IUnitOfWorkCommitVerifying по умолчанию создаёт техническую запись в БД.
        if (ThrowOnDefaultCommitVerifying)
        {
            WattleThrowsHelper.ThrowInternalException("Стратегия проверки успешности завершения IUnitOfWork не определена.");
        }

        return base.DoCreateUnitOfWorkCommitVerifyingAsync(cancellationToken);
    }
#endif
}