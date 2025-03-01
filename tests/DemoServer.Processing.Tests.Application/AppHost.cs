using Newtonsoft.Json;
using NUnit.Framework;
using Acme.DemoServer.Common;
using Acme.DemoServer.Processing.Application;
using Acme.DemoServer.Processing.Application.Startups;
using Acme.DemoServer.Processing.DataAccess.PostgreSql;
using Acme.DemoServer.Processing.Model.Implements.SystemSettings;
using Acme.DemoServer.Testing;
using Acme.Wattle.Common.Interfaces;
using Acme.Wattle.Infrastructures.Rest.Clients.Monitors;
using Acme.Wattle.Json.Extensions;
using Acme.Wattle.Testing;
using Acme.Wattle.Testing.Databases.PostgreSql;
using Acme.Wattle.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using Path = System.IO.Path;

#pragma warning disable SYSLIB1054

namespace Acme.DemoServer.Processing.Tests.Application;

public class AppHost : IDisposable
{
    private bool m_freeAll;
    private StreamReader? m_output;
    private readonly string? m_dbName;
    private readonly string m_dbConnectionString;
    private readonly string m_serverConnectionString;
    private readonly TestDirectory m_directoryLogs;
    private readonly bool m_dropDb;
    private readonly bool m_buildEnviroment;
    private readonly bool m_buildDb;
    private readonly string m_tag;
    private readonly string m_appPath;
    private Process? m_process;
    private readonly int m_portApiProcessing;
    private readonly int m_portApiMonitoring;

    public readonly Uri UrlApiProcessing;

    public AppHost(
        string? configuration = null,
        bool dropDb = true,
        bool buildEnviroment = false,
        bool buildDb = true,
        string? dbName = null,
        string? tag = null)
    {
        m_freeAll = true;

        m_dropDb = dropDb;
        m_buildEnviroment = buildEnviroment;
        m_buildDb = buildDb;
        m_dbName = dbName ?? $"test_{Constants.ProductTag.ToLower()}_" + BaseDbTests.UniqueMark();
        m_tag = tag ?? Environment.StackTrace;
        configuration ??= Testing.BaseTests.Configuration;
        m_appPath = ProviderProjectBasePath.GetFullPath($@"src\DemoServer.Processing.Application\bin\{configuration}\net9.0-windows\win-x64");
        m_directoryLogs = new TestDirectory(Path.Combine(m_appPath, "Logs"), m_buildEnviroment == false);
        m_portApiProcessing = Constants.DefaultPortApiProcessing;
        m_portApiMonitoring = Constants.DefaultPortApiProcessingMonitoring;
        UrlApiProcessing = new Uri($"http://localhost:{m_portApiProcessing}");

        /*
        Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
        Файл с настройками реестра.
        src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
        */
        m_serverConnectionString = PostgreSqlDbHelper.GetServerConnectionString(userCredentials: BaseDbTests.PostgreSqlUserCredentials, serverAdress: BaseDbTests.PostgreSqlServerAdress);

        /*
        Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
        Файл с настройками реестра.
        src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
        */
        m_dbConnectionString = PostgreSqlDbHelper.GetDatabaseConnectionString(m_dbName, userCredentials: BaseDbTests.PostgreSqlUserCredentials, serverAdress: BaseDbTests.PostgreSqlServerAdress);
    }

    public void Start(
        Action<SystemSettings>? updateSystemSettings = null,
        bool showWindow = false)
    {
        try
        {
            m_freeAll = true;

            var systemSettings = SystemSettings.GetDefault();
            systemSettings.ConnectionString.Value = m_dbConnectionString;
            updateSystemSettings?.Invoke(systemSettings);

            WaitHelpers.TimeOut(
                () => NetHelpers.IsOpenTcpIpPort(m_portApiProcessing) == false,
                TimeSpan.FromMinutes(1));

            WaitHelpers.TimeOut(
                () => NetHelpers.IsOpenTcpIpPort(m_portApiMonitoring) == false,
                TimeSpan.FromMinutes(1));

            WaitHelpers.TimeOut(
                () =>
                {
                    using var mutex = WebApplicationBuilderExtensions.CreateMutex(systemSettings.InstanceId.Value, out var mutexCreatedNew);

                    return mutexCreatedNew;
                },
                TimeSpan.FromMinutes(1));

            if (m_buildDb)
            {
                try
                {
                    PostgreSqlDbHelper.DropDb(
                        m_dbName!,
                        serverConnectionString: m_serverConnectionString);
                }
                catch
                {
                    /* NONE */
                }

                var sqlScript = Deploy.GetSqlScript();
                PostgreSqlDbHelper.CreateDb(
                    m_dbName!, 
                    tag: m_tag, 
                    sqlScript: sqlScript,
                    serverConnectionString: m_serverConnectionString,
                    databaseConnectionString: m_dbConnectionString,
                    lcCollate: null,
                    lcCtype: null);

                Model.Environment.BaseDbTests.DefineRandomDbSequences(m_dbConnectionString);
            }

            m_freeAll = false;

            DoStartApplication(systemSettings, showWindow);

            WaitIsReady();
        }
        catch
        {
            DoStop(true);

            FreeAll();

            throw;
        }
    }

