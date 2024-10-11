using Acme.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.DomainObjects.UnitOfWorks;
using System;
using System.Runtime.CompilerServices;
using Acme.DemoServer.Processing.Generated.Interface;

namespace Acme.DemoServer.Processing.Model.Implements;

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
}