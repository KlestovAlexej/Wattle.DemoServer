using ShtrihM.Wattle3.Json;
using System.ComponentModel;

namespace ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки уведомления об исключениях системы.
/// </summary>
[Description("Настройки уведомления об исключениях системы")]
public class ExceptionPolicySettings
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once ConvertConstructorToMemberInitializers
    public ExceptionPolicySettings()
    {
        ControllersEnabledUnexpectedException =
            new SettingValue<bool>(default,
                "Разрешение контроллерам уведомлять о неожиданных исключениях");
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
        return new ExceptionPolicySettings
        {
            ControllersEnabledUnexpectedException =
            {
                Value = false,
            },
        };
    }
}