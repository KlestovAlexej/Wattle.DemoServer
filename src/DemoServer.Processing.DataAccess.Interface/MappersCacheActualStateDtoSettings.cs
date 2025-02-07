﻿using Newtonsoft.Json;
using Acme.DemoServer.Processing.Common;
using Acme.Wattle.Caching;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Json;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Acme.DemoServer.Processing.DataAccess.Interface;

/// <summary>
/// Настройки кэшей актуальных данных состояний доменнй объектов в БД.
/// </summary>
[Description("Настройки кэшей актуальных данных состояний доменнй объектов в БД")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
[SuppressMessage("ReSharper", "PreferConcreteValueOverDefault")]
public class MappersCacheActualStateDtoSettings
{
    public static readonly TimeSpan DefaultExpirationTimeout = TimeSpan.FromMinutes(20);
    public static readonly TimeSpan DefaultPollingInterval = DefaultExpirationTimeout.Add(TimeSpan.FromMinutes(5));

    // ReSharper disable once ConvertConstructorToMemberInitializers
    // ReSharper disable once MemberCanBePrivate.Global
    public MappersCacheActualStateDtoSettings()
    {
        Enabled =
            new SettingValue<bool>(
                default,
                "Разрешение для кэширования");

        DemoObject =
            new SettingValue<MemoryCacheSettings>(
                default!,
                $"Маппер '{WellknownDomainObjectDisplayNames.DisplayNamesProvider!(WellknownDomainObjects.DemoObject)}'");

        DemoObjectX =
            new SettingValue<MemoryCacheSettings>(
                default!,
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
        return new MappersCacheActualStateDtoSettings
        {
            Enabled =
            {
                Value = true
            },

            DemoObject =
            {
                Value =
                    new MemoryCacheSettings
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
                    new MemoryCacheSettings
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