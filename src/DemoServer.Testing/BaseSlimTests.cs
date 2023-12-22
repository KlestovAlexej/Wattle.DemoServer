using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using NUnit.Framework;
using Serilog;
using ShtrihM.DemoServer.Testing.Loggers;
using ShtrihM.Wattle3.Utils;
using System.IO;
using ILogger = Microsoft.Extensions.Logging.ILogger;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ShtrihM.DemoServer.Testing;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public abstract class BaseSlimTests : BaseTests
{
    protected ILoggerFactory m_loggerFactory;
    protected NUnitConsoleLoggerProvider m_consoleLoggerProvider;
    
    // ReSharper disable once NotAccessedField.Global
    protected ILogger m_logger;

    [SetUp]
    public void BaseSlimTests_SetUp()
    {
        var appPath = Path.GetDirectoryName(GetType().Assembly.Location);
        Assert.IsNotNull(appPath);

        m_consoleLoggerProvider = new NUnitConsoleLoggerProvider(true);

        m_loggerFactory =
            LoggerFactory.Create(
                builder =>
                {
                    var appSettingsConfiguration =
                        new ConfigurationBuilder().AddJsonFile(Path.Combine(appPath!, "AppSettings.json"), false, false)
                            .Build();

                    builder.AddSerilog(LoggerSerilog.New(appPath!, appSettingsConfiguration), true);
                    m_consoleLoggerProvider.Add(builder);
                });

        m_logger = m_loggerFactory.CreateLogger(GetType());

        NpgsqlLoggingConfiguration.InitializeLogging(m_loggerFactory, true);
    }

    [TearDown]
    public void BaseSlimTests_TearDown()
    {
        CommonWattleExtensions.SilentDisposeAndFree(ref m_loggerFactory);
    }
}