using System;
using System.Reflection;

namespace ShtrihM.DemoServer.Common;

/// <summary>
/// Общие константы.
/// </summary>
public static class Constants
{
    static Constants()
    {
        var assembly = typeof(Constants).Assembly;
        if (assembly.IsDefined(typeof(AssemblyFileVersionAttribute), false))
        {
            var attibute = (AssemblyFileVersionAttribute)assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)[0];
            ProductBuildVersion = new(attibute.Version);
        }
        else
        {
            ProductBuildVersion = new(0, 0, 0, 0);
        }
        ProductVersion = assembly.GetName().Version;
    }

    /// <summary>
    /// Точность Сравнения Версий.
    /// </summary>
    public static readonly int VersionComparePrecision = 3;

    /// <summary>
    /// Версия продукта.
    /// </summary>
    public static readonly Version ProductVersion;

    /// <summary>
    /// Версия сборки продукта.
    /// </summary>
    public static readonly Version ProductBuildVersion;

    /// <summary>
    /// Порт API мониторинга.
    /// </summary>
    public const int DefaultPortApiProcessingMonitoring = 7702;

    /// <summary>
    /// Порт API прогцессинга.
    /// </summary>
    public const int DefaultPortApiProcessing = 7701;

    /// <summary>
    /// Имя проекта.
    /// </summary>
    public const string ProductTag = "DemoServer";
}