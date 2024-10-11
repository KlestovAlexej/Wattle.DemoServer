using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;

namespace Acme.DemoServer.Testing.Loggers;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class NUnitConsoleLogger : ILogger
{
    #region Private Class StubScope
    private class StubScope : IDisposable
    {
        public void Dispose()
        {
            /* NONE */
        }
    }
    #endregion

    private readonly string m_categoryName;
    private readonly NUnitConsoleLoggerProvider m_owner;

    // ReSharper disable once ConvertToPrimaryConstructor
    public NUnitConsoleLogger(string categoryName, NUnitConsoleLoggerProvider owner)
    {
        m_categoryName = categoryName;
        m_owner = owner;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (m_owner.SuppressOutput)
        {
            return;
        }

        TestContext.Progress.WriteLine($"{m_categoryName} : {formatter(state, exception)}");
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable BeginScope<TState>(TState state) 
        where TState : notnull
    {
        return new StubScope();
    }
}