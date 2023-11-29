using NUnit.Framework;
using ShtrihM.DemoServer.Processing.Api.Clients;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Tests.Application;

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
        m_appHost = new();
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
            new()
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
        CommonWattleExtensions.SilentDisposeAndFree(ref m_httpClient);
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
                new()
                {
                    Enabled = true,
                    Name = "test",
                });
            Assert.IsNotNull(info);

            info = await client.DemoObjectReadAsync(info.Id);
            Assert.IsNotNull(info);

            info = await client.DemoObjectUpdateAsync(
                new()
                {
                    Id = info.Id,
                    Fields =
                        new()
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