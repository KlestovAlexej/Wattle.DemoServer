#nullable enable

using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

public interface ITelegram
{
    /// <summary>
    /// Отправить сообщение.
    /// </summary>
    /// <param name="message">Причина показа динамического идентификатор покупателя с форматированием <see cref="ParseMode.MarkdownV2"/>.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    ValueTask SendAsync(string message, CancellationToken cancellationToken = default);

    /// <summary>
    /// Отправить файл с сообщением.
    /// </summary>
    /// <param name="message">Причина показа динамического идентификатор покупателя с форматированием <see cref="ParseMode.MarkdownV2"/>.</param>
    /// <param name="fileName">Имя файла.</param>
    /// <param name="fileContent">Содержимое файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    ValueTask SendFileAsync(string message, string fileName, byte[] fileContent, CancellationToken cancellationToken = default);
}