using Microsoft.OpenApi.Models;
using ShtrihM.DemoServer.Processing.Api;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ShtrihM.DemoServer.Processing.Application.Startups;

// ReSharper disable once ClassNeverInstantiated.Global
public class DocumentFilterHealthCheck : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Paths.TryAdd(HealthCheckExtensions.Path, new OpenApiPathItem
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
                        OperationId = "healthCheck",
                        Parameters = null,
                        RequestBody = null,
                        Responses = new OpenApiResponses
                        {
                            { "200", new OpenApiResponse { Content = null, Description = "Сервер работоспособен" } },
                            { "503", new OpenApiResponse { Content = null, Description = "Сервер не работоспособен" } },
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
    }
}