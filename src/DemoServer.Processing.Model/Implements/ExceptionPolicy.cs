using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using ShtrihM.DemoServer.Common;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.SystemLog;
using ShtrihM.DemoServer.Processing.Model.Implements.SystemSettings;
using ShtrihM.DemoServer.Processing.Model.Interfaces;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.OpenTelemetry;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Model.Implements;

public class ExceptionPolicy : BaseExceptionPolicy
{
    public static readonly string ExceptionSourceModule = "ExceptionSourceModule";
    public static readonly string ExceptionSourceModuleAsController = "Controller";

    private static readonly SpanAttributes SpanAttributes;

    // ReSharper disable once NotAccessedField.Local
    private readonly bool m_debugMode;

    private readonly IWorkflowExceptionPolicy m_workflowExceptionPolicy;
    private readonly ExceptionPolicySettings m_settings;
    private readonly Tracer m_tracer;
    private readonly Metrics m_metrics;

    static ExceptionPolicy()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<ExceptionPolicy>();
    }

    public ExceptionPolicy(
        SystemSettings.SystemSettings systemSettings,
        IWorkflowExceptionPolicy workflowExceptionPolicy,
        ITimeService timeService,
        ILogger logger,
        Tracer tracer,
        Metrics metrics)
        : base(
            timeService,
            logger)
    // ReSharper disable once ConvertToPrimaryConstructor
    {
        m_workflowExceptionPolicy = workflowExceptionPolicy ?? throw new ArgumentNullException(nameof(workflowExceptionPolicy));
        m_settings = systemSettings.ExceptionPolicySettings.Value;
        m_debugMode = systemSettings.DebugMode.Value;
        m_tracer = tracer;
        m_metrics = metrics;
    }

    public ICustomEntryPoint EntryPoint;

    protected override WorkflowException DoApplyWorkflowException(WorkflowException exception)
    {
        m_metrics?.ExceptionsWorkflow.Add(1);

        DoWorkflowExceptionLogger(exception);

        return base.DoApplyWorkflowException(exception);
    }

    protected override void DoNotfyWorkflowException(WorkflowException exception)
    {
        m_metrics?.ExceptionsWorkflow.Add(1);

        DoWorkflowExceptionLogger(exception);
    }

    protected override void DoNotfyInternalException(InternalException exception)
    {
        m_metrics?.ExceptionsUnexpected.Add(1);

        DoInternalExceptionLogger(exception);
    }

    protected override void DoNotfyUnexpectedException(Exception exception)
    {
        m_metrics?.ExceptionsUnexpected.Add(1);

        DoExceptionLogger(exception);
    }

    protected override void DoNotfyNotfication(ExceptionPolicyNotfication notfication)
    {
        m_metrics?.ExceptionsUnexpected.Add(1);

        DoNotficationLogger(notfication);
    }

    protected override void DoNotfyMappersException(MappersException exception)
    {
        m_metrics?.ExceptionsUnexpected.Add(1);

        DoMappersExceptionLogger(exception);
    }

    protected override WorkflowException DoApplyMappersException(MappersException exception)
    {
        m_metrics?.ExceptionsUnexpected.Add(1);

        DoMappersExceptionLogger(exception);

        var result =
            m_workflowExceptionPolicy.Create(
                CommonWorkflowException.ServiceTemporarilyUnavailable,
                "Неожиданная ошибка БД.");

#if DEBUG
        result.Data.Add(WellknownWorkflowExceptionDataKeys.Exception, exception.ToString());
#else
        if (m_debugMode)
        {
            result.Data.Add(WellknownWorkflowExceptionDataKeys.Exception, exception.ToString());
        }
#endif

        return (result);
    }

    protected override WorkflowException DoApplyInternalException(InternalException exception)
    {
        m_metrics?.ExceptionsUnexpected.Add(1);

        DoInternalExceptionLogger(exception);

        var result =
            m_workflowExceptionPolicy.Create(
                CommonWorkflowException.Unexpected,
                "Неожиданная ошибка сервера.");

#if DEBUG
        result.Data.Add(WellknownWorkflowExceptionDataKeys.Exception, exception.ToString());
#else
        if (m_debugMode)
        {
            result.Data.Add(WellknownWorkflowExceptionDataKeys.Exception, exception.ToString());
        }
#endif

        return (result);
    }

    protected override WorkflowException DoApplyUnexpectedException(Exception exception)
    {
        m_metrics?.ExceptionsUnexpected.Add(1);

        DoExceptionLogger(exception);

        var result =
            m_workflowExceptionPolicy.Create(
                CommonWorkflowException.Unexpected,
                "Неожиданная ошибка.");

#if DEBUG
        result.Data.Add(WellknownWorkflowExceptionDataKeys.Exception, exception.ToString());
#else
        if (m_debugMode)
        {
            result.Data.Add(WellknownWorkflowExceptionDataKeys.Exception, exception.ToString());
        }
#endif

        return (result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DoWorkflowExceptionLogger(WorkflowException exception)
    {
        if (m_logger.IsInformationEnabled())
        {
            m_logger.LogInformation(exception, "Исключение поведения доменных объектов.");
        }

        if (m_tracer != null)
        {
            using var mainSpan = m_tracer.StartActiveSpan(nameof(DoWorkflowExceptionLogger), initialAttributes: SpanAttributes);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeExceptionType, exception.GetType().FullName);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeException, exception.ToString());
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DoInternalExceptionLogger(InternalException exception)
    {
        if (m_logger.IsCriticalEnabled())
        {
            m_logger.LogCritical(exception, "Не предвиденная ошибка поведения доменных объектов.");
        }

        if (m_tracer != null)
        {
            using var mainSpan = m_tracer.StartActiveSpan(nameof(DoInternalExceptionLogger), initialAttributes: SpanAttributes);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeExceptionType, exception.GetType().FullName);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeException, exception.ToString());
        }

        try
        {
            var oldUnitOfWork = EntryPoint.UnitOfWorkProvider.SetCurrentUnitOfWork(null);
            try
            {
                using var unitOfWork = EntryPoint.CreateUnitOfWork();

                var register = unitOfWork.Registers.GetRegister(WellknownDomainObjects.SystemLog);

                register.New(
                    new DomainObjectSystemLog.Template(
                        WellknownSytemLogCodes.InternalException,
                        WellknownSytemLogTypes.Fatal,
                        exception.Message,
                        exception.ToString()));

                unitOfWork.Commit();
            }
            finally
            {
                EntryPoint.UnitOfWorkProvider.SetCurrentUnitOfWork(oldUnitOfWork);
            }
        }
        catch (Exception exception2)
        {
            if (m_logger.IsCriticalEnabled())
            {
                m_logger.LogCritical(exception2, "Ошибка логирования не предвиденной ошибки поведения доменных объектов." + Environment.NewLine + exception);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DoExceptionLogger(Exception exception)
    {
        if (m_tracer != null)
        {
            using var mainSpan = m_tracer.StartActiveSpan(nameof(DoExceptionLogger), initialAttributes: SpanAttributes);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeExceptionType, exception.GetType().FullName);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeException, exception.ToString());
        }

        if (exception is OperationCanceledException)
        {
            if (m_logger.IsDebugEnabled())
            {
                m_logger.LogDebug(exception, "Не предвиденная ошибка.");
            }

            return;
        }

        if (m_logger.IsWarningEnabled())
        {
            m_logger.LogWarning(exception, "Не предвиденная ошибка.");
        }

        if (m_settings.ControllersEnabledUnexpectedException.Value == false)
        {
            var exceptionScourceModule = exception.Data[ExceptionSourceModule];
            if ((exceptionScourceModule != null) && (exceptionScourceModule.ToString() == ExceptionSourceModuleAsController))
            {
                return;
            }
        }

        try
        {
            var oldUnitOfWork = EntryPoint.UnitOfWorkProvider.SetCurrentUnitOfWork(null);
            try
            {
                using var unitOfWork = EntryPoint.CreateUnitOfWork();

                var register = unitOfWork.Registers.GetRegister(WellknownDomainObjects.SystemLog);

                register.New(
                    new DomainObjectSystemLog.Template(
                        WellknownSytemLogCodes.UnexpectedException,
                        WellknownSytemLogTypes.Warning,
                        exception.Message,
                        exception.ToString()));

                unitOfWork.Commit();
            }
            finally
            {
                EntryPoint.UnitOfWorkProvider.SetCurrentUnitOfWork(oldUnitOfWork);
            }
        }
        catch (Exception exception2)
        {
            if (m_logger.IsCriticalEnabled())
            {
                m_logger.LogCritical(exception2, "Ошибка логирования не предвиденной ошибки." + Environment.NewLine + exception);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DoMappersExceptionLogger(MappersException exception)
    {
        if (m_logger.IsWarningEnabled())
        {
            m_logger.LogWarning(exception, "Ошибка мапперов данных состояний доменный объектов в БД.");
        }

        if (m_tracer != null)
        {
            using var mainSpan = m_tracer.StartActiveSpan(nameof(DoMappersExceptionLogger), initialAttributes: SpanAttributes);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeExceptionType, exception.GetType().FullName);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeException, exception.ToString());
        }

        try
        {
            var oldUnitOfWork = EntryPoint.UnitOfWorkProvider.SetCurrentUnitOfWork(null);
            try
            {
                using var unitOfWork = EntryPoint.CreateUnitOfWork();

                var register = unitOfWork.Registers.GetRegister(WellknownDomainObjects.SystemLog);

                register.New(
                    new DomainObjectSystemLog.Template(
                        WellknownSytemLogCodes.MappersException,
                        WellknownSytemLogTypes.Warning,
                        exception.Message,
                        exception.ToString()));

                unitOfWork.Commit();
            }
            finally
            {
                EntryPoint.UnitOfWorkProvider.SetCurrentUnitOfWork(oldUnitOfWork);
            }
        }
        catch (Exception exception2)
        {
            if (m_logger.IsCriticalEnabled())
            {
                m_logger.LogCritical(exception2, "Ошибка логирования не предвиденной ошибки мапперов БД." + Environment.NewLine + exception);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DoNotficationLogger(ExceptionPolicyNotfication notfication)
    {
        if (m_tracer != null)
        {
            using var mainSpan = m_tracer.StartActiveSpan(nameof(DoNotficationLogger), initialAttributes: SpanAttributes);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeErrorMessage, notfication.ToString());
        }

        if (m_logger.IsEnabled(notfication.Level))
        {
            m_logger.Log(notfication.Level, $"Неожиданное уведомление.{Environment.NewLine}{notfication}");
        }

        int type;
        if (notfication.Level == LogLevel.Warning)
        {
            type = WellknownSytemLogTypes.Warning;
        }
        else if (notfication.Level == LogLevel.Error)
        {
            type = WellknownSytemLogTypes.Error;
        }
        else if (notfication.Level == LogLevel.Critical)
        {
            type = WellknownSytemLogTypes.Fatal;
        }
        else
        {
            return;
        }

        try
        {
            var oldUnitOfWork = EntryPoint.UnitOfWorkProvider.SetCurrentUnitOfWork(null);
            try
            {
                using var unitOfWork = EntryPoint.CreateUnitOfWork();

                var register = unitOfWork.Registers.GetRegister(WellknownDomainObjects.SystemLog);

                register.New(
                    new DomainObjectSystemLog.Template(
                        WellknownSytemLogCodes.UnexpectedException,
                        type,
                        notfication.Message,
                        notfication.ToString()));

                unitOfWork.Commit();
            }
            finally
            {
                EntryPoint.UnitOfWorkProvider.SetCurrentUnitOfWork(oldUnitOfWork);
            }
        }
        catch (Exception exception2)
        {
            if (m_logger.IsCriticalEnabled())
            {
                m_logger.LogCritical(exception2, "Ошибка логирования неожиданного уведомления." + Environment.NewLine + notfication);
            }
        }
    }
}