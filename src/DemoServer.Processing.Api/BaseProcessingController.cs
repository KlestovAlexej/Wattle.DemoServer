using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Acme.DemoServer.Processing.Api.Examples;
using Acme.Wattle.Common.Exceptions;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Acme.DemoServer.Processing.Api;

[ApiController]
[SwaggerResponse(StatusCodes.Status409Conflict, "Штатная ошибка", typeof(WorkflowExceptionData))]
[SwaggerResponse(StatusCodes.Status400BadRequest, "Неверный запрос", typeof(string))]
[SwaggerResponseExample(StatusCodes.Status409Conflict, typeof(ExamplesWorkflowExceptionData))]
public abstract class BaseProcessingController : ControllerBase;