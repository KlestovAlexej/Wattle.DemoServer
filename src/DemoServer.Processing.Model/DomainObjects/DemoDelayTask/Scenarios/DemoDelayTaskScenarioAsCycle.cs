using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;

/// <summary>
/// Сценарий задачи с отложенным запуском - циклическое исполнение.
/// </summary>
[Description("Сценарий задачи с отложенным запуском - циклическое исполнение")]
public sealed class DemoDelayTaskScenarioAsCycle : DemoDelayTaskScenario
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private DemoDelayTaskScenarioAsCycle(DemoDelayTaskScenarioAsCycle other)
        : this()
    {
        NextRunTimeout = other.NextRunTimeout;
        Count = other.Count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoDelayTaskScenarioAsCycle()
        : base(DemoDelayTaskScenariosType.Cycle)
    {
    }

    /// <summary>
    /// Количество шагов цикла.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [Description("Количество шагов цикла")]
    public int Count;

    /// <summary>
    /// Интервал задержки исполнения следующего шага цикла.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [Description("Интервал задержки исполнения следующего шага цикла")]
    public TimeSpan? NextRunTimeout;

    public override object Clone()
    {
        var result = new DemoDelayTaskScenarioAsCycle(this);

        return result;
    }
}