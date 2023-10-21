using NUnit.Framework;
using ShtrihM.DemoServer.Common;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.DemoServer.Processing.Tests.Application;

[TestFixture]
public class TestsBuildEnviroment : BaseSlimTests
{
    private AppHost m_appHost;

    protected override void BeforeSetUp()
    {
        base.BeforeSetUp();

        m_validateConfiguration = false;
    }

    [SetUp]
    public void SetUp()
    {
        m_appHost = new AppHost(
            dbName: $"test_{Constants.ProductTag.ToLower()}_enviroment",
            buildEnviroment: true);
        try
        {
            m_appHost.Start();
        }
        catch
        {
            m_appHost.Stop();
            m_appHost.SilentDispose();
            m_appHost = null;

            throw;
        }
    }

    [TearDown]
    public void TearDown()
    {
        m_appHost?.Stop();
        m_appHost.SilentDispose();
        m_appHost = null;
    }

    [Test]
    [Timeout(TestTimeout.Short)]
    [Explicit]
    public void Test()
    {
    }
}