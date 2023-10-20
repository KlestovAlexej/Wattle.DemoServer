using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects;

/// <summary>
/// Базовая реализация доменного объекта с поддержкой изменения.
/// </summary>
public abstract class DomainObjectMutable<TDomainObject> : BaseDomainObject<TDomainObject>
    where TDomainObject : BaseDomainObject<TDomainObject>
{
    private bool m_isChanged;

    [DomainObjectFieldValue(DomainObjectDataTarget.Update, DomainObjectDataTarget.Delete, DomainObjectDataTarget.Version, DtoFiledName = nameof(IMapperDtoVersion.Revision))]
    private readonly long m_revision;

    protected readonly ICustomEntryPoint m_entryPoint;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected DomainObjectMutable(ICustomEntryPoint entryPoint, IMapperDtoVersion data)
        : base(data.Id, false)
    {
        m_entryPoint = entryPoint;
        m_revision = data.Revision;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected DomainObjectMutable(ICustomEntryPoint entryPoint, long identity)
        : base(identity, true)
    {
        m_entryPoint = entryPoint;
        m_revision = Wattle3.Mappers.Constants.StartRevision;
    }

    /// <summary>
    /// Версия состояния доменного объекта.
    /// </summary>
    public long Version
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (IsGhost || (false == m_isChanged))
            {
                return m_revision;
            }

            return m_revision + 1;
        }
    }

    /// <summary>
    /// Фиксация в <see cref="IUnitOfWork"/> изменений доменного объекта.
    /// </summary>
    protected virtual void DoUpdate()
    {
        if (IsGhost || m_isChanged)
        {
            return;
        }

        m_isChanged = true;

        m_entryPoint.UnitOfWorkProvider.Instance.AddUpdate(this);
    }
}
