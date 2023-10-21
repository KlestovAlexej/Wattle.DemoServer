using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Api.Clients;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Tests.Application;

[TestFixture]
public class TestsApiServer : BaseSlimTests
{
    private AppHost m_appHost;
    private HttpClient m_httpClient;

    [SetUp]
    public void SetUp()
    {
        m_appHost = new AppHost();
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

        m_httpClient =
            new HttpClient
            {
                BaseAddress = m_appHost.UrlApiProcessing,
            };
    }

    [TearDown]
    public void TearDown()
    {
        m_appHost?.Stop();
        m_appHost.SilentDispose();
        m_appHost = null;

        m_httpClient.SilentDispose();
        m_httpClient = null;
    }

    [Test]
    [Timeout(TestTimeout.Short)]
    [Category(TestCategory.Short)]
    public async Task Test_GetDescriptionAsync()
    {
        try
        {
            using IProcessingClient client = new ProcessingClient(m_httpClient);
            var description = await client.GetDescriptionAsync();
            Assert.IsNotNull(description);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            Console.WriteLine(m_appHost.CollectLogs());

            throw;
        }
    }

    [Test]
    [Timeout(TestTimeout.Short)]
    [Category(TestCategory.Short)]
    public async Task Test_DemoObjectCreateAsync()
    {
        try
        {
            using IProcessingClient client = new ProcessingClient(m_httpClient);
            var info = await client.DemoObjectCreateAsync(
                new DemoObjectCreate
                {
                    Enabled = true,
                    Name = "test",
                });
            Assert.IsNotNull(info);

            info = await client.DemoObjectReadAsync(info.Id);
            Assert.IsNotNull(info);

            info = await client.DemoObjectUpdateAsync(
                new DemoObjectUpdate
                {
                    Id = info.Id,
                    Fields =
                        new List<BaseDemoObjectUpdateFieldValue>
                        {
                            new DemoObjectUpdateFieldValueOfEnabled
                            {
                                Enabled = false,
                            },
                            new DemoObjectUpdateFieldValueOfName
                            {
                                Name = "test2",
                            },
                        },
                });
            Assert.IsNotNull(info);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            Console.WriteLine(m_appHost.CollectLogs());

            throw;
        }
    }
}