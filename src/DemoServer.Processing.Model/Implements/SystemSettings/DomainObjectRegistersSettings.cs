using System;
using System.ComponentModel;
using Newtonsoft.Json;
using ShtrihM.DemoServer.Processing.DataAccess.Interface;
using ShtrihM.Wattle3.Caching;
using ShtrihM.Wattle3.Json;

namespace ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки реестров доменных объектов.
/// </summary>
[Description("Настройки реестров доменных объектов")]
public class DomainObjectRegistersSettings
{
    public static readonly int MemoryCacheMaxItems = 10_000;

    public DomainObjectRegistersSettings()
    {
        InitializeEmergencyTimeout =
            new SettingValue<TimeSpan>(
                default,
                @"Аварийный интервал ожидания инициализации реестра доменных объектов");

        MemoryCacheDemoObjectX =
            new SettingValue<MemoryCacheSettings>(
                default,
                @"Настройки кэширования реестра доменных объектов - Объект X");

        UseIdentitiesServices =
            new SettingValue<bool>(
                default,
                @"Использовать реестры идентити объектов");
    }

    /// <summary>
    /// Аварийный интервал ожидания инициализации реестра доменных объектов.
    /// </summary>
    [JsonRequired]
    public SettingValue<TimeSpan> InitializeEmergencyTimeout { get; set; }

    /// <summary>
    /// Настройки кэширования реестра доменных объектов - Объект X.
    /// </summary>
    [Description("Настройки кэширования реестра доменных объектов - Объект X")]
    [JsonRequired]
    public SettingValue<MemoryCacheSettings> MemoryCacheDemoObjectX { get; set; }

    /// <summary>
    /// Использовать реестры идентити объектов.
    /// </summary>
    [JsonRequired]
    public SettingValue<bool> UseIdentitiesServices { get; set; }

    /// <summary>
    /// Настройки по умолчанию.
    /// </summary>
    public static DomainObjectRegistersSettings GetDefault()
    {
        return new()
        {
            UseIdentitiesServices =
            {
                Value = true,
            },

            InitializeEmergencyTimeout =
            {
                Value = TimeSpan.FromSeconds(3)
            },

            MemoryCacheDemoObjectX =
            {
                Value =
                    new()
                    {
                        ExpirationTimeout =
                        {
                            Value = MappersCacheActualStateDtoSettings.InteractiveExpirationTimeout,
                        },
                        Enabled =
                        {
                            Value = true
                        },
                        PollingInterval =
                        {
                            Value = MappersCacheActualStateDtoSettings.InteractivePollingInterval,
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
                            Value = MemoryCacheMaxItems
                        },
                    }
            },
        };
    }
}