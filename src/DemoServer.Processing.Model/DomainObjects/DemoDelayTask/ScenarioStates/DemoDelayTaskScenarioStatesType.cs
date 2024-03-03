using System.ComponentModel;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.ScenarioStates;

/// <summary>
/// Типы состояний сценариев задач с отложенным запуском.
/// </summary>
[Description("Типы состояний сценариев задач с отложенным запуском")]
public enum DemoDelayTaskScenarioStatesType
{
    /// <summary>
    /// Циклическое исполнение.
    /// </summary>
    [Description("Циклическое исполнение")]
    Cycle = 1,
}
