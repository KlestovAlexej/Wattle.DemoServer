using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using System;
using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Generated.Interface;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public sealed class UnitOfWork : UnitOfWorkFull<ProcessingDbContext, IMapperChangeTracker>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
}