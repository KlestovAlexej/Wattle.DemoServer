using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.Common;

/// <summary>
/// Базовая реализация доменного объекта с поддержкой изменения.
/// </summary>
public abstract class BaseDomainObjectMutable<TDomainObject> : BaseDomainObject<TDomainObject>
    where TDomainObject : BaseDomainObject<TDomainObject>
{
    private bool m_isChanged;

    [DomainObjectFieldValue(DomainObjectDataTarget.Update, DomainObjectDataTarget.Delete, DomainObjectDataTarget.Version, DtoFiledName = nameof(IMapperDtoVersion.Revision))]
    // ReSharper disable once NotAccessedField.Local
#pragma warning disable IDE0052
    private readonly long m_revision;
#pragma warning restore IDE0052

    protected readonly ICustomEntryPoint m_entryPoint;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectMutable(
        ICustomEntryPoint entryPoint, 
        IMapperDtoVersion data)
        : base(data.Id, false)
    {
        m_entryPoint = entryPoint;
        m_revision = data.Revision;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectMutable(
        ICustomEntryPoint entryPoint, 
        long identity,
        bool defineCommitVerifying = false)
        : base(identity, true)
    {
        m_entryPoint = entryPoint;
        m_revision = Wattle3.Mappers.Constants.StartRevision;

        if (defineCommitVerifying)
        {
            DefineCommitVerifying();
        }
    }

    /// <summary>
    /// Фиксация в <see cref="IUnitOfWork"/> изменений доменного объекта.
    /// </summary>
    // ReSharper disable once UnusedParameter.Global
    protected virtual ValueTask DoUpdateAsync(CancellationToken cancellationToken = default)
    {
        if (IsGhost || m_isChanged)
        {
            return ValueTask.CompletedTask;
        }

        m_isChanged = true;

        m_entryPoint.UnitOfWorkProvider.Instance.AddUpdate(this);

        return ValueTask.CompletedTask;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once MemberCanBePrivate.Global
    protected void DefineCommitVerifying()
    {
        var unitOfWork = m_entryPoint.UnitOfWorkProvider.Instance;

        if (unitOfWork.IsDefinedCommitVerifying)
        {
            return;
        }

        // Если маппер доменного объекта поддерживает удаление то создание стратегии IUnitOfWorkCommitVerifying по Identity не безопасно.
        // Будет использоватся стратегия IUnitOfWorkCommitVerifying по умолчанию.
        if (m_entryPoint.CommitVerifyingFactory.TryCreate(TypeId, Identity, out var commitVerifying))
        {
            unitOfWork.CommitVerifying = commitVerifying!;

            return;
        }

        // Вызов CommitVerifying создаёт стратегию IUnitOfWorkCommitVerifying по умолчанию.
        if (null == unitOfWork.CommitVerifying)
        {
            throw new InvalidOperationException("Это невозможно!");
        }
    }
}
