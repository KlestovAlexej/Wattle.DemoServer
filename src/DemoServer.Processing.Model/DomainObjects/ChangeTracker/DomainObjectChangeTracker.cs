using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;
using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Generated.Interface;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.ChangeTracker;

[DomainObjectDataMapper(WellknownMappersAsText.ChangeTracker, DomainObjectDataTarget.Create)]
public sealed class DomainObjectChangeTracker : BaseDomainObject<DomainObjectChangeTracker>, IDomainObjectChangeTracker
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DomainObjectChangeTracker(ChangeTrackerDtoActual data)
        : base(data.Id, false)
    {
        /* NONE */
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DomainObjectChangeTracker(long identity)
        : base(identity, true)
    {
        /* NONE */
    }

    public override Guid TypeId => WellknownDomainObjects.ChangeTracker;
}