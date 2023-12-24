using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Generated.PostgreSql.Implements;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;
using ShtrihM.Wattle3.Common.Interfaces;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Testing.DomainObjects;
using ShtrihM.Wattle3.Utils;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using ShtrihM.DemoServer.Processing.Application.Startups;
using ShtrihM.DemoServer.Processing.Generated.Interface;
using ShtrihM.Wattle3.Json.Extensions;
using Unity;
using Constants = ShtrihM.DemoServer.Common.Constants;
using System.Threading;

// ReSharper disable MemberCanBePrivate.Global

namespace ShtrihM.DemoServer.Processing.Tests.Model.Environment;

[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
public abstract class BaseTestsWithEntryPoint : BaseDbTests
{
    protected static readonly TimeSpan WaitTimeout = TimeSpan.FromMinutes(1);

    protected EntryPoint m_entryPoint;
    protected bool m_useTablespaces;
    protected ServiceProvider m_entryPointServiceProvider;
    protected ManagedTimeService m_timeService;
    protected Mappers m_mappers;
    protected TestDirectory m_dataPathTablespace1;
    protected TestDirectory m_dataPathTablespace2;
    protected string m_nameTablespace1;
    protected string m_nameTablespace2;
    protected bool m_useMappersFeatures;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected BaseTestsWithEntryPoint()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        EnvironmentVariablesHelpers.Define(Array.Empty<string>(), Path.GetDirectoryName(typeof(BaseTestsWithEntryPoint).Assembly.Location)!);

        m_useMappersFeatures = true;
    }

    [SetUp]
    public void BaseTestsWithEntryPoint_SetUp()
    {
        TestsMappersFeatures.SetValidateUpdateResults(m_useMappersFeatures);

        EntryPointStartUpExtensions.RegisterGlobals();

        m_useTablespaces = false;
        m_dataPathTablespace1 = new TestDirectory("Tablespace1");
        m_dataPathTablespace2 = new TestDirectory("Tablespace2");
        m_nameTablespace1 = $"tests_{Constants.ProductTag.ToLower()}_tablespace1";
        m_nameTablespace2 = $"tests_{Constants.ProductTag.ToLower()}_tablespace2";

        CommonWattleExtensions.SilentDisposeAndFree(ref m_entryPoint);
        CommonWattleExtensions.SilentDisposeAndFree(ref m_entryPointServiceProvider);

        DomainEnviromentConfigurator.DisposeAll();

        m_logger.LogDebug($@"

Начало теста : {{ {TestContext.CurrentContext.Test.FullName}

");

        DropTablespaces();
        CreateTablespaces();

        m_mappers =
            new Mappers(
                new MappersExceptionPolicy(),
                m_dbConnectionString,
                new ManagedTimeService(),
                WellknownInfrastructureMonitors.Mappers,
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers));


        DoCreateEntryPoint();
    }

    [TearDown]
    public void BaseTestsWithEntryPoint_TearDown()
    {
        // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
        m_entryPoint?.Stop();
        CommonWattleExtensions.SilentDisposeAndFree(ref m_entryPoint!);

        CommonWattleExtensions.SilentDisposeAndFree(ref m_entryPointServiceProvider);

        DomainEnviromentConfigurator.DisposeAll();

        CommonWattleExtensions.SilentDisposeAndFree(ref m_mappers);

        m_logger.LogDebug($@"

Конец теста : }} {TestContext.CurrentContext.Test.FullName}

");

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    private void CreateTablespaces()
    {
        if (false == m_useTablespaces)
        {
            return;
        }

        using var connection = new NpgsqlConnection(m_serverConnectionString);

        connection.Open();

        using (var command = connection.CreateCommand())
        {
            command.CommandType = CommandType.Text;
            command.CommandText = $"CREATE TABLESPACE {m_nameTablespace1} LOCATION '{m_dataPathTablespace1.BasePath}'";

            command.ExecuteNonQuery();
        }

        using (var command = connection.CreateCommand())
        {
            command.CommandType = CommandType.Text;
            command.CommandText = $"CREATE TABLESPACE {m_nameTablespace2} LOCATION '{m_dataPathTablespace2.BasePath}'";

            command.ExecuteNonQuery();
        }
    }

    protected override void DoPostDropDb()
    {
        base.DoPostDropDb();

        DropTablespaces();

        m_dataPathTablespace1.SilentDispose();
        m_dataPathTablespace2.SilentDispose();
    }

    private void DropTablespaces()
    {
        if (false == m_useTablespaces)
        {
            return;
        }

        using var connection = new NpgsqlConnection(m_serverConnectionString);

        connection.Open();

        {
            using var command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = $"DROP TABLESPACE IF EXISTS {m_nameTablespace1}";

            command.ExecuteNonQuery();
        }

        {
            using var command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = $"DROP TABLESPACE IF EXISTS {m_nameTablespace2}";

            command.ExecuteNonQuery();
        }
    }

    protected string GetDbLogs(int maxEntries = 100)
    {
        var countEntries = 0;
        {
            var result = new StringBuilder();
            result.AppendLine();
            result.AppendLine("-- { SystemLog -------------------------");
            using var session = m_mappers.OpenSession();
            var mapper = m_mappers.GetMapper<IMapperSystemLog>();
            foreach (var dto in mapper.GetEnumeratorRaw(session).OrderByDescending(i => i.Id))
            {
                result.AppendLine(dto.ToJsonText(true));
                ++countEntries;
                if (countEntries > maxEntries)
                {
                    break;
                }
            }
            result.AppendLine("-- } SystemLog -------------------------");
            result.AppendLine();

            if (countEntries != 0)
            {
                return result.ToString();
            }
        }

        {
            Thread.Sleep(TimeSpan.FromSeconds(5));

            var result = new StringBuilder();
            result.AppendLine();
            result.AppendLine("-- { SystemLog -------------------------");
            using var session = m_mappers.OpenSession();
            var mapper = m_mappers.GetMapper<IMapperSystemLog>();
            foreach (var dto in mapper.GetEnumeratorRaw(session).OrderByDescending(i => i.Id))
            {
                result.AppendLine(dto.ToJsonText(true));
                ++countEntries;
                if (countEntries > maxEntries)
                {
                    break;
                }
            }
            result.AppendLine("-- } SystemLog -------------------------");
            result.AppendLine();

            return result.ToString();
        }
    }

    // ReSharper disable once MemberCanBePrivate.Global
    protected void DisposeEntryPoint()
    {
        // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
        m_entryPoint?.Stop();
        CommonWattleExtensions.SilentDisposeAndFree(ref m_entryPoint!);

        CommonWattleExtensions.SilentDisposeAndFree(ref m_entryPointServiceProvider);

        DomainEnviromentConfigurator.DisposeAll();
    }

    // ReSharper disable once MemberCanBePrivate.Global
    protected void CreateEntryPoint(
        bool startAndWaitIsReady = true,
        Action<EntryPoint>? postCreate = null)
    {
        DoCreateEntryPoint();

        postCreate?.Invoke(m_entryPoint);

        if (startAndWaitIsReady)
        {
            m_entryPoint.Start();

            WaitHelpers.TimeOut(() => m_entryPoint.IsReady, WaitTimeout, () => GetDbLogs());
            WaitHelpers.TimeOut(() => m_entryPoint.GlobalIsReady, WaitTimeout, () => GetDbLogs());
        }
    }

    protected void ReCreateEntryPoint(
        bool startAndWaitIsReady = true,
        Action<EntryPoint>? postCreate = null)
    {
        DisposeEntryPoint();

        CreateEntryPoint(
            startAndWaitIsReady,
            postCreate);
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual void DoCreateEntryPoint()
    {
        var domainEnviromentConfigurator = DomainEnviromentConfigurator.Begin();

        using var container = new UnityContainer().AddExtension(new Diagnostic());
        container.RegisterInstance(m_loggerFactory, InstanceLifetime.External);

        m_timeService = new ManagedTimeService(round: true);

        var systemSettings = CreateSystemSettings();
        container.RegisterInstance(systemSettings, InstanceLifetime.External);
        container.RegisterInstance<ITimeService>(m_timeService, InstanceLifetime.External);

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddEntryPointServices();

        serviceCollection.AddSingleton(m_loggerFactory);

        m_entryPointServiceProvider = serviceCollection.BuildServiceProvider();
        container.RegisterInstance<IServiceProvider>(m_entryPointServiceProvider, InstanceLifetime.External);

        try
        {
            m_entryPoint = EntryPoint.New(container);

            domainEnviromentConfigurator
                .SetEntryPoint(m_entryPoint)
                .SetExceptionPolicy(m_entryPoint.ExceptionPolicy)
                .SetInfrastructureMonitorRegisters(m_entryPoint.InfrastructureMonitorRegisters)
                .SetWorkflowExceptionPolicy(m_entryPoint.WorkflowExceptionPolicy)
                .Build();
        }
        catch (Exception exception)
        {
            CommonWattleExtensions.SilentDisposeAndFree(ref m_entryPoint!);
            CommonWattleExtensions.SilentDisposeAndFree(ref m_entryPointServiceProvider);

            ExceptionDispatchInfo.Capture(exception).Throw();
        }
    }

    // ReSharper disable once VirtualMemberNeverOverridden.Global
    protected virtual SystemSettings CreateSystemSettings()
    {
        var result = SystemSettings.GetDefault();

        result.ConnectionString.Value = m_dbConnectionString;
        result.QueueEmergencyTimeoutEmergencyDomainBehaviour.Value = TimeSpan.FromMilliseconds(100);
        result.PartitionsSponsorSettings.Value.ActivateTimeout.Value = TimeSpan.FromSeconds(1);

        if (m_useTablespaces)
        {
            result.PartitionsSponsorSettings.Value.TablespaceNames.Value =
                new PartitionsSponsorSettings.TablespacesEntry
                {
                    Tablespaces =
                    [
                        new()
                        {
                            Index = 0,
                            TablespaceName = m_nameTablespace1
                        },

                        new()
                        {
                            Index = 1,
                            TablespaceName = m_nameTablespace2
                        }

                    ]
                };

            result.PartitionsSponsorSettings.Value.DomainObjectsTablespaceNames.Value =
                new PartitionsSponsorSettings.DomainObjectsEntry();

            var flag = 0;
            using var mappers =
                new Mappers(
                    new MappersExceptionPolicy(),
                    "",
                    new TimeService(),
                    WellknownInfrastructureMonitors.Mappers,
                    WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                    WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers));
            foreach (var manager in PartitionsSponsor.GetAllPartitionsManagers(mappers))
            {
                if (flag == 0)
                {
                    result.PartitionsSponsorSettings.Value.DomainObjectsTablespaceNames.Value.DomainObjects.Add(
                        new PartitionsSponsorSettings.DomainObjectTablespaceEntry
                        {
                            DomainObjectType = manager.Mapper.MapperId,
                            Comment = WellknownDomainObjectDisplayNames.DisplayNamesProvider(manager.Mapper.MapperId),
                            Tablespaces =
                            [
                                new()
                                {
                                    Index = 0,
                                    TablespaceName = m_nameTablespace1
                                },

                                new()
                                {
                                    Index = 1,
                                    TablespaceName = m_nameTablespace2
                                }

                            ]
                        });
                }
                else if (flag == 1)
                {
                    result.PartitionsSponsorSettings.Value.DomainObjectsTablespaceNames.Value.DomainObjects.Add(
                        new PartitionsSponsorSettings.DomainObjectTablespaceEntry
                        {
                            DomainObjectType = manager.Mapper.MapperId,
                            Comment = WellknownDomainObjectDisplayNames.DisplayNamesProvider(manager.Mapper.MapperId),
                            Tablespaces = []
                        });
                }

                if (flag >= 3)
                {
                    flag = 0;
                }
                else
                {
                    ++flag;
                }
            }
        }
        else
        {
            result.PartitionsSponsorSettings.Value.TablespaceNames.Value =
                new PartitionsSponsorSettings.TablespacesEntry();

            result.PartitionsSponsorSettings.Value.DomainObjectsTablespaceNames.Value =
                new PartitionsSponsorSettings.DomainObjectsEntry();
        }

        return result;
    }
}