using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorkLocks;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Mappers.Interfaces;
using System;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public sealed class CustomUnitOfWorkContext(
        IEntryPoint entryPoint,
        IDomainObjectDataMappers dataMappers,
        IMappers mappers,
        IExceptionPolicy exceptionPolicy,
        IWorkflowExceptionPolicy workflowExceptionPolicy,
        ILogger logger,
        bool addStackTrace,
        IUnitOfWorkProvider unitOfWorkProvider,
        IDbContextFactory<ProcessingDbContext> pooledDbContextFactory,
        IServiceProvider serviceProvider,
        IUnitOfWorkLocksHub unitOfWorkLocksHub)
    : UnitOfWorkContext(
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
    public readonly IUnitOfWorkLocksHub UnitOfWorkLocksHub =
        unitOfWorkLocksHub ?? throw new ArgumentNullException(nameof(unitOfWorkLocksHub));

    public readonly IDbContextFactory<ProcessingDbContext> PooledDbContextFactory =
        pooledDbContextFactory ?? throw new ArgumentNullException(nameof(pooledDbContextFactory));
}