using NUnit.Framework;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Testing;

namespace ShtrihM.DemoServer.Processing.Tests.Model.Environment;

public abstract class BaseTestsDomainObjects : BaseTestsWithEntryPoint
{
    [SetUp]
    public void BaseTestsDomainObjects_SetUp()
    {
        m_entryPoint.Start();

        WaitHelpers.TimeOut(() => m_entryPoint.IsReady, WaitTimeout, () => GetDbLogs() + System.Environment.NewLine + m_entryPoint.InfrastructureMonitor.GetSnapShot().ToJsonText(true));
        WaitHelpers.TimeOut(() => m_entryPoint.GlobalIsReady, WaitTimeout, () => GetDbLogs() + System.Environment.NewLine + m_entryPoint.InfrastructureMonitor.GetSnapShot().ToJsonText(true));
    }
}