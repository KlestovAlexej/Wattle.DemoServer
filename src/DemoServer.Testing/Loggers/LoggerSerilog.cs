using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;

namespace Acme.DemoServer.Testing.Loggers;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

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
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", Environment.CurrentManagedThreadId));
        }
    }

    public static Logger New(
        string appPath,
        IConfiguration configuration,
        string environmentVariable = EnvironmentVariableAsLogsDir)
    {
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