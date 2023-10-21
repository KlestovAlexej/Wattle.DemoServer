using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

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
    public long Id;

    /// <summary>
    /// Значения полей объекта для обновления.
    /// </summary>
    [JsonRequired]
    [Description("Значения полей объекта для обновления")]
    public List<BaseDemoObjectUpdateFieldValue> Fields;
}