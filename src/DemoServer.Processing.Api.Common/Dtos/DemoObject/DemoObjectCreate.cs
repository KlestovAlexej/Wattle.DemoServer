using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject;

/// <summary>
/// Создание объекта.
/// </summary>
[Description("Создание объекта")]
public sealed class DemoObjectCreate
{
    /// <summary>
    /// Название.
    /// </summary>
    [JsonRequired]
    [Description("Название")]
    [StringLength(FieldsConstants.DemoObjectNameMaxLength)]
    public string Name;

    /// <summary>
    /// Признак разрешения работы.
    /// </summary>
    [JsonRequired]
    [Description("Признак разрешения работы")]
    public bool Enabled;
}