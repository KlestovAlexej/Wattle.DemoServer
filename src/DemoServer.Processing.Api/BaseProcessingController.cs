using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShtrihM.DemoServer.Processing.Api.Examples;
using ShtrihM.Wattle3.Common.Exceptions;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace ShtrihM.DemoServer.Processing.Api;

[ApiController]
[SwaggerResponse(StatusCodes.Status409Conflict, "Штатная ошибка", typeof(WorkflowExceptionData))]
[SwaggerResponse(StatusCodes.Status400BadRequest, "Неверный запрос", typeof(string))]
[SwaggerResponseExample(StatusCodes.Status409Conflict, typeof(ExamplesWorkflowExceptionData))]
public abstract class BaseProcessingController : ControllerBase;