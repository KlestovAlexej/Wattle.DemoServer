using System.Runtime.CompilerServices;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.Implements.ControllersServices;

public sealed class ServerControllerService : IServerControllerService
{
    private readonly ICustomEntryPoint m_entryPoint;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    public ServerControllerService(ICustomEntryPoint entryPoint)
    {
        m_entryPoint = entryPoint;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MetaServerDescription GetDescription()
    {
        var result = m_entryPoint.ServerDescription;

        return result;
    }
}