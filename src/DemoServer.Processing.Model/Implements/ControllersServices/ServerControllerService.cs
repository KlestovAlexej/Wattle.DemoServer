using System.Runtime.CompilerServices;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.Common.Interfaces;

namespace Acme.DemoServer.Processing.Model.Implements.ControllersServices;

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