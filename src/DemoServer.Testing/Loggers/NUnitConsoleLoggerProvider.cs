﻿using Microsoft.Extensions.Logging;

namespace Acme.DemoServer.Testing.Loggers;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class NUnitConsoleLoggerProvider : ILoggerProvider
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public NUnitConsoleLoggerProvider(bool suppressOutput = false)
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