using Acme.Wattle.Common.Interfaces;

namespace Acme.DemoServer.Processing.Model.Interfaces;

public interface IServerControllerService
{
    /// <summary>
    /// Получить описание сервера.
    /// </summary>
    MetaServerDescription GetDescription();
}