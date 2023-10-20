using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Common;

/// <summary>
/// Идентификаторы объектов.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class WellknownDomainObjects
{
    /// <summary>
    /// Идентификаторы объектов в текстовом виде.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public static class Text
    {
        /// <summary>
        /// Системный лог.
        /// </summary>
        public const string SystemLog = "4F3F6CCB-47C7-4AD8-B0FF-C8CBC1AF003F";

        /// <summary>
        /// Партиция таблицы БД.
        /// </summary>
        public const string TablePartition = "B426ED4E-B645-4C26-8EDD-63B1E89E899C";

        /// <summary>
        /// Контроль изменений.
        /// </summary>
        public const string ChangeTracker = "CFF5C7BE-9F43-4C15-9038-55CE28E2C810";

        /// <summary>
        /// Объект.
        /// </summary>
        public const string DemoObject = "86347CA3-B1EF-4C32-A9C0-E38E3B1D1C5D";

        /// <summary>
        /// Объект X.
        /// </summary>
        public const string DemoObjectX = "322D2242-C942-4643-BA8C-9E2E1E8A7828";
    }

    /// <summary>
    /// Все идентификаторы объектов и их описание.
    /// </summary>
    public static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

    static WellknownDomainObjects()
    {
        WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod()!.DeclaringType);

        WellknownDomainObjectDisplayNames.DisplayNamesProvider = GetDisplayName;
    }

    /// <summary>
    /// Системный лог.
    /// </summary>
    [Description("Системный лог")]
    public static readonly Guid SystemLog = new(Text.SystemLog);

    /// <summary>
    /// Контроль изменений.
    /// </summary>
    [Description("Контроль изменений")]
    public static readonly Guid ChangeTracker = new(Text.ChangeTracker);

    /// <summary>
    /// Партиция таблицы БД.
    /// </summary>
    [Description("Партиция таблицы БД")]
    public static readonly Guid TablePartition = new(Text.TablePartition);

    /// <summary>
    /// Объект.
    /// </summary>
    [Description("Объект")]
    public static readonly Guid DemoObject = new(Text.DemoObject);

    /// <summary>
    /// Объект X.
    /// </summary>
    [Description("Объект X")]
    public static readonly Guid DemoObjectX = new(Text.DemoObjectX);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName(Guid id)
    {
        return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
    }
}