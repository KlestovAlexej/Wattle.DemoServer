/*
* Файл создан автоматически. Не редактировать вручную.
*
* Общий код мапперов.
*
* Генератор - ShtrihM.Wattle3.CodeGeneration.Generators.Mappers.MappersCommonCodeGenerator
*
*/
// ReSharper disable RedundantUsingDirective
using System;
using ShtrihM.Wattle3.Common.Queries;
using ShtrihM.Wattle3.Common.Queries.Schema;
using ShtrihM.Wattle3.Mappers.Primitives;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.DemoServer.Processing.Generated.Common
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public static class WellknownSchemaQueriesFields
    {
        /// <summary>
        /// Контроль изменений
        /// </summary>
        public static class ChangeTracker
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("cff5c7be-9f43-4c15-9038-55ce28e2c810");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
                /// <summary>
                /// Идентити.
                /// </summary>
                public static readonly Guid Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

            }
        }

        /// <summary>
        /// Системный лог
        /// </summary>
        public static class SystemLog
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("4f3f6ccb-47c7-4ad8-b0ff-c8cbc1af003f");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
                /// <summary>
                /// Дата создания
                /// </summary>
                public static readonly Guid CreateDate = new Guid("fabb42ed-5c3a-4234-8bf6-0cffa10baa18");

                /// <summary>
                /// Код записи
                /// </summary>
                public static readonly Guid Code = new Guid("e3d3d0f8-7e96-4979-bf73-b0b527e6f76c");

                /// <summary>
                /// Тип записи
                /// </summary>
                public static readonly Guid Type = new Guid("ff1c3d22-44de-4488-8fd3-1e5925ffa40a");

                /// <summary>
                /// Сообщение
                /// </summary>
                public static readonly Guid Message = new Guid("b446c595-7046-42ec-8b51-d67ac42328be");

                /// <summary>
                /// Данные
                /// </summary>
                public static readonly Guid Data = new Guid("e4e2c27a-124d-44de-93e7-62b411c24d6a");

                /// <summary>
                /// Идентити.
                /// </summary>
                public static readonly Guid Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

            }
        }

        /// <summary>
        /// Партиция таблицы БД
        /// </summary>
        public static class TablePartition
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("b426ed4e-b645-4c26-8edd-63b1e89e899c");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
                /// <summary>
                /// Дата создания
                /// </summary>
                public static readonly Guid CreateDate = new Guid("e2b3ecf0-17b5-4212-9da0-3c05f17e5c3f");

                /// <summary>
                /// Имя таблицы БД
                /// </summary>
                public static readonly Guid TableName = new Guid("0617eeaf-95c0-4e62-abc8-4f32fc81c0ef");

                /// <summary>
                /// Имя партиции таблицы БД
                /// </summary>
                public static readonly Guid PartitionName = new Guid("1a062039-4a49-4d63-80c0-bcd0ac79b200");

                /// <summary>
                /// День партиции таблицы БД
                /// </summary>
                public static readonly Guid Day = new Guid("840edb69-c08f-4d64-a05a-440888cc7398");

                /// <summary>
                /// Минимальный идентификатор группы идентити хранимый в партиции
                /// </summary>
                public static readonly Guid MinGroupId = new Guid("72889c90-73c2-4d41-82c1-c36c27ffd0a8");

                /// <summary>
                /// Максимальный идентификатор группы идентити не хранимый в партиции
                /// </summary>
                public static readonly Guid MaxNotIncludeGroupId = new Guid("408730b7-2fa1-4b3e-a6a8-74e7efa0397b");

                /// <summary>
                /// Минимальный идентити хранимый в партиции
                /// </summary>
                public static readonly Guid MinId = new Guid("087d9636-4846-400b-8882-8d10b22339fb");

                /// <summary>
                /// Максимальный идентити не хранимый в партиции
                /// </summary>
                public static readonly Guid MaxNotIncludeId = new Guid("621e6e67-b436-4767-b933-e4313b6cc80c");

                /// <summary>
                /// Идентити.
                /// </summary>
                public static readonly Guid Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

            }
        }

        /// <summary>
        /// Объект
        /// </summary>
        public static class DemoObject
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("86347ca3-b1ef-4c32-a9c0-e38e3b1d1c5d");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
                /// <summary>
                /// Дата создания
                /// </summary>
                public static readonly Guid CreateDate = new Guid("19d14b24-d899-4ad9-b97b-ae7a7b12fff8");

                /// <summary>
                /// Дата модификации
                /// </summary>
                public static readonly Guid ModificationDate = new Guid("f69bae78-0fbd-426a-971c-63dcc6d7f4f7");

                /// <summary>
                /// Название
                /// </summary>
                public static readonly Guid Name = new Guid("c1dd6a57-d661-4487-9610-f6f35d78744f");

                /// <summary>
                /// Признак разрешения работы
                /// </summary>
                public static readonly Guid Enabled = new Guid("51dbedef-4206-473d-85d2-b189426f5456");

                /// <summary>
                /// Идентити.
                /// </summary>
                public static readonly Guid Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

            }
        }

        /// <summary>
        /// Объект X
        /// </summary>
        public static class DemoObjectX
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("322d2242-c942-4643-ba8c-9e2e1e8a7828");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
                /// <summary>
                /// Дата создания
                /// </summary>
                public static readonly Guid CreateDate = new Guid("cd109655-1dc8-4e88-aa24-5c27e3ef778f");

                /// <summary>
                /// Дата модификации
                /// </summary>
                public static readonly Guid ModificationDate = new Guid("6862d6bb-3405-48c1-864c-46601da5726b");

                /// <summary>
                /// Название
                /// </summary>
                public static readonly Guid Name = new Guid("0c54e3f8-3754-4b99-a144-a8c3d5e15958");

                /// <summary>
                /// Признак разрешения работы
                /// </summary>
                public static readonly Guid Enabled = new Guid("070ef35a-908f-450e-92b6-508e52dc5306");

                /// <summary>
                /// Альтернативный ключ - часть №1
                /// </summary>
                public static readonly Guid Key1 = new Guid("14367e40-cc94-47a7-8fbd-47e81c62b9bd");

                /// <summary>
                /// Альтернативный ключ - часть №2
                /// </summary>
                public static readonly Guid Key2 = new Guid("95d0bdf7-5420-4b5c-b89b-7c7979a05f99");

                /// <summary>
                /// Номер группы
                /// </summary>
                public static readonly Guid Group = new Guid("f8b8b8ce-11b8-4108-b811-a5fc7255238a");

                /// <summary>
                /// Идентити.
                /// </summary>
                public static readonly Guid Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

            }
        }

    }

    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class SchemaQueriesProvider
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public static SchemaQueries Schema;

        static SchemaQueriesProvider()
        {
            Schema = new SchemaQueries();

            #region Объект ChangeTracker
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Контроль изменений";
                schemaObjectQuey.Id = new Guid("cff5c7be-9f43-4c15-9038-55ce28e2c810");

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Контроль изменений";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект ChangeTracker

            #region Объект SystemLog
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Системный лог";
                schemaObjectQuey.Id = new Guid("4f3f6ccb-47c7-4ad8-b0ff-c8cbc1af003f");

                #region Поле CreateDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("fabb42ed-5c3a-4234-8bf6-0cffa10baa18");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                }
                #endregion Поле CreateDate

                #region Поле Code
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Код записи";
                    schemaObjectFieldQuey.Id = new Guid("e3d3d0f8-7e96-4979-bf73-b0b527e6f76c");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Code";
                }
                #endregion Поле Code

                #region Поле Type
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Тип записи";
                    schemaObjectFieldQuey.Id = new Guid("ff1c3d22-44de-4488-8fd3-1e5925ffa40a");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Type";
                }
                #endregion Поле Type

                #region Поле Message
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Сообщение";
                    schemaObjectFieldQuey.Id = new Guid("b446c595-7046-42ec-8b51-d67ac42328be");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Message";
                }
                #endregion Поле Message

                #region Поле Data
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Данные";
                    schemaObjectFieldQuey.Id = new Guid("e4e2c27a-124d-44de-93e7-62b411c24d6a");
                    schemaObjectFieldQuey.Order = false;
                    schemaObjectFieldQuey.Where = false;
                    schemaObjectFieldQuey.Name = @"Data";
                }
                #endregion Поле Data

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Системный лог";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект SystemLog

            #region Объект TablePartition
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Партиция таблицы БД";
                schemaObjectQuey.Id = new Guid("b426ed4e-b645-4c26-8edd-63b1e89e899c");

                #region Поле CreateDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("e2b3ecf0-17b5-4212-9da0-3c05f17e5c3f");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                }
                #endregion Поле CreateDate

                #region Поле TableName
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Имя таблицы БД";
                    schemaObjectFieldQuey.Id = new Guid("0617eeaf-95c0-4e62-abc8-4f32fc81c0ef");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"TableName";
                }
                #endregion Поле TableName

                #region Поле PartitionName
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Имя партиции таблицы БД";
                    schemaObjectFieldQuey.Id = new Guid("1a062039-4a49-4d63-80c0-bcd0ac79b200");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"PartitionName";
                }
                #endregion Поле PartitionName

                #region Поле Day
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"День партиции таблицы БД";
                    schemaObjectFieldQuey.Id = new Guid("840edb69-c08f-4d64-a05a-440888cc7398");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Day";
                }
                #endregion Поле Day

                #region Поле MinGroupId
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Минимальный идентификатор группы идентити хранимый в партиции";
                    schemaObjectFieldQuey.Id = new Guid("72889c90-73c2-4d41-82c1-c36c27ffd0a8");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"MinGroupId";
                }
                #endregion Поле MinGroupId

                #region Поле MaxNotIncludeGroupId
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Максимальный идентификатор группы идентити не хранимый в партиции";
                    schemaObjectFieldQuey.Id = new Guid("408730b7-2fa1-4b3e-a6a8-74e7efa0397b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"MaxNotIncludeGroupId";
                }
                #endregion Поле MaxNotIncludeGroupId

                #region Поле MinId
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Минимальный идентити хранимый в партиции";
                    schemaObjectFieldQuey.Id = new Guid("087d9636-4846-400b-8882-8d10b22339fb");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"MinId";
                }
                #endregion Поле MinId

                #region Поле MaxNotIncludeId
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Максимальный идентити не хранимый в партиции";
                    schemaObjectFieldQuey.Id = new Guid("621e6e67-b436-4767-b933-e4313b6cc80c");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"MaxNotIncludeId";
                }
                #endregion Поле MaxNotIncludeId

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Партиция таблицы БД";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект TablePartition

            #region Объект DemoObject
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Объект";
                schemaObjectQuey.Id = new Guid("86347ca3-b1ef-4c32-a9c0-e38e3b1d1c5d");

                #region Поле CreateDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("19d14b24-d899-4ad9-b97b-ae7a7b12fff8");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                }
                #endregion Поле CreateDate

                #region Поле ModificationDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата модификации";
                    schemaObjectFieldQuey.Id = new Guid("f69bae78-0fbd-426a-971c-63dcc6d7f4f7");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"ModificationDate";
                }
                #endregion Поле ModificationDate

                #region Поле Name
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Название";
                    schemaObjectFieldQuey.Id = new Guid("c1dd6a57-d661-4487-9610-f6f35d78744f");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Name";
                }
                #endregion Поле Name

                #region Поле Enabled
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Признак разрешения работы";
                    schemaObjectFieldQuey.Id = new Guid("51dbedef-4206-473d-85d2-b189426f5456");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Enabled";
                }
                #endregion Поле Enabled

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект DemoObject

            #region Объект DemoObjectX
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Объект X";
                schemaObjectQuey.Id = new Guid("322d2242-c942-4643-ba8c-9e2e1e8a7828");

                #region Поле CreateDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("cd109655-1dc8-4e88-aa24-5c27e3ef778f");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                }
                #endregion Поле CreateDate

                #region Поле ModificationDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата модификации";
                    schemaObjectFieldQuey.Id = new Guid("6862d6bb-3405-48c1-864c-46601da5726b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"ModificationDate";
                }
                #endregion Поле ModificationDate

                #region Поле Name
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Название";
                    schemaObjectFieldQuey.Id = new Guid("0c54e3f8-3754-4b99-a144-a8c3d5e15958");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Name";
                }
                #endregion Поле Name

                #region Поле Enabled
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Признак разрешения работы";
                    schemaObjectFieldQuey.Id = new Guid("070ef35a-908f-450e-92b6-508e52dc5306");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Enabled";
                }
                #endregion Поле Enabled

                #region Поле Key1
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Альтернативный ключ - часть №1";
                    schemaObjectFieldQuey.Id = new Guid("14367e40-cc94-47a7-8fbd-47e81c62b9bd");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Key1";
                }
                #endregion Поле Key1

                #region Поле Key2
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Альтернативный ключ - часть №2";
                    schemaObjectFieldQuey.Id = new Guid("95d0bdf7-5420-4b5c-b89b-7c7979a05f99");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Key2";
                }
                #endregion Поле Key2

                #region Поле group
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Номер группы";
                    schemaObjectFieldQuey.Id = new Guid("f8b8b8ce-11b8-4108-b811-a5fc7255238a");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"group";
                }
                #endregion Поле group

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект X";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект DemoObjectX

        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов ChangeTracker.
        /// </summary>
        /// <param name="query">Запрос.</param>
        [MapperQueryBuilder("cff5c7be-9f43-4c15-9038-55ce28e2c810")]
        public static QueryBuilder QueryForChangeTracker(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("cff5c7be-9f43-4c15-9038-55ce28e2c810"), query);
        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов SystemLog.
        /// </summary>
        /// <param name="query">Запрос.</param>
        [MapperQueryBuilder("4f3f6ccb-47c7-4ad8-b0ff-c8cbc1af003f")]
        public static QueryBuilder QueryForSystemLog(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("4f3f6ccb-47c7-4ad8-b0ff-c8cbc1af003f"), query);
        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов TablePartition.
        /// </summary>
        /// <param name="query">Запрос.</param>
        [MapperQueryBuilder("b426ed4e-b645-4c26-8edd-63b1e89e899c")]
        public static QueryBuilder QueryForTablePartition(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("b426ed4e-b645-4c26-8edd-63b1e89e899c"), query);
        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов DemoObject.
        /// </summary>
        /// <param name="query">Запрос.</param>
        [MapperQueryBuilder("86347ca3-b1ef-4c32-a9c0-e38e3b1d1c5d")]
        public static QueryBuilder QueryForDemoObject(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("86347ca3-b1ef-4c32-a9c0-e38e3b1d1c5d"), query);
        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов DemoObjectX.
        /// </summary>
        /// <param name="query">Запрос.</param>
        [MapperQueryBuilder("322d2242-c942-4643-ba8c-9e2e1e8a7828")]
        public static QueryBuilder QueryForDemoObjectX(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("322d2242-c942-4643-ba8c-9e2e1e8a7828"), query);
        }
    }

}
