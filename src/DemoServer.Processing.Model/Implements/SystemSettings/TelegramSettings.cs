using Acme.Wattle.Json;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Acme.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки Telegram.
/// </summary>
[Description("Настройки Telegram")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public class TelegramSettings
{
    // ReSharper disable once ConvertConstructorToMemberInitializers
    public TelegramSettings()
    {
        Enabled =
            new SettingValue<bool>(default,
                "Разрешает отправку сообщений");

        ApiKey =
            new SettingValue<string>(default!,
                "Ключ API");

        ChatId =
            new SettingValue<long>(default,
                $"Идентификатор чата");
    }

    /// <summary>
    /// Разрешает отправку сообщений.
    /// </summary>
    [Description("Разрешает отправку сообщений")]
    public SettingValue<bool> Enabled { get; set; }

    /// <summary>
    /// Ключ API.
    /// </summary>
    [Description("Ключ API")]
    public SettingValue<string> ApiKey { get; set; }

    /// <summary>
    /// Идентификатор чата.
    /// </summary>
    [Description("Идентификатор чата")]
    public SettingValue<long> ChatId { get; set; }

    /// <summary>
    /// Настройки по умолчанию.
    /// </summary>
    public static TelegramSettings GetDefault()
    {
        return new TelegramSettings
        {
            ApiKey =
            {
                Value = "0:0",
            },

            ChatId =
            {
                Value = -1,
            },

            Enabled =
            {
                Value = true,
            },
        };
    }
}