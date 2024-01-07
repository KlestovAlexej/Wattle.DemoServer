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
public abstract class BaseDomainObjectMutable<TDomainObject> : BaseDomainObjectWithVersion<TDomainObject>, IDomainObjectVersion
    where TDomainObject : BaseDomainObject<TDomainObject>
{
    private bool m_isChanged;
    private readonly bool m_defineCommitVerifying;

    protected readonly ICustomEntryPoint m_entryPoint;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectMutable(
        ICustomEntryPoint entryPoint,
        IMapperDtoVersion data,
        bool defineCommitVerifying = true)
        : base(data)
    {
        m_entryPoint = entryPoint;
        m_defineCommitVerifying = defineCommitVerifying;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDomainObjectMutable(
        ICustomEntryPoint entryPoint,
        long identity,
        bool defineCommitVerifying = true)
        : base(identity)
    {
        m_entryPoint = entryPoint;
        m_defineCommitVerifying = false;

        if (defineCommitVerifying)
        {
            var unitOfWork = m_entryPoint.UnitOfWorkProvider.Instance;

            if (unitOfWork.IsDefinedCommitVerifying)
            {
                return;
            }

            // Если маппер доменного объекта поддерживает удаление то создание стратегии IUnitOfWorkCommitVerifying по Identity не безопасно.
            // Будет использоватся стратегия IUnitOfWorkCommitVerifying по умолчанию.
            // ReSharper disable once VirtualMemberCallInConstructor
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

    /// <summary>
    /// Версия данных (инкрементальное значение от 1), чем больше значение тем актуальнее данные.
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

            return (m_revision + 1);
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

        if (m_defineCommitVerifying)
        {
            var unitOfWork = m_entryPoint.CurrentUnitOfWork;
            if (unitOfWork.IsDefinedCommitVerifying)
            {
                return ValueTask.CompletedTask;
            }

            var commitVerifying = DoCreateUnitOfWorkCommitVerifying();
            if (commitVerifying != null)
            {
                unitOfWork.CommitVerifying = commitVerifying;
            }
        }

        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Создание специализированной стратегии <see cref="IUnitOfWorkCommitVerifying"/> проверки успешности завершения <see cref="IUnitOfWork" />.
    /// </summary>
    protected virtual IUnitOfWorkCommitVerifying? DoCreateUnitOfWorkCommitVerifying()
    {
        // Если маппер доменного объекта поддерживает удаление то создание стратегии IUnitOfWorkCommitVerifying по Identity не безопасно.
        if (m_entryPoint.CommitVerifyingFactory.TryCreate(TypeId, Identity, out var result))
        {
            return (result);
        }

        return (null);
    }
}