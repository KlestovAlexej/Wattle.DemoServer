using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.OpenTelemetry;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Services;
using ShtrihM.Wattle3.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ITrigger = ShtrihM.Wattle3.DomainObjects.Interfaces.ITrigger;
using Status = OpenTelemetry.Trace.Status;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public class PartitionsSponsor : BaseServiceScheduled
{
    private static readonly SpanAttributes SpanAttributes;

    private readonly (Guid Id, IPartitionsManager Manager)? m_manager;
    private readonly List<(Guid Id, IPartitionsManager Manager)> m_managers;
    private readonly ICustomEntryPoint m_entryPoint;
    private readonly IMapperTablePartition m_mapperTablePartition;
    private DateTime? m_lastDay;

    static PartitionsSponsor()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<PartitionsSponsor>();
    }

    public PartitionsSponsor(
        ICustomEntryPoint entryPoint,
        ITrigger trigger,
        ILoggerFactory loggerFactory)
        : base(
            entryPoint.ExceptionPolicy,
            DomainObjectRegisterStateless.DefaultInitializeThreadEmergencyTimeout,
            WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
            owner => new(
                WellknownCommonInfrastructureMonitors.PartitionsSponsor,
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
                entryPoint.TimeService,
                owner),
            trigger.GetSmartDisposableReference(true),
            loggerFactory.CreateLogger<PartitionsSponsor>())
    {
        m_entryPoint = entryPoint;
        m_managers = new();
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
        var nowDay = m_entryPoint.TimeService.Now.Date;

        if (m_lastDay.HasValue)
        {
            if (m_lastDay == nowDay)
            {
                return;
            }
        }

        Debug.Assert(m_manager != null, nameof(m_manager) + " != null");

        DoCreate(nowDay, m_manager!.Value, tracer);

        foreach (var manager in m_managers)
        {
            DoCreate(nowDay, manager, tracer);
        }

        m_lastDay = nowDay;
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

            if (m_logger.IsErrorEnabled())
            {
                m_logger.LogError(exception, "Ошибка создания партиций БД.");
            }
        }
    }

    private void DoCreate(
        DateTime nowDay,
        (Guid Id, IPartitionsManager Manager) manager,
        Tracer? tracer)
    {
        using var span = tracer?.StartActiveSpan(nameof(DoCreate) + " " + manager.Manager.TableName, initialAttributes: SpanAttributes);

        var nextDay = nowDay.AddDays(1);
        var nowDayPartitionInfo = manager.Manager.CreatePartitionInfo(m_entryPoint.PartitionsDay.GetDayIndex(nowDay), m_entryPoint.PartitionsDay.GetDayIndex(nextDay));
        var nextDayPartitionInfo = manager.Manager.CreatePartitionInfo(m_entryPoint.PartitionsDay.GetDayIndex(nextDay), m_entryPoint.PartitionsDay.GetDayIndex(nextDay.AddDays(1)));

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

                var id = ComplexIdentity.Build(manager.Manager.Level, m_entryPoint.PartitionsDay.GetDayIndex(nowDay), m_mapperTablePartition.GetNextId(session));
                m_mapperTablePartition.New(
                    session,
                    new()
                    {
                        Id = id,
                        Day = nowDay,
                        CreateDate = m_entryPoint.TimeService.Now,
                        MaxNotIncludeGroupId = nowDayPartitionInfo.MaxNotIncludeGroupId,
                        MaxNotIncludeId = nowDayPartitionInfo.MaxNotIncludeId,
                        MinGroupId = nowDayPartitionInfo.MinGroupId,
                        MinId = nowDayPartitionInfo.MinId,
                        PartitionName = nowDayPartitionInfo.PartitionName,
                        TableName = nowDayPartitionInfo.TableName,
                    });

                m_logger.LogDebug($"Создана партиция БД '{partitionInfo}'.");
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

                m_logger.LogDebug($"Создана партиция БД '{partitionInfo}'.");

                m_mapperTablePartition.New(
                    session,
                    new()
                    {
                        Id = ComplexIdentity.Build(manager.Manager.Level, m_entryPoint.PartitionsDay.GetDayIndex(nowDay), m_mapperTablePartition.GetNextId(session)),
                        Day = nextDay,
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