    private void DoStop(bool silentMode = false)
    {
        if (m_process != null)
        {
            string? output = null;
            var hasException = false;
            try
            {
                FreeConsole();
                AttachConsole((uint)m_process.Id);
                SetConsoleCtrlHandler(null, true);
                GenerateConsoleCtrlEvent(CtrlTypes.CtrlCEvent, 0);

                output = m_output?.ReadToEnd();

                if (false == m_process.WaitForExit((int)TimeSpan.FromSeconds(30).TotalMilliseconds))
                {
                    m_process.Kill(true);
                    m_process.WaitForExit();
                }

                FreeConsole();
                SetConsoleCtrlHandler(null, false);

                Assert.AreEqual(0, m_process.ExitCode, CollectLogs());
            }
            catch (Exception exception)
            {
                if (false == silentMode)
                {
                    hasException = true;

                    ExceptionDispatchInfo.Capture(exception).Throw();
                }
            }
            finally
            {
                Console.WriteLine("- [Processing : Консоль приложения] << -----------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine(output);
                Console.WriteLine();
                Console.WriteLine("- [Processing : Консоль приложения] >> -----------------------------------------------------");

                try
                {
                    m_process.Refresh();
                }
                catch
                {
                    /* NONE */
                }
                try
                {
                    if (false == m_process.HasExited)
                    {
                        m_process.Kill(true);
                        m_process.WaitForExit();
                    }
                }
                catch
                {
                    /* NONE */
                }

                m_process.SilentDispose();
                m_process = null;

                if (hasException)
                {
                    DoFinalize();
                }
            }
        }
    }

    public void Stop(bool silentMode = false)
    {
        m_freeAll = false;

        DoStop(silentMode);

        DoFinalize();
    }

    private void DoFinalize()
    {
        if (m_buildEnviroment)
        {
            return;
        }

        m_directoryLogs.SilentDispose();

        if (m_buildDb && m_dropDb)
        {
            try
            {
                PostgreSqlDbHelper.DropDb(
                    m_dbName!,
                    serverConnectionString: m_serverConnectionString);
            }
            catch
            {
                /* NONE */
            }
        }
    }

    public void Dispose()
    {
        FreeAll();

        GC.SuppressFinalize(this);
    }

    private void FreeAll()
    {
        if (false == m_freeAll)
        {
            return;
        }

        if (m_process != null)
        {
            try
            {
                m_process.Refresh();
            }
            catch
            {
                /* NONE */
            }
            try
            {
                m_process.Kill(true);
                m_process.WaitForExit(TimeSpan.FromSeconds(30));
            }
            catch
            {
                /* NONE */
            }

            m_process.SilentDispose();
            m_process = null;
        }

        m_directoryLogs.DeleteDirectoryOnDispose = true;

        m_directoryLogs.SilentDispose();

        if (m_dbName != null)
        {
            try
            {
                PostgreSqlDbHelper.DropDb(
                    m_dbName,
                    serverConnectionString: m_serverConnectionString);
            }
            catch
            {
                /* NONE */
            }
        }
    }

    private void DoStartApplication(SystemSettings systemSettings, bool showWindow)
    {
        var pathAppSettings = Path.Combine(m_appPath, Program.FileNameOfAppSettings);
        var textAppSettings = File.ReadAllText(pathAppSettings);
        var appSettings = JsonConvert.DeserializeObject<dynamic>(textAppSettings);
        Assert.IsNotNull(appSettings);
        var systemSettingsDeserializeObject = JsonConvert.DeserializeObject<dynamic>(systemSettings.ToJsonText());
        Assert.IsNotNull(systemSettingsDeserializeObject);
        appSettings!.SystemSettings = systemSettingsDeserializeObject!;
        textAppSettings = JsonConvert.SerializeObject(appSettings, Formatting.Indented);
        File.WriteAllText(pathAppSettings, textAppSettings);

        m_process
            = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(m_appPath, "Acme.DemoServer.Processing.Application.exe"),
                    WorkingDirectory = m_appPath,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WindowStyle = showWindow ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Maximized,
                    CreateNoWindow = !showWindow,
                    Verb = "runas",
                    UseShellExecute = false,
                    StandardErrorEncoding = Encoding.UTF8,
                    StandardInputEncoding = Encoding.UTF8,
                    StandardOutputEncoding = Encoding.UTF8,
                },
                EnableRaisingEvents = true,
            };

        m_process.StartInfo.EnvironmentVariables[EnvironmentVariablesHelpers.EnvironmentVariableAsLogsDir] = m_directoryLogs.BasePath;

        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine($"БД : {m_dbName}");
        Console.WriteLine();
        Console.WriteLine("Команда :");
        Console.WriteLine();
        Console.WriteLine($"SET {EnvironmentVariablesHelpers.EnvironmentVariableAsLogsDir}={m_directoryLogs.BasePath}");
        Console.WriteLine(m_process.StartInfo.FileName);
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine();

        var isStart = m_process.Start();

        m_output = m_process.StandardOutput;

        if (isStart == false)
        {
            var output = m_output.ReadToEnd();
            Console.WriteLine("- [Processing : Консоль приложения] << -----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(output);
            Console.WriteLine();
            Console.WriteLine("- [Processing : Консоль приложения] >> -----------------------------------------------------");
        }

        Assert.IsTrue(isStart);
    }

    private bool GetEntryPointIsReady()
    {
        using var monitorsClient = new InfrastructureMonitorClient(port: m_portApiMonitoring);

        var snapshot = monitorsClient.GetInfrastructureMonitorSnapshot(WellknownInfrastructureMonitors.EntryPoint);
        var value = (bool)snapshot.Values.Single(o => o.Id == WellknownSnapShotInfrastructureMonitorValues.DeferredReadyObject.IsReady).Data.Value;

        return value;
    }

    private bool GetEntryPointGlobalIsReady()
    {
        using var monitorsClient = new InfrastructureMonitorClient(port: m_portApiMonitoring);

        var snapshot = monitorsClient.GetInfrastructureMonitorSnapshot(WellknownInfrastructureMonitors.EntryPoint);
        var value = (bool)snapshot.Values.Single(o => o.Id == WellknownSnapShotInfrastructureMonitorValues.DeferredReadyObject.GlobalIsReady).Data.Value;

        return value;
    }

    private void WaitIsReady()
    {
        WaitHelpers.TimeOut(
            () =>
            {
                try
                {
                    return GetEntryPointIsReady();
                }
                catch
                {
                    return false;
                }
            },
            TimeSpan.FromSeconds(30),
            () =>
            {
                try
                {
                    return $"IsReady = {GetEntryPointIsReady()}"
                           + Environment.NewLine
                           + CollectLogs();
                }
                catch (Exception exception)
                {
                    return ("InfrastructureMonitorClient Exception => "
                            + Environment.NewLine
                            + exception
                            + Environment.NewLine
                            + CollectLogs());
                }
            });

        WaitHelpers.TimeOut(
            () =>
            {
                try
                {
                    return GetEntryPointGlobalIsReady();
                }
                catch
                {
                    return false;
                }
            },
            TimeSpan.FromSeconds(30),
            () =>
            {
                try
                {
                    return $"GlobalIsReady = {GetEntryPointGlobalIsReady()}"
                           + Environment.NewLine
                           + CollectLogs();
                }
                catch (Exception exception)
                {
                    return ("InfrastructureMonitorClient Exception => "
                            + Environment.NewLine
                            + exception
                            + Environment.NewLine
                            + CollectLogs());
                }
            });
    }

    public string CollectLogs()
    {
        var text = new StringBuilder();
        foreach (var file in Directory.GetFiles(m_appPath, "Acme.DemoServer.Processing.Application.log.*.txt"))
        {
            try
            {
                text.AppendLine();
                text.AppendLine("----------------------------------------------------------------------");
                text.AppendLine(file);
                text.AppendLine("----------------------------------------------------------------------");
                text.AppendLine();

                using var stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var reader = new StreamReader(stream, Encoding.UTF8);
                var content = reader.ReadToEnd();
                text.AppendLine(content);
            }
            catch
            {
                /* NONE */
            }
        }

        return text.ToString();
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AttachConsole(uint dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern bool FreeConsole();

    [DllImport("kernel32.dll")]
    static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate? handler, bool add);

    delegate bool ConsoleCtrlDelegate(CtrlTypes type);

    enum CtrlTypes : uint
    {
        CtrlCEvent = 0,
    }

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);
}

