using NpgsqlTypes;
using ShtrihM.DemoServer.Common;
using ShtrihM.DemoServer.Processing.Api.Common;
using ShtrihM.Wattle3.CodeGeneration.Common;
using ShtrihM.Wattle3.Common;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ShtrihM.DemoServer.Processing.Common;

/// <summary>
/// Поля доменных объектов.
/// <remarks>
/// При изменении руками запутить тест <code>ShtrihM.DemoServer.Processing.Tests.DbMappersSchemaXmlBuilder.Test</code>
/// Для пересоздания XML схемы мапперов <code>src\DemoServer.Processing.Model\DbMappers.Schema.xml</code>.
/// </remarks>
/// </summary>
[Description("Мапперы")]
[SchemaMappers(SchemaMapperStorage.PostgreSql, Namespace = "ShtrihM.DemoServer.Processing")]
public static class WellknownDomainObjectFields
{
    /// <summary>
    /// Все поля доменных объектов и их описание.
    /// </summary>
    private static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

    static WellknownDomainObjectFields()
    {
        var mainType = MethodBase.GetCurrentMethod()!.DeclaringType;
        var types = mainType!.GetNestedTypes();
        var displayNames = new Dictionary<Guid, string>(CommonDomainObjectValues.DisplayNames);
        foreach (var type in types)
        {
            WellknowConstantsHelper.CollectDisplayNames(displayNames, type);
        }
        DisplayNames = displayNames;
    }

