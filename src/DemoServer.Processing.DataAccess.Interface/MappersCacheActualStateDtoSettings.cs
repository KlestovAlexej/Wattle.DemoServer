using Newtonsoft.Json;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.Caching;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Json;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ShtrihM.DemoServer.Processing.DataAccess.Interface;

/// <summary>
/// Настройки кэшей актуальных данных состояний доменнй объектов в БД.
/// </summary>
[Description("Настройки кэшей актуальных данных состояний доменнй объектов в БД")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public class MappersCacheActualStateDtoSettings
{
    public static readonly TimeSpan DefaultExpirationTimeout = TimeSpan.FromMinutes(20);
    public static readonly TimeSpan DefaultPollingInterval = DefaultExpirationTimeout.Add(TimeSpan.FromMinutes(5));

    // ReSharper disable once ConvertConstructorToMemberInitializers
    // ReSharper disable once MemberCanBePrivate.Global
    public MappersCacheActualStateDtoSettings()
    {
        Enabled =
            new(
                default,
                "Разрешение для кэширования");

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
    /// Разрешение для кэширования.
    /// </summary>
    [Description("Разрешение для кэширования")]
    public SettingValue<bool> Enabled { get; set; }

    /// <summary>
    /// Настройки маппера - Объект.
    /// </summary>
    [Description("Настройки маппера - Объект")]
    [JsonRequired]
    public SettingValue<MemoryCacheSettings> DemoObject { get; set; }

    /// <summary>
    /// Настройки маппера - Объект X.
    /// </summary>
    [Description("Настройки маппера - Объект X")]
    [JsonRequired]
    public SettingValue<MemoryCacheSettings> DemoObjectX { get; set; }

    /// <summary>
    /// Настройки по умолчанию.
    /// </summary>
    public static MappersCacheActualStateDtoSettings GetDefault()
    {
        return new()
        {
            Enabled =
            {
                Value = true
            },

            DemoObject =
            {
                Value =
                    new()
                    {
                        ExpirationTimeout =
                        {
                            Value = DefaultExpirationTimeout,
                        },
                        Enabled =
                        {
                            Value = true
                        },
                        PollingInterval =
                        {
                            Value = DefaultPollingInterval
                        },
                        ActiveExpired =
                        {
                            Value = true
                        },
                        ExpirationMode =
                        {
                            Value = MemoryCacheSettings.ExpirationTimeoutMode.Absolute
                        },
                        FillFactor =
                        {
                            Value = 99
                        },
                        FoundBehavior =
                        {
                            Value = MemoryCacheSettings.FoundBehaviorMode.None
                        },
                        MaxItems =
                        {
                            Value = 100_000
                        },
                    }
            },

            DemoObjectX =
            {
                Value =
                    new()
                    {
                        ExpirationTimeout =
                        {
                            Value = DefaultExpirationTimeout,
                        },
                        Enabled =
                        {
                            Value = true
                        },
                        PollingInterval =
                        {
                            Value = DefaultPollingInterval
                        },
                        ActiveExpired =
                        {
                            Value = true
                        },
                        ExpirationMode =
                        {
                            Value = MemoryCacheSettings.ExpirationTimeoutMode.Absolute
                        },
                        FillFactor =
                        {
                            Value = 99
                        },
                        FoundBehavior =
                        {
                            Value = MemoryCacheSettings.FoundBehaviorMode.None
                        },
                        MaxItems =
                        {
                            Value = 100_000
                        },
                    }
            },
        };
    }
}