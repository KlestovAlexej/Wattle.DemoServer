using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
    public required long Id { get; init; }

    /// <summary>
    /// Название.
    /// </summary>
    [JsonRequired] 
    [Description("Название")] 
    [StringLength(FieldsConstants.DemoObjectNameMaxLength)]
    public required string Name { get; init; }

    /// <summary>
    /// Признак разрешения работы.
    /// </summary>
    [JsonRequired]
    [Description("Признак разрешения работы")]
    public required bool Enabled { get; init; }
}
