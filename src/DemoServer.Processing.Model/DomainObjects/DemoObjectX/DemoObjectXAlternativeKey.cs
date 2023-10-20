using ShtrihM.DemoServer.Processing.Common;
using System;

namespace ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

/// <summary>
/// Альтернативный ключ объекта X.
/// </summary>
public readonly record struct DemoObjectXAlternativeKey(Guid Key1, string Key2)
{
    public static readonly string AlternativeKeyName = WellknownDomainObjectFields.DemoObjectX.NameAlternateKey;

    public static (Type[] TypeArguments, Func<DemoObjectXAlternativeKey, object[]> DecodeArguments) AlternativeKeyDecode
        => (new[] { typeof(Guid), typeof(string) }, key => new object[] { key.Key1, key.Key2 });
}