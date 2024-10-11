using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;

/// <summary>
/// Сценарий задачи с отложенным запуском - задержка исполнения.
/// </summary>
[Description("Сценарий задачи с отложенным запуском - задержка исполнения")]
public sealed class DemoDelayTaskScenarioAsDelay : DemoDelayTaskScenario
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private DemoDelayTaskScenarioAsDelay(DemoDelayTaskScenarioAsDelay other)
        : this()
    {
        Delay = other.Delay;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoDelayTaskScenarioAsDelay()
        : base(DemoDelayTaskScenariosType.Delay)
    {
    }

    /// <summary>
    /// Интервал задержки исполнения.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [Description("Интервал задержки исполнения")]
    public TimeSpan Delay;

    public override object Clone()
    {
        var result = new DemoDelayTaskScenarioAsDelay(this);

        return result;
    }
}