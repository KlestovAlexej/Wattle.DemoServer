using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.ChangeTracker;
using ShtrihM.Wattle3.DomainObjects.DomainBehaviours;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.Wattle3.DomainObjects;
using Microsoft.EntityFrameworkCore;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.DemoServer.Processing.Generated.Interface;

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
        var identity =
            (await register.NewAsync(DomainObjectChangeTracker.Template.Instance, cancellationToken)
                .ConfigureAwait(false)).Identity;
        var context = (CustomUnitOfWorkContext)m_context;
        var result = context.CommitVerifyingFactory.Create<IMapperChangeTracker>(identity);

        return result;
    }

    protected override IUnitOfWorkCommitVerifying DoCreateUnitOfWorkCommitVerifying()
    {
        var register = Registers.GetRegister(WellknownDomainObjects.ChangeTracker);
        var identity = register.New(DomainObjectChangeTracker.Template.Instance).Identity;
        var context = (CustomUnitOfWorkContext)m_context;
        var result = context.CommitVerifyingFactory.Create<IMapperChangeTracker>(identity);

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
        var mappersSession = (IDbMappersSession)MappersSession;
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
        var mappersSession = (IDbMappersSession)MappersSession;
        var (connection, transaction) = mappersSession.GetConnection(useTransaction);
        var result = context.PooledDbContextFactory.CreateDbContext();
        result.SetDbConnection(connection, transaction);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IDomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation<TMapper>(long identity)
        where TMapper : IMapper
    {
        if (false == IsDefinedCommitVerifying)
        {
            var context = (CustomUnitOfWorkContext)m_context;
            CommitVerifying = context.CommitVerifyingFactory.Create<TMapper>(identity);
        }

        return DoCreateDomainBehaviourWithСonfirmation();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IDomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation()
    {
        var result = DoCreateDomainBehaviourWithСonfirmation();

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    async ValueTask<DbContext> IUnitOfWorkDbContextFactory.NewDbContextAsync(bool useTransaction, CancellationToken cancellationToken)
    {
        var result = await NewDbContextAsync(useTransaction, cancellationToken).ConfigureAwait(false);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    DbContext IUnitOfWorkDbContextFactory.NewDbContext(bool useTransaction)
    {
        var result = NewDbContext(useTransaction);

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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