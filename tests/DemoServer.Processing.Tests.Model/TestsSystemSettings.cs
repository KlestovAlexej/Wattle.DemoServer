using NUnit.Framework;
using Acme.DemoServer.Processing.Model.Implements.SystemSettings;
using Acme.DemoServer.Testing;
using Acme.Wattle.Json.Extensions;
using Acme.Wattle.Testing;

namespace Acme.DemoServer.Processing.Tests.Model;

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