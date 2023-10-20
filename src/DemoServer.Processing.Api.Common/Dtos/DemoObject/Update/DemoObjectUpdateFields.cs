using System.ComponentModel;

namespace ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

/// <summary>
/// Типы полей объекта доступные для обновления.
/// </summary>
[Description("Типы полей объекта доступные для обновления")]
public enum DemoObjectUpdateFields
{
    /// <summary>
    /// Название.
    /// </summary>
    [Description("Название")]
    Name = 1,

    /// <summary>
    /// Признак разрешения работы.
    /// </summary>
    [Description("Признак разрешения работы")]
    Enabled = 2,
}
