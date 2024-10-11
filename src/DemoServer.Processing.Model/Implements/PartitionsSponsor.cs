using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.Common.Exceptions;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.OpenTelemetry;
using Acme.Wattle.Primitives;
using Acme.Wattle.Services;
using Acme.Wattle.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Acme.DemoServer.Processing.Generated.Interface;
using Acme.Wattle.Infrastructures.Monitors;
using ITrigger = Acme.Wattle.DomainObjects.Interfaces.ITrigger;
using Status = OpenTelemetry.Trace.Status;
using Acme.Wattle.DomainObjects.DomainObjectsRegisters;

namespace Acme.DemoServer.Processing.Model.Implements;

public class PartitionsSponsor : BaseServiceScheduled
{
    private static readonly SpanAttributes SpanAttributes;

    private readonly (Guid Id, IPartitionsManager Manager)? m_manager;
    private readonly List<(Guid Id, IPartitionsManager Manager)> m_managers;
    private readonly ICustomEntryPoint m_entryPoint;
    private readonly IMapperTablePartition m_mapperTablePartition;
    private long? m_lastDayIndex;

    static PartitionsSponsor()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<PartitionsSponsor>();
    }

    public PartitionsSponsor(
        ICustomEntryPoint entryPoint,
        ITrigger trigger,
        ILoggerFactory? loggerFactory)
        : base(
            entryPoint.ExceptionPolicy,
            DomainObjectRegisterStateless.DefaultInitializeThreadEmergencyTimeout,
            WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
            owner => new InfrastructureMonitorDrivenObject(
                WellknownCommonInfrastructureMonitors.PartitionsSponsor,
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
                entryPoint.TimeService,
                owner),
            trigger.GetSmartDisposableReference(true),
            loggerFactory?.CreateLogger<PartitionsSponsor>())
    {
        m_entryPoint = entryPoint;
        m_managers = new List<(Guid Id, IPartitionsManager Manager)>();
        foreach (var manager in GetAllPartitionsManagers(m_entryPoint.Mappers))
        {
            if (manager.Mapper.MapperId == WellknownMappers.TablePartition)
            {
                m_manager = (manager.Mapper.MapperId, manager.PartitionsManager);
            }

            m_managers.Add((manager.Mapper.MapperId, manager.PartitionsManager));
        }

        if (m_manager == null)
        {
            throw new InternalException($"Не найден маппер '{WellknownMappers.TablePartition}'.");
        }

        m_mapperTablePartition = m_entryPoint.Mappers.GetMapper<IMapperTablePartition>();
    }

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

    public void Create(Tracer? tracer)
    {
        var nowDay = m_entryPoint.TimeService.Now;
        var nowDayIndex = m_entryPoint.PartitionsDay.GetDayIndex(nowDay);

        if (m_lastDayIndex.HasValue)
        {
            if (m_lastDayIndex == nowDayIndex)
            {
                return;
            }
        }

        Debug.Assert(m_manager != null, nameof(m_manager) + " != null");

        DoCreate(nowDay, m_manager.Value, tracer);

        foreach (var manager in m_managers)
        {
            DoCreate(nowDay, manager, tracer);
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
        var tracer = m_entryPoint.Tracer;
        using var mainSpan = tracer?.StartActiveSpan(nameof(DoWork), initialAttributes: SpanAttributes, kind: SpanKind.Internal);

        try
        {
            Create(tracer);
        }
        catch (Exception exception)
        {
            m_entryPoint.ExceptionPolicy.Notfy(exception);

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
        (Guid Id, IPartitionsManager Manager) manager,
        Tracer? tracer)
    {
        using var span = tracer?.StartActiveSpan(nameof(DoCreate) + " " + manager.Manager.TableName, initialAttributes: SpanAttributes);

        var nextDay = nowDay.AddDays(1);
        var nowDayIndex = m_entryPoint.PartitionsDay.GetDayIndex(nowDay);
        var nextDayIndex = m_entryPoint.PartitionsDay.GetDayIndex(nextDay);
        var nextNextDayIndex = m_entryPoint.PartitionsDay.GetDayIndex(nextDay.AddDays(1));
        var nowDayPartitionInfo = manager.Manager.CreatePartitionInfo(nowDayIndex, nextDayIndex);
        var nextDayPartitionInfo = manager.Manager.CreatePartitionInfo(nextDayIndex, nextNextDayIndex);

        using (var session = m_entryPoint.Mappers.OpenSession())
        {
            var existsPartitions = manager.Manager.GetExistsPartitions(session);

            if (false == existsPartitions.Any(pi =>
                    (pi.MinGroupId == nowDayPartitionInfo.MinGroupId)
                    && (pi.MaxNotIncludeGroupId == nowDayPartitionInfo.MaxNotIncludeGroupId)))
            {
                string? tablespaceName = null;
                var mapDomainObjectsTablespaceNames =
                    m_entryPoint.SystemSettings.PartitionsSponsorSettings.Value.DomainObjectsTablespaceNames.Value.DomainObjects
                        .ToDictionary(v => v.DomainObjectType, v => v.Tablespaces.ToDictionary(t => t.Index, t => t.TablespaceName));
                if (mapDomainObjectsTablespaceNames.TryGetValue(manager.Id, out var domainObjectTablespaceNames))
                {
                    if (domainObjectTablespaceNames.Count > 0)
                    {
                        var tablespaceNameIndex = (int)(nowDayPartitionInfo.MinGroupId % domainObjectTablespaceNames.Count);
                        if (false == domainObjectTablespaceNames.TryGetValue(tablespaceNameIndex, out tablespaceName))
                        {
                            throw new InternalException($"Для доменного объекта '{manager.Id}' не найден частный индекс '{tablespaceNameIndex}'.");
                        }
                    }
                }
                if (tablespaceName == null)
                {
                    if (m_entryPoint.SystemSettings.PartitionsSponsorSettings.Value.TablespaceNames.Value.Tablespaces.Count > 0)
                    {
                        var tablespaceNameIndex = (int)(nowDayPartitionInfo.MinGroupId % m_entryPoint.SystemSettings.PartitionsSponsorSettings.Value.TablespaceNames.Value.Tablespaces.Count);
                        var mapTablespaceNames = m_entryPoint.SystemSettings.PartitionsSponsorSettings.Value.TablespaceNames.Value.Tablespaces.ToDictionary(v => v.Index, v => v.TablespaceName);
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
                    tablespaceName);

                var id = ComplexIdentity.Build(manager.Manager.Level, nowDayIndex, m_mapperTablePartition.GetNextId(session));
                m_mapperTablePartition.New(
                    session,
                    new TablePartitionDtoNew
                    {
                        Id = id,
                        Day = m_entryPoint.PartitionsDay.GetDay(nowDayIndex).Date,
                        CreateDate = m_entryPoint.TimeService.Now,
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
                    m_entryPoint.SystemSettings.PartitionsSponsorSettings.Value.DomainObjectsTablespaceNames.Value.DomainObjects
                        .ToDictionary(v => v.DomainObjectType, v => v.Tablespaces.ToDictionary(t => t.Index, t => t.TablespaceName));
                if (mapDomainObjectsTablespaceNames.TryGetValue(manager.Id, out var domainObjectTablespaceNames))
                {
                    if (domainObjectTablespaceNames.Count > 0)
                    {
                        var tablespaceNameIndex = (int)(nextDayPartitionInfo.MinGroupId % domainObjectTablespaceNames.Count);
                        if (false == domainObjectTablespaceNames.TryGetValue(tablespaceNameIndex, out tablespaceName))
                        {
                            throw new InternalException($"Для доменного объекта '{manager.Id}' не найден частный индекс '{tablespaceNameIndex}'.");
                        }
                    }
                }
                if (tablespaceName == null)
                {
                    if (m_entryPoint.SystemSettings.PartitionsSponsorSettings.Value.TablespaceNames.Value.Tablespaces.Count > 0)
                    {
                        var tablespaceNameIndex = (int)(nextDayPartitionInfo.MinGroupId % m_entryPoint.SystemSettings.PartitionsSponsorSettings.Value.TablespaceNames.Value.Tablespaces.Count);
                        var mapTablespaceNames = m_entryPoint.SystemSettings.PartitionsSponsorSettings.Value.TablespaceNames.Value.Tablespaces.ToDictionary(v => v.Index, v => v.TablespaceName);
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
                    tablespaceName);

                m_logger?.LogDebug($"Создана партиция БД '{partitionInfo}'.");

                m_mapperTablePartition.New(
                    session,
                    new TablePartitionDtoNew
                    {
                        Id = ComplexIdentity.Build(manager.Manager.Level, nowDayIndex, m_mapperTablePartition.GetNextId(session)),
                        Day = m_entryPoint.PartitionsDay.GetDay(nextDayIndex).Date,
                        CreateDate = m_entryPoint.TimeService.Now,
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

        using (var session = m_entryPoint.Mappers.OpenSession())
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
}