using Acme.Wattle.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// ReSharper disable All

namespace Acme.DemoServer.Common;

/// <summary>
/// Типы событий системного лога.
/// </summary>
public static class WellknownSytemLogTypes
{
    /// <summary>
    /// Все типы событий системного лога и их описание.
    /// </summary>
    private static readonly IReadOnlyDictionary<int, string>? DisplayNames;

    static WellknownSytemLogTypes()
    {
        WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod()!.DeclaringType!);
    }

    /// <summary>
    /// Информация.
    /// </summary>
    [Description("Информация")]
    public static readonly int Information = 1;

    /// <summary>
    /// Предупреждение.
    /// </summary>
    [Description("Предупреждение")]
    public static readonly int Warning = 2;

    /// <summary>
    /// Ошибка.
    /// </summary>
    [Description("Ошибка")]
    public static readonly int Error = 3;

    /// <summary>
    /// Критическое.
    /// </summary>
    [Description("Критическое")]
    public static readonly int Fatal = 5;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once UnusedMember.Global
    public static string GetDisplayName(int id)
    {
        Debug.Assert(DisplayNames != null, nameof(DisplayNames) + " != null");

        if (DisplayNames.TryGetValue(id, out var result))
        {
            return (result);
        }

        return (id.ToString());
    }
}