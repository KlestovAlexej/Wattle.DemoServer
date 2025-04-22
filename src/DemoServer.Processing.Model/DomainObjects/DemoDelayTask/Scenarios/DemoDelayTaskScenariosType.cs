using System.ComponentModel;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;

/// <summary>
/// Типы сценариев задач с отложенным запуском.
/// </summary>
[Description("Типы сценариев задач с отложенным запуском")]
public enum DemoDelayTaskScenariosType
{
    /// <summary>
    /// Задержка исполнения.
    /// </summary>
    [Description("Задержка исполнения")]
    Delay = 1,

    /// <summary>
    /// Циклическое исполнение.
    /// </summary>
    [Description("Циклическое исполнение")]
    Cycle = 2,

    /// <summary>
    /// Отравленный сценарий - приводит к остановке обработке всех задач.
    /// </summary>
    [Description("Отравленный сценарий - приводит к остановке обработке всех задач")]
    Poisoned = 3,

    /// <summary>
    /// Пустая задача.
    /// </summary>
    [Description("Пустая задача")]
    Empty = 4,
}
