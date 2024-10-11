using Microsoft.Extensions.Logging;
using Acme.DemoServer.Common;
using System;
using System.IO;
using System.Linq;

namespace Acme.DemoServer.Processing.Application.Startups;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public static class EnvironmentVariablesHelpers
{
    private static readonly string NameLogsDir = "Logs";
    public static readonly string EnvironmentVariableAsLogsDir = "LOGS_DIR";

    public static void Print(ILogger logger)
    {
        var text = $@"
Переменные среды :
{EnvironmentVariableAsLogsDir} = {Environment.GetEnvironmentVariable(EnvironmentVariableAsLogsDir)}
";

        Console.WriteLine(text);
        WebApplicationBuilderExtensions.AddInformationEventLogMessage(text);
        logger.LogDebug(text);
    }

    public static void Define(string[] args, string? baseDirectoryName = null)
    {
        var basePath = new DirectoryInfo(baseDirectoryName ?? Path.GetDirectoryName(typeof(Program).Assembly.Location)!).FullName;

        #region Переменная среды %LOGS_DIR% - Путь хранения логов приложения

        var logsPath = Environment.GetEnvironmentVariable(EnvironmentVariableAsLogsDir);

        var argLogsPath = args.SingleOrDefault(arg => arg.StartsWith($"{EnvironmentVariableAsLogsDir}:", StringComparison.CurrentCultureIgnoreCase));
        if (argLogsPath != null)
        {
            logsPath = argLogsPath.Substring(EnvironmentVariableAsLogsDir.Length + 1);
        }

        if (string.IsNullOrEmpty(logsPath))
        {
            logsPath = Path.Combine(basePath, NameLogsDir);

            if (false == Directory.Exists(logsPath))
            {
                Directory.CreateDirectory(logsPath);
            }
        }
        else
        {
            logsPath = PathHelpers.GetBasedPath(basePath, logsPath);

            if (false == Directory.Exists(logsPath))
            {
                Directory.CreateDirectory(logsPath);
            }
            logsPath = new DirectoryInfo(logsPath).FullName;
        }
        Environment.SetEnvironmentVariable(EnvironmentVariableAsLogsDir, logsPath);

        #endregion
    }
}