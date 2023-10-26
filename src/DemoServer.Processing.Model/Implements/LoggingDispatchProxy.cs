using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.OpenTelemetry;
using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public class LoggingDispatchProxy<TService> : DispatchProxy
{
    private TService m_service;
    private ILogger m_logger;
    private Tracer m_tracer;
    private SpanAttributes m_spanAttributes;

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        using var mainSpan = m_tracer?.StartActiveSpan(targetMethod!.Name, initialAttributes: m_spanAttributes, kind: SpanKind.Server);

        try
        {
            if (m_logger.IsDebugEnabled())
            {
                var parameters = targetMethod!.GetParameters();
                var text = $@"
Метод '{targetMethod!.Name}'
Аргументы ({parameters.Length}) :";

                var textParameters = string.Empty;
                for (var i = 0; i < parameters.Length; i++)
                {
                    textParameters += Environment.NewLine;

                    var parameter = parameters[i];
                    if (parameter.ParameterType == typeof(CancellationToken))
                    {
                        textParameters += $"{i+1}# '{parameter.Name}' : [CancellationToken]";
                    }
                    else
                    {
                        textParameters += $"{i+1}# '{parameter.Name}' : " + (args![i]?.ToJsonText(true) ?? "NULL");
                    }
                }
                textParameters += Environment.NewLine;
                
                m_logger.LogDebug(text + textParameters + Environment.NewLine);
                mainSpan?.SetAttribute(OpenTelemetryConstants.AttributeMethodParameters, textParameters);

                text = $@"
Метод '{targetMethod!.Name}'
Результат :";

                if (CallAsyncMethodsHelpers.Invoke(m_service, targetMethod, args, out var result, out var taskResult))
                {
                    var textResult = taskResult?.ToJsonText(true) ?? "NULL";

                    m_logger.LogDebug(text + textResult + Environment.NewLine);
                    mainSpan?.SetAttribute(OpenTelemetryConstants.AttributeMethodResult, textResult);
                }
                else
                {
                    var textResult = result?.ToJsonText(true) ?? "NULL";

                    m_logger.LogDebug(text + textResult + Environment.NewLine);
                    mainSpan?.SetAttribute(OpenTelemetryConstants.AttributeMethodResult, textResult);
                }

                return result;
            }

            {
                var result = targetMethod!.Invoke(m_service, args);

                return result;
            }
        }
        catch (WorkflowException exception)
        {
            mainSpan?.RecordException(exception);

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

        var proxy = Create<TService, LoggingDispatchProxy<TService>>();

        var typedProxy = proxy as LoggingDispatchProxy<TService>;
        typedProxy!.m_service = service;
        typedProxy.m_tracer = entryPoint.Tracer;
        typedProxy.m_logger = logger;
        typedProxy.m_spanAttributes = new SpanAttributes().AddModuleType<LoggingDispatchProxy<TService>>();

        return proxy;
    }
}