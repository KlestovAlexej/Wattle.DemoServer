using ShtrihM.Wattle3.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Common;

/// <summary>
/// Коды событий системного лога.
/// </summary>
public static class WellknownSytemLogCodes
{
    /// <summary>
    /// Все коды событий системного лога и их описание.
    /// </summary>
    public static readonly IReadOnlyDictionary<int, string> DisplayNames;

    static WellknownSytemLogCodes()
    {
        WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod()!.DeclaringType);
    }

    /// <summary>
    /// Не предвиденная ошибка поведения доменных объектов.
    /// </summary>
    [Description("Не предвиденная ошибка поведения доменных объектов")]
    public static readonly int InternalException = 1;

    /// <summary>
    /// Не предвиденная ошибка.
    /// </summary>
    [Description("Не предвиденная ошибка")]
    public static readonly int UnexpectedException = 2;

    /// <summary>
    /// Не предвиденная ошибка мапперов БД.
    /// </summary>
    [Description("Не предвиденная ошибка мапперов БД")]
    public static readonly int MappersException = 3;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once UnusedMember.Global
    public static string GetDisplayName(int id)
    {
        if (DisplayNames.TryGetValue(id, out var result))
        {
            return (result);
        }

        return (id.ToString());
    }
}