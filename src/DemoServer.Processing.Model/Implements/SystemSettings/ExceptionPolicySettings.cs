using ShtrihM.Wattle3.Json;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки уведомления об исключениях системы.
/// </summary>
[Description("Настройки уведомления об исключениях системы")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public class ExceptionPolicySettings
{
    public ExceptionPolicySettings()
    {
        ControllersEnabledUnexpectedException =
            new SettingValue<bool>(default,
                @"Разрешение контроллерам уведомлять о неожиданных исключениях");
    }

    /// <summary>
    /// Разрешение контроллерам уведомлять о неожиданных исключениях.
    /// </summary>
    [Description("Разрешение контроллерам уведомлять о неожиданных исключениях")]
    public SettingValue<bool> ControllersEnabledUnexpectedException { get; set; }

    /// <summary>
    /// Настройки по умолчанию.
    /// </summary>
    public static ExceptionPolicySettings GetDefault()
    {
        return new()
        {
            ControllersEnabledUnexpectedException =
            {
                Value = false,
            },
        };
    }
}