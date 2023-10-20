using NUnit.Framework;
using ShtrihM.Wattle3.Testing;

namespace ShtrihM.DemoServer.Processing.Tests.Model.Environment;

public abstract class BaseTestsDomainObjects : BaseTestsWithEntryPoint
{
    [SetUp]
    public void BaseTestsDomainObjects_SetUp()
    {
        m_entryPoint.Start();

        WaitHelpers.TimeOut(() => m_entryPoint.IsReady, WaitTimeout, GetDbLogs);
        WaitHelpers.TimeOut(() => m_entryPoint.GlobalIsReady, WaitTimeout, GetDbLogs);
    }
}