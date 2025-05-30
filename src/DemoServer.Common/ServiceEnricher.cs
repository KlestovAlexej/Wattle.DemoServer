﻿using Serilog.Core;
using Serilog.Events;
using System;

namespace Acme.DemoServer.Common;

public class ServiceEnricher : ILogEventEnricher
{
    private const string PropertyName = "Service.Name";
    private const string PropertyVersion = "Service.Version";
    private const string PropertyInstanceId = "Service.InstanceId";

    private readonly LogEventProperty m_propertyName;
    private readonly LogEventProperty m_propertyVersion;
    private readonly LogEventProperty m_propertyInstanceId;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ServiceEnricher(string serviceName, Version serviceVersion, Guid instanceId)
    {
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