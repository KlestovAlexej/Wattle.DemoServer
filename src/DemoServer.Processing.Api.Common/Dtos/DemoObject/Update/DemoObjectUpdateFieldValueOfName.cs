using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

/// <summary>
/// Значение поля объекта для обновления - название.
/// </summary>
[Description("Значение поля объекта для обновления - название")]
public sealed class DemoObjectUpdateFieldValueOfName : BaseDemoObjectUpdateFieldValue
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DemoObjectUpdateFieldValueOfName()
        : base(DemoObjectUpdateFields.Name)
    {
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
}