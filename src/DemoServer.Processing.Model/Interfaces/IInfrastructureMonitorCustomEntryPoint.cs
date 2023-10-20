using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
using System.Diagnostics.CodeAnalysis;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IInfrastructureMonitorCustomEntryPoint : IInfrastructureMonitorEntryPoint
{
    /// <summary>
    /// Получить текущий снимок стостояния.
    /// </summary>
    /// <returns>Состояние.</returns>
    new ISnapShotInfrastructureMonitorCustomEntryPoint GetSnapShot();
}