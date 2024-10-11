using System.Diagnostics.CodeAnalysis;
using Acme.Wattle.Infrastructures.Interfaces.Monitors;

namespace Acme.DemoServer.Processing.Model.Interfaces;

[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
public interface ISnapShotInfrastructureMonitorCustomEntryPoint : ISnapShotInfrastructureMonitorEntryPoint
{
    /// <summary>
    /// Идентификатор процесса сервера.
    /// </summary>
    string ProcessId { get; }

    /// <summary>
    /// Признак работы сервера в отладочном режиме.
    /// </summary>
    bool DebugMode { get; }
}