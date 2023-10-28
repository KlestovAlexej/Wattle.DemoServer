using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.ChangeTracker;
using ShtrihM.Wattle3.DomainObjects.DomainBehaviours;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.Wattle3.DomainObjects;
using Microsoft.EntityFrameworkCore;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.Mappers.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public sealed class UnitOfWork : BaseUnitOfWork, IUnitOfWorkDbContextFactory
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public UnitOfWork(
        UnitOfWorkContext unitOfWorkContext,
        Func<ProxyDomainObjectRegisters> registersFactory,
        IUnitOfWorkVisitor visitor)
        : base(
            unitOfWorkContext,
            registersFactory,
            visitor)
    {
    }

    public AbstractUnitOfWorkLocks CurrentLocksGetOrCreate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (AbstractUnitOfWorkLocks)GetLocks();
    }

    protected override async ValueTask<IUnitOfWorkCommitVerifying> DoCreateUnitOfWorkCommitVerifyingAsync(
        CancellationToken cancellationToken = default)
    {
        var register = Registers.GetRegister(WellknownDomainObjects.ChangeTracker);
        var domainObject =
            await register.NewAsync(DomainObjectChangeTracker.Template.Instance, cancellationToken)
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
                    var context = (CustomUnitOfWorkContext)m_context;
                    var existsRaw = context.MapperChangeTracker.ExistsRaw(mappersSession, identity);

                    return (existsRaw
                        ? UnitOfWorkCommitVerifyingResult.Successfully
                        : UnitOfWorkCommitVerifyingResult.Fail);
                },
                async mappersSession =>
                {
                    var context = (CustomUnitOfWorkContext)m_context;
                    var existsRaw = await context.MapperChangeTracker.ExistsRawAsync(mappersSession, identity).ConfigureAwait(false);

                    return (existsRaw
                        ? UnitOfWorkCommitVerifyingResult.Successfully
                        : UnitOfWorkCommitVerifyingResult.Fail);
                });

        return result;
    }

    protected override IUnitOfWorkLocks DoCreateLocks()
    {
        var context = (CustomUnitOfWorkContext)m_context;
        var result =
            new UnitOfWorkLocks.UnitOfWorkLocks(
                context.WorkflowExceptionPolicy,
                context.UnitOfWorkLocksHub);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public async ValueTask<ProcessingDbContext> NewDbContextAsync(
        bool useTransaction = true,
        CancellationToken cancellationToken = default)
    {
        var context = (CustomUnitOfWorkContext)m_context;
        var mappersSession = (IPostgreSqlMappersSession)MappersSession;
        var (connection, transaction) =
            await mappersSession.GetConnectionAsync(useTransaction, cancellationToken)
                .ConfigureAwait(false);
        var result = await context.PooledDbContextFactory.CreateDbContextAsync(cancellationToken).ConfigureAwait(false);
        result.SetDbConnection(connection, transaction);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ProcessingDbContext NewDbContext(bool useTransaction = true)
    {
        var context = (CustomUnitOfWorkContext)m_context;
        var mappersSession = (IPostgreSqlMappersSession)MappersSession;
        var (connection, transaction) = mappersSession.GetConnection(useTransaction);
        var result = context.PooledDbContextFactory.CreateDbContext();
        result.SetDbConnection(connection, transaction);

        return result;
    }

    public IDomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation<TMapper>(long identity)
        where TMapper : IMapper
    {
        var result = CreateDomainBehaviourWithСonfirmation(
            () =>
            {
                var context = (CustomUnitOfWorkContext)m_context;
                var result = DomainObjectsHelpers.CreateUnitOfWorkCommitVerifyingDelegate<TMapper>(identity, context.Mappers);

                return result;
            });

        return result;
    }

    public IDomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation()
    {
        var result = DoCreateDomainBehaviourWithСonfirmation();

        return result;
    }

    async ValueTask<DbContext> IUnitOfWorkDbContextFactory.NewDbContextAsync(bool useTransaction, CancellationToken cancellationToken)
    {
        var result = await NewDbContextAsync(useTransaction, cancellationToken).ConfigureAwait(false);

        return result;
    }

    DbContext IUnitOfWorkDbContextFactory.NewDbContext(bool useTransaction)
    {
        var result = NewDbContext(useTransaction);

        return result;
    }

    protected override IDomainBehaviourWithСonfirmation DoCreateDomainBehaviourWithСonfirmation()
    {
        var context = (CustomUnitOfWorkContext)m_context;
        var result =
            new DomainBehaviourWithСonfirmation(
                m_context.ExceptionPolicy,
                m_context.Mappers,
                context.QueueEmergencyDomainBehaviour,
                CommitVerifying);

        return result;
    }
}