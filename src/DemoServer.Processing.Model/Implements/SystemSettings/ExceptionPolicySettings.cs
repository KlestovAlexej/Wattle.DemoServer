using Acme.Wattle.Json;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Acme.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки уведомления об исключениях системы.
/// </summary>
[Description("Настройки уведомления об исключениях системы")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public sealed class ExceptionPolicySettings
{
    public ExceptionPolicySettings()
    {
        ControllersEnabledUnexpectedException =
            new SettingValue<bool>(default,
                "Разрешение контроллерам уведомлять о неожиданных исключениях");

        UnexpectedExceptionSendToTelegram =
            new SettingValue<bool>(default,
                @"Разрешение уведомлять о неожиданных исключениях в Telegram");

        TimeoutUnexpectedExceptionSendToTelegram =
            new SettingValue<TimeSpan>(default,
                "Интервал отправки уведомлений о неожиданных исключениях в Telegram");
    }

    /// <summary>
    /// Разрешение контроллерам уведомлять о неожиданных исключениях.
    /// </summary>
    [Description("Разрешение контроллерам уведомлять о неожиданных исключениях")]
    public SettingValue<bool> ControllersEnabledUnexpectedException { get; set; }

    /// <summary>
    /// Разрешение уведомлять о неожиданных исключениях в Telegram.
    /// </summary>
    [Description("Разрешение уведомлять о неожиданных исключениях в Telegram")]
    public SettingValue<bool> UnexpectedExceptionSendToTelegram { get; set; }

    /// <summary>
    /// Интервал отправки уведомлений о неожиданных исключениях в Telegram.
    /// </summary>
    [Description("Интервал отправки уведомлений о неожиданных исключениях в Telegram")]
    public SettingValue<TimeSpan> TimeoutUnexpectedExceptionSendToTelegram { get; set; }

    /// <summary>
    /// Настройки по умолчанию.
    /// </summary>
    public static ExceptionPolicySettings GetDefault()
    {
        return new ExceptionPolicySettings
        {
            ControllersEnabledUnexpectedException =
            {
                Value = true,
            },

            TimeoutUnexpectedExceptionSendToTelegram =
            {
                Value = TimeSpan.FromMinutes(30),
            },

            UnexpectedExceptionSendToTelegram =
            {
                Value = true,
            },
        };
    }
}