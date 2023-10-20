using Serilog.Core;
using Serilog.Events;
using System;

#pragma warning disable CS1591

namespace ShtrihM.DemoServer.Common;

public class ServiceEnricher : ILogEventEnricher
{
    public const string PropertyName = "Service.Name";
    public const string PropertyVersion = "Service.Version";
    public const string PropertyInstanceId = "Service.InstanceId";

    private readonly LogEventProperty m_propertyName;
    private readonly LogEventProperty m_propertyVersion;
    private readonly LogEventProperty m_propertyInstanceId;

    public ServiceEnricher(string serviceName, Version serviceVersion, Guid instanceId)
    {
        if (serviceName == null)
        {
            throw new ArgumentNullException(nameof(serviceName));
        }

        m_propertyName = new LogEventProperty(PropertyName, new ScalarValue(serviceName));
        m_propertyVersion = new LogEventProperty(PropertyVersion, new ScalarValue(serviceVersion));
        m_propertyInstanceId = new LogEventProperty(PropertyInstanceId, new ScalarValue(instanceId));
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(m_propertyName);
        logEvent.AddPropertyIfAbsent(m_propertyVersion);
        logEvent.AddPropertyIfAbsent(m_propertyInstanceId);
    }
}