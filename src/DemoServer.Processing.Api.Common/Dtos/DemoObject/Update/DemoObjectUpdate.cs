using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

/// <summary>
/// Обновление объекта.
/// </summary>
[Description("Обновление объекта")]
public sealed class DemoObjectUpdate
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    [JsonRequired]
    [Description("Идентификатор")]
    public long Id
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set;
    }

    /// <summary>
    /// Значения полей объекта для обновления.
    /// </summary>
    [Description("Значения полей объекта для обновления")]
    public List<BaseDemoObjectUpdateFieldValue> Fields
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set;
    }
}