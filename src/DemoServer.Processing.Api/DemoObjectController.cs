using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Acme.DemoServer.Processing.Api.Common;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject;
using Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;
using Acme.DemoServer.Processing.Api.Examples;
using Acme.DemoServer.Processing.Model.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Asp.Versioning;

#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)

namespace Acme.DemoServer.Processing.Api;

[ApiVersion("1")]
[ApiExplorerSettings(GroupName = "v1")]
[Route(DemoObjectControllerConstants.Route)]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public sealed class DemoObjectController : BaseProcessingController
{
    private const string Tag = "Объект";

    private readonly IDemoObjectControllerService m_controllerService;
    private readonly ICustomEntryPoint m_entryPoint;

    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoObjectController(
        IDemoObjectControllerService controllerService,
        ICustomEntryPoint entryPoint)
    {
        m_controllerService = controllerService;
        m_entryPoint = entryPoint;
    }

    /// <summary>
    /// Создание объекта.
    /// </summary>
    /// <param name="parameters">Параметры создание объекта.</param>
    [HttpPost(DemoObjectControllerConstants.MethodCreate.Name)]
    [SwaggerOperation(
        Summary = "Создание объекта.",
        Description = "Создание объекта.",
        OperationId = DemoObjectControllerConstants.MethodCreate.Name,
        Tags = new[] { Tag })]
    [SwaggerRequestExample(typeof(DemoObjectCreate), typeof(ExamplesDemoObjectCreate))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ExamplesDemoObjectInfo))]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные объекта.", typeof(DemoObjectInfo))]
    public async Task<IActionResult> Create(
        [FromBody] DemoObjectCreate parameters,
        CancellationToken cancellationToken)
    {
        m_entryPoint.Metrics?.RequestsIncoming.Add(1);

        var result = await m_controllerService.CreateAsync(parameters, cancellationToken).ConfigureAwait(false);

        m_entryPoint.Metrics?.RequestsIncomingSuccessful.Add(1);

        return Ok(result);
    }

    /// <summary>
    /// Обновление объекта.
    /// </summary>
    /// <param name="parameters">Параметры обновления объекта.</param>
    [HttpPost(DemoObjectControllerConstants.MethodUpdate.Name)]
    [SwaggerOperation(
        Summary = "Обновление объекта.",
        Description = "Обновление объекта.",
        OperationId = DemoObjectControllerConstants.MethodUpdate.Name,
        Tags = new[] { Tag })]
    [SwaggerRequestExample(typeof(DemoObjectUpdate), typeof(ExamplesDemoObjectUpdate))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ExamplesDemoObjectInfo))]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные объекта.", typeof(DemoObjectInfo))]
    public async Task<IActionResult> Update(
        [FromBody] DemoObjectUpdate parameters,
        CancellationToken cancellationToken)
    {
        m_entryPoint.Metrics?.RequestsIncoming.Add(1);

        var result = await m_controllerService.UpdateAsync(parameters, cancellationToken).ConfigureAwait(false);

        m_entryPoint.Metrics?.RequestsIncomingSuccessful.Add(1);

        return Ok(result);
    }

    /// <summary>
    /// Чтение объекта.
    /// </summary>
    /// <param name="id">Идентификатор объекта.</param>
    [HttpGet(DemoObjectControllerConstants.MethodRead.Name)]
    [SwaggerOperation(
        Summary = "Чтение объекта.",
        Description = "Чтение объекта.",
        OperationId = DemoObjectControllerConstants.MethodRead.Name,
        Tags = new[] { Tag })]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ExamplesDemoObjectInfo))]
    [SwaggerResponse(StatusCodes.Status200OK, "Данные объекта.", typeof(DemoObjectInfo))]
    public async Task<IActionResult> Read(
        [FromQuery(Name = DemoObjectControllerConstants.MethodRead.Arguments.Id)] [Required]
        long id,
        CancellationToken cancellationToken)
    {
        m_entryPoint.Metrics?.RequestsIncoming.Add(1);

        var result = await m_controllerService.ReadAsync(id, cancellationToken).ConfigureAwait(false);

        m_entryPoint.Metrics?.RequestsIncomingSuccessful.Add(1);

        return Ok(result);
    }
}