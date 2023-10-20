using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Api.Clients;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Tests.Application;

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