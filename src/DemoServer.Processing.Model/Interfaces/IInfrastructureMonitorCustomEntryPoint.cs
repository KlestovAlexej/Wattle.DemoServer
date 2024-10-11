using Acme.Wattle.Infrastructures.Interfaces.Monitors;

namespace Acme.DemoServer.Processing.Model.Interfaces;

public interface IInfrastructureMonitorCustomEntryPoint : IInfrastructureMonitorEntryPoint
{
    /// <summary>
    /// Получить текущий снимок стостояния.
    /// </summary>
    /// <returns>Состояние.</returns>
    // ReSharper disable once UnusedMember.Global
    new ISnapShotInfrastructureMonitorCustomEntryPoint GetSnapShot();
}