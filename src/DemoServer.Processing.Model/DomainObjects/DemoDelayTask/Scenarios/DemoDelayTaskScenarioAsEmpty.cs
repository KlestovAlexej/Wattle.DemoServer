using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Acme.DemoServer.Processing.Model.DomainObjects.DemoDelayTask.Scenarios;

/// <summary>
/// Сценарий задачи с отложенным запуском - пустая задача.
/// </summary>
[Description("Сценарий задачи с отложенным запуском - пустая задача")]
public sealed class DemoDelayTaskScenarioAsEmpty : DemoDelayTaskScenario
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoDelayTaskScenarioAsEmpty()
        : base(DemoDelayTaskScenariosType.Empty)
    {
    }

    public override object Clone()
    {
        var result = new DemoDelayTaskScenarioAsEmpty();

        return result;
    }
}