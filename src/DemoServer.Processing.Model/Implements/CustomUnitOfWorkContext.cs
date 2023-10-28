using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Mappers.Interfaces;
using System;
using System.Runtime.CompilerServices;
using ShtrihM.Wattle3.QueueProcessors.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public sealed class CustomUnitOfWorkContext : UnitOfWorkContext
{
    public CustomUnitOfWorkContext(
        IEntryPoint entryPoint,
        IDomainObjectDataMappers dataMappers,
        IMappers mappers,
        IExceptionPolicy exceptionPolicy,
        WorkflowExceptionPolicy workflowExceptionPolicy,
        ILogger logger,
        bool addStackTrace,
        IUnitOfWorkProvider unitOfWorkProvider,
        IDbContextFactory<ProcessingDbContext> pooledDbContextFactory,
        IServiceProvider serviceProvider,
        IUnitOfWorkLocksHub unitOfWorkLocksHub,
        IQueueItemProcessor queueEmergencyDomainBehaviour,
        IUnitOfWorkCommitVerifyingFactory commitVerifyingFactory)
        : base(
            entryPoint,
            dataMappers,
            mappers,
            exceptionPolicy,
            workflowExceptionPolicy,
            logger,
            addStackTrace,
            unitOfWorkProvider,
            serviceProvider)
    {
        QueueEmergencyDomainBehaviour = queueEmergencyDomainBehaviour ?? throw new ArgumentNullException(nameof(queueEmergencyDomainBehaviour));
        UnitOfWorkLocksHub = unitOfWorkLocksHub ?? throw new ArgumentNullException(nameof(unitOfWorkLocksHub));
        PooledDbContextFactory = pooledDbContextFactory ?? throw new ArgumentNullException(nameof(pooledDbContextFactory));
        CommitVerifyingFactory = commitVerifyingFactory ?? throw new ArgumentNullException(nameof(commitVerifyingFactory));
    }

    public readonly IQueueItemProcessor QueueEmergencyDomainBehaviour;
    public readonly IUnitOfWorkLocksHub UnitOfWorkLocksHub;
    public readonly IDbContextFactory<ProcessingDbContext> PooledDbContextFactory;
    public readonly IUnitOfWorkCommitVerifyingFactory CommitVerifyingFactory;

    public new WorkflowExceptionPolicy WorkflowExceptionPolicy
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (WorkflowExceptionPolicy)base.WorkflowExceptionPolicy;
    }
}