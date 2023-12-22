using System.Diagnostics.CodeAnalysis;
using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

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