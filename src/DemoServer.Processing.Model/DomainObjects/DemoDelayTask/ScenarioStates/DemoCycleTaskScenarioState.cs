using Acme.Wattle.Json;
using JsonSubTypes;
using MessagePack;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.ScenarioStates;

/// <summary>
/// Состояние сценария задачи с отложенным запуском.
/// </summary>
[JsonConverter(typeof(JsonSubtypes), nameof(Type))]
[JsonSubtypes.KnownSubType(typeof(DemoCycleTaskScenarioStateAsCycle), DemoDelayTaskScenarioStatesType.Cycle)]
[Description("Состояние сценария задачи с отложенным запуском")]
[SmartDeserializerBase(typeof(DemoCycleTaskScenarioState))]
[Union((int)DemoDelayTaskScenarioStatesType.Cycle, typeof(DemoCycleTaskScenarioStateAsCycle))]
public abstract class DemoCycleTaskScenarioState : ICloneable
{
    protected const int KeyStart = 0;

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
    [IgnoreMember, JsonProperty(Required = Required.Always)]
    [EnumDataType(typeof(DemoDelayTaskScenarioStatesType))]
    [JsonConverter(typeof(StringEnumConverter))]
    public readonly DemoDelayTaskScenarioStatesType Type;

    public abstract object Clone();
}