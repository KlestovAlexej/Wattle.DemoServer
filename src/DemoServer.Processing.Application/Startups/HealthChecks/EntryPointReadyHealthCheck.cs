using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Acme.DemoServer.Processing.Model.Interfaces;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Acme.DemoServer.Processing.Application.Startups.HealthChecks;

public class EntryPointReadyHealthCheck : IHealthCheck
{
    private readonly ICustomEntryPoint m_entryPoint;

    private volatile bool m_isReady;

    public void SetIsReady(bool value)
    {
        m_isReady = value;
    }

    // ReSharper disable once ConvertToPrimaryConstructor
    public EntryPointReadyHealthCheck(
        ICustomEntryPoint entryPoint)
    {
        m_entryPoint = entryPoint;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        m_entryPoint.Metrics?.RequestsHealthCheck.Add(1);

        if (m_isReady)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("Сервер работоспособен"));
        }

        return Task.FromResult(
            HealthCheckResult.Unhealthy("Сервер не работоспособен"));
    }
}