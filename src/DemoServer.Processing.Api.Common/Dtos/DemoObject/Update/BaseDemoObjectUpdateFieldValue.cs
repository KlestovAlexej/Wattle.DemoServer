using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Api.Common.Dtos.DemoObject.Update;

/// <summary>
/// Базовое значение поля объекта для обновления.
/// </summary>
[JsonConverter(typeof(JsonSubtypes), "field")]
[JsonSubtypes.KnownSubType(typeof(DemoObjectUpdateFieldValueOfName), DemoObjectUpdateFields.Name)]
[JsonSubtypes.KnownSubType(typeof(DemoObjectUpdateFieldValueOfEnabled), DemoObjectUpdateFields.Enabled)]
[Description("Базовое значение поля объекта для обновления")]
[SwaggerDiscriminator("field")]
[SwaggerSubType(typeof(DemoObjectUpdateFieldValueOfName), DiscriminatorValue = nameof(DemoObjectUpdateFields.Name))]
[SwaggerSubType(typeof(DemoObjectUpdateFieldValueOfEnabled), DiscriminatorValue = nameof(DemoObjectUpdateFields.Enabled))]
public abstract class BaseDemoObjectUpdateFieldValue
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected BaseDemoObjectUpdateFieldValue(DemoObjectUpdateFields filed)
    {
        Field = filed;
    }

    /// <summary>
    /// Тип поля.
    /// </summary>
    [Description("Тип поля")]
    [JsonRequired]
    [JsonProperty(PropertyName = "field")]
    [EnumDataType(typeof(DemoObjectUpdateFields))]
    [JsonConverter(typeof(StringEnumConverter))]
    public DemoObjectUpdateFields Field
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }
}