using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Threading;

namespace ShtrihM.DemoServer.Testing.Loggers;

#pragma warning disable CS1591

public static class LoggerSerilog
{
    /// <summary>
    /// Путь хранения логов приложения.
    /// </summary>
    private const string EnvironmentVariableAsLogsDir = "LOGS_DIR";

    private class ThreadIdEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", Thread.CurrentThread.ManagedThreadId));
        }
    }

    public static Logger New(
        string appPath,
        IConfiguration configuration,
        string environmentVariable = EnvironmentVariableAsLogsDir)
    {
        if (appPath == null)
        {
            throw new ArgumentNullException(nameof(appPath));
        }

        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        if (environmentVariable == null)
        {
            throw new ArgumentNullException(nameof(environmentVariable));
        }

        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(environmentVariable)))
        {
            Environment.SetEnvironmentVariable(environmentVariable, appPath);
        }

        var settings = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .Enrich.With(new ThreadIdEnricher())
            .ReadFrom
            .Configuration(configuration);

        var result = settings.CreateLogger();

        return result;
    }
}