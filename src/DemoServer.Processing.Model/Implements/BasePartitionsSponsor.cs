using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.Model.Implements.SystemSettings;
using Acme.Wattle.Common.Exceptions;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Infrastructures.Monitors;
using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.OpenTelemetry;
using Acme.Wattle.Primitives;
using Acme.Wattle.Services;
using Acme.Wattle.Utils;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Acme.DemoServer.Processing.Model.Implements;

public abstract class BasePartitionsSponsor : BaseServiceScheduled
{
    private static readonly SpanAttributes SpanAttributes;

    public sealed class TablePartitionEntry
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public long Id;

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset CreateDate;

        /// <summary>
        /// Имя таблицы БД
        /// </summary>
        public string TableName;

        /// <summary>
        /// Имя партиции таблицы БД
        /// </summary>
        public string PartitionName;

        /// <summary>
        /// День партиции таблицы БД
        /// </summary>
        public DateTime Day;

        /// <summary>
        /// Минимальный идентификатор группы идентити хранимый в партиции
        /// </summary>
        public long MinGroupId;

        /// <summary>
        /// Максимальный идентификатор группы идентити не хранимый в партиции
        /// </summary>
        public long MaxNotIncludeGroupId;

        /// <summary>
        /// Минимальный идентити хранимый в партиции
        /// </summary>
        public long MinId;

