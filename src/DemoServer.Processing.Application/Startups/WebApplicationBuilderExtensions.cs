using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;
using Serilog;
using Acme.DemoServer.Common;
using Acme.DemoServer.Processing.Api;
using Acme.DemoServer.Processing.Api.Common;
using Acme.DemoServer.Processing.Api.Validators;
using Acme.DemoServer.Processing.Model.Implements;
using Acme.DemoServer.Processing.Model.Implements.SystemSettings;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Infrastructures.Rest.Common.SwaggerTypes;
using Acme.Wattle.Infrastructures.Rest.Controllers.Monitors;
using Acme.Wattle.Json.Extensions;
using Acme.Wattle.OpenTelemetry;
using Acme.Wattle.Primitives;
using Acme.Wattle.Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Newtonsoft;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Threading;
using System.Xml.XPath;
using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Acme.Wattle.Utils;
using Constants = Acme.DemoServer.Common.Constants;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Acme.DemoServer.Processing.Application.Startups.HealthChecks;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Acme.DemoServer.Processing.Application.Startups;

public static class WebApplicationBuilderExtensions
{
    private static readonly string ServiceName = "Acme.DemoServer.Processing";
    private static readonly string EventSourceName = $"{ServiceName} [{Constants.ProductVersion.ToString(Constants.VersionComparePrecision)}]";

    private static readonly List<string> XmlCommentsText;

    static WebApplicationBuilderExtensions()
    {
        XmlCommentsText = [];
        foreach (var assembly in Wattle.Utils.ExtensionsReflection.GetAssemblies())
        {
            var filename = Path.Combine(AppContext.BaseDirectory, $"{assembly.GetName().Name}.xml");
            if (false == filename.ToLower().Contains("acme"))
            {
                continue;
            }

            if (File.Exists(filename))
            {
                XmlCommentsText.Add(File.ReadAllText(filename));
            }
        }
    }

    public static WebApplicationBuilder AddEnvironmentVariablesCustom(
        this WebApplicationBuilder builder)
    {
        builder.Configuration.AddEnvironmentVariables(prefix: $"{Constants.ProductTag}_");

        return builder;
    }

    public static Mutex CreateMutex(Guid instanceId, out bool mutexCreatedNew)
    {
        return new Mutex(
            true,
            $"{ServiceName}.{instanceId}",
            out mutexCreatedNew);
    }

    // ReSharper disable once UnusedMethodReturnValue.Global
    public static WebApplicationBuilder AddCustoms(
        this WebApplicationBuilder builder,
        bool isWindowsService,
        SystemSettings systemSettings)
    {
        if (isWindowsService)
        {
            builder.Services.AddWindowsService(
                options =>
                {
                    options.ServiceName = EventSourceName;
                });
        }

        var configuration = builder.Configuration;
        builder.Services.AddSingleton(configuration);
        builder.Services.AddEntryPointServices(systemSettings);

        builder
            .UseCustomSerilog(builder.Configuration, systemSettings)
            .AddCustomOpenTelemetry(
                ServiceName,
                Constants.ProductVersion.ToString(Constants.VersionComparePrecision),
                systemSettings.InstanceId.Value.ToString("D"),
                metics: (_, _, _) => builder.Services.AddSingleton<Metrics>())
            .AddCustomControllersWithNewtonsoftJson()
            .AddCustomSwagger()
            .AddCustomHealthCheck();

        return builder;
    }

    private static WebApplicationBuilder UseCustomSerilog(
        this WebApplicationBuilder builder,
        IConfigurationRoot configuration,
        SystemSettings systemSettings)
    {
        builder.Host.UseSerilog(
            (_, cfg) =>
                cfg
                    .Enrich.WithThreadId()
                    .Enrich.With(new ServiceEnricher(ServiceName, new Version(Constants.ProductVersion.ToString(Constants.VersionComparePrecision)), systemSettings.InstanceId.Value))
                    .ReadFrom.Configuration(configuration));

        return builder;
    }