    #region Контроль изменений
    /// <summary>
    /// Контроль изменений.
    /// </summary>
    [Description("Контроль изменений")]
    [SchemaMapper(MapperId = WellknownDomainObjects.Text.ChangeTracker)]
    [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel, PartitionsExpandInterface = true)]
    [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
    public static class ChangeTracker
    {
        /* Нет полей */
    }
    #endregion

    #region Системный лог
    /// <summary>
    /// Системный лог.
    /// </summary>
    [Description("Системный лог")]
    [SchemaMapper(MapperId = WellknownDomainObjects.Text.SystemLog)]
    [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel, PartitionsExpandInterface = true)]
    [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
    public static class SystemLog
    {
        /// <summary>
        /// Дата создания.
        /// </summary>
        [Description("Дата создания")]
        [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
        public static readonly Guid CreateDate = new("FABB42ED-5C3A-4234-8BF6-0CFFA10BAA18");

        /// <summary>
        /// Код записи <seealso cref="WellknownSytemLogCodes"/>.
        /// </summary>
        [Description("Код записи")]
        [SchemaMapperField(typeof(int), Where = true, Order = true)]
        public static readonly Guid Code = new("E3D3D0F8-7E96-4979-BF73-B0B527E6F76C");

        /// <summary>
        /// Тип записи <seealso cref="WellknownSytemLogTypes"/>.
        /// </summary>
        [Description("Тип записи")]
        [SchemaMapperField(typeof(int), Where = true, Order = true)]
        public static readonly Guid Type = new("FF1C3D22-44DE-4488-8FD3-1E5925FFA40A");

        /// <summary>
        /// Сообщение.
        /// </summary>
        [Description("Сообщение")]
        [SchemaMapperField(typeof(string), Where = true, Order = true, DbSize = Constants.SystemLogFieldMaxSizeMessage)]
        public static readonly Guid Message = new("B446C595-7046-42EC-8B51-D67AC42328BE");

        /// <summary>
        /// Данные.
        /// </summary>
        [Description("Данные")]
        [SchemaMapperField(typeof(string), Where = true)]
        public static readonly Guid Data = new("E4E2C27A-124D-44DE-93E7-62B411C24D6A");
    }
    #endregion

    #region Партиция таблицы БД
    /// <summary>
    /// Партиция таблицы БД.
    /// </summary>
    [Description("Партиция таблицы БД")]
    [SchemaMapper(MapperId = WellknownDomainObjects.Text.TablePartition)]
    [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel, PartitionsExpandInterface = true)]
    [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
    public static class TablePartition
    {
        /// <summary>
        /// Дата создания.
        /// </summary>
        [Description("Дата создания")]
        [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
        public static readonly Guid CreateDate = new("E2B3ECF0-17B5-4212-9DA0-3C05F17E5C3F");

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        [Description("Имя таблицы БД")]
        [SchemaMapperField(typeof(string), Where = true, Order = true)]
        public static readonly Guid TableName = new("0617EEAF-95C0-4E62-ABC8-4F32FC81C0EF");

        /// <summary>
        /// Имя партиции таблицы БД.
        /// </summary>
        [Description("Имя партиции таблицы БД")]
        [SchemaMapperField(typeof(string), Where = true, Order = true)]
        public static readonly Guid PartitionName = new("1A062039-4A49-4D63-80C0-BCD0AC79B200");

        /// <summary>
        /// День партиции таблицы БД.
        /// </summary>
        [Description("День партиции таблицы БД")]
        [SchemaMapperField(typeof(DateTime), Where = true, Order = true, DbColumnTypeName = nameof(NpgsqlDbType.Date))]
        public static readonly Guid Day = new("840EDB69-C08F-4D64-A05A-440888CC7398");

        /// <summary>
        /// Минимальный идентификатор группы идентити хранимый в партиции.
        /// </summary>
        [Description("Минимальный идентификатор группы идентити хранимый в партиции")]
        [SchemaMapperField(typeof(long), Where = true, Order = true)]
        public static readonly Guid MinGroupId = new("72889C90-73C2-4D41-82C1-C36C27FFD0A8");

        /// <summary>
        /// Максимальный идентификатор группы идентити не хранимый в партиции.
        /// </summary>
        [Description("Максимальный идентификатор группы идентити не хранимый в партиции")]
        [SchemaMapperField(typeof(long), Where = true, Order = true)]
        public static readonly Guid MaxNotIncludeGroupId = new("408730B7-2FA1-4B3E-A6A8-74E7EFA0397B");

        /// <summary>
        /// Минимальный идентити хранимый в партиции.
        /// </summary>
        [Description("Минимальный идентити хранимый в партиции")]
        [SchemaMapperField(typeof(long), Where = true, Order = true)]
        public static readonly Guid MinId = new("087D9636-4846-400B-8882-8D10B22339FB");

        /// <summary>
        /// Максимальный идентити не хранимый в партиции.
        /// </summary>
        [Description("Максимальный идентити не хранимый в партиции")]
        [SchemaMapperField(typeof(long), Where = true, Order = true)]
        public static readonly Guid MaxNotIncludeId = new("621E6E67-B436-4767-B933-E4313B6CC80C");
    }
    #endregion

    #region Объект
    /// <summary>
    /// Объект.
    /// </summary>
    [Description("Объект")]
    [SchemaMapper(MapperId = WellknownDomainObjects.Text.DemoObject, DeleteMode = SchemaMapperDeleteMode.Disabled, IsCached = true, UpdateCacheOnEnumerator = true)]
    [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel, PartitionsExpandInterface = true)]
    [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
    [SchemaMapperRevisionField(IsVersion = true)]
    public static class DemoObject
    {
        /// <summary>
        /// Дата создания.
        /// </summary>
        [Description("Дата создания")]
        [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
        public static readonly Guid CreateDate = new("19D14B24-D899-4AD9-B97B-AE7A7B12FFF8");

        /// <summary>
        /// Дата модификации.
        /// </summary>
        [Description("Дата модификации")]
        [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
        public static readonly Guid ModificationDate = new("F69BAE78-0FBD-426A-971C-63DCC6D7F4F7");

        /// <summary>
        /// Название.
        /// </summary>
        [Description("Название")]
        [SchemaMapperField(typeof(string), Where = true, Order = true, DbSize = FieldsConstants.DemoObjectNameMaxLength, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
        public static readonly Guid Name = new("C1DD6A57-D661-4487-9610-F6F35D78744F");

        /// <summary>
        /// Признак разрешения работы.
        /// </summary>
        [Description("Признак разрешения работы")]
        [SchemaMapperField(typeof(bool), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
        public static readonly Guid Enabled = new("51DBEDEF-4206-473D-85D2-B189426F5456");
    }
    #endregion

    #region Объект X
    /// <summary>
    /// Объект X.
    /// </summary>
    [Description("Объект X")]
    [SchemaMapper(MapperId = WellknownDomainObjects.Text.DemoObjectX, DeleteMode = SchemaMapperDeleteMode.Delete, IsCached = true, UpdateCacheOnEnumerator = true)]
    [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
    [SchemaMapperRevisionField(IsVersion = true)]
    [SchemaMapperAlternateKey(NameAlternateKey, "Уникальность по 'Альтернативный ключ - часть №1 и №2'")]
    [SchemaMapperCollection(NameCollection, "Группировка по 'Номер группы'")]
    public static class DemoObjectX
    {
        public const string NameAlternateKey = "Key";
        public const string NameCollection = nameof(Group);
        public const int IndexAlternateKeyValue1 = 0;
        public const int IndexAlternateKeyValue2 = 1;

        /// <summary>
        /// Дата создания.
        /// </summary>
        [Description("Дата создания")]
        [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
        public static readonly Guid CreateDate = new("CD109655-1DC8-4E88-AA24-5C27E3EF778F");

        /// <summary>
        /// Дата модификации.
        /// </summary>
        [Description("Дата модификации")]
        [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
        public static readonly Guid ModificationDate = new("6862D6BB-3405-48C1-864C-46601DA5726B");

        /// <summary>
        /// Название.
        /// </summary>
        [Description("Название")]
        [SchemaMapperField(typeof(string), Where = true, Order = true, DbSize = FieldsConstants.DemoObjectXNameMaxLength, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
        public static readonly Guid Name = new("0C54E3F8-3754-4B99-A144-A8C3D5E15958");

        /// <summary>
        /// Признак разрешения работы.
        /// </summary>
        [Description("Признак разрешения работы")]
        [SchemaMapperField(typeof(bool), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
        public static readonly Guid Enabled = new("070EF35A-908F-450E-92B6-508E52DC5306");

        /// <summary>
        /// Альтернативный ключ - часть №1.
        /// </summary>
        [Description("Альтернативный ключ - часть №1")]
        [SchemaMapperField(typeof(Guid), Where = true, Order = true)]
        [SchemaMapperFieldAlternateKey(NameAlternateKey, IndexAlternateKeyValue1)]
        public static readonly Guid Key1 = new("14367E40-CC94-47A7-8FBD-47E81C62B9BD");

        /// <summary>
        /// Альтернативный ключ - часть №2.
        /// </summary>
        [Description("Альтернативный ключ - часть №2")]
        [SchemaMapperField(typeof(string), Where = true, Order = true, DbSize = FieldsConstants.DemoObjectXKey2MaxLength)]
        [SchemaMapperFieldAlternateKey(NameAlternateKey, IndexAlternateKeyValue2)]
        public static readonly Guid Key2 = new("95D0BDF7-5420-4B5C-B89B-7C7979A05F99");

        /// <summary>
        /// Номер группы.
        /// </summary>
        [Description("Номер группы")]
        [SchemaMapperField(typeof(long), Where = true, Order = true, Name = "group")]
        [SchemaMapperFieldPostgreSql(IsQuotedName = true)]
        [SchemaMapperFieldCollection(NameCollection, 1)]
        public static readonly Guid Group = new("F8B8B8CE-11B8-4108-B811-A5FC7255238A");
    }
    #endregion

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName(Guid id)
    {
        return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
    }
}