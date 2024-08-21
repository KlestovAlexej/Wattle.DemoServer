using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
    public required long Id { get; init; }

    /// <summary>
    /// Значения полей объекта для обновления.
    /// </summary>
    [JsonRequired]
    [Description("Значения полей объекта для обновления")]
    public required List<BaseDemoObjectUpdateFieldValue> Fields { get; init; }
}