    // ReSharper disable once UnusedMethodReturnValue.Global
    public static WebApplication UseCustoms(
        this WebApplication application,
        ILogger logger,
        MonitorsHostApplet monitors)
    {
        application
            .AddCustomOpenTelemetry()
            .UseCustomExceptionsHandle()
            .UseCustomRouting()
            .UseCustomHealthCheck()
            .UseCustomSwagger()
            .AddEntryPointServices();

        application.UseReDoc(c =>
        {
            c.RoutePrefix = "docs";
            c.DocumentTitle = $"API {SystemSettingsLocal.ProductNameText}";
            c.SpecUrl("/swagger/v1/swagger.json");
            c.EnableUntrustedSpec();
            c.ScrollYOffset(10);
            c.HideHostname();
            c.HideDownloadButton();
            c.ExpandResponses("200,409,400");
            c.RequiredPropsFirst();
            c.NoAutoAuth();
            c.PathInMiddlePanel();
            c.HideLoading();
            c.NativeScrollbars();
            c.DisableSearch();
            c.OnlyRequiredInSamples();
            c.SortPropsAlphabetically();
        });

        application.Lifetime
            .ApplicationStarted
            .Register(
                () =>
                {
                    Console.WriteLine("Запуск API мониторинга...");
                    AddInformationEventLogMessage("Запуск API мониторинга...");
                    logger.LogDebug("Запуск API мониторинга...");

                    monitors.Start();

                    Console.WriteLine("API мониторинга запущено.");
                    AddInformationEventLogMessage("API мониторинга запущено.");
                    logger.LogDebug("API мониторинга запущено.");

                    Console.WriteLine("Запуск точки входа...");
                    AddInformationEventLogMessage("Запуск точки входа...");
                    logger.LogDebug("Запуск точки входа...");

                    var entryPoint = (ICustomEntryPoint)ServiceProviderHolder.Instance.GetRequiredService<IEntryPoint>();
                    entryPoint.Start();

                    Console.WriteLine("Точка входа запущена.");
                    AddInformationEventLogMessage("Точка входа запущена.");
                    logger.LogDebug("Точка входа запущена.");

                    Console.WriteLine("Сервер запущен.");
                    AddInformationEventLogMessage("Сервер запущен.");
                    logger.LogDebug("Сервер запущен.");

                    if (entryPoint.SystemSettings.TelegramShowApplicationStartStop.Value)
                    {
                        var telegram = entryPoint.ServiceProvider.GetRequiredService<ITelegram>();
                        telegram.SendAsync(@$"👍 Полёт нормальный!

Сервер запущен.

{ExceptionPolicy.GetProductDetails(entryPoint.SystemSettingsLocal, entryPoint.SystemSettings)}").SafeGetResult();
                    }
                });

        application.Lifetime
            .ApplicationStopping
            .Register(
                () =>
                {
                    Console.WriteLine("Остановка точки входа...");
                    AddInformationEventLogMessage("Остановка точки входа...");
                    logger.LogDebug("Остановка точки входа...");

                    var entryPoint = (ICustomEntryPoint)ServiceProviderHolder.Instance.GetRequiredService<IEntryPoint>();

                    entryPoint.BeginStop();
                    entryPoint.WaitStop();

                    Console.WriteLine("Точка входа остановлена.");
                    AddInformationEventLogMessage("Точка входа остановлена.");
                    logger.LogDebug("Точка входа остановлена.");

                    Console.WriteLine("Остановка API мониторинга...");
                    AddInformationEventLogMessage("Остановка API мониторинга...");
                    logger.LogDebug("Остановка API мониторинга...");

                    monitors.Stop();

                    Console.WriteLine("API мониторинга остановлено.");
                    AddInformationEventLogMessage("API мониторинга остановлено.");
                    logger.LogDebug("API мониторинга остановлено.");

                    Console.WriteLine("Сервер остановлен.");
                    AddInformationEventLogMessage("Сервер остановлен.");
                    logger.LogDebug("Сервер остановлен.");

                    if (entryPoint.SystemSettings.TelegramShowApplicationStartStop.Value)
                    {
                        var telegram = entryPoint.ServiceProvider.GetRequiredService<ITelegram>();
                        telegram.SendAsync(@$"🗣 Без паники!

Сервер остановлен.

{ExceptionPolicy.GetProductDetails(entryPoint.SystemSettingsLocal, entryPoint.SystemSettings)}").SafeGetResult();
                    }
                });

        return application;
    }

    public static void AddErrorEventLogMessage(string message)
    {
        try
        {
            if (OperatingSystem.IsWindows())
            {
                EventLog.WriteEntry(EventSourceName,
                    message
                    + Environment.NewLine
                    + Assembly.GetExecutingAssembly().Location,
                    EventLogEntryType.Error,
                    WellknownSytemLogTypes.Error);
            }
        }
        catch
        {
            /* NONE */
        }
    }

    public static void AddInformationEventLogMessage(string message)
    {
        try
        {
            if (OperatingSystem.IsWindows())
            {
                EventLog.WriteEntry(EventSourceName,
                    message
                    + Environment.NewLine
                    + Assembly.GetExecutingAssembly().Location,
                    EventLogEntryType.Information,
                    WellknownSytemLogTypes.Information);
            }
        }
        catch
        {
            /* NONE */
        }
    }

    private static WebApplication UseCustomExceptionsHandle(this WebApplication application)
    {
        application.UseMiddleware<ExceptionMiddleware>();

        return application;
    }

    private static WebApplication UseCustomRouting(this WebApplication application)
    {
        application.UseCors(
            builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        application.UseRouting();
        application.MapControllerRoute(
            name: "apiroute",
            pattern: "api/v{version:apiVersion}/{controller}/{action?}");

        return application;
    }

    private static WebApplication UseCustomSwagger(this WebApplication application)
    {
        application.UseSwagger();
        application.UseSwaggerUI(
            options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
                options.EnableFilter();
                options.EnableValidator(null);
            });

        return application;
    }

    private static WebApplicationBuilder AddCustomSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(
            options =>
            {
                options.ExampleFilters();
                options.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
                options.SchemaFilter<SwaggerDefineDescriptionSchemaFilter>();

                options.SelectSubTypesUsing(
                    baseType =>
                        typeof(WorkflowErrorCodes).Assembly.GetTypes().Where(
                            type => type.IsSubclassOf(baseType) && !type.IsAbstract));

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"API {SystemSettingsLocal.ProductNameText}",
                    Description = SystemSettingsLocal.ProductNameText,
                });

                foreach (var text in XmlCommentsText)
                {
                    options.IncludeXmlComments(() => new XPathDocument(new StringReader(text)), true);
                }

                {
                    var remarks = WorkflowErrorCodeDataKeysAttribute.GetRemarks(
                        typeof(WorkflowExceptionPolicy),
                        WellknownWorkflowExceptionDataKeys.GetDisplayName, 
                        WorkflowErrorCodes.Remarks);

                    options.SchemaFilter<WorkflowErrorCodesSchemaFilter>(
                        new WorkflowErrorCodesSchemaFilter.Parameters(
                            WorkflowErrorCodes.DisplayNames,
                            remarks,
                            WorkflowErrorCodes.Severities));
                }
            });

