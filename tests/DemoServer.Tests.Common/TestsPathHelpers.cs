using System;
using System.IO;
using NUnit.Framework;
using Acme.DemoServer.Common;
using Acme.Wattle.Testing;
using BaseTests = Acme.DemoServer.Testing.BaseTests;

namespace Acme.DemoServer.Tests.Common;

[TestFixture]
public class TestsPathHelpers : BaseTests
{
    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public void Test()
    {
        var basePath = new DirectoryInfo(Path.GetDirectoryName(typeof(TestsPathHelpers).Assembly.Location)!).FullName;
        var path = PathHelpers.GetBasedPath(basePath, "TestsPathHelpers.cs");

        Console.WriteLine(path);
        Assert.AreEqual(Path.Combine(basePath, "TestsPathHelpers.cs"), path);
    }
}