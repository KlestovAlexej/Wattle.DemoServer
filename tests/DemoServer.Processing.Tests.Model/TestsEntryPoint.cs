using NUnit.Framework;
using Acme.DemoServer.Processing.Tests.Model.Environment;
using Acme.Wattle.Testing;

namespace Acme.DemoServer.Processing.Tests.Model;

[TestFixture]
public class TestsEntryPoint : BaseTestsWithEntryPoint
{
    [Test]
    [Timeout(TestTimeout.Short)]
    [Category(TestCategory.Short)]
    public void Test_Start()
    {
        m_entryPoint.Start();

        WaitHelpers.TimeOut(() => m_entryPoint.IsReady, WaitTimeout, () => GetDbLogs());
        WaitHelpers.TimeOut(() => m_entryPoint.GlobalIsReady, WaitTimeout, () => GetDbLogs());
    }
}