using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;

/// <summary>
/// Сценарий задачи с отложенным запуском.
/// </summary>
[JsonConverter(typeof(JsonSubtypes), nameof(Type))]
[JsonSubtypes.KnownSubType(typeof(DemoDelayTaskScenarioAsDelay), DemoDelayTaskScenariosType.Delay)]
[Description("Сценарий задачи с отложенным запуском")]
public abstract class DemoDelayTaskScenario
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
}