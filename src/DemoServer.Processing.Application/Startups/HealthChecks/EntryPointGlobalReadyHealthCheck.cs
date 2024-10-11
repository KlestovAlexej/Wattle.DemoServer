using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Acme.DemoServer.Processing.Model.Interfaces;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Acme.DemoServer.Processing.Application.Startups.HealthChecks;

public class EntryPointGlobalReadyHealthCheck : IHealthCheck
{
    private readonly ICustomEntryPoint m_entryPoint;

    private volatile bool m_isGlobalReady;

    public void SetIsGlobalReady(bool value)
    {
        m_isGlobalReady = value;
    }

    // ReSharper disable once ConvertToPrimaryConstructor
    public EntryPointGlobalReadyHealthCheck(
        ICustomEntryPoint entryPoint)
    {
        m_entryPoint = entryPoint;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        m_entryPoint.Metrics?.RequestsHealthCheck.Add(1);

        if (m_isGlobalReady)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("Сервер полностью работоспособен"));
        }

        return Task.FromResult(
            HealthCheckResult.Unhealthy("Сервер не работоспособен"));
    }
}