using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.OpenTelemetry;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace ShtrihM.DemoServer.Processing.Model.Implements.ControllersServices;

public class ControllerServiceDispatchProxy<TService> : DispatchProxy
{
    private TService m_service;
    private ILogger m_logger;
    private ICustomEntryPoint m_entryPoint;
    private SpanAttributes m_spanAttributes;

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        using var mainSpan = m_entryPoint.Tracer?.StartActiveSpan(targetMethod!.Name, initialAttributes: m_spanAttributes, kind: SpanKind.Server);

        try
        {
            if (m_logger.IsDebugEnabled())
            {
                var text = $@"
Метод '{targetMethod!.Name}'";

                var parameters = targetMethod.GetParameters();
                for (var i = 0; i < parameters.Length; i++)
                {
                    var parameter = parameters[i];
                    if (parameter.ParameterType == typeof(CancellationToken))
                    {
                        text += Environment.NewLine + parameter.Name + ": [CancellationToken]";
                    }
                    else
                    {
                        text += Environment.NewLine + parameter.Name + ": " + (args![i]?.ToJsonText() ?? "[NULL]");
                    }
                }
                text += Environment.NewLine;

                m_logger.LogDebug(text);
                mainSpan?.SetAttribute(OpenTelemetryConstants.AttributeParametersIn, text);
            }

            var result = targetMethod!.Invoke(m_service, args);

            return result;
        }
        catch (WorkflowException exception)
        {
            ExceptionDispatchInfo.Capture(exception).Throw();

            throw;
        }
        catch (Exception exception)
        {
            mainSpan?.RecordException(exception);
            mainSpan?.SetStatus(Status.Error);

            ExceptionDispatchInfo.Capture(exception).Throw();

            throw;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TService CreateProxy(
        ICustomEntryPoint entryPoint,
        TService service)
    {
        if (entryPoint == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(entryPoint));
        }
        if (service == null)
        {
            ThrowsHelper.ThrowArgumentNullException(nameof(service));
        }

        var logger = entryPoint!.LoggerFactory.CreateLogger<TService>();
        if (entryPoint.Tracer == null && false == logger.IsDebugEnabled())
        {
            return service;
        }

        var proxy = Create<TService, ControllerServiceDispatchProxy<TService>>();

        // ReSharper disable once SuspiciousTypeConversion.Global
        var typedProxy = proxy as ControllerServiceDispatchProxy<TService>;
        typedProxy!.m_service = service;
        typedProxy.m_entryPoint = entryPoint;
        typedProxy.m_logger = logger;
        typedProxy.m_spanAttributes = new SpanAttributes().AddModuleType<ControllerServiceDispatchProxy<TService>>();

        return proxy;
    }
}