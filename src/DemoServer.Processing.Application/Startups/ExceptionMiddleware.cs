using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.DemoServer.Processing.Model.Implements;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.OpenTelemetry;
using System;
using System.Net;
using System.Threading.Tasks;

#pragma warning disable IDE0290
#pragma warning disable CS1591

namespace ShtrihM.DemoServer.Processing.Application.Startups;

public class ExceptionMiddleware
{
    private static readonly SpanAttributes SpanAttributes;

    private readonly ICustomEntryPoint m_entryPoint;
    private readonly RequestDelegate m_next;
    private readonly Tracer m_tracer;
    private readonly IOptionsSnapshot<OpenTelemetrySettings> m_openTelemetrySettings;

    static ExceptionMiddleware()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<ExceptionMiddleware>();
    }

    public ExceptionMiddleware(
        ICustomEntryPoint entryPoint,
        RequestDelegate next,
        Tracer tracer = null,
        IOptionsSnapshot<OpenTelemetrySettings> openTelemetrySettings = null)
    {
        m_entryPoint = entryPoint;
        m_next = next;
        m_tracer = tracer;
        m_openTelemetrySettings = openTelemetrySettings;
    }

    // ReSharper disable once UnusedMember.Global
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await m_next(context).ConfigureAwait(false);
        }
        catch (WorkflowException exception)
        {
            using var mainSpan = m_tracer?.StartActiveSpan($"{nameof(IExceptionPolicy.ApplyAsync)}.{nameof(WorkflowException)}", initialAttributes: SpanAttributes, kind: SpanKind.Client);

            if (mainSpan != null)
            {
                mainSpan.SetStatus(Status.Error);

                if (m_openTelemetrySettings?.Value.Tracing.AspNetCoreInstrumentation is { Enabled: true, RecordException: true })
                {
                    mainSpan.RecordException(exception);
                }
            }

            var workflowException = (WorkflowException)await m_entryPoint.ExceptionPolicy.ApplyAsync(exception).ConfigureAwait(false);

            using var span = m_tracer?.StartActiveSpan(nameof(HttpResponseWritingExtensions.WriteAsync), initialAttributes: SpanAttributes, kind: SpanKind.Client);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;

            await context.Response.WriteAsync(workflowException.GetData().ToJsonText()).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            using var mainSpan = m_tracer?.StartActiveSpan($"{nameof(IExceptionPolicy.ApplyAsync)}.{nameof(Exception)}", initialAttributes: SpanAttributes, kind: SpanKind.Client);

            if (mainSpan != null)
            {
                mainSpan.SetStatus(Status.Error);

                if (m_openTelemetrySettings?.Value.Tracing.AspNetCoreInstrumentation is { Enabled: true, RecordException: true })
                {
                    mainSpan.RecordException(exception);
                }
            }

            exception.Data.Add(ExceptionPolicy.ExceptionSourceModule, ExceptionPolicy.ExceptionSourceModuleAsController);

            var workflowException = (WorkflowException)await m_entryPoint.ExceptionPolicy.ApplyAsync(exception).ConfigureAwait(false);

            if (m_entryPoint.SystemSettings.DebugMode.Value)
            {
                workflowException.Data.Add(WellknownWorkflowExceptionDataKeys.Exception2, exception.ToString());
            }

            using var span = m_tracer?.StartActiveSpan(nameof(HttpResponseWritingExtensions.WriteAsync), initialAttributes: SpanAttributes, kind: SpanKind.Client);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;

            await context.Response.WriteAsync(workflowException.GetData().ToJsonText()).ConfigureAwait(false);
        }
    }
}