using Acme.DemoServer.Processing.Api.Common;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using Acme.Wattle.Common.Exceptions;
using Acme.Wattle.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Acme.DemoServer.Processing.Api.Clients;

public interface IProcessingClient : IDisposable
{
    /// <summary>
    /// Получить описание сервера.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <exception cref="InvalidOperationException">Если не удается прочитать ответ сервера.</exception>
    /// <exception cref="WorkflowException">Отказ сервера <seealso cref="WorkflowErrorCodes"/>.</exception>
    ValueTask<MetaServerDescription> GetDescriptionAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Создание объекта.
    /// </summary>
    /// <param name="parameters">Параметры создание объекта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <exception cref="InvalidOperationException">Если не удается прочитать ответ сервера.</exception>
    /// <exception cref="WorkflowException">Отказ сервера <seealso cref="WorkflowErrorCodes"/>.</exception>
    ValueTask<DemoObjectInfo> DemoObjectCreateAsync(
        DemoObjectCreate parameters,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Чтение объекта.
    /// </summary>
    /// <param name="id">Идентификатор объекта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <exception cref="InvalidOperationException">Если не удается прочитать ответ сервера.</exception>
    /// <exception cref="WorkflowException">Отказ сервера <seealso cref="WorkflowErrorCodes"/>.</exception>
    ValueTask<DemoObjectInfo> DemoObjectReadAsync(
        long id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновление объекта.
    /// </summary>
    /// <param name="parameters">Параметры обновления объекта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <exception cref="InvalidOperationException">Если не удается прочитать ответ сервера.</exception>
    /// <exception cref="WorkflowException">Отказ сервера <seealso cref="WorkflowErrorCodes"/>.</exception>
    ValueTask<DemoObjectInfo> DemoObjectUpdateAsync(
        DemoObjectUpdate parameters,
        CancellationToken cancellationToken = default);
}