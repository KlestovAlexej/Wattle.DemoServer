using Microsoft.Extensions.Logging;

namespace ShtrihM.DemoServer.Testing.Loggers;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class NUnitConsoleLoggerProvider : ILoggerProvider
{
    public NUnitConsoleLoggerProvider(bool suppressOutput = false)
        // ReSharper disable once ConvertToPrimaryConstructor
    {
        SuppressOutput = suppressOutput;
    }

    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public bool SuppressOutput;

    public void Dispose()
    {
        /* NONE */
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new NUnitConsoleLogger(categoryName, this);
    }

    public void Add(ILoggingBuilder builder)
    {
        builder.AddProvider(this);
        builder.AddFilter<NUnitConsoleLoggerProvider>(null, LogLevel.Trace);
    }
}