        /// <summary>
        /// Максимальный идентити не хранимый в партиции
        /// </summary>
        public long MaxNotIncludeId;
    }

    private readonly ITimeService m_timeService;
    private readonly IMappers m_mappers;
    private readonly IPartitionsDay m_partitionsDay;
    private readonly Tracer? m_tracer;
    private readonly PartitionsSponsorSettings m_partitionsSponsorSettings;
    private readonly (Guid MapperId, IPartitionsManager Manager)? m_manager;
    private readonly List<(Guid MapperId, IPartitionsManager Manager)> m_managers;
    private long? m_lastDayIndex;
    private readonly Dictionary<Guid, CreatePartitionOptions?> m_createPartitionOptionsMap;

    static BasePartitionsSponsor()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<BasePartitionsSponsor>();
    }

    protected BasePartitionsSponsor(
        ITrigger trigger,
        ILoggerFactory? loggerFactory,
        IExceptionPolicy exceptionPolicy,
        ITimeService timeService,
        IMappers mappers,
        IPartitionsDay partitionsDay,
        Tracer? tracer,
        PartitionsSponsorSettings partitionsSponsorSettings,
        Guid domainObjectTablePartition)
        : base(
            exceptionPolicy,
            DomainObjectRegisterStateless.DefaultInitializeThreadEmergencyTimeout,
            WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
            owner => new InfrastructureMonitorDrivenObject(
                WellknownCommonInfrastructureMonitors.PartitionsSponsor,
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
                timeService,
                owner),
            trigger.GetSmartDisposableReference(true),
            loggerFactory?.CreateLogger<BasePartitionsSponsor>())
    {
        m_timeService = timeService;
        m_mappers = mappers;
        m_partitionsDay = partitionsDay;
        m_tracer = tracer;
        m_partitionsSponsorSettings = partitionsSponsorSettings;
        m_managers = new List<(Guid MapperId, IPartitionsManager Manager)>();
        m_createPartitionOptionsMap = new Dictionary<Guid, CreatePartitionOptions?>();
        foreach (var manager in GetAllPartitionsManagers(mappers))
        {
            if (false == m_createPartitionOptionsMap.TryAdd(manager.Mapper.MapperId, null))
            {
                throw new InternalException($"Маппер '{manager.Mapper.MapperId}' уже определён.");
            }

            if (manager.Mapper.MapperId == domainObjectTablePartition)
            {
                m_manager = (manager.Mapper.MapperId, manager.PartitionsManager);
            }

            m_managers.Add((manager.Mapper.MapperId, manager.PartitionsManager));
        }

        if (m_manager == null)
        {
            throw new InternalException($"Не найден маппер '{domainObjectTablePartition}'.");
        }
        Trigger = trigger;

        CreatePartitionOptions? defaultCreatePartitionOptions = null;
        if (partitionsSponsorSettings.DefaultCreatePartitionOptions.Value.Enabled.Value)
        {
            defaultCreatePartitionOptions = partitionsSponsorSettings.DefaultCreatePartitionOptions.Value.GetOptions();
        }

        if (partitionsSponsorSettings.TablesCreatePartitionOptions.Value.Enabled.Value)
        {
            foreach (var settings in partitionsSponsorSettings.TablesCreatePartitionOptions.Value.Tables.Value)
            {
                if (false == m_createPartitionOptionsMap.ContainsKey(settings.MapperId.Value))
                {
                    throw new InternalException($"Не найден маппер '{settings.MapperId}'.");
                }

                if (settings.UseDefaultCreatePartitionOptions.Value)
                {
                    m_createPartitionOptionsMap[settings.MapperId.Value] = defaultCreatePartitionOptions;
                }

                if (settings.CreatePartitionOptions.Value is { Enabled.Value: true })
                {
                    var createPartitionOptions = partitionsSponsorSettings.DefaultCreatePartitionOptions.Value.GetOptions();
                    m_createPartitionOptionsMap[settings.MapperId.Value] = createPartitionOptions;
                }
            }
        }
    }

    public ITrigger Trigger { get; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<(IMapper Mapper, IPartitionsManager PartitionsManager)> GetAllPartitionsManagers(IMappers mappers)
    {
        if (mappers == null)
        {
            throw new ArgumentNullException(nameof(mappers));
        }

        foreach (var mapper in mappers)
        {
            if (mapper is IPartitionsMapper partitionsMapper)
            {
                yield return (mapper, partitionsMapper.Partitions);
            }
        }
    }

    public void Create()
    {
        var nowDay = m_timeService.Now;
        var nowDayIndex = m_partitionsDay.GetDayIndex(nowDay);

        if (m_lastDayIndex.HasValue)
        {
            if (m_lastDayIndex == nowDayIndex)
            {
                return;
            }
        }

        Debug.Assert(m_manager != null, nameof(m_manager) + " != null");

        DoCreate(nowDay, m_manager.Value, m_tracer);

        foreach (var manager in m_managers)
        {
            DoCreate(nowDay, manager, m_tracer);
        }

        m_lastDayIndex = nowDayIndex;
    }

    protected override bool DoInitialize(CancellationToken cancellationToken, out string? retryReason)
    {
        retryReason = null;

        return true;
    }

    protected override void DoWork(CancellationToken cancellationToken)
    {
        using var mainSpan = m_tracer?.StartActiveSpan(nameof(DoWork), initialAttributes: SpanAttributes, kind: SpanKind.Client);

        try
        {
            Create();
        }
        catch (Exception exception)
        {
            m_exceptionPolicy.Notfy(exception);

            mainSpan?.SetStatus(Status.Error);
            mainSpan?.RecordException(exception);

            if (m_logger?.IsErrorEnabled() == false)
            {
                m_logger.LogError(exception, "Ошибка создания партиций БД.");
            }
        }
    }

    private void DoCreate(
        DateTimeOffset nowDay,
        (Guid MapperId, IPartitionsManager Manager) manager,
        Tracer? tracer)
    {
        using var span = tracer?.StartActiveSpan(nameof(DoCreate) + " " + manager.Manager.TableName, initialAttributes: SpanAttributes);

        var nextDay = nowDay.AddDays(1);
        var nowDayIndex = m_partitionsDay.GetDayIndex(nowDay);
        var nextDayIndex = m_partitionsDay.GetDayIndex(nextDay);
        var nextNextDayIndex = m_partitionsDay.GetDayIndex(nextDay.AddDays(1));
        var nowDayPartitionInfo = manager.Manager.CreatePartitionInfo(nowDayIndex, nextDayIndex);
        var nextDayPartitionInfo = manager.Manager.CreatePartitionInfo(nextDayIndex, nextNextDayIndex);

        using (var session = m_mappers.OpenSession())
        {
            var existsPartitions = manager.Manager.GetExistsPartitions(session);

            if (false == existsPartitions.Any(pi =>
                    (pi.MinGroupId == nowDayPartitionInfo.MinGroupId)
                    && (pi.MaxNotIncludeGroupId == nowDayPartitionInfo.MaxNotIncludeGroupId)))
            {
                string? tablespaceName = null;
                var mapDomainObjectsTablespaceNames =
                    m_partitionsSponsorSettings.DomainObjectsTablespaceNames.Value.DomainObjects
                        .ToDictionary(v => v.DomainObjectType, v => v.Tablespaces.ToDictionary(t => t.Index, t => t.TablespaceName));
                if (mapDomainObjectsTablespaceNames.TryGetValue(manager.MapperId, out var domainObjectTablespaceNames))
                {
                    if (domainObjectTablespaceNames.Count > 0)
                    {
                        var tablespaceNameIndex = (int)(nowDayPartitionInfo.MinGroupId % domainObjectTablespaceNames.Count);
                        if (false == domainObjectTablespaceNames.TryGetValue(tablespaceNameIndex, out tablespaceName))
                        {
                            throw new InternalException($"Для доменного объекта '{manager.MapperId}' не найден частный индекс '{tablespaceNameIndex}'.");
                        }
                    }
                }
                if (tablespaceName == null)
                {
                    if (m_partitionsSponsorSettings.TablespaceNames.Value.Tablespaces.Count > 0)
                    {
                        var tablespaceNameIndex = (int)(nowDayPartitionInfo.MinGroupId % m_partitionsSponsorSettings.TablespaceNames.Value.Tablespaces.Count);
                        var mapTablespaceNames = m_partitionsSponsorSettings.TablespaceNames.Value.Tablespaces.ToDictionary(v => v.Index, v => v.TablespaceName);
                        if (false == mapTablespaceNames.TryGetValue(tablespaceNameIndex, out tablespaceName))
                        {
                            throw new InternalException($"Не найден общий индекс '{tablespaceNameIndex}'.");
                        }
                    }
                }

                var partitionInfo = manager.Manager.CreatePartition(
                    session,
                    nowDayPartitionInfo.MinGroupId,
                    nowDayPartitionInfo.MaxNotIncludeGroupId,
                    GetCreatePartitionOptions(manager.MapperId),
                    tablespaceName);

                var id = ComplexIdentity.Build(manager.Manager.Level, nowDayIndex, GetNextId(session));
                InsertPartitionInfo(
                    session,
                    new TablePartitionEntry
                    {
                        Id = id,
                        Day = m_partitionsDay.GetDay(nowDayIndex).Date,
                        CreateDate = m_timeService.Now,
                        MaxNotIncludeGroupId = nowDayPartitionInfo.MaxNotIncludeGroupId,
                        MaxNotIncludeId = nowDayPartitionInfo.MaxNotIncludeId,
                        MinGroupId = nowDayPartitionInfo.MinGroupId,
                        MinId = nowDayPartitionInfo.MinId,
                        PartitionName = nowDayPartitionInfo.PartitionName,
                        TableName = nowDayPartitionInfo.TableName,
                    });

                m_logger?.LogDebug($"Создана партиция БД '{partitionInfo}'.");
            }

            if (false == existsPartitions.Any(pi =>
                    (pi.MinGroupId == nextDayPartitionInfo.MinGroupId)
                    && (pi.MaxNotIncludeGroupId == nextDayPartitionInfo.MaxNotIncludeGroupId)))
            {
                string? tablespaceName = null;
                var mapDomainObjectsTablespaceNames =
                    m_partitionsSponsorSettings.DomainObjectsTablespaceNames.Value.DomainObjects
                        .ToDictionary(v => v.DomainObjectType, v => v.Tablespaces.ToDictionary(t => t.Index, t => t.TablespaceName));
                if (mapDomainObjectsTablespaceNames.TryGetValue(manager.MapperId, out var domainObjectTablespaceNames))
                {
                    if (domainObjectTablespaceNames.Count > 0)
                    {
                        var tablespaceNameIndex = (int)(nextDayPartitionInfo.MinGroupId % domainObjectTablespaceNames.Count);
                        if (false == domainObjectTablespaceNames.TryGetValue(tablespaceNameIndex, out tablespaceName))
                        {
                            throw new InternalException($"Для доменного объекта '{manager.MapperId}' не найден частный индекс '{tablespaceNameIndex}'.");
                        }
                    }
                }
                if (tablespaceName == null)
                {
                    if (m_partitionsSponsorSettings.TablespaceNames.Value.Tablespaces.Count > 0)
                    {
                        var tablespaceNameIndex = (int)(nextDayPartitionInfo.MinGroupId % m_partitionsSponsorSettings.TablespaceNames.Value.Tablespaces.Count);
                        var mapTablespaceNames = m_partitionsSponsorSettings.TablespaceNames.Value.Tablespaces.ToDictionary(v => v.Index, v => v.TablespaceName);
                        if (false == mapTablespaceNames.TryGetValue(tablespaceNameIndex, out tablespaceName))
                        {
                            throw new InternalException($"Не найден общий индекс '{tablespaceNameIndex}'.");
                        }
                    }
                }

                var partitionInfo = manager.Manager.CreatePartition(
                    session,
                    nextDayPartitionInfo.MinGroupId,
                    nextDayPartitionInfo.MaxNotIncludeGroupId,
                    GetCreatePartitionOptions(manager.MapperId),
                    tablespaceName);

                m_logger?.LogDebug($"Создана партиция БД '{partitionInfo}'.");

                InsertPartitionInfo(
                    session,
                    new TablePartitionEntry
                    {
                        Id = ComplexIdentity.Build(manager.Manager.Level, nowDayIndex, GetNextId(session)),
                        Day = m_partitionsDay.GetDay(nextDayIndex).Date,
                        CreateDate = m_timeService.Now,
                        MaxNotIncludeGroupId = nextDayPartitionInfo.MaxNotIncludeGroupId,
                        MaxNotIncludeId = nextDayPartitionInfo.MaxNotIncludeId,
                        MinGroupId = nextDayPartitionInfo.MinGroupId,
                        MinId = nextDayPartitionInfo.MinId,
                        PartitionName = nextDayPartitionInfo.PartitionName,
                        TableName = nextDayPartitionInfo.TableName,
                    });
            }

            session.Commit();
        }

        using (var session = m_mappers.OpenSession())
        {
            var existsPartitions = manager.Manager.GetExistsPartitions(session);

            if (false == existsPartitions.Any(pi =>
                    (pi.MinGroupId == nowDayPartitionInfo.MinGroupId)
                    && (pi.MaxNotIncludeGroupId == nowDayPartitionInfo.MaxNotIncludeGroupId)))
            {
                throw new InternalException($"Не создана партиция БД '{nowDayPartitionInfo}'.");
            }

            if (false == existsPartitions.Any(pi =>
                    (pi.MinGroupId == nextDayPartitionInfo.MinGroupId)
                    && (pi.MaxNotIncludeGroupId == nextDayPartitionInfo.MaxNotIncludeGroupId)))
            {
                throw new InternalException($"Не создана партиция БД '{nextDayPartitionInfo}'.");
            }
        }
    }

    protected abstract long GetNextId(IMappersSession session);
    protected abstract void InsertPartitionInfo(IMappersSession session, TablePartitionEntry entry);

    protected virtual CreatePartitionOptions? GetCreatePartitionOptions(Guid mapperId)
    {
        if (m_createPartitionOptionsMap.TryGetValue(mapperId, out var result))
        {
            return result;
        }

        throw new InternalException($"Маппер '{mapperId}' не найден.");
    }
}