        builder.Services.AddSwaggerExamplesFromAssemblyOf(typeof(BaseProcessingController));
        builder.Services.AddSwaggerGenNewtonsoftSupport();

        return builder;
    }

    private static WebApplicationBuilder AddCustomControllersWithNewtonsoftJson(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers()
            .ConfigureApplicationPartManager(
                manager =>
                {
                    var type = typeof(BaseProcessingController);

                    manager.ApplicationParts.Clear();
                    var assembly = type.Assembly;
                    var partFactory = ApplicationPartFactory.GetApplicationPartFactory(assembly);
                    foreach (var applicationPart in partFactory.GetApplicationParts(assembly))
                    {
                        manager.ApplicationParts.Add(applicationPart);
                    }

                    manager.FeatureProviders
                        .OfType<IApplicationFeatureProvider<ControllerFeature>>()
                        .ToList()
                        .ForEach(provider => manager.FeatureProviders.Remove(provider));

                    manager.FeatureProviders
                        .Add(new RestrictedControllerFeatureProvider(type));
                })
            .AddNewtonsoftJson(
                options =>
                {
                    var settings = JsonExtensions.CreateSettings();
                    options.SerializerSettings.DateFormatHandling = settings.DateFormatHandling;
                    options.SerializerSettings.DateTimeZoneHandling = settings.DateTimeZoneHandling;
                    options.SerializerSettings.DateParseHandling = settings.DateParseHandling;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

        builder.Services.AddOptions<MvcOptions>().PostConfigure(
            options =>
            {
                var formatter =
                    options.InputFormatters.OfType<NewtonsoftJsonInputFormatter>()
                        .First(i => i.SupportedMediaTypes.Contains(MediaTypeNames.Application.Json));
                options.InputFormatters.Clear();
                options.InputFormatters.Add(formatter);
            });

        builder.Services.Replace(
            ServiceDescriptor.Transient<ISerializerDataContractResolver>((s) =>
            {
                var serializerSettings = s.GetRequiredService<IOptions<MvcNewtonsoftJsonOptions>>().Value.SerializerSettings;

                return new NewtonsoftDataContractResolver(serializerSettings);
            }));

        builder.Services.AddApiVersioning(
            o =>
            {
                o.ReportApiVersions = false;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

        builder.AddCustomValidators();

        return builder;
    }
}
