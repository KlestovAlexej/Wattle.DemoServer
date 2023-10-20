using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Testing;

namespace ShtrihM.DemoServer.Processing.Tests.Model;

[TestFixture]
public class TestsSystemSettings : BaseSlimTests
{
    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test()
    {
        var instance = SystemSettings.GetDefault();
        var text = instance.ToJsonText(true);
        var instance2 = text.FromJson<SystemSettings>();
        var text2 = instance2.ToJsonText(true);
        Assert.AreEqual(text, text2, text2);
    }
}