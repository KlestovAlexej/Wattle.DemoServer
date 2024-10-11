using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Acme.Wattle.Json;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;

/// <summary>
/// Сценарий задачи с отложенным запуском.
/// </summary>
[JsonConverter(typeof(JsonSubtypes), nameof(Type))]
[JsonSubtypes.KnownSubType(typeof(DemoDelayTaskScenarioAsDelay), DemoDelayTaskScenariosType.Delay)]
[JsonSubtypes.KnownSubType(typeof(DemoDelayTaskScenarioAsCycle), DemoDelayTaskScenariosType.Cycle)]
[Description("Сценарий задачи с отложенным запуском")]
[SmartJsonDeserializerBase(typeof(DemoDelayTaskScenario))]
public abstract class DemoDelayTaskScenario : ICloneable
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    protected DemoDelayTaskScenario(DemoDelayTaskScenariosType type)
    {
        Type = type;
    }

    /// <summary>
    /// Тип сценария.
    /// </summary>
    [Description("Тип сценария")]
    [JsonProperty(Required = Required.Always)]
    [EnumDataType(typeof(DemoDelayTaskScenariosType))]
    [JsonConverter(typeof(StringEnumConverter))]
    public readonly DemoDelayTaskScenariosType Type;

    public abstract object Clone();
}