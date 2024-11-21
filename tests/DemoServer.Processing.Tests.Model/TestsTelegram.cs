using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Acme.DemoServer.Processing.Model.Implements.SystemSettings;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.DemoServer.Processing.Tests.Model.Environment;
using Acme.Wattle.Testing;
using Acme.Wattle.Utils;

namespace Acme.DemoServer.Processing.Tests.Model;

[TestFixture]
[Explicit]
public class TestsTelegram : BaseTestsDomainObjects
{
    protected override SystemSettings CreateSystemSettings()
    {
        var result = base.CreateSystemSettings();

        result.ExceptionPolicySettings.Value.UnexpectedExceptionSendToTelegram.Value = true;
        result.TelegramSettings.Value.Enabled.Value = true;

        // TODO Указать реальные токен бота и ID чата.
        result.TelegramSettings.Value.ApiKey.Value = "0:0";
        result.TelegramSettings.Value.ChatId.Value = -1;

        return result;
    }

    [Test]
    [Timeout(TestTimeout.Unit)]
    [Category(TestCategory.Unit)]
    public async ValueTask TestAsync()
    {
        var telegram = m_entryPoint.ServiceProvider.GetRequiredService<ITelegram>();

        await telegram.SendAsync(@"😊 Привет!
Я робот, что будет отправлять сюда сообщения о критических отказах сервера.");

        await telegram.SendFileAsync(@"😊 Привет!
Я робот, что будет отправлять сюда сообщения о критических отказах сервера.",
            "test.txt",
            "Привет !"u8.ToArray());

        m_entryPoint.ExceptionPolicy.NotfyAsync(new ApplicationException("Тест")).SafeGetResult();
    }
}
