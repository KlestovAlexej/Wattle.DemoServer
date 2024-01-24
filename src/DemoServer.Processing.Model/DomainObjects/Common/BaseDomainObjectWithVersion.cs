using System.Runtime.CompilerServices;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.Mappers.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.Common;

/// <summary>
/// Базовая реализация доменного объекта с версией.
/// </summary>
public abstract class BaseDomainObjectWithVersion<TDomainObject> : BaseDomainObject<TDomainObject>
    where TDomainObject : BaseDomainObject<TDomainObject>
{
    [DomainObjectFieldValue]
    protected readonly long m_revision;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectWithVersion(IMapperDtoVersion data)
        : base(data.Id, false)
    {
        m_revision = data.Revision;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectWithVersion(long identity)
        : base(identity, true)
    {
        m_revision = Wattle3.Mappers.Constants.StartRevision;
    }
}