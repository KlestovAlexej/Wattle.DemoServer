using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Acme.Wattle.Json;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.ScenarioStates;

/// <summary>
/// Состояние сценария задачи с отложенным запуском.
/// </summary>
[JsonConverter(typeof(JsonSubtypes), nameof(Type))]
[JsonSubtypes.KnownSubType(typeof(DemoCycleTaskScenarioStateAsCycle), DemoDelayTaskScenarioStatesType.Cycle)]
[Description("Состояние сценария задачи с отложенным запуском")]
[SmartJsonDeserializerBase(typeof(DemoCycleTaskScenarioState))]
public abstract class DemoCycleTaskScenarioState : ICloneable
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    protected DemoCycleTaskScenarioState(DemoDelayTaskScenarioStatesType type)
    {
        Type = type;
    }

    /// <summary>
    /// Тип состояния сценария.
    /// </summary>
    [Description("Тип состояния сценария")]
    [JsonProperty(Required = Required.Always)]
    [EnumDataType(typeof(DemoDelayTaskScenarioStatesType))]
    [JsonConverter(typeof(StringEnumConverter))]
    public readonly DemoDelayTaskScenarioStatesType Type;

    public abstract object Clone();
}