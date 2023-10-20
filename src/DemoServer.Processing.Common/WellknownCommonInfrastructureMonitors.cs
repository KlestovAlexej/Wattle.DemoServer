using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Common;

/// <summary>
/// Идентификаторы интерфейсов мониторинга инфраструктуры.
/// </summary>
public static class WellknownCommonInfrastructureMonitors
{
    private static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

    static WellknownCommonInfrastructureMonitors()
    {
        WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod()!.DeclaringType);
    }

    /// <summary>
    /// Расписание создания партиций БД.
    /// </summary>
    [Description("Расписание создания партиций БД")]
    public static readonly Guid ActivatePartitionsSponsor = new("90F72243-5419-4622-8EAF-C9100E18403F");

    /// <summary>
    /// Очередь обработки аварийных ситуаций доменного поведения.
    /// </summary>
    [Description("Очередь обработки аварийных ситуаций доменного поведения")]
    public static readonly Guid QueueEmergencyDomainBehaviour = new("2CBFDCD6-02FF-4F0E-8F7C-90C0D1670DBB");

    /// <summary>
    /// Создатель партиций БД.
    /// </summary>
    [Description("Создатель партиций БД")]
    public static readonly Guid PartitionsSponsor = new("153EF7B4-AA4C-4EE4-B5A1-82CB5C4133A9");

    /// <summary>
    /// Пул лок-объектов сценария создания объекта 'Объект X'.
    /// </summary>
    [Description("Пул лок-объектов сценария создания объекта 'Объект X'")]
    public static readonly Guid LocksCreateDemoObjectX = new("82157EAD-A3AA-4E9B-9CED-6631BDC2F0A5");

    /// <summary>
    /// Пул лок-объектов сценария обновления объекта 'Объект'.
    /// </summary>
    [Description("Пул лок-объектов сценария обновления объекта 'Объект'")]
    public static readonly Guid LocksUpdateDemoObject = new("619026D1-E030-4DDB-A879-FF7169FE368F");

    /// <summary>
    /// Маппер данных состояния доменного объекта 'Объект' в БД.
    /// </summary>
    [Description("Маппер данных состояния доменного объекта 'Объект' в БД")]
    public static readonly Guid MapperDemoObject = new("ACF0F934-7A89-4AD7-A7E5-AD6E66639B7F");

    /// <summary>
    /// Кэш актуальных данных состояния доменного объекта 'Объект' в БД.
    /// </summary>
    [Description("Кэш актуальных данных состояния доменного объекта 'Объект' в БД")]
    public static readonly Guid MapperDemoObjectCacheActualStateDto = new("D40EF9A2-0C27-4859-A524-85FFB68920ED");

    /// <summary>
    /// Пул лок-объектов сценария обновления объекта 'Объект X'.
    /// </summary>
    [Description("Пул лок-объектов сценария обновления объекта 'Объект X'")]
    public static readonly Guid LocksUpdateDemoObjectX = new("96D3DDA8-E5DB-4253-BB31-2916AE0790A6");

    /// <summary>
    /// Маппер данных состояния доменного объекта 'Объект X' в БД.
    /// </summary>
    [Description("Маппер данных состояния доменного объекта 'Объект X' в БД")]
    public static readonly Guid MapperDemoObjectX = new("1133A907-5A1D-410A-9D66-B7C8392C9F36");

    /// <summary>
    /// Кэш актуальных данных состояния доменного объекта 'Объект X' в БД.
    /// </summary>
    [Description("Кэш актуальных данных состояния доменного объекта 'Объект X' в БД")]
    public static readonly Guid MapperDemoObjectXCacheActualStateDto = new("572ECC86-4280-4EF4-B250-8FD823E5637E");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName(Guid id)
    {
        return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
    }
}