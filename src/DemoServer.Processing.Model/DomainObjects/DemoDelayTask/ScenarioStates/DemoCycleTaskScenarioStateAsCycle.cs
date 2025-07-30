#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MessagePack;
using Newtonsoft.Json;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.ScenarioStates;

/// <summary>
/// Состояние сценария задачи с отложенным запуском - циклическое исполнение.
/// </summary>
[Description("Состояние сценария задачи с отложенным запуском - циклическое исполнение")]
[MessagePackObject]
public sealed class DemoCycleTaskScenarioStateAsCycle : DemoCycleTaskScenarioState
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private DemoCycleTaskScenarioStateAsCycle(DemoCycleTaskScenarioStateAsCycle other)
        : this()
    {
        Index = other.Index;
        RunDate = [..other.RunDate];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoCycleTaskScenarioStateAsCycle()
        : base(DemoDelayTaskScenarioStatesType.Cycle)
    {
    }

    /// <summary>
    /// Индекс.
    /// </summary>
    [Key(KeyStart + 1), JsonProperty(Required = Required.Always)]
    [Description("Индекс")]
    public int Index;

    /// <summary>
    /// Дата-время запуска циклов.
    /// </summary>
    [Key(KeyStart + 2), JsonProperty(Required = Required.Always)]
    [Description("Дата-время запуска циклов")]
    public List<DateTimeOffset> RunDate;

    public override object Clone()
    {
        var result = new DemoCycleTaskScenarioStateAsCycle(this);

        return result;
    }
}