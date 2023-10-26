using System;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.Implements.ControllersServices;

public class ServerControllerService : IServerControllerService
{
    private readonly ICustomEntryPoint m_entryPoint;

    public ServerControllerService(ICustomEntryPoint entryPoint)
        // ReSharper disable once ConvertToPrimaryConstructor
    {
        m_entryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));
    }

    public MetaServerDescription GetDescription()
    {
        var result = m_entryPoint.ServerDescription;

        return result;
    }
}