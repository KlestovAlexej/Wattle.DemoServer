using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Acme.DemoServer.Processing.Api;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Globalization;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Acme.DemoServer.Processing.Application.Startups.HealthChecks;

// ReSharper disable once ClassNeverInstantiated.Global
public class DocumentFilterHealthCheck : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Paths.TryAdd(HealthCheckExtensions.PathLive, new OpenApiPathItem
        {
            Description = "Проверка жизнеспособности",
            Extensions = null,
            Operations = new Dictionary<OperationType, OpenApiOperation>()
            {
                {
                    OperationType.Get,
                    new OpenApiOperation
                    {
                        Callbacks = null,
                        Deprecated = false,
                        Description = "Проверка жизнеспособности",
                        ExternalDocs = null,
                        OperationId = "healthcheck_live",
                        Parameters = null,
                        RequestBody = null,
                        Responses = new OpenApiResponses
                        {
                            {
                                StatusCodes.Status200OK.ToString(CultureInfo.InvariantCulture),
                                new OpenApiResponse { Content = null, Description = "Сервер жизнеспособен" }
                            },
                            {
                                StatusCodes.Status503ServiceUnavailable.ToString(CultureInfo.InvariantCulture),
                                new OpenApiResponse { Content = null, Description = "Сервер не жизнеспособен" }
                            },
                        },
                        Security = null,
                        Summary = "Проверка жизнеспособности",
                        Tags = new List<OpenApiTag> { new() { Name = ServerController.Tag } }
                    }
                },
            },
            Parameters = null,
            Servers = null,
        });

        swaggerDoc.Paths.TryAdd(HealthCheckExtensions.PathReady, new OpenApiPathItem
        {
            Description = "Проверка работоспособности",
            Extensions = null,
            Operations = new Dictionary<OperationType, OpenApiOperation>()
            {
                {
                    OperationType.Get,
                    new OpenApiOperation
                    {
                        Callbacks = null,
                        Deprecated = false,
                        Description = "Проверка работоспособности",
                        ExternalDocs = null,
                        OperationId = "healthcheck_ready",
                        Parameters = null,
                        RequestBody = null,
                        Responses = new OpenApiResponses
                        {
                            {
                                StatusCodes.Status200OK.ToString(CultureInfo.InvariantCulture),
                                new OpenApiResponse { Content = null, Description = "Сервер работоспособен" }
                            },
                            {
                                StatusCodes.Status503ServiceUnavailable.ToString(CultureInfo.InvariantCulture),
                                new OpenApiResponse { Content = null, Description = "Сервер не работоспособен" }
                            },
                        },
                        Security = null,
                        Summary = "Проверка работоспособности",
                        Tags = new List<OpenApiTag> { new() { Name = ServerController.Tag } }
                    }
                },
            },
            Parameters = null,
            Servers = null,
        });

        swaggerDoc.Paths.TryAdd(HealthCheckExtensions.PathGlobalReady, new OpenApiPathItem
        {
            Description = "Проверка полной работоспособности",
            Extensions = null,
            Operations = new Dictionary<OperationType, OpenApiOperation>()
            {
                {
                    OperationType.Get,
                    new OpenApiOperation
                    {
                        Callbacks = null,
                        Deprecated = false,
                        Description = "Проверка полной работоспособности",
                        ExternalDocs = null,
                        OperationId = "healthcheck_globalready",
                        Parameters = null,
                        RequestBody = null,
                        Responses = new OpenApiResponses
                        {
                            {
                                StatusCodes.Status200OK.ToString(CultureInfo.InvariantCulture),
                                new OpenApiResponse { Content = null, Description = "Сервер полностью работоспособен" }
                            },
                            {
                                StatusCodes.Status503ServiceUnavailable.ToString(CultureInfo.InvariantCulture),
                                new OpenApiResponse { Content = null, Description = "Сервер не работоспособен" }
                            },
                        },
                        Security = null,
                        Summary = "Проверка полной работоспособности",
                        Tags = new List<OpenApiTag> { new() { Name = ServerController.Tag } }
                    }
                },
            },
            Parameters = null,
            Servers = null,
        });
    }
}