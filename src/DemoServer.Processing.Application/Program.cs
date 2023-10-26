using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using ShtrihM.DemoServer.Processing.Api;
using ShtrihM.DemoServer.Processing.Application.Startups;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Infrastructures.Rest.Controllers.Monitors;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.OpenTelemetry;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Utils;
using System;
using System.Globalization;
using System.Text;
using System.Threading;
using Unity;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using WebApplicationBuilderExtensions = ShtrihM.DemoServer.Processing.Application.Startups.WebApplicationBuilderExtensions;

namespace ShtrihM.DemoServer.Processing.Application;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class Program
{
    private static bool IsWindowsService;
    public static readonly string FileNameOfAppSettings = "appsettings.json";
    private static readonly string AppSettingsOfSystemSettings = "-S:" + SystemSettings.SectionName;
    private static readonly string AppSettingsOfOpenTelemetrySettings = "-S:" + OpenTelemetrySettings.SectionName;

    // ReSharper disable once InconsistentNaming
    private static ILogger Logger;

    private static int Main(string[] args)
    {
        try
        {
            // Для сохранения явной ссылки на пакет.
            _ = typeof(Serilog.Sinks.Logz.Io.LogzIoSerializer);

            IsWindowsService = (args.Length > 0) && (string.Equals(args[0], "-Service", StringComparison.CurrentCultureIgnoreCase));

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (false == IsWindowsService)
            {
                Console.OutputEncoding = Encoding.UTF8;
            }

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;

            if (args.Length > 0)
            {
                if (args[0].ToUpper() == "-VB")
                {
#if BUILD_PROD
                    Console.WriteLine("Боевая установка");
#elif BUILD_TEST
                    Console.WriteLine("Тестовая установка");
#else
                    Console.WriteLine("Локальная тестовая установка");
#endif

                    return 0;
                }

                if (args[0].ToUpper() == AppSettingsOfSystemSettings.ToUpper())
                {
                    Console.WriteLine(SystemSettings.GetDefault().ToJsonText(true));

                    return 0;
                }

                if (args[0].ToUpper() == AppSettingsOfOpenTelemetrySettings.ToUpper())
                {
                    var lightstepAccessToken = "ENTER_TOKEN";

                    Console.WriteLine(
                        new OpenTelemetrySettings
                        {
                            Enabled = true,
                            Wattle = 
                                new()
                                {
                                    Enabled = true,
                                    UseMetics = true,
                                    UseTracing = true,
                                },
                            Tracing =
                                    new()
                                    {
                                        Enabled = true,
                                        Npgsql =
                                            new()
                                            {
                                                Enabled = true,
                                            },
                                        HttpClientInstrumentation =
                                            new()
                                            {
                                                Enabled = true,
                                                DisplayNameWithUrl = true,
                                                RecordException = true,
                                                RecordHttpResponse = true,
                                            },
                                        AspNetCoreInstrumentation =
                                            new()
                                            {
                                                Enabled = true,
                                                RecordException = true,
                                                RecordHttpResponse = true,
                                                RecordHttpRequest = true,
                                            },
                                        Otlp =
                                            new()
                                            {
                                                Enabled = true,
                                                Headers = $"lightstep-access-token={lightstepAccessToken}",
                                                Endpoint = "https://ingest.lightstep.com:443",
                                            },
                                        Jaeger =
                                            new()
                                            {
                                                Enabled = false,
                                                Endpoint = "",
                                            },
                                        EntityFrameworkCoreInstrumentation =
                                            new()
                                            {
                                                Enabled = true,
                                            },
                                    },
                            Metics =
                                    new()
                                    {
                                        Enabled = true,
                                        UseHttpClientInstrumentation = true,
                                        UseAspNetCoreInstrumentation = true,
                                        UseRuntimeInstrumentation = true,
                                        Otlp =
                                            new()
                                            {
                                                Enabled = true,
                                                Headers = $"lightstep-access-token={lightstepAccessToken}",
                                                Endpoint = "https://ingest.lightstep.com:443",
                                            },
                                        Prometheus =
                                            new()
                                            {
                                                Enabled = true,
                                                SwaggerTag = ServerController.Tag,
                                            },
                                        EventCounters =
                                            new()
                                            {
                                                "Microsoft.AspNetCore.Hosting",
                                                "Microsoft.AspNetCore.Http.Connections",
                                                "Microsoft-AspNetCore-Server-Kestrel",
                                                "System.Net.Http",
                                                "System.Net.NameResolution",
                                                "System.Net.Security",
                                                "System.Net.Socket",
                                            },
                                    },
                        }
                            .ToJsonText(true));

                    return 0;
                }
            }

            Console.WriteLine("Запуск сервера...");
            WebApplicationBuilderExtensions.AddInformationEventLogMessage("Запуск сервера...");

            EnvironmentVariablesHelpers.Define(args);

            EntryPointExtensions.RegisterGlobals();

            var builder = WebApplication.CreateBuilder();

            var systemSettings =
                builder.Configuration
                    .GetSection(SystemSettings.SectionName)
                    .Get<SystemSettings>();

            if (systemSettings.MappersFeaturesValidateUpdateResults.Value)
            {
                TestsMappersFeatures.SetValidateUpdateResults(true);
            }

            using var mutex = WebApplicationBuilderExtensions.CreateMutex(systemSettings!.InstanceId.Value, out var mutexCreatedNew);

            builder.AddCustoms(IsWindowsService, systemSettings);

            using var application = builder.Build();

            var loggerFactory = application.Services.GetRequiredService<ILoggerFactory>();
            Logger = loggerFactory.CreateLogger<Program>();

            try
            {
                if (false == mutexCreatedNew)
                {
                    Logger.LogCritical("Одновременно может работать только один экземпляр приложения.");
                    Console.WriteLine("Одновременно может работать только один экземпляр приложения.");
                    WebApplicationBuilderExtensions.AddErrorEventLogMessage("Одновременно может работать только один экземпляр приложения.");

                    return 1;
                }

                EnvironmentVariablesHelpers.Print(Logger);

                NpgsqlLoggingConfiguration.InitializeLogging(loggerFactory, systemSettings.DebugMode.Value);

                #region EntryPoint

                using var container = new UnityContainer().AddExtension(new Diagnostic());

                container.RegisterInstance(loggerFactory, InstanceLifetime.External);
                container.RegisterInstance(application.Services, InstanceLifetime.External);

                Logger.LogDebug(@"

Настройки сервера:
{systemSettings}

", systemSettings.ToJsonText(true));

                container.RegisterInstance(systemSettings, InstanceLifetime.External);

                var entryPoint = EntryPoint.New(container);

                DomainEnviromentConfigurator
                    .Begin()
                    .SetEntryPoint(entryPoint)
                    .SetExceptionPolicy(entryPoint.ExceptionPolicy)
                    .SetInfrastructureMonitorRegisters(entryPoint.InfrastructureMonitorRegisters)
                    .SetWorkflowExceptionPolicy(entryPoint.WorkflowExceptionPolicy)
                    .Build();

                #endregion

                #region InfrastructureMonitors

                var infrastructureMonitorsSettings =
                    builder.Configuration
                        .GetSection(InfrastructureMonitorsSettings.SectionName)
                        .Get<InfrastructureMonitorsSettings>();

                using var monitors =
                    new MonitorsHostApplet(
                        () =>
                        {
                            var ep = (ICustomEntryPoint)ServiceProviderHolder.Instance.GetService<IEntryPoint>();
                            if (ep != null)
                            {
                                var result = ep.ServerDescription;

                                return (result);
                            }

                            throw DefaultWorkflowExceptionPolicy.CreateDefault(
                                CommonWorkflowException.ServiceTemporarilyUnavailable,
                                "Не удалось получить EntryPoint.");
                        },
                        infrastructureMonitorsSettings!.Endpoint,
                        loggerFactory.CreateLogger<MonitorsHostApplet>());

                #endregion

                application.UseCustoms(Logger, monitors);

                application.Run();

                return 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                WebApplicationBuilderExtensions.AddErrorEventLogMessage(exception.ToString());
                Logger.LogCritical(exception, "Ошибка запуска сервера.");

                return 1;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            WebApplicationBuilderExtensions.AddErrorEventLogMessage(exception.ToString());

            // ReSharper disable once SuspiciousTypeConversion.Global
            (Logger as IDisposable)?.SilentDispose();

            return 1;
        }
        finally
        {
            DomainEnviromentConfigurator.DisposeAll();
        }
    }

    private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs args)
    {
        if (args.ExceptionObject is ThreadAbortException)
        {
            return;
        }

        try
        {
            var exception = (Exception)args.ExceptionObject;

            try
            {
                Logger?.LogCritical(exception, "Неожиданная ошибка сервера.");
            }
            catch
            {
                /* NONE */
            }

            try
            {
                WebApplicationBuilderExtensions.AddErrorEventLogMessage("Неожиданная ошибка сервера." + Environment.NewLine + exception);
            }
            catch
            {
                /* NONE */
            }

            try
            {
                Console.WriteLine(exception);
            }
            catch
            {
                /* NONE */
            }
        }
        catch
        {
            /* NONE */
        }
    }
}