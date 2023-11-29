using NUnit.Framework;
using ShtrihM.DemoServer.Common;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.DemoServer.Processing.Tests.Application;

[TestFixture]
public class TestsBuildEnviroment : BaseSlimTests
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private AppHost m_appHost;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected override void BeforeSetUp()
    {
        base.BeforeSetUp();

        m_validateConfiguration = false;
    }

    [SetUp]
    public void SetUp()
    {
        m_appHost = new(
            dbName: $"test_{Constants.ProductTag.ToLower()}_enviroment",
            buildEnviroment: true);
        try
        {
            m_appHost.Start();
        }
        catch
        {
            // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
            m_appHost?.Stop();
            CommonWattleExtensions.SilentDisposeAndFree(ref m_appHost!);

            throw;
        }
    }

    [TearDown]
    public void TearDown()
    {
        // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
        m_appHost?.Stop();
        CommonWattleExtensions.SilentDisposeAndFree(ref m_appHost!);
    }

    [Test]
    [Timeout(TestTimeout.Short)]
    [Explicit]
    [Description("Создать среду для ручного запуска сервера")]
    public void Test()
    {
    }
}