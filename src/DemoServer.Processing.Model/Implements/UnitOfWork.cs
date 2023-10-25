using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.ChangeTracker;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainBehaviours;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public sealed class UnitOfWork(
        UnitOfWorkContext unitOfWorkContext,
        Func<ProxyDomainObjectRegisters> registersFactory,
        IUnitOfWorkVisitor visitor)
    : BaseUnitOfWork(
        unitOfWorkContext,
        registersFactory,
        visitor), IUnitOfWorkDbContextFactory
{
    public UnitOfWorkLocks.UnitOfWorkLocks CurrentLocks
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (UnitOfWorkLocks.UnitOfWorkLocks)GetLocks();
    }

    protected override async ValueTask<IUnitOfWorkCommitVerifying> DoCreateUnitOfWorkCommitVerifyingAsync(
        CancellationToken cancellationToken = default)
    {
        var register = Registers.GetRegister(WellknownDomainObjects.ChangeTracker);
        var domainObject = await register.NewAsync(DomainObjectChangeTracker.Template.Instance, cancellationToken)
            .ConfigureAwait(false);
        var result = DoCreateUnitOfWorkCommitVerifying(domainObject.Identity);

        return result;
    }

    protected override IUnitOfWorkCommitVerifying DoCreateUnitOfWorkCommitVerifying()
    {
        var register = Registers.GetRegister(WellknownDomainObjects.ChangeTracker);
        var identity = register.New(DomainObjectChangeTracker.Template.Instance).Identity;
        var result = DoCreateUnitOfWorkCommitVerifying(identity);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private IUnitOfWorkCommitVerifying DoCreateUnitOfWorkCommitVerifying(long identity)
    {
        var result =
            new UnitOfWorkCommitVerifyingDelegate(
                mappersSession =>
                {
                    var entryPoint = (ICustomEntryPoint)m_context.EntryPoint;
                    var mapper = entryPoint.Mappers.GetMapper<IMapperChangeTracker>();
                    var existsRaw = mapper.ExistsRaw(mappersSession, identity);

                    return (existsRaw
                        ? UnitOfWorkCommitVerifyingResult.Successfully
                        : UnitOfWorkCommitVerifyingResult.Fail);
                },
                async mappersSession =>
                {
                    var entryPoint = (ICustomEntryPoint)m_context.EntryPoint;
                    var mapper = entryPoint.Mappers.GetMapper<IMapperChangeTracker>();
                    var existsRaw = await mapper.ExistsRawAsync(mappersSession, identity).ConfigureAwait(false);

                    return (existsRaw
                        ? UnitOfWorkCommitVerifyingResult.Successfully
                        : UnitOfWorkCommitVerifyingResult.Fail);
                });

        return result;
    }

    protected override IUnitOfWorkLocks DoCreateLocks()
        => new UnitOfWorkLocks.UnitOfWorkLocks(
            ((ICustomEntryPoint)m_context.EntryPoint).WorkflowExceptionPolicy,
            ((CustomUnitOfWorkContext)m_context).UnitOfWorkLocksHub);

    public async ValueTask<ProcessingDbContext> NewDbContextAsync(
        bool useTransaction = true,
        CancellationToken cancellationToken = default)
    {
        var context = (CustomUnitOfWorkContext)m_context;
        var mappersSession = (IPostgreSqlMappersSession)MappersSession;
        var (connection, transaction) = await mappersSession.GetConnectionAsync(useTransaction, cancellationToken)
            .ConfigureAwait(false);
        var result = await context.PooledDbContextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false);
        result.SetDbConnection(connection, transaction);

        return result;
    }

    public ProcessingDbContext NewDbContext(bool useTransaction = true)
    {
        var context = (CustomUnitOfWorkContext)m_context;
        var mappersSession = (IPostgreSqlMappersSession)MappersSession;
        var (connection, transaction) = mappersSession.GetConnection(useTransaction);
        var result = context.PooledDbContextFactory.CreateDbContext();
        result.SetDbConnection(connection, transaction);

        return result;
    }

    async ValueTask<DbContext> IUnitOfWorkDbContextFactory.NewDbContextAsync(bool useTransaction, CancellationToken cancellationToken)
    {
        var context = (CustomUnitOfWorkContext)m_context;
        var mappersSession = (IPostgreSqlMappersSession)MappersSession;
        var (connection, transaction) = await mappersSession.GetConnectionAsync(useTransaction, cancellationToken)
            .ConfigureAwait(false);
        var result = await context.PooledDbContextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false);
        result.SetDbConnection(connection, transaction);

        return result;
    }

    DbContext IUnitOfWorkDbContextFactory.NewDbContext(bool useTransaction)
    {
        var context = (CustomUnitOfWorkContext)m_context;
        var mappersSession = (IPostgreSqlMappersSession)MappersSession;
        var (connection, transaction) = mappersSession.GetConnection(useTransaction);
        var result = context.PooledDbContextFactory.CreateDbContext();
        result.SetDbConnection(connection, transaction);

        return result;
    }
}