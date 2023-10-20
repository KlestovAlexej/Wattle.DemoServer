using Newtonsoft.Json;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.Json;
using System.ComponentModel;

namespace ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки кэширующих провайдеров идентити объектов.
/// </summary>
[Description("Настройки кэширующих провайдеров идентити объектов")]
public class IdentityCachesSettings
{
    public IdentityCachesSettings()
    {
        SystemLog =
            new SettingValue<IdentityCacheSettings>(
                default,
                @$"Маппер '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.SystemLog)}'");

        ChangeTracker =
            new SettingValue<IdentityCacheSettings>(
                default,
                @$"Маппер '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.ChangeTracker)}'");

        DemoObject =
            new SettingValue<IdentityCacheSettings>(
                default,
                @$"Маппер '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObject)}'");

        DemoObjectX =
            new SettingValue<IdentityCacheSettings>(
                default,
                @$"Маппер '{WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.DemoObjectX)}'");
    }

    /// <summary>
    /// Настройки маппера - Системный лог.
    /// </summary>
    [Description("Настройки маппера - Системный лог")]
    [JsonRequired]
    public SettingValue<IdentityCacheSettings> SystemLog { get; set; }

    /// <summary>
    /// Настройки маппера - Контроль изменений.
    /// </summary>
    [Description("Настройки маппера - Контроль изменений")]
    [JsonRequired]
    public SettingValue<IdentityCacheSettings> ChangeTracker { get; set; }

    /// <summary>
    /// Настройки маппера - Объект.
    /// </summary>
    [Description("Настройки маппера - Объект")]
    [JsonRequired]
    public SettingValue<IdentityCacheSettings> DemoObject { get; set; }

    /// <summary>
    /// Настройки маппера - Объект X.
    /// </summary>
    [Description("Настройки маппера - Объект X")]
    [JsonRequired]
    public SettingValue<IdentityCacheSettings> DemoObjectX { get; set; }

    /// <summary>
    /// Настройки по умолчанию.
    /// </summary>
    public static IdentityCachesSettings GetDefault()
    {
        var fillFactor = 0.9f;

        return new()
        {
            SystemLog =
            {
                Value =
                    IdentityCacheSettings.GetDefault(10_000, fillFactor)
            },

            DemoObject =
            {
                Value =
                    IdentityCacheSettings.GetDefault(10_000, fillFactor)
            },

            DemoObjectX =
            {
                Value =
                    IdentityCacheSettings.GetDefault(10_000, fillFactor)
            },

            ChangeTracker =
            {
                Value =
                    IdentityCacheSettings.GetDefault(100_000, fillFactor)
            },
        };
    }
}