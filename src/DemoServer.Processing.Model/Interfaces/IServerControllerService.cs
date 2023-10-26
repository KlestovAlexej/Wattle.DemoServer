using ShtrihM.Wattle3.Common.Interfaces;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

public interface IServerControllerService
{
    /// <summary>
    /// Получить описание сервера.
    /// </summary>
    MetaServerDescription GetDescription();
}