using System;
using Acme.DemoServer.Processing.Model.Interfaces;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace Acme.DemoServer.Processing.Model.Implements;

public class Telegram : ITelegram
{
    private readonly ICustomEntryPoint m_entryPoint;
    private readonly TelegramBotClient m_bot;
    private readonly ILogger m_logger;

    public Telegram(ICustomEntryPoint entryPoint)
    {
        m_entryPoint = entryPoint;
        m_bot = new TelegramBotClient(m_entryPoint.SystemSettings.Telegram.Value.ApiKey.Value);
        m_logger = entryPoint.LoggerFactory.CreateLogger<Telegram>();
    }

    public async ValueTask SendAsync(
        string message,
        CancellationToken cancellationToken = default)
    {
        if (false == m_entryPoint.SystemSettings.Telegram.Value.Enabled.Value)
        {
            return;
        }

        try
        {
            await m_bot.SendMessage(
                    new ChatId(m_entryPoint.SystemSettings.Telegram.Value.ChatId.Value),
                    EscapeTextMarkdownV2(message),
                    parseMode: ParseMode.MarkdownV2,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            m_logger.LogError(exception, "Ошибка отправки системного сообщение в Telegram.");
        }
    }

    public async ValueTask SendFileAsync(
        string message,
        string fileName,
        byte[] fileContent,
        CancellationToken cancellationToken = default)
    {
        if (false == m_entryPoint.SystemSettings.Telegram.Value.Enabled.Value)
        {
            return;
        }

        try
        {
            using var stream = new MemoryStream(fileContent);
            await m_bot.SendDocument(
                    new ChatId(m_entryPoint.SystemSettings.Telegram.Value.ChatId.Value),
                    new InputFileStream(stream, fileName),
                    caption: EscapeTextMarkdownV2(message),
                    parseMode: ParseMode.MarkdownV2,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            m_logger.LogError(exception, "Ошибка отправки системного сообщение в Telegram.");
        }
    }

    /// <summary>
    /// Экранирование символов дл стиля <seealso cref="ParseMode.MarkdownV2"/>> <seealso><cref>https://core.telegram.org/bots/api#formatting-options</cref></seealso>.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string EscapeTextMarkdownV2(string text)
    {
        var temp = new StringBuilder(text.Length + 1);

        foreach (var symbol in text)
        {
            if ((1 <= symbol) && (symbol <= 126))
            {
                temp.Append('\\');
            }

            temp.Append(symbol);
        }

        var result = temp.ToString();

        return result;
    }
}
