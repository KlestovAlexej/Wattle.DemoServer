using Newtonsoft.Json;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Json;
using Acme.Wattle.Json.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Acme.DemoServer.Processing.Common;
using Acme.Wattle.CodeGeneration.Common;
using Acme.Wattle.Common.Exceptions;
using Acme.Wattle.Mappers.Interfaces;

namespace Acme.DemoServer.Processing.Model.Implements.SystemSettings;

/// <summary>
/// Настройки создателя партиций БД.
/// </summary>
[Description("Настройки создателя партиций БД")]
[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
public sealed class PartitionsSponsorSettings
{
    /// <summary>
    /// Настройки параметров создания партиций таблиц БД.
    /// </summary>
    [Description("Настройки параметров создания партиций таблиц БД")]
    public sealed class TablesCreatePartitionOptionsSettings
    {
        [SuppressMessage("ReSharper", "PreferConcreteValueOverDefault")]
        [SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
        public TablesCreatePartitionOptionsSettings()
        {
            Enabled =
                new SettingValue<bool>(
                    default,
                    "Разрешает ипользование настроек");

            Tables =
                new SettingValue<List<TableCreatePartitionOptionsSettings>>(
                    default!,
                    "Настройки параметров создания партиций таблиц БД");
        }

        /// <summary>
        /// Разрешает ипользование настроек.
        /// </summary>
        [Description("Разрешает ипользование настроек")]
        [JsonRequired]
        public SettingValue<bool> Enabled { get; set; }

        /// <summary>
        /// Настройки параметров создания партиций таблиц БД.
        /// </summary>
        [Description("Настройки параметров создания партиций таблиц БД")]
        [JsonRequired]
        public SettingValue<List<TableCreatePartitionOptionsSettings>> Tables { get; set; }

        /// <summary>
        /// Настройки по умолчанию.
        /// </summary>
        // ReSharper disable once MemberHidesStaticFromOuterClass
        public static TablesCreatePartitionOptionsSettings GetDefault(IMappers mappers, Type typeWellknownDomainObjectFields)
        {
            var result =
                new TablesCreatePartitionOptionsSettings
                {
                    Enabled =
                    {
                        Value = true,
                    },

                    Tables =
                    {
                        Value = [],
                    },
                };

            var mapperIdsUseDefaultCreatePartitionOptions = new HashSet<Guid>();
            var mappersCreatePartitionOptions = new Dictionary<Guid, CreatePartitionOptions>();
            var objectNames = new Dictionary<Guid, string>();
            foreach (var type in typeWellknownDomainObjectFields.GetNestedTypes())
            {
                if (false == type.IsDefined(typeof(SchemaMapperAttribute), false))
                {
                    continue;
                }

                var schemaMapperAttribute = type.GetCustomAttribute<SchemaMapperAttribute>();
                var configuration = schemaMapperAttribute!.Configuration;

                if (type.IsDefined(typeof(UseDefaultCreatePartitionOptionsAttribute), false))
                {
                    if (false == mapperIdsUseDefaultCreatePartitionOptions.Add(configuration.MapperId.Value))
                    {
                        throw new InternalException($"Маппер '{configuration.MapperId.Value}' уже определён.");
                    }
                }

                if (type.IsDefined(typeof(CreatePartitionOptionsAttribute), false))
                {
                    var createPartitionOptionsAttribute = type.GetCustomAttribute<CreatePartitionOptionsAttribute>();

                    if (false == mappersCreatePartitionOptions.TryAdd(configuration.MapperId.Value, createPartitionOptionsAttribute!.GetOptions()))
                    {
                        throw new InternalException($"Маппер '{configuration.MapperId.Value}' уже определён.");
                    }
                }

                if (false == objectNames.TryAdd(configuration.MapperId.Value, type.Name))
                {
                    throw new InternalException($"Маппер '{configuration.MapperId.Value}' уже определён.");
                }
            }

            foreach (var manager in BasePartitionsSponsor.GetAllPartitionsManagers(mappers))
            {
                var useDefaultCreatePartitionOptions = mapperIdsUseDefaultCreatePartitionOptions.Remove(manager.Mapper.MapperId);
                mappersCreatePartitionOptions.Remove(manager.Mapper.MapperId, out var createPartitionOptions);
                if (false == objectNames.Remove(manager.Mapper.MapperId, out var objectName))
                {
                    throw new InternalException($"Не найден маппер '{manager.Mapper.MapperId}'.");
                }
                result.Tables.Value.Add(TableCreatePartitionOptionsSettings.GetDefault(objectName, manager.Mapper, useDefaultCreatePartitionOptions, createPartitionOptions));
            }

            if (mapperIdsUseDefaultCreatePartitionOptions.Count != 0)
            {
                throw new InternalException($"Осиротевшие мапперы.{Environment.NewLine}{string.Join(',', mapperIdsUseDefaultCreatePartitionOptions.Select(mapperId => mapperId.ToString()))}");
            }

            if (mappersCreatePartitionOptions.Count != 0)
            {
                throw new InternalException($"Осиротевшие мапперы.{Environment.NewLine}{string.Join(',', mappersCreatePartitionOptions.Select(mapper => mapper.Key.ToString()))}");
            }

            return result;
        }
    }

    /// <summary>
    /// Настройки параметров создания партиций таблицы БД.
    /// </summary>
    [Description("Настройки параметров создания партиций таблицы БД")]
    public sealed class TableCreatePartitionOptionsSettings
    {
        [SuppressMessage("ReSharper", "PreferConcreteValueOverDefault")]
        [SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
        public TableCreatePartitionOptionsSettings()
        {
            UseDefaultCreatePartitionOptions =
                new SettingValue<bool>(
                    default,
                    "Разрешает ипользование общих настроек параметров создания партиций таблиц БД");

            CreatePartitionOptions =
                new SettingValue<CreatePartitionOptionsSettings?>(
                    default,
                    "Настройки параметров создания партиций таблицы БД");

            MapperId =
                new SettingValue<Guid>(
                    default,
                    "Идентификатор маппера");

            MapperName =
                new SettingValue<string>(
                    default!,
                    "Имя маппера");

            ObjectName =
                new SettingValue<string>(
                    default!,
                    "Имя объекта");
        }

        /// <summary>
        /// Разрешает ипользование общих настроек параметров создания партиций таблиц БД.
        /// </summary>
        [Description("Разрешает ипользование общих настроек параметров создания партиций таблиц БД")]
        [JsonRequired]
        public SettingValue<bool> UseDefaultCreatePartitionOptions { get; set; }

        /// <summary>
        /// Настройки параметров создания партиций таблицы БД.
        /// </summary>
        [Description("Настройки параметров создания партиций таблицы БД")]
        [JsonRequired]
        public SettingValue<CreatePartitionOptionsSettings?> CreatePartitionOptions { get; set; }

        /// <summary>
        /// Идентификатор маппера.
        /// </summary>
        [Description("Идентификатор маппера")]
        [JsonRequired]
        public SettingValue<Guid> MapperId { get; set; }

        /// <summary>
        /// Имя маппера.
        /// </summary>
        [Description("Имя маппера")]
        [JsonRequired]
        public SettingValue<string> MapperName { get; set; }

        /// <summary>
        /// Имя объекта.
        /// </summary>
        [Description("Имя объекта")]
        [JsonRequired]
        public SettingValue<string> ObjectName { get; set; }

        /// <summary>
        /// Настройки по умолчанию.
        /// </summary>
        public static TableCreatePartitionOptionsSettings GetDefault(
            string objectName,
            IMapper mapper,
            bool useDefaultCreatePartitionOptions,
            CreatePartitionOptions? createPartitionOptions)
        {
            var result =
                new TableCreatePartitionOptionsSettings
                {
                    ObjectName =
                    {
                        Value = objectName.ToLower(),
                    },

                    MapperId =
                    {
                        Value = mapper.MapperId,
                    },

                    MapperName =
                    {
                        Value = WellknownDomainObjectDisplayNames.DisplayNamesProvider!(mapper.MapperId),
                    },

                    CreatePartitionOptions =
                    {
                        Value = (createPartitionOptions != null) ? CreatePartitionOptionsSettings.GetDefault(createPartitionOptions) : null,
                    },

                    UseDefaultCreatePartitionOptions =
                    {
                        Value = useDefaultCreatePartitionOptions
                    },
                };

            return result;
        }
    }

    /// <summary>
    /// Настройки параметров создания партиций таблицы БД.
    /// </summary>
    [Description("Настройки параметров создания партиций таблицы БД")]
    public sealed class CreatePartitionOptionsSettings
    {
        [SuppressMessage("ReSharper", "PreferConcreteValueOverDefault")]
        [SuppressMessage("ReSharper", "ConvertToPrimaryConstructor")]
        public CreatePartitionOptionsSettings()
        {
            Enabled =
                new SettingValue<bool>(
                    default,
                    "Разрешает ипользование настроек");

            FillFactor =
                new SettingValue<byte?>(
                    default,
                    "Фактор заполнения для таблицы, задаваемый в процентах, от 10 до 100. Значение по умолчанию — 100 (плотное заполнение). https://postgrespro.ru/docs/postgresql/current/sql-createtable");
        }

        /// <summary>
        /// Разрешает ипользование настроек.
        /// </summary>
        [Description("Разрешает ипользование настроек")]
        [JsonRequired]
        public SettingValue<bool> Enabled { get; set; }

        /// <summary>
        /// Фактор заполнения для таблицы, задаваемый в процентах, от 10 до 100. Значение по умолчанию — 100 (плотное заполнение).
        /// <see href="https://postgrespro.ru/docs/postgresql/current/sql-createtable"/>
        /// </summary>
        [Description("Фактор заполнения для таблицы, задаваемый в процентах, от 10 до 100. Значение по умолчанию — 100 (плотное заполнение). https://postgrespro.ru/docs/postgresql/current/sql-createtable")]
        [JsonRequired]
        public SettingValue<byte?> FillFactor { get; set; }

        /// <summary>
        /// Настройки по умолчанию.
        /// </summary>
        public static CreatePartitionOptionsSettings GetDefault()
        {
            var result =
                new CreatePartitionOptionsSettings
                {
                    Enabled =
                    {
                        Value = true
                    },

                    FillFactor =
                    {
                        Value = 80
                    },
                };

            return result;
        }

        /// <summary>
        /// Настройки по умолчанию.
        /// </summary>
        public static CreatePartitionOptionsSettings GetDefault(CreatePartitionOptions createPartitionOptions)
        {
            var result =
                new CreatePartitionOptionsSettings
                {
                    Enabled =
                    {
                        Value = true
                    },

                    FillFactor =
                    {
                        Value = createPartitionOptions.FillFactor
                    },
                };

            return result;
        }

        /// <summary>
        /// Параметры создания партиций таблицы БД.
        /// </summary>
        public CreatePartitionOptions GetOptions()
        {
            var result =
                new CreatePartitionOptions
                {
                    FillFactor = FillFactor.Value,
                };

            return result;
        }
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class TablespaceEntry
    {
        public int Index { get; init; }
        public string TablespaceName { get; init; }
    }

    public class DomainObjectTablespaceEntry
    {
        public Guid DomainObjectType { get; init; }
        public string Comment { get; set; }
        public List<TablespaceEntry> Tablespaces { get; init; } = [];
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public class TablespacesEntry
    {
        public List<TablespaceEntry> Tablespaces { get; init; } = [];
    }

    public class DomainObjectsEntry
    {
        public List<DomainObjectTablespaceEntry> DomainObjects { get; init; } = [];
    }

    [SuppressMessage("ReSharper", "PreferConcreteValueOverDefault")]
    // ReSharper disable once ConvertToPrimaryConstructor
    public PartitionsSponsorSettings()
    {
        ActivateTimeout =
            new SettingValue<TimeSpan>(
                default,
                "Интервал активации");

        TablespaceNames =
            new SettingValue<TablespacesEntry>(
                default!,
                $"Карта имён табличных пространств БД для партиций БД - Пример: {new TablespacesEntry
                {
                    Tablespaces =
                    [
                        new()
                        {
                            Index = 0,
                            TablespaceName = "tablespace_1"
                        },

                        new()
                        {
                            Index = 1,
                            TablespaceName = "tablespace_2"
                        }

                    ]
                }.ToJsonText(true)}");

        DomainObjectsTablespaceNames =
            new SettingValue<DomainObjectsEntry>(
                default!,
                $"Карта имён табличных пространств БД для партиций БД для конкретных доменных объектов - Пример: {new DomainObjectsEntry
                {
                    DomainObjects =
                    [
                        new()
                        {
                            Comment = "Комментарий",
                            DomainObjectType = Guid.NewGuid(),
                            Tablespaces =
                            [
                                new()
                                {
                                    Index = 0,
                                    TablespaceName = "tablespace_1"
                                },

                                new()
                                {
                                    Index = 1,
                                    TablespaceName = "tablespace_2"
                                }

                            ],
                        },

                        new()
                        {
                            Comment = "Комментарий",
                            DomainObjectType = Guid.NewGuid(),
                            Tablespaces =
                            [
                                new()
                                {
                                    Index = 0,
                                    TablespaceName = "tablespace_1"
                                },

                                new()
                                {
                                    Index = 1,
                                    TablespaceName = "tablespace_2"
                                }

                            ],
                        }

                    ]
                }.ToJsonText(true)}");

        DefaultCreatePartitionOptions =
            new SettingValue<CreatePartitionOptionsSettings>(
                default!,
                "Общие настройки параметров создания партиций таблиц БД");

        TablesCreatePartitionOptions =
            new SettingValue<TablesCreatePartitionOptionsSettings>(
                default!,
                "Настройки параметров создания партиций таблиц БД");
    }

    /// <summary>
    /// Общие настройки параметров создания партиций таблиц БД.
    /// </summary>
    [Description("Общие настройки параметров создания партиций таблиц БД")]
    [JsonRequired]
    public SettingValue<CreatePartitionOptionsSettings> DefaultCreatePartitionOptions { get; set; }

    /// <summary>
    /// Настройки параметров создания партиций таблиц БД.
    /// </summary>
    [Description("Настройки параметров создания партиций таблиц БД")]
    [JsonRequired]
    public SettingValue<TablesCreatePartitionOptionsSettings> TablesCreatePartitionOptions { get; set; }

    /// <summary>
    /// Интервал активации.
    /// </summary>
    [Description("Интервал активации")]
    [JsonRequired]
    public SettingValue<TimeSpan> ActivateTimeout { get; set; }

    /// <summary>
    /// Карта имён табличных пространств БД для партиций БД.
    /// </summary>
    [Description("Карта имён табличных пространств БД для партиций БД")]
    [JsonRequired]
    public SettingValue<TablespacesEntry> TablespaceNames { get; set; }

    /// <summary>
    /// Карта имён табличных пространств БД для партиций БД для конкретных доменных объектов.
    /// </summary>
    [Description("Карта имён табличных пространств БД для партиций БД для конкретных доменных объектов")]
    [JsonRequired]
    public SettingValue<DomainObjectsEntry> DomainObjectsTablespaceNames { get; set; }

    /// <summary>
    /// Настройки по умолчанию.
    /// </summary>
    public static PartitionsSponsorSettings GetDefault(IMappers mappers, Type typeWellknownDomainObjectFields)
    {
        var result =
            new PartitionsSponsorSettings
            {
                ActivateTimeout =
                {
                    Value = TimeSpan.FromHours(4)
                },

                TablespaceNames =
                {
                    Value = new TablespacesEntry()
                },

                DomainObjectsTablespaceNames =
                {
                    Value = new DomainObjectsEntry()
                },

                DefaultCreatePartitionOptions =
                {
                    Value = CreatePartitionOptionsSettings.GetDefault()
                },

                TablesCreatePartitionOptions =
                {
                    Value = TablesCreatePartitionOptionsSettings.GetDefault(mappers, typeWellknownDomainObjectFields)
                },
            };

        foreach (var manager in BasePartitionsSponsor.GetAllPartitionsManagers(mappers))
        {
            result.DomainObjectsTablespaceNames.Value.DomainObjects.Add(
                new DomainObjectTablespaceEntry
                {
                    DomainObjectType = manager.Mapper.MapperId,
                    Comment = WellknownDomainObjectDisplayNames.DisplayNamesProvider!(manager.Mapper.MapperId),
                    Tablespaces = [],
                });
        }

        return result;
    }
}