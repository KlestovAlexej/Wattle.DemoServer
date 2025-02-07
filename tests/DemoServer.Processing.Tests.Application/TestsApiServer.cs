using NUnit.Framework;
using Acme.DemoServer.Processing.Api.Clients;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using Acme.DemoServer.Testing;
using Acme.Wattle.Testing;
using Acme.Wattle.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject;

namespace Acme.DemoServer.Processing.Tests.Application;

[TestFixture]
public class TestsApiServer : BaseSlimTests
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private AppHost m_appHost;
    private HttpClient m_httpClient;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
            // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
            m_appHost?.Stop();
            CommonWattleExtensions.SilentDisposeAndFree(ref m_appHost!);

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
        // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
        m_appHost?.Stop();
        CommonWattleExtensions.SilentDisposeAndFree(ref m_appHost!);

        m_httpClient.SilentDispose();
        CommonWattleExtensions.SilentDisposeAndFree(ref m_httpClient!);
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
                    [
                        new DemoObjectUpdateFieldValueOfEnabled
                        {
                            Enabled = false,
                        },

                        new DemoObjectUpdateFieldValueOfName
                        {
                            Name = "test2",
                        }

                    ],
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