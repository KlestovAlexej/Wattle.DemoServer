using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Api.Common;

/// <summary>
/// Коды ошибок поведения доменных объектов.
/// </summary>
public static class WorkflowErrorCodes
{
    /// <summary>
    /// Все коды ошибок с описаниями.
    /// </summary>
    public static readonly IReadOnlyDictionary<int, string>? DisplayNames;

    /// <summary>
    /// Все коды ошибок с уровнями серьезности.
    /// </summary>
    public static readonly IReadOnlyDictionary<int, int>? Severities;

    /// <summary>
    /// Коды ошибок с замечаниями.
    /// </summary>
    public static readonly IReadOnlyDictionary<int, string>? Remarks;

    static WorkflowErrorCodes()
    {
        WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod()!.DeclaringType!);
        WorkflowExceptionErrorSeverityAttribute.CollectSeverities(out Severities, MethodBase.GetCurrentMethod()!.DeclaringType!);
        WellknowConstantsHelper.CollectRemarks(out Remarks, MethodBase.GetCurrentMethod()!.DeclaringType!);
    }

    /// <summary>
    /// Сервер перегружен.
    /// </summary>
    [Description("Сервер перегружен")]
    [WorkflowExceptionErrorSeverity(CommonWorkflowExceptionErrorSeverities.ServiceTemporarilyUnavailable)]
    public const int TooBusy = 1;

    /// <summary>
    /// Объект не найден.
    /// </summary>
    [Description("Объект не найден")]
    [WorkflowExceptionErrorSeverity(CommonWorkflowExceptionErrorSeverities.ServicePermanentlyUnavailable)]
    public const int DemoObjectNotFound = 2;

    /// <summary>
    /// Альтернативный ключ объекта X уже существует.
    /// </summary>
    [Description("Альтернативный ключ объекта X уже существует")]
    [WorkflowExceptionErrorSeverity(CommonWorkflowExceptionErrorSeverities.ServicePermanentlyUnavailable)]
    public const int DemoObjectXKeyAlreadyExists = 3;
    
    /// <summary>
    /// Получить текстовое описание кода ошибки.
    /// </summary>
    /// <param name="id">Код ошибоки.</param>
    /// <returns>Текстовое описание кода ошибки.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName(int id)
    {
        Debug.Assert(DisplayNames != null, nameof(DisplayNames) + " != null");

        if (DisplayNames.TryGetValue(id, out var result))
        {
            return (result);
        }

        return (id.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Получить уровень серьезности по коду ошибки.
    /// </summary>
    /// <param name="id">Код ошибоки.</param>
    /// <returns>Уровень серьезности ошибки.</returns>
    /// <exception cref="InvalidOperationException">Не найден код ошибки '{id}'.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetSeverity(int id)
    {
        Debug.Assert(Severities != null, nameof(Severities) + " != null");

        if (Severities.TryGetValue(id, out var result))
        {
            return (result);
        }

        ThrowsHelper.ThrowInvalidOperationException($"Не найден код ошибки '{id}'.");

        return default;
    }
}