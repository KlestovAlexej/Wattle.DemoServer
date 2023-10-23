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
        MemoryCacheDemoObjectX =
            new SettingValue<MemoryCacheSettings>(
                default,
                "Настройки кэширования реестра доменных объектов - Объект X");

        UseIdentitiesServices =
            new SettingValue<bool>(
                default,
                "Использовать реестры идентити объектов");
    }

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

            MemoryCacheDemoObjectX =
            {
                Value =
                    new()
                    {
                        ExpirationTimeout =
                        {
                            Value = MappersCacheActualStateDtoSettings.DefaultExpirationTimeout,
                        },
                        Enabled =
                        {
                            Value = true
                        },
                        PollingInterval =
                        {
                            Value = MappersCacheActualStateDtoSettings.DefaultPollingInterval,
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