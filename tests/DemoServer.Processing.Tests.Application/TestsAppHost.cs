using NUnit.Framework;
using Acme.DemoServer.Processing.Api.Clients;
using Acme.DemoServer.Testing;
using Acme.Wattle.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Acme.DemoServer.Processing.Tests.Application;

[TestFixture]
public class TestsAppHost : BaseSlimTests
{
    [Test]
    [Timeout(TestTimeout.Short)]
    [Category(TestCategory.Short)]
    public async Task Test()
    {
        using var appHost = new AppHost();
        try
        {
            appHost.Start();

            var httpClient =
                new HttpClient
                {
                    BaseAddress = appHost.UrlApiProcessing,
                };
            using var client = new ProcessingClient(httpClient, true);
            var description = await client.GetDescriptionAsync();
            Assert.IsNotNull(description);

            var snapShot = appHost.GetExceptionPolicyInfrastructureMonitorValues();
            Assert.AreEqual(0, snapShot.CountInternalException, appHost.GetDbLogs());
            Assert.AreEqual(0, snapShot.CountMapperException, appHost.GetDbLogs());
            Assert.AreEqual(0, snapShot.CountUnexpectedException, appHost.GetDbLogs());
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            Console.WriteLine(appHost.CollectLogs());

            throw;
        }
        finally
        {
            appHost.Stop();
        }
    }
}