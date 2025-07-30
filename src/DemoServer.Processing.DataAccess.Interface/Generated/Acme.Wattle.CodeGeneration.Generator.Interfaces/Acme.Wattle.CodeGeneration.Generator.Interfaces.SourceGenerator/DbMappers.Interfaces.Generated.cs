/*
* Файл создан автоматически. Не редактировать вручную.
*
* Интерфейсы мапперов.
*
* Генератор - Acme.Wattle.CodeGeneration.Generators.Mappers.MappersInterfacesCodeGenerator
*
*/

#nullable enable
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using MessagePack;
using MessagePack.Formatters;
using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.Mappers;
using Acme.Wattle.Mappers.Primitives;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Mappers.PostgreSql;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace Acme.DemoServer.Processing.Generated.Interface
{
    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Контроль изменений
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoCreate(WellknownMappersAsText.ChangeTracker)]
    public sealed partial class ChangeTrackerDtoNew : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

    }

    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Системный лог
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoCreate(WellknownMappersAsText.SystemLog)]
    public sealed partial class SystemLogDtoNew : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTimeOffset CreateDate;

        /// <summary>
        /// Код записи
        /// </summary>
        public required int Code;

        /// <summary>
        /// Тип записи
        /// </summary>
        public required int Type;

        /// <summary>
        /// Сообщение
        /// </summary>
        public required string Message;

        /// <summary>
        /// Данные
        /// </summary>
        public required string Data;

    }

    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Партиция таблицы БД
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoCreate(WellknownMappersAsText.TablePartition)]
    public sealed partial class TablePartitionDtoNew : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTimeOffset CreateDate;

        /// <summary>
        /// Имя таблицы БД
        /// </summary>
        public required string TableName;

        /// <summary>
        /// Имя партиции таблицы БД
        /// </summary>
        public required string PartitionName;

        /// <summary>
        /// День партиции таблицы БД
        /// </summary>
        public required DateTime Day;

        /// <summary>
        /// Минимальный идентификатор группы идентити хранимый в партиции
        /// </summary>
        public required long MinGroupId;

        /// <summary>
        /// Максимальный идентификатор группы идентити не хранимый в партиции
        /// </summary>
        public required long MaxNotIncludeGroupId;

        /// <summary>
        /// Минимальный идентити хранимый в партиции
        /// </summary>
        public required long MinId;

        /// <summary>
        /// Максимальный идентити не хранимый в партиции
        /// </summary>
        public required long MaxNotIncludeId;

    }

    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Объект
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoCreate(WellknownMappersAsText.DemoObject)]
    public sealed partial class DemoObjectDtoNew : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTime CreateDate;

        /// <summary>
        /// Дата модификации
        /// </summary>
        public required DateTime ModificationDate;

        /// <summary>
        /// Название
        /// </summary>
        public required string Name;

        /// <summary>
        /// Признак разрешения работы
        /// </summary>
        public required bool Enabled;

    }

    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Объект X
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoCreate(WellknownMappersAsText.DemoObjectX)]
    public sealed partial class DemoObjectXDtoNew : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTimeOffset CreateDate;

        /// <summary>
        /// Дата модификации
        /// </summary>
        public required DateTimeOffset ModificationDate;

        /// <summary>
        /// Название
        /// </summary>
        public required string Name;

        /// <summary>
        /// Признак разрешения работы
        /// </summary>
        public required bool Enabled;

        /// <summary>
        /// Альтернативный ключ - часть №1
        /// </summary>
        public required Guid Key1;

        /// <summary>
        /// Альтернативный ключ - часть №2
        /// </summary>
        public required string Key2;

        /// <summary>
        /// Номер группы
        /// </summary>
        public required long Group;

    }

    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Задача с отложенным запуском
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoCreate(WellknownMappersAsText.DemoDelayTask)]
    public sealed partial class DemoDelayTaskDtoNew : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Доступность.
        /// </summary>
        public required bool Available;

        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTimeOffset CreateDate;

        /// <summary>
        /// Дата модификации
        /// </summary>
        public required DateTimeOffset ModificationDate;

        /// <summary>
        /// Сценарий
        /// </summary>
        public required string Scenario;

        /// <summary>
        /// Состояние сценария
        /// </summary>
        public required byte[] ScenarioState;

        /// <summary>
        /// Дата запуска
        /// </summary>
        public required DateTimeOffset? StartDate;

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Контроль изменений
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoSelect(WellknownMappersAsText.ChangeTracker)]
    [DataContract]
    public sealed partial class ChangeTrackerDtoActual : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        [DataMember(Order = 1)]
        public long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Системный лог
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoSelect(WellknownMappersAsText.SystemLog)]
    [DataContract]
    public sealed partial class SystemLogDtoActual : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        [DataMember(Order = 1)]
        public long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [DataMember(Order = 2)]
        public DateTimeOffset CreateDate;

        /// <summary>
        /// Код записи
        /// </summary>
        [DataMember(Order = 3)]
        public int Code;

        /// <summary>
        /// Тип записи
        /// </summary>
        [DataMember(Order = 4)]
        public int Type;

        /// <summary>
        /// Сообщение
        /// </summary>
        [DataMember(Order = 5)]
        public string Message;

        /// <summary>
        /// Данные
        /// </summary>
        [DataMember(Order = 6)]
        public string Data;

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Партиция таблицы БД
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoSelect(WellknownMappersAsText.TablePartition)]
    [DataContract]
    public sealed partial class TablePartitionDtoActual : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        [DataMember(Order = 1)]
        public long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [DataMember(Order = 2)]
        public DateTimeOffset CreateDate;

        /// <summary>
        /// Имя таблицы БД
        /// </summary>
        [DataMember(Order = 3)]
        public string TableName;

        /// <summary>
        /// Имя партиции таблицы БД
        /// </summary>
        [DataMember(Order = 4)]
        public string PartitionName;

        /// <summary>
        /// День партиции таблицы БД
        /// </summary>
        [DataMember(Order = 5)]
        [MessagePackFormatter(typeof(MessagePackFormatterForDateTime))]
        public DateTime Day;

        /// <summary>
        /// Минимальный идентификатор группы идентити хранимый в партиции
        /// </summary>
        [DataMember(Order = 6)]
        public long MinGroupId;

        /// <summary>
        /// Максимальный идентификатор группы идентити не хранимый в партиции
        /// </summary>
        [DataMember(Order = 7)]
        public long MaxNotIncludeGroupId;

        /// <summary>
        /// Минимальный идентити хранимый в партиции
        /// </summary>
        [DataMember(Order = 8)]
        public long MinId;

        /// <summary>
        /// Максимальный идентити не хранимый в партиции
        /// </summary>
        [DataMember(Order = 9)]
        public long MaxNotIncludeId;

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Объект
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoSelect(WellknownMappersAsText.DemoObject)]
    [DataContract]
    public sealed partial class DemoObjectDtoActual : IMapperDtoVersion
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        [DataMember(Order = 1)]
        public long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Номер ревизии данных.
        /// </summary>
        [DataMember(Order = 2)]
        public long Revision { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [DataMember(Order = 3)]
        [MessagePackFormatter(typeof(MessagePackFormatterForDateTime))]
        public DateTime CreateDate;

        /// <summary>
        /// Дата модификации
        /// </summary>
        [DataMember(Order = 4)]
        [MessagePackFormatter(typeof(MessagePackFormatterForDateTime))]
        public DateTime ModificationDate;

        /// <summary>
        /// Название
        /// </summary>
        [DataMember(Order = 5)]
        public string Name;

        /// <summary>
        /// Признак разрешения работы
        /// </summary>
        [DataMember(Order = 6)]
        public bool Enabled;

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Объект X
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoSelect(WellknownMappersAsText.DemoObjectX)]
    [DataContract]
    public sealed partial class DemoObjectXDtoActual : IMapperDtoVersion
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        [DataMember(Order = 1)]
        public long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Номер ревизии данных.
        /// </summary>
        [DataMember(Order = 2)]
        public long Revision { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [DataMember(Order = 3)]
        public DateTimeOffset CreateDate;

        /// <summary>
        /// Дата модификации
        /// </summary>
        [DataMember(Order = 4)]
        public DateTimeOffset ModificationDate;

        /// <summary>
        /// Название
        /// </summary>
        [DataMember(Order = 5)]
        public string Name;

        /// <summary>
        /// Признак разрешения работы
        /// </summary>
        [DataMember(Order = 6)]
        public bool Enabled;

        /// <summary>
        /// Альтернативный ключ - часть №1
        /// </summary>
        [DataMember(Order = 7)]
        public Guid Key1;

        /// <summary>
        /// Альтернативный ключ - часть №2
        /// </summary>
        [DataMember(Order = 8)]
        public string Key2;

        /// <summary>
        /// Номер группы
        /// </summary>
        [DataMember(Order = 9)]
        public long Group;

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Задача с отложенным запуском
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoSelect(WellknownMappersAsText.DemoDelayTask)]
    [DataContract]
    public sealed partial class DemoDelayTaskDtoActual : IMapperDtoVersion
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        [DataMember(Order = 1)]
        public long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Номер ревизии данных.
        /// </summary>
        [DataMember(Order = 2)]
        public long Revision { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Доступность.
        /// </summary>
        [DataMember(Order = 3)]
        public bool Available;

        /// <summary>
        /// Дата создания
        /// </summary>
        [DataMember(Order = 4)]
        public DateTimeOffset CreateDate;

        /// <summary>
        /// Дата модификации
        /// </summary>
        [DataMember(Order = 5)]
        public DateTimeOffset ModificationDate;

        /// <summary>
        /// Сценарий
        /// </summary>
        [DataMember(Order = 6)]
        public string Scenario;

        /// <summary>
        /// Состояние сценария
        /// </summary>
        [DataMember(Order = 7)]
        public byte[] ScenarioState;

        /// <summary>
        /// Дата запуска
        /// </summary>
        [DataMember(Order = 8)]
        public DateTimeOffset? StartDate;

    }

    /// <summary>
    /// Класс данных состояния изменённого доменного объекта.
    /// Объект
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoUpdate(WellknownMappersAsText.DemoObject)]
    public sealed partial class DemoObjectDtoChanged : IMapperDtoVersion
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Номер ревизии данных.
        /// </summary>
        public required long Revision { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTime CreateDate;

        /// <summary>
        /// Дата модификации
        /// </summary>
        public required DateTime ModificationDate;

        /// <summary>
        /// Название
        /// </summary>
        public required MapperChangedStateDtoField<string> Name;

        /// <summary>
        /// Признак разрешения работы
        /// </summary>
        public required MapperChangedStateDtoField<bool> Enabled;

    }

    /// <summary>
    /// Класс данных состояния изменённого доменного объекта.
    /// Объект X
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoUpdate(WellknownMappersAsText.DemoObjectX)]
    public sealed partial class DemoObjectXDtoChanged : IMapperDtoVersion
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Номер ревизии данных.
        /// </summary>
        public required long Revision { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTimeOffset CreateDate;

        /// <summary>
        /// Дата модификации
        /// </summary>
        public required DateTimeOffset ModificationDate;

        /// <summary>
        /// Название
        /// </summary>
        public required MapperChangedStateDtoField<string> Name;

        /// <summary>
        /// Признак разрешения работы
        /// </summary>
        public required MapperChangedStateDtoField<bool> Enabled;

        /// <summary>
        /// Альтернативный ключ - часть №1
        /// </summary>
        public required Guid Key1;

        /// <summary>
        /// Альтернативный ключ - часть №2
        /// </summary>
        public required string Key2;

        /// <summary>
        /// Номер группы
        /// </summary>
        public required long Group;

    }

    /// <summary>
    /// Класс данных состояния изменённого доменного объекта.
    /// Задача с отложенным запуском
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoUpdate(WellknownMappersAsText.DemoDelayTask)]
    public sealed partial class DemoDelayTaskDtoChanged : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Доступность.
        /// </summary>
        public required bool Available;

        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTimeOffset CreateDate;

        /// <summary>
        /// Дата модификации
        /// </summary>
        public required DateTimeOffset ModificationDate;

        /// <summary>
        /// Сценарий
        /// </summary>
        public required string Scenario;

        /// <summary>
        /// Состояние сценария
        /// </summary>
        public required byte[] ScenarioState;

        /// <summary>
        /// Дата запуска
        /// </summary>
        public required DateTimeOffset? StartDate;

    }

    /// <summary>
    /// Класс данных состояния удалённого доменного объекта.
    /// Объект X
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoDelete(WellknownMappersAsText.DemoObjectX)]
    public sealed partial class DemoObjectXDtoDeleted : IMapperDtoVersion
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public required long Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

        /// <summary>
        /// Номер ревизии данных.
        /// </summary>
        public required long Revision { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] set; }

    }

    /// <summary>
    /// Идентификаторы мапперов в тектовом виде.
    /// </summary>
    public static class WellknownMappersAsText
    {
        /// <summary>
        /// Контроль изменений
        /// </summary>
        public const string ChangeTracker = "cff5c7be-9f43-4c15-9038-55ce28e2c810";

        /// <summary>
        /// Системный лог
        /// </summary>
        public const string SystemLog = "4f3f6ccb-47c7-4ad8-b0ff-c8cbc1af003f";

        /// <summary>
        /// Партиция таблицы БД
        /// </summary>
        public const string TablePartition = "b426ed4e-b645-4c26-8edd-63b1e89e899c";

        /// <summary>
        /// Объект
        /// </summary>
        public const string DemoObject = "86347ca3-b1ef-4c32-a9c0-e38e3b1d1c5d";

        /// <summary>
        /// Объект X
        /// </summary>
        public const string DemoObjectX = "322d2242-c942-4643-ba8c-9e2e1e8a7828";

        /// <summary>
        /// Задача с отложенным запуском
        /// </summary>
        public const string DemoDelayTask = "5f729000-5139-469f-90b8-74301e342df3";

    }

    /// <summary>
    /// Идентификаторы мапперов.
    /// </summary>
    public static class WellknownMappers
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly Dictionary<Guid, string> DisplayNames;

        static WellknownMappers()
        {
            DisplayNames = new Dictionary<Guid, string>
            {
                {new Guid(WellknownMappersAsText.ChangeTracker), @"Контроль изменений"},
                {new Guid(WellknownMappersAsText.SystemLog), @"Системный лог"},
                {new Guid(WellknownMappersAsText.TablePartition), @"Партиция таблицы БД"},
                {new Guid(WellknownMappersAsText.DemoObject), @"Объект"},
                {new Guid(WellknownMappersAsText.DemoObjectX), @"Объект X"},
                {new Guid(WellknownMappersAsText.DemoDelayTask), @"Задача с отложенным запуском"},
            };
        }

        /// <summary>
        /// Контроль изменений
        /// </summary>
        public static readonly Guid ChangeTracker = new Guid(WellknownMappersAsText.ChangeTracker);

        /// <summary>
        /// Системный лог
        /// </summary>
        public static readonly Guid SystemLog = new Guid(WellknownMappersAsText.SystemLog);

        /// <summary>
        /// Партиция таблицы БД
        /// </summary>
        public static readonly Guid TablePartition = new Guid(WellknownMappersAsText.TablePartition);

        /// <summary>
        /// Объект
        /// </summary>
        public static readonly Guid DemoObject = new Guid(WellknownMappersAsText.DemoObject);

        /// <summary>
        /// Объект X
        /// </summary>
        public static readonly Guid DemoObjectX = new Guid(WellknownMappersAsText.DemoObjectX);

        /// <summary>
        /// Задача с отложенным запуском
        /// </summary>
        public static readonly Guid DemoDelayTask = new Guid(WellknownMappersAsText.DemoDelayTask);

        public static string GetDisplayName(Guid id)
        {
            if (DisplayNames.TryGetValue(id, out var result))
            {
                return (result);
            }

            return (id.ToString());
        }
    }

    /// <summary>
    /// Контроль изменений
    /// </summary>
    [MapperInterface(WellknownMappersAsText.ChangeTracker)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperChangeTracker : IMapper, IAbstractMapper, IPartitionsMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_ChangeTracker".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_ChangeTracker".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_ChangeTracker".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записи с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        bool Exists(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записи с указаным идентити..
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRaw(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         ChangeTrackerDtoActual? Get(IMappersSession mappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         ValueTask<IMapperDto?> GetAsync(IMappersSession mappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ChangeTrackerDtoActual? GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<ChangeTrackerDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<ChangeTrackerDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<ChangeTrackerDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ChangeTrackerDtoActual New(IMappersSession session, ChangeTrackerDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> NewAsync(IMappersSession session, ChangeTrackerDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        new IEnumerable<ChangeTrackerDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IAsyncEnumerable<ChangeTrackerDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<ChangeTrackerDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<ChangeTrackerDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null);
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Системный лог
    /// </summary>
    [MapperInterface(WellknownMappersAsText.SystemLog)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperSystemLog : IMapper, IAbstractMapper, IPartitionsMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_SystemLog".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_SystemLog".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_SystemLog".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записи с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        bool Exists(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записи с указаным идентити..
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRaw(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         SystemLogDtoActual? Get(IMappersSession mappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         ValueTask<IMapperDto?> GetAsync(IMappersSession mappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        SystemLogDtoActual? GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<SystemLogDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<SystemLogDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<SystemLogDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        SystemLogDtoActual New(IMappersSession session, SystemLogDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> NewAsync(IMappersSession session, SystemLogDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        new IEnumerable<SystemLogDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IAsyncEnumerable<SystemLogDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<SystemLogDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<SystemLogDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null);
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Партиция таблицы БД
    /// </summary>
    [MapperInterface(WellknownMappersAsText.TablePartition)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperTablePartition : IMapper, IAbstractMapper, IPartitionsMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_TablePartition".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_TablePartition".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_TablePartition".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записи с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        bool Exists(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записи с указаным идентити..
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRaw(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         TablePartitionDtoActual? Get(IMappersSession mappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         ValueTask<IMapperDto?> GetAsync(IMappersSession mappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        TablePartitionDtoActual? GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<TablePartitionDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<TablePartitionDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<TablePartitionDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        TablePartitionDtoActual New(IMappersSession session, TablePartitionDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> NewAsync(IMappersSession session, TablePartitionDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        new IEnumerable<TablePartitionDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IAsyncEnumerable<TablePartitionDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TablePartitionDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TablePartitionDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null);
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Объект
    /// </summary>
    [MapperInterface(WellknownMappersAsText.DemoObject)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperDemoObject : IMapper, IAbstractMapper, IPartitionsMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoObject".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_DemoObject".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoObject".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записи с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        bool Exists(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записи с указаным идентити..
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRaw(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRevision(IMappersSession session, long id, long revision);

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRevisionAsync(IMappersSession session, long id, long revision, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         DemoObjectDtoActual? Get(IMappersSession mappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         ValueTask<IMapperDto?> GetAsync(IMappersSession mappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        DemoObjectDtoActual? GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<DemoObjectDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        DemoObjectDtoActual Update(IMappersSession session, DemoObjectDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> UpdateAsync(IMappersSession session, DemoObjectDtoChanged data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<DemoObjectDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<DemoObjectDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        DemoObjectDtoActual New(IMappersSession session, DemoObjectDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> NewAsync(IMappersSession session, DemoObjectDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        new IEnumerable<DemoObjectDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IAsyncEnumerable<DemoObjectDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<DemoObjectDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<DemoObjectDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null);
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Объект X
    /// </summary>
    [MapperInterface(WellknownMappersAsText.DemoObjectX)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperDemoObjectX : IMapper, IAbstractMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoObjectX".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_DemoObjectX".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoObjectX".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записи с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        bool Exists(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записи по альтернативному ключу 'Уникальность по 'Альтернативный ключ - часть №1 и №2''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        bool ExistsByKey(IMappersSession session, Guid argKey1, string argKey2);

        /// <summary>
        /// Проверка существования записи с указаным идентити..
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записи по альтернативному ключу 'Уникальность по 'Альтернативный ключ - часть №1 и №2''..
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        ValueTask<bool> ExistsByKeyAsync(IMappersSession session, Guid argKey1, string argKey2, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRaw(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRevision(IMappersSession session, long id, long revision);

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRevisionAsync(IMappersSession session, long id, long revision, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         DemoObjectXDtoActual? Get(IMappersSession mappersSession, long id);

        /// <summary>
        /// Получить запись записи по альтернативному ключу 'Уникальность по 'Альтернативный ключ - часть №1 и №2''.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         DemoObjectXDtoActual? GetByKey(IMappersSession mappersSession, Guid argKey1, string argKey2);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         ValueTask<IMapperDto?> GetAsync(IMappersSession mappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись по альтернативному ключу 'Уникальность по 'Альтернативный ключ - часть №1 и №2''.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
         ValueTask<IMapperDto?> GetByKeyAsync(IMappersSession mappersSession, Guid argKey1, string argKey2, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        DemoObjectXDtoActual? GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<DemoObjectXDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        DemoObjectXDtoActual Update(IMappersSession session, DemoObjectXDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> UpdateAsync(IMappersSession session, DemoObjectXDtoChanged data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<DemoObjectXDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<DemoObjectXDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        DemoObjectXDtoActual New(IMappersSession session, DemoObjectXDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> NewAsync(IMappersSession session, DemoObjectXDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        void Delete(IMappersSession session, DemoObjectXDtoDeleted data);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask DeleteAsync(IMappersSession session, DemoObjectXDtoDeleted data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        new IEnumerable<DemoObjectXDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей коллекции 'Группировка по 'Номер группы''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argGroup">Номер группы</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
         IEnumerable<DemoObjectXDtoActual> GetEnumeratorAsGroup(IMappersSession session, long argGroup);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IAsyncEnumerable<DemoObjectXDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей коллекции 'Группировка по 'Номер группы''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argGroup">Номер группы</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IAsyncEnumerable<DemoObjectXDtoActual> GetEnumeratorAsGroupAsync(IMappersSession session, long argGroup, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<DemoObjectXDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<DemoObjectXDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null);
        /// <summary>
        /// Получить количество записей коллекции 'Группировка по 'Номер группы''.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="argGroup">Номер группы</param>
        /// <returns>Возвращает количество записей коллекции.</returns>
        long GetCountByGroup(IMappersSession mappersSession, long argGroup);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Получить количество записей коллекции 'Группировка по 'Номер группы''.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="argGroup">Номер группы</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает количество записей коллекции.</returns>
        ValueTask<long> GetCountByGroupAsync(IMappersSession mappersSession, long argGroup, CancellationToken cancellationToken = default);

    }

    /// <summary>
    /// Задача с отложенным запуском
    /// </summary>
    [MapperInterface(WellknownMappersAsText.DemoDelayTask)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperDemoDelayTask : IMapper, IAbstractMapper, IPartitionsMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoDelayTask".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_DemoDelayTask".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoDelayTask".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записи с указаным идентити.
        /// ВАЖНО : Проверка не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует или скрыта.</returns>
        bool Exists(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записи с указаным идентити..
        /// ВАЖНО : Проверка не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует или скрыта.</returns>
        ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRaw(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует или скрыта.</returns>
         DemoDelayTaskDtoActual? Get(IMappersSession mappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует или скрыта.</returns>
         ValueTask<IMapperDto?> GetAsync(IMappersSession mappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        DemoDelayTaskDtoActual? GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<DemoDelayTaskDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить запись.
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        DemoDelayTaskDtoActual Update(IMappersSession session, DemoDelayTaskDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> UpdateAsync(IMappersSession session, DemoDelayTaskDtoChanged data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<DemoDelayTaskDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<DemoDelayTaskDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        DemoDelayTaskDtoActual New(IMappersSession session, DemoDelayTaskDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> NewAsync(IMappersSession session, DemoDelayTaskDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        new IEnumerable<DemoDelayTaskDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        IAsyncEnumerable<DemoDelayTaskDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<DemoDelayTaskDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        IEnumerable<DemoDelayTaskDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей кроме скрытых записей.</returns>
        IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки кроме скрытых записей.</returns>
        long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null);
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки кроме скрытых записей.</returns>
        ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default);
    }

}
