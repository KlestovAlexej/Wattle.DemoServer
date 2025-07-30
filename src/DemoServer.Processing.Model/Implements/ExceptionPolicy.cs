#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using Acme.DemoServer.Common;
using Acme.DemoServer.Processing.Api.Common;
using Acme.DemoServer.Processing.Common;
using Acme.DemoServer.Processing.Model.DomainObjects.SystemLog;
using Acme.DemoServer.Processing.Model.Implements.SystemSettings;
using Acme.DemoServer.Processing.Model.Interfaces;
using Acme.Wattle.Common.Exceptions;
using Acme.Wattle.DomainObjects.EntryPoints;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Mappers;
using Acme.Wattle.OpenTelemetry;
using Acme.Wattle.Primitives;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Acme.Wattle.Utils;
using Constants = Acme.DemoServer.Common.Constants;

namespace Acme.DemoServer.Processing.Model.Implements;

public sealed class ExceptionPolicy : BaseExceptionPolicy
{
    public static readonly string ExceptionSourceModule = "ExceptionSourceModule";
    public static readonly string ExceptionSourceModuleAsController = "Controller";

    private static readonly SpanAttributes SpanAttributes;

    // ReSharper disable once NotAccessedField.Local
    private readonly bool m_debugMode;

    private readonly IWorkflowExceptionPolicy m_workflowExceptionPolicy;
    private readonly ExceptionPolicySettings m_settings;
    private readonly Tracer? m_tracer;
    private readonly Metrics? m_metrics;
    private readonly SystemSettingsLocal m_systemSettingsLocal;
    private readonly Dictionary<string, DateTime> m_unexpectedExceptionSendToTelegram;
    private readonly IServiceProvider m_serviceProvider;
    private readonly SystemSettings.SystemSettings m_systemSettings;

    static ExceptionPolicy()
    {
        SpanAttributes = new SpanAttributes()
            .AddModuleType<ExceptionPolicy>();
    }

    // ReSharper disable once ConvertToPrimaryConstructor
    public ExceptionPolicy(
        SystemSettings.SystemSettings systemSettings,
        IWorkflowExceptionPolicy workflowExceptionPolicy,
        ITimeService timeService,
        ILogger logger,
        Tracer? tracer,
        Metrics? metrics,
        SystemSettingsLocal systemSettingsLocal,
        IServiceProvider serviceProvider)
        : base(
            timeService,
            logger)
    {
        m_systemSettings = systemSettings;
        m_workflowExceptionPolicy = workflowExceptionPolicy;
        m_settings = systemSettings.ExceptionPolicy.Value;
        m_debugMode = systemSettings.DebugMode.Value;
        m_tracer = tracer;
        m_metrics = metrics;
        m_systemSettingsLocal = systemSettingsLocal;
        m_unexpectedExceptionSendToTelegram = new Dictionary<string, DateTime>();
        m_serviceProvider = serviceProvider;
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
        if (DoExceptionLogger(exception))
        {
            m_metrics?.ExceptionsUnexpected.Add(1);
        }
    }

    protected override void DoNotfyNotfication(ExceptionPolicyNotfication notfication)
    {
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
        if (DoExceptionLogger(exception))
        {
            m_metrics?.ExceptionsUnexpected.Add(1);
        }

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
        m_logger?.LogInformation(exception, "Исключение поведения доменных объектов.");

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
        m_logger?.LogCritical(exception, "Не предвиденная ошибка поведения доменных объектов.");

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
            if (m_logger?.IsCriticalEnabled() ?? false)
            {
                m_logger?.LogCritical(exception2, "Ошибка логирования не предвиденной ошибки поведения доменных объектов." + Environment.NewLine + exception);
            }
        }

