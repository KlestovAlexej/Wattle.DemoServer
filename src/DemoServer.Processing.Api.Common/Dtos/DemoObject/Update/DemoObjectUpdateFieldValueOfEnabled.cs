using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Acme.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

/// <summary>
/// Значение поля объекта для обновления - признак разрешения работы.
/// </summary>
[Description("Значение поля объекта для обновления - признак разрешения работы")]
public sealed class DemoObjectUpdateFieldValueOfEnabled : BaseDemoObjectUpdateFieldValue
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once ConvertToPrimaryConstructor
    public DemoObjectUpdateFieldValueOfEnabled()
        : base(DemoObjectUpdateFields.Enabled)
    {
    }

    /// <summary>
    /// Признак разрешения работы.
    /// </summary>
    [JsonRequired]
    [Description("Признак разрешения работы")]
    public required bool Enabled { get; init; }
}