﻿using Acme.Wattle.Common.Interfaces;
using Acme.Wattle.Primitives;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Acme.DemoServer.Processing.Common;

/// <summary>
/// Общие значения снимка состояния мониторинга инфраструктуры.
/// </summary>
public static class WellknownCommonSnapShotInfrastructureMonitorValues
{
    private static readonly Dictionary<Guid, SnapShotInfrastructureMonitorValueDescription> DisplayDescriptions;

    static WellknownCommonSnapShotInfrastructureMonitorValues()
    {
        DisplayDescriptions = WellknownSnapShotInfrastructureMonitorValuesHelpers.CollectDescriptions(MethodBase.GetCurrentMethod()!.DeclaringType!);
    }

    #region CustomEntryPoint

    /// <summary>
    /// Точка входа.
    /// </summary>
    public static class CustomEntryPoint
    {
        /// <summary>
        /// Идентификатор процесса сервера.
        /// </summary>
        [DisplayDescription("Идентификатор процесса сервера")]
        [Tags(WellknownTags.Id)]
        public static readonly Guid ProcessId = new("E6C7F585-04B6-486D-BEEA-39B093BF8F89");

        /// <summary>
        /// Признак работы сервера в отладочном режиме.
        /// </summary>
        [DisplayDescription("Признак работы сервера в отладочном режиме")]
        public static readonly Guid DebugMode = new("C027A4F4-340B-483E-BEDD-E49133807F96");
    }

    #endregion

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SnapShotInfrastructureMonitorValueDescription GetDescription(Guid id)
    {
        if (DisplayDescriptions.TryGetValue(id, out var result))
        {
            return (result);
        }

        ThrowsHelper.ThrowInvalidOperationException($"Описание '{id}' не найдено.");

        // ReSharper disable once PreferConcreteValueOverDefault
        return default!;
    }
}