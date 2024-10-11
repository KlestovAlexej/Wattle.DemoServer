using Newtonsoft.Json;
using Acme.DemoServer.Processing.Common;
using Acme.Wattle.DomainObjects.DomainObjectDataMappers;
using Acme.Wattle.Json;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Acme.Wattle.DomainObjects.Interfaces;

namespace Acme.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки кэширующих провайдеров идентити объектов.
/// </summary>
[Description("Настройки кэширующих провайдеров идентити объектов")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public sealed class IdentityCachesSettings
{
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once ConvertConstructorToMemberInitializers
    public IdentityCachesSettings()
    {
        SystemLog =
            new SettingValue<IdentityCacheSettings>(
                default!,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.SystemLog)}'");

        ChangeTracker =
            new SettingValue<IdentityCacheSettings>(
                default!,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.ChangeTracker)}'");

        DemoObject =
            new SettingValue<IdentityCacheSettings>(
                default!,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.DemoObject)}'");

        DemoObjectX =
            new SettingValue<IdentityCacheSettings>(
                default!,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.DemoObjectX)}'");

        DemoDelayTask =
            new SettingValue<IdentityCacheSettings>(
                default!,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.DemoDelayTask)}'");
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
    /// Настройки маппера - Задача с отложенным запуском.
    /// </summary>
    [Description("Настройки маппера - Задача с отложенным запуском")]
    [JsonRequired]
    public SettingValue<IdentityCacheSettings> DemoDelayTask { get; set; }

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

        return new IdentityCachesSettings
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

            DemoDelayTask =
            {
                Value =
                    IdentityCacheSettings.GetDefault(100_000, fillFactor)
            },
        };
    }
}