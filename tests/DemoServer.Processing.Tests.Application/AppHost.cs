using Newtonsoft.Json;
using NUnit.Framework;
using ShtrihM.DemoServer.Common;
using ShtrihM.DemoServer.Processing.Application;
using ShtrihM.DemoServer.Processing.Application.Startups;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql;
using ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Common.Interfaces;
using ShtrihM.Wattle3.Infrastructures.Rest.Clients.Monitors;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;
using ShtrihM.Wattle3.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using Path = System.IO.Path;

namespace ShtrihM.DemoServer.Processing.Tests.Application;

public class AppHost : IDisposable
{
    private bool m_freeAll;
    private StreamReader m_output;

    public readonly string DbName;
    public readonly string DbConnectionString;
    public readonly string ServerConnectionString;
    public readonly TestDirectory DirectoryLogs;
    public readonly bool DropDb;
    public readonly bool BuildEnviroment;
    public readonly bool BuildDb;
    public readonly string Tag;
    public readonly string AppPath;
    public Process Process { get; private set; }
    public readonly int PortApiProcessing;
    public readonly int PortApiMonitoring;
    public readonly Uri UrlApiProcessing;

    public AppHost(
        string configuration = null,
        bool dropDb = true,
        bool buildEnviroment = false,
        bool buildDb = true,
        string dbName = null,
        string tag = null,
        Guid? instanceId = null)
    {
        m_freeAll = true;

        DropDb = dropDb;
        BuildEnviroment = buildEnviroment;
        BuildDb = buildDb;
        DbName = dbName ?? $"test_{Constants.ProductTag.ToLower()}_" + DateTime.Now.ToString("yyyMMddhhmmss") + "_" + Guid.NewGuid().ToString("N");
        Tag = tag ?? Environment.StackTrace;
        configuration ??= Testing.BaseTests.Configuration;
        AppPath = ProviderProjectBasePath.GetFullPath($@"src\DemoServer.Processing.Application\bin\{configuration}\net7.0-windows\win-x64");
        DirectoryLogs = new TestDirectory(Path.Combine(AppPath, "Logs"), BuildEnviroment == false);
        PortApiProcessing = Constants.DefaultPortApiProcessing;
        PortApiMonitoring = Constants.DefaultPortApiProcessingMonitoring;
        UrlApiProcessing = new Uri($"http://localhost:{PortApiProcessing}");

        /*
        Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
        Файл с настройками реестра.
        src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
        */
        ServerConnectionString = PostgreSqlDbHelper.GetServerConnectionString(userCredentials: BaseDbTests.PostgreSqlUserCredentials, serverAdress: BaseDbTests.PostgreSqlServerAdress);

        /*
        Если адрес, логин и пароль БД PostgreSQL не указаны явно то они берутся из реестра Windows.
        Файл с настройками реестра.
        src\DemoServer.Testing\WindowsRegisterTestingEnvirioment.reg
        */
        DbConnectionString = PostgreSqlDbHelper.GetDatabaseConnectionString(DbName, userCredentials: BaseDbTests.PostgreSqlUserCredentials, serverAdress: BaseDbTests.PostgreSqlServerAdress);
    }

    public void Start(
        Action<SystemSettings> updateSystemSettings = null,
        bool showWindow = false)
    {
        try
        {
            m_freeAll = true;

            var systemSettings = SystemSettings.GetDefault();
            systemSettings.ConnectionString.Value = DbConnectionString;
            updateSystemSettings?.Invoke(systemSettings);

            WaitHelpers.TimeOut(
                () => NetHelpers.IsOpenTcpIpPort(PortApiProcessing) == false,
                TimeSpan.FromMinutes(1));

            WaitHelpers.TimeOut(
                () => NetHelpers.IsOpenTcpIpPort(PortApiMonitoring) == false,
                TimeSpan.FromMinutes(1));

            WaitHelpers.TimeOut(
                () =>
                {
                    using var mutex = WebApplicationBuilderExtensions.CreateMutex(systemSettings.InstanceId.Value, out var mutexCreatedNew);

                    return mutexCreatedNew;
                },
                TimeSpan.FromMinutes(1));

            if (BuildDb)
            {
                try
                {
                    PostgreSqlDbHelper.DropDb(
                        DbName,
                        serverConnectionString: ServerConnectionString);
                }
                catch
                {
                    /* NONE */
                }

                var sqlScript = Deploy.GetSqlScript();
                PostgreSqlDbHelper.CreateDb(
                    DbName, 
                    tag: Tag, 
                    sqlScript: sqlScript,
                    serverConnectionString: ServerConnectionString,
                    databaseConnectionString: DbConnectionString);

                Model.Environment.BaseDbTests.DefineRandomDbSequences(DbConnectionString);
            }

            m_freeAll = false;

            DoStartApplication(systemSettings, showWindow);

            WaitIsReady();
        }
        catch
        {
            FreeAll();

            throw;
        }
    }

    public void Stop(bool silentMode = false)
    {
        m_freeAll = false;

        if (Process != null)
        {
            string output = null;
            var hasException = false;
            try
            {
                FreeConsole();
                AttachConsole((uint)Process.Id);
                SetConsoleCtrlHandler(null, true);
                GenerateConsoleCtrlEvent(CtrlTypes.CtrlCEvent, 0);

                output = m_output.ReadToEnd();

                if (false == Process.WaitForExit((int)TimeSpan.FromSeconds(30).TotalMilliseconds))
                {
                    Process.Kill(true);
                    Process.WaitForExit();
                }

                FreeConsole();
                SetConsoleCtrlHandler(null, false);

                Assert.AreEqual(0, Process.ExitCode, CollectLogs());
            }
            catch (Exception exception)
            {
                Console.WriteLine("- [Processing : Консоль приложения] << -----------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine(output);
                Console.WriteLine();
                Console.WriteLine("- [Processing : Консоль приложения] >> -----------------------------------------------------");

                if (false == silentMode)
                {
                    hasException = true;

                    ExceptionDispatchInfo.Capture(exception).Throw();
                }
            }
            finally
            {
                try
                {
                    Process.Refresh();
                }
                catch
                {
                    /* NONE */
                }
                try
                {
                    if (false == Process.HasExited)
                    {
                        Process.Kill(true);
                        Process.WaitForExit();
                    }
                }
                catch
                {
                    /* NONE */
                }

                Process.SilentDispose();
                Process = null;

                if (hasException)
                {
                    DoFinalize();
                }
            }
        }

        DoFinalize();
    }

    private void DoFinalize()
    {
        if (BuildEnviroment)
        {
            return;
        }

        DirectoryLogs.SilentDispose();

        if (BuildDb && DropDb)
        {
            try
            {
                PostgreSqlDbHelper.DropDb(
                    DbName,
                    serverConnectionString: ServerConnectionString);
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
    }

    private void FreeAll()
    {
        if (false == m_freeAll)
        {
            return;
        }

        if (Process != null)
        {
            try
            {
                Process.Refresh();
            }
            catch
            {
                /* NONE */
            }
            try
            {
                Process.Kill(true);
                Process.WaitForExit(TimeSpan.FromSeconds(30));
            }
            catch
            {
                /* NONE */
            }

            Process.SilentDispose();
            Process = null;
        }

        DirectoryLogs.DeleteDirectoryOnDispose = true;

        DirectoryLogs.SilentDispose();

        if (DbName != null)
        {
            try
            {
                PostgreSqlDbHelper.DropDb(
                    DbName,
                    serverConnectionString: ServerConnectionString);
            }
            catch
            {
                /* NONE */
            }
        }
    }

    private void DoStartApplication(SystemSettings systemSettings, bool showWindow)
    {
        var pathAppSettings = Path.Combine(AppPath, Program.FileNameOfAppSettings);
        var textAppSettings = File.ReadAllText(pathAppSettings);
        var appSettings = JsonConvert.DeserializeObject<dynamic>(textAppSettings);
        var systemSettingsDeserializeObject = JsonConvert.DeserializeObject<dynamic>(systemSettings.ToJsonText());
        Assert.IsNotNull(appSettings);
        appSettings.SystemSettings = systemSettingsDeserializeObject;
        textAppSettings = JsonConvert.SerializeObject(appSettings, Formatting.Indented);
        File.WriteAllText(pathAppSettings, textAppSettings);

        Process
            = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(AppPath, "ShtrihM.DemoServer.Processing.Application.exe"),
                    WorkingDirectory = AppPath,
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

        Process.StartInfo.EnvironmentVariables[EnvironmentVariablesHelpers.EnvironmentVariableAsLogsDir] = DirectoryLogs.BasePath;

        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine($"БД : {DbName}");
        Console.WriteLine();
        Console.WriteLine("Команда :");
        Console.WriteLine();
        Console.WriteLine($"SET {EnvironmentVariablesHelpers.EnvironmentVariableAsLogsDir}={DirectoryLogs.BasePath}");
        Console.WriteLine(Process.StartInfo.FileName);
        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine();

        var isStart = Process.Start();

        m_output = Process.StandardOutput;

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
        using var monitorsClient = new InfrastructureMonitorClient(port: PortApiMonitoring);

        var snapshot = monitorsClient.GetInfrastructureMonitorSnapshot(WellknownInfrastructureMonitors.EntryPoint);
        var value = (bool)snapshot.Values.Single(o => o.Id == WellknownSnapShotInfrastructureMonitorValues.DeferredReadyObject.IsReady).Data.Value;

        return value;
    }

    private bool GetEntryPointGlobalIsReady()
    {
        using var monitorsClient = new InfrastructureMonitorClient(port: PortApiMonitoring);

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
        foreach (var file in Directory.GetFiles(AppPath, "ShtrihM.DemoServer.Processing.Application.log.*.txt"))
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
    static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate handler, bool add);

    delegate bool ConsoleCtrlDelegate(CtrlTypes type);

    enum CtrlTypes : uint
    {
        CtrlCEvent = 0,
    }

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GenerateConsoleCtrlEvent(CtrlTypes dwCtrlEvent, uint dwProcessGroupId);
}

