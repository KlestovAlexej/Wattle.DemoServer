using ShtrihM.DemoServer.Processing.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using ShtrihM.DemoServer.Processing.Model.DomainObjects.DemoObjectX;

namespace ShtrihM.DemoServer.Processing.Model.Interfaces;

/// <summary>
/// Объект X.
/// </summary>
[DomainObjectInterface(WellknownDomainObjects.Text.DemoObjectX)]
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
public interface IDomainObjectDemoObjectX : IDomainObject, IDomainObjectVersion
{
    DomainObjectDemoObjectX.AlternativeKey GetKey();
    void Delete();

    /// <summary>
    /// Дата создания.
    /// </summary>
    DateTimeOffset CreateDate { get; }

    /// <summary>
    /// Дата модификации.
    /// </summary>
    DateTimeOffset ModificationDate { get; }

    /// <summary>
    /// Название.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Признак разрешения работы.
    /// </summary>
    bool Enabled { get; set; }

    /// <summary>
    /// Альтернативный ключ - часть №1.
    /// </summary>
    Guid Key1 { get; }

    /// <summary>
    /// Альтернативный ключ - часть №2.
    /// </summary>
    string Key2 { get; }

    /// <summary>
    /// Номер группы.
    /// </summary>
    long Group { get; }
}