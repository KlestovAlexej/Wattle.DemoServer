using Newtonsoft.Json;
using ShtrihM.Wattle3.Json;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки пулов лок-объектов.
/// </summary>
[Description("Настройки пулов лок-объектов")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public sealed class LocksPoolSettings
{
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(3);

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once ConvertConstructorToMemberInitializers
    public LocksPoolSettings()
    {
        Update =
            new SettingValue<TimeSpan?>(
                default,
                "Интервал ожидания получение объекта из пула лок-объектов сценария обновления объекта");

        Any =
            new SettingValue<TimeSpan?>(
                default,
                "Интервал ожидания получение объекта из пула лок-объектов сценария действия по альтернативному ключу");
    }

    /// <summary>
    /// Интервал ожидания получение объекта из пула лок-объектов сценария обновления объекта.
    /// </summary>
    [JsonRequired]
    public SettingValue<TimeSpan?> Update { get; set; }

    /// <summary>
    /// Интервал ожидания получение объекта из пула лок-объектов произвольного сценария.
    /// </summary>
    [JsonRequired]
    public SettingValue<TimeSpan?> Any { get; set; }

    /// <summary>
    /// Настройки по умолчанию.
    /// </summary>
    public static LocksPoolSettings GetDefault()
    {
        return new LocksPoolSettings
        {
            Any =
            {
                Value = DefaultTimeout
            },
            Update =
            {
                Value = DefaultTimeout
            },
        };
    }
}