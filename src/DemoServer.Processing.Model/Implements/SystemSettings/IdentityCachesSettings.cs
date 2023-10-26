using Newtonsoft.Json;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.Json;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки кэширующих провайдеров идентити объектов.
/// </summary>
[Description("Настройки кэширующих провайдеров идентити объектов")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public class IdentityCachesSettings
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once ConvertConstructorToMemberInitializers
    public IdentityCachesSettings()
    {
        SystemLog =
            new(
                default,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.SystemLog)}'");

        ChangeTracker =
            new(
                default,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.ChangeTracker)}'");

        DemoObject =
            new(
                default,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.DemoObject)}'");

        DemoObjectX =
            new(
                default,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.DemoObjectX)}'");
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