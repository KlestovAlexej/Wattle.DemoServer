using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Acme.DemoServer.Processing.Api.Common;
using Acme.DemoServer.Processing.Api.Examples;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.Common.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net.Mime;

namespace Acme.DemoServer.Processing.Api;

[Route(ServerControllerConstants.Route)]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public sealed class ServerController : BaseProcessingController
{
    public const string Tag = "Служебное";

    private readonly IServerControllerService m_controllerService;
    private readonly ICustomEntryPoint m_entryPoint;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ServerController(
        IServerControllerService controllerService,
        ICustomEntryPoint entryPoint)
    {
        m_controllerService = controllerService;
        m_entryPoint = entryPoint;
    }

    [HttpGet(ServerControllerConstants.MethodDescription.Name)]
    [SwaggerOperation(
        Summary = "Получить описание сервера",
        Description = "Получить описание сервера.",
        OperationId = ServerControllerConstants.MethodDescription.Name,
        Tags = [Tag])]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ExamplesMetaServerDescription))]
    [SwaggerResponse(StatusCodes.Status200OK, "Описание сервера", typeof(MetaServerDescription))]
    public IActionResult Description()
    {
        m_entryPoint.Metrics?.RequestsIncoming.Add(1);

        var result = m_controllerService.GetDescription();

        m_entryPoint.Metrics?.RequestsIncomingSuccessful.Add(1);

        return Ok(result);
    }
}