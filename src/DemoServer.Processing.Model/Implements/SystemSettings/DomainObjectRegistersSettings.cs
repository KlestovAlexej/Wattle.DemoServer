using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.DataAccess.Interface;
using Acme.Wattle.Caching;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Json;

namespace Acme.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки реестров доменных объектов.
/// </summary>
[Description("Настройки реестров доменных объектов")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public sealed class DomainObjectRegistersSettings
{
    private static readonly int MemoryCacheMaxItems = 10_000;

    // ReSharper disable once ConvertConstructorToMemberInitializers
    // ReSharper disable once MemberCanBePrivate.Global
    public DomainObjectRegistersSettings()
    {
        MemoryCacheDemoObjectX =
            new SettingValue<MemoryCacheSettings>(
                default!,
                $"Настройки кэширования реестра доменных объектов - {WellknownDomainObjectDisplayNames.DisplayNamesProvider(WellknownDomainObjects.DemoObjectX)}");

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
        return new DomainObjectRegistersSettings
        {
            UseIdentitiesServices =
            {
                Value = true,
            },

            MemoryCacheDemoObjectX =
            {
                Value =
                    new MemoryCacheSettings
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