using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

/// <summary>
/// Значение поля объекта для обновления - название.
/// </summary>
[Description("Значение поля объекта для обновления - название")]
public sealed class DemoObjectUpdateFieldValueOfName : BaseDemoObjectUpdateFieldValue
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
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
    public string Name;
}