        UnexpectedExceptionSendToTelegram(exception);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool DoExceptionLogger(Exception exception)
    {
        if (m_tracer != null)
        {
            using var mainSpan = m_tracer.StartActiveSpan(nameof(DoExceptionLogger), initialAttributes: SpanAttributes);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeExceptionType, exception.GetType().FullName);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeException, exception.ToString());
        }

        if (exception is OperationCanceledException)
        {
            m_logger?.LogDebug(exception, "Не предвиденная ошибка.");

            return false;
        }

        m_logger?.LogWarning(exception, "Не предвиденная ошибка.");

        if (m_settings.ControllersEnabledUnexpectedException.Value == false)
        {
            var exceptionScourceModule = exception.Data[ExceptionSourceModule];
            if ((exceptionScourceModule != null) && (exceptionScourceModule.ToString() == ExceptionSourceModuleAsController))
            {
                return false;
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
            if (m_logger?.IsCriticalEnabled() ?? false)
            {
                m_logger?.LogCritical(exception2, "Ошибка логирования не предвиденной ошибки." + Environment.NewLine + exception);
            }
        }

        UnexpectedExceptionSendToTelegram(exception);

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DoMappersExceptionLogger(MappersException exception)
    {
        m_logger?.LogWarning(exception, "Ошибка мапперов данных состояний доменный объектов в БД.");

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
            if (m_logger?.IsCriticalEnabled() ?? false)
            {
                m_logger?.LogCritical(exception2, "Ошибка логирования не предвиденной ошибки мапперов БД." + Environment.NewLine + exception);
            }
        }

        UnexpectedExceptionSendToTelegram(exception);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DoNotficationLogger(ExceptionPolicyNotfication notfication)
    {
        if (m_tracer != null)
        {
            using var mainSpan = m_tracer.StartActiveSpan(nameof(DoNotficationLogger), initialAttributes: SpanAttributes);
            mainSpan.SetAttribute(OpenTelemetryAttibutes.AttributeErrorMessage, notfication.ToString());
        }

        if (m_logger?.IsEnabled(notfication.Level) ?? false)
        {
            m_logger?.Log(notfication.Level, $"Неожиданное уведомление.{Environment.NewLine}{notfication}");
        }

        UnexpectedExceptionSendToTelegram(notfication);

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

        m_metrics?.ExceptionsUnexpected.Add(1);

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
            if (m_logger?.IsCriticalEnabled() ?? false)
            {
                m_logger?.LogCritical(exception2, "Ошибка логирования неожиданного уведомления." + Environment.NewLine + notfication);
            }
        }
    }

    private void UnexpectedExceptionSendToTelegram(ExceptionPolicyNotfication notfication)
    {
        if ((notfication.Level == LogLevel.Critical)
            || (notfication.Level == LogLevel.Error))
        {
            UnexpectedExceptionSendToTelegram(
                notfication.Message,
                notfication.ToString());
        }
    }

    private void UnexpectedExceptionSendToTelegram(Exception exception)
    {
        UnexpectedExceptionSendToTelegram(
            exception.GetType().AssemblyQualifiedName + exception.StackTrace,
            exception.ToString());
    }

    private void UnexpectedExceptionSendToTelegram(string key, string message)
    {
        try
        {
            if (m_settings.UnexpectedExceptionSendToTelegram.Value)
            {
                var time = EntryPoint.TimeService.NowDateTime;
                lock (m_unexpectedExceptionSendToTelegram)
                {
                    if (m_unexpectedExceptionSendToTelegram.TryGetValue(key, out var existsTime))
                    {
                        if ((time - existsTime) < m_settings.TimeoutUnexpectedExceptionSendToTelegram.Value)
                        {
                            return;
                        }
                    }

                    m_unexpectedExceptionSendToTelegram[key] = time;
                }

                var telegram = m_serviceProvider.GetRequiredService<ITelegram>();
                telegram.SendFileAsync(@$"🐷 Сервер сломался!

{GetProductDetails(m_systemSettingsLocal, m_systemSettings)}",
                        "details.txt",
                        Encoding.UTF8.GetBytes(message))
                    .SafeGetResult();
            }
        }
        catch
        {
            /* NONE */
        }
    }

    public static string GetProductDetails(
        SystemSettingsLocal systemSettingsLocal,
        SystemSettings.SystemSettings systemSettings)
    {
        return @$"Название = '{systemSettingsLocal.InstallationName}'
Установка = '{systemSettings.InstanceName.Value}'
Версия = {Constants.ProductVersion}
Версия сборки = {Constants.ProductBuildVersion}
Идентификатор = '{systemSettings.InstanceId.Value}'
Продукт = '{systemSettingsLocal.ProductName}'";
    }
}