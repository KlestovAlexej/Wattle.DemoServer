using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;

/// <summary>
/// Данные объекта.
/// </summary>
[Description("Данные объекта")]
public sealed class DemoObjectInfo
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
    /// Название.
    /// </summary>
    [JsonRequired]
    [Description("Название")]
    [StringLength(FieldsConstants.DemoObjectNameMaxLength)]
    public string Name
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set;
    }

    /// <summary>
    /// Признак разрешения работы.
    /// </summary>
    [JsonRequired]
    [Description("Признак разрешения работы")]
    public bool Enabled
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set;
    }
}