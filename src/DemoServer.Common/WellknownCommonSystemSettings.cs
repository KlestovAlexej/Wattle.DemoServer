using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Common;

/// <summary>
/// Идентификаторы стандартных, общих для всех систем настроек.
/// </summary>
public static class WellknownCommonSystemSettings
{
    /// <summary>
    /// Все идентификаторы стандартных, общих для всех систем настроек и их описания.
    /// </summary>
    private static readonly IReadOnlyDictionary<Guid, string>? DisplayNames;

    static WellknownCommonSystemSettings()
    {
        WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod()!.DeclaringType!);
    }

    /// <summary>
    /// Код продукта.
    /// </summary>
    [Description("Код продукта")]
    public static readonly Guid ProductId = new("{CF0ED582-05EC-4AFE-883F-1D68A751B4A8}");

    /// <summary>
    /// Версия продукта.
    /// </summary>
    [Description("Версия продукта")]
    public static readonly Guid ProductVersion = new("1BF69D7C-2CBF-45a8-9526-0C33234ED62D");

    /// <summary>
    /// Имя инсталляции.
    /// </summary>
    [Description("Имя инсталляции")]
    public static readonly Guid InstallationName = new("{208B4E39-A3D1-45E2-A9DC-E79B3E064DF1}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName(Guid id)
    {
        Debug.Assert(DisplayNames != null, nameof(DisplayNames) + " != null");

        if (DisplayNames.TryGetValue(id, out var result))
        {
            return (result);
        }

        return (id.ToString());
    }
}