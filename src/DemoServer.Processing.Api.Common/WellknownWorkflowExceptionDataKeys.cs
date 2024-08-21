using ShtrihM.Wattle3.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Api.Common;

/// <summary>
/// Ключи произвольных данных иключения доменной области.
/// </summary>
public static class WellknownWorkflowExceptionDataKeys
{
    /// <summary>
    /// Все ключи с описаниями.
    /// </summary>
    private static readonly IReadOnlyDictionary<string, string>? DisplayNames;

    static WellknownWorkflowExceptionDataKeys()
    {
        WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod()!.DeclaringType!);
    }

    /// <summary>
    /// Исключение.
    /// </summary>
    [Description("Исключение")]
    public const string Exception = "Exception";

    /// <summary>
    /// Исключение 2.
    /// </summary>
    [Description("Исключение 2")]
    public const string Exception2 = "Exception2";

    /// <summary>
    /// Идентифкатор.
    /// </summary>
    [Description("Идентифкатор")]
    public const string Id = "Id";

    /// <summary>
    /// Идентификатор пула лок-объектов.
    /// </summary>
    [Description("Идентификатор пула лок-объектов")]
    public const string LockId = "LockId";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName(string id)
    {
        Debug.Assert(DisplayNames != null, nameof(DisplayNames) + " != null");

        if (DisplayNames.TryGetValue(id, out var str))
        {
            return str;
        }

        return (id);
    }
}