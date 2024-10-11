using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Acme.DemoServer.Processing.Model.Interfaces;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Acme.DemoServer.Processing.Application.Startups.HealthChecks;

public class EntryPointGlobalReadyBackgroundService : BackgroundService
{
    private readonly ICustomEntryPoint m_entryPoint;
    private readonly EntryPointGlobalReadyHealthCheck m_healthCheck;

    // ReSharper disable once ConvertToPrimaryConstructor
    public EntryPointGlobalReadyBackgroundService(
        ICustomEntryPoint entryPoint,
        EntryPointGlobalReadyHealthCheck healthCheck)
    {
        m_entryPoint = entryPoint;
        m_healthCheck = healthCheck;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (false == stoppingToken.IsCancellationRequested)
        {
            m_healthCheck.SetIsGlobalReady(m_entryPoint.GlobalIsReady);

            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}