using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.DataAccess.Interface;
using ShtrihM.Wattle3.Caching;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Json;

namespace ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки реестров доменных объектов.
/// </summary>
[Description("Настройки реестров доменных объектов")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public class DomainObjectRegistersSettings
{
    private static readonly int MemoryCacheMaxItems = 10_000;

    // ReSharper disable once ConvertConstructorToMemberInitializers
    // ReSharper disable once MemberCanBePrivate.Global
    public DomainObjectRegistersSettings()
    {
        MemoryCacheDemoObjectX =
            new(
                default!,
                $"Настройки кэширования реестра доменных объектов - {WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.DemoObjectX)}");

        UseIdentitiesServices =
            new(
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