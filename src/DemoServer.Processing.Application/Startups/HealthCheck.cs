using Microsoft.Extensions.Diagnostics.HealthChecks;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.OpenTelemetry;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable IDE0290
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ShtrihM.DemoServer.Processing.Application.Startups;

public class HealthCheck : IHealthCheck
{
    private static readonly SpanAttributes SpanAttributes;

    private readonly Tracer? m_tracer;
    private readonly ICustomEntryPoint m_entryPoint;

    static HealthCheck()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<HealthCheck>();
    }

    public HealthCheck(
        ICustomEntryPoint entryPoint,
        Tracer? tracer = null)
        // ReSharper disable once ConvertToPrimaryConstructor
    {
        m_tracer = tracer;
        m_entryPoint = entryPoint;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        using var mainSpan = m_tracer?.StartActiveSpan(nameof(CheckHealthAsync), initialAttributes: SpanAttributes, kind: SpanKind.Server);
        
        m_entryPoint.Metrics?.RequestsHealthCheck.Add(1);

        var isHealthy = m_entryPoint.IsReady;

        if (isHealthy)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("Сервер работоспособен"));
        }

        return Task.FromResult(
            HealthCheckResult.Unhealthy("Сервер не работоспособен"));
    }
}