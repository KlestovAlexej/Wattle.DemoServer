using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.DemoServer.Processing.Api.Examples;
using ShtrihM.DemoServer.Processing.Model;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Interfaces;
using ShtrihM.Wattle3.OpenTelemetry;
using ShtrihM.Wattle3.Primitives;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net.Mime;

namespace ShtrihM.DemoServer.Processing.Api;

[Route(ServerControllerConstants.Route)]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class ServerController : BaseProcessingController
{
    private static readonly SpanAttributes SpanAttributes;
    public const string Tag = "Служебное";

    private readonly ILogger<ServerController> m_logger;
    private readonly Tracer m_tracer;
    private readonly ICustomEntryPoint m_entryPoint;

    static ServerController()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<ServerController>();
    }

    public ServerController(
        ILogger<ServerController> logger,
        ICustomEntryPoint entryPoint,
        Tracer tracer = null)
        // ReSharper disable once ConvertToPrimaryConstructor
    {
        m_logger = logger;
        m_tracer = tracer;
        m_entryPoint = entryPoint;
    }

    [HttpGet(ServerControllerConstants.MethodDescription.Name)]
    [SwaggerOperation(
        Summary = "Получить описание сервера",
        Description = "Получить описание сервера.",
        OperationId = ServerControllerConstants.MethodDescription.Name,
        Tags = new[] { Tag })]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ExamplesMetaServerDescription))]
    [SwaggerResponse(StatusCodes.Status200OK, "Описание сервера", typeof(MetaServerDescription))]
    public IActionResult Description()
    {
        using var mainSpan = m_tracer?.StartActiveSpan(nameof(Description), initialAttributes: SpanAttributes, kind: SpanKind.Server);

        if (m_logger.IsDebugEnabled())
        {
            var text = $@"
Метод '{nameof(Description)}'";

            m_logger.LogDebug(text);
            mainSpan?.SetAttribute(OpenTelemetryConstants.AttributeParametersIn, text);
        }

        m_entryPoint.Metrics?.RequestsIncoming.Add(1);

        var result = m_entryPoint.ServerDescription;

        m_entryPoint.Metrics?.RequestsIncomingSuccessful.Add(1);

        return Ok(result);
    }
}