using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;
using Acme.DemoServer.Processing.Api;
using Acme.DemoServer.Processing.Application.Startups;
using Acme.DemoServer.Processing.Model.Implements;
using Acme.DemoServer.Processing.Model.Implements.SystemSettings;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects;
using Acme.Wattle.DomainObjects.Common;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Infrastructures.Rest.Controllers.Monitors;
using Acme.Wattle.Json.Extensions;
using Acme.Wattle.OpenTelemetry;
using Acme.Wattle.Primitives;
using Acme.Wattle.Testing;
using Acme.Wattle.Utils;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using Unity;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using WebApplicationBuilderExtensions = Acme.DemoServer.Processing.Application.Startups.WebApplicationBuilderExtensions;

namespace Acme.DemoServer.Processing.Application;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class Program
{
    private static bool IsWindowsService;
    public static readonly string FileNameOfAppSettings = "appsettings.json";

    // ReSharper disable once InconsistentNaming
    private static ILogger? Logger;

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

                if (args[0].ToUpper() == "-S")
                {
                    var basePath = new DirectoryInfo(Path.GetDirectoryName(typeof(Program).Assembly.Location)!).FullName;
                    var path = Path.Combine(basePath, FileNameOfAppSettings);
                    var text = File.ReadAllText(path);
                    var model = text.FromJson<dynamic>();
                    
                    model.SystemSettings = SystemSettings.GetDefault().ToJsonText().FromJson<dynamic>();
                    model.OpenTelemetry = GetOpenTelemetrySettings().ToJsonText().FromJson<dynamic>();

                    text = ((object)model).ToJsonText(true);
                    File.WriteAllText(path, text);

                    return 0;
                }
            }

            Console.WriteLine("Запуск сервера...");
            WebApplicationBuilderExtensions.AddInformationEventLogMessage("Запуск сервера...");

            EnvironmentVariablesHelpers.Define(args);

            EntryPointStartUpExtensions.RegisterGlobals();

            var builder =
                WebApplication
                    .CreateBuilder()
                    .AddEnvironmentVariablesCustom();

            var systemSettings =
                builder.Configuration
                    .GetSection(SystemSettings.SectionName)
                    .Get<SystemSettings>();

            if (systemSettings == null)
            {
                throw new InvalidOperationException($"Не найдена секция '{SystemSettings.SectionName}'.");
            }

            if (systemSettings.MappersFeaturesValidateUpdateResults.Value)
            {
                TestsMappersFeatures.SetValidateUpdateResults(true);
            }

            using var mutex = WebApplicationBuilderExtensions.CreateMutex(systemSettings.InstanceId.Value, out var mutexCreatedNew);

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
                            var ep = (ICustomEntryPoint?)ServiceProviderHolder.Instance.GetService<IEntryPoint>();
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

    private static OpenTelemetrySettings GetOpenTelemetrySettings()
    {
        var lightstepAccessToken = "ENTER_TOKEN";

        return
            new OpenTelemetrySettings
            {
                Enabled = true,
                Wattle =
                    new WattleInstrumentationSettings
                    {
                        Enabled = true,
                        UseMetics = true,
                        UseTracing = true,
                    },
                Tracing =
                    new OpenTelemetryTracingSettings
                    {
                        Enabled = true,
                        Npgsql =
                            new NpgsqlSettings
                            {
                                Enabled = true,
                            },
                        HttpClientInstrumentation =
                            new HttpClientInstrumentationSettings
                            {
                                Enabled = true,
                                DisplayNameWithUrl = true,
                                RecordException = true,
                                RecordHttpResponse = true,
                            },
                        AspNetCoreInstrumentation =
                            new AspNetCoreInstrumentationSettings
                            {
                                Enabled = true,
                                RecordException = true,
                                RecordHttpResponse = true,
                                RecordHttpRequest = true,
                            },
                        Otlp =
                            new OtlpSettings
                            {
                                Enabled = true,
                                Headers = $"lightstep-access-token={lightstepAccessToken}",
                                Endpoint = "https://ingest.lightstep.com:443",
                            },
                        EntityFrameworkCoreInstrumentation =
                            new EntityFrameworkCoreInstrumentationSettings
                            {
                                Enabled = true,
                            },
                    },
                Metics =
                    new OpenTelemetryMeticsSettings
                    {
                        Enabled = true,
                        UseHttpClientInstrumentation = true,
                        UseAspNetCoreInstrumentation = true,
                        UseRuntimeInstrumentation = true,
                        Otlp =
                            new OtlpSettings
                            {
                                Enabled = true,
                                Headers = $"lightstep-access-token={lightstepAccessToken}",
                                Endpoint = "https://ingest.lightstep.com:443",
                            },
                        Prometheus =
                            new PrometheusSettings
                            {
                                Enabled = true,
                                SwaggerTag = ServerController.Tag,
                            },
                        EventCounters =
                        [
                            "Microsoft.AspNetCore.Hosting",
                            "Microsoft.AspNetCore.Http.Connections",
                            "Microsoft-AspNetCore-Server-Kestrel",
                            "System.Net.Http",
                            "System.Net.NameResolution",
                            "System.Net.Security",
                            "System.Net.Socket"
                        ],
                    },
            };
    }
}