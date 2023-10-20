using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using System.Threading;
using System.Threading.Tasks;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

public interface IDemoObjectControllerService
{
    /// <summary>
    /// Создание объекта.
    /// </summary>
    /// <param name="parameters">Параметры создание объекта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    ValueTask<DemoObjectInfo> CreateAsync(
        DemoObjectCreate parameters,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Чтение объекта.
    /// </summary>
    /// <param name="id">Идентификатор объекта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    ValueTask<DemoObjectInfo> ReadAsync(
        long id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновление объекта.
    /// </summary>
    /// <param name="parameters">Параметры обновления объекта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    ValueTask<DemoObjectInfo> UpdateAsync(
        DemoObjectUpdate parameters,
        CancellationToken cancellationToken = default);
}