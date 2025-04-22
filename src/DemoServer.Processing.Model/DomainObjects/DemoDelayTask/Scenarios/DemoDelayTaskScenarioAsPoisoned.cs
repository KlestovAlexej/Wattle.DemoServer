using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;

/// <summary>
/// Сценарий задачи с отложенным запуском - отравленный сценарий - приводит к остановке обработке всех задач.
/// </summary>
[Description("Сценарий задачи с отложенным запуском - отравленный сценарий - приводит к остановке обработке всех задач")]
public sealed class DemoDelayTaskScenarioAsPoisoned : DemoDelayTaskScenario
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoDelayTaskScenarioAsPoisoned()
        : base(DemoDelayTaskScenariosType.Poisoned)
    {
    }

    public override object Clone()
    {
        var result = new DemoDelayTaskScenarioAsPoisoned();

        return result;
    }
}