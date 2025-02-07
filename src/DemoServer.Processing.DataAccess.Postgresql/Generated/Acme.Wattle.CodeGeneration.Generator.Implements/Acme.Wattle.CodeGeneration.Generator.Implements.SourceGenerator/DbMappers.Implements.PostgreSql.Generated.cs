/*
* Файл создан автоматически. Не редактировать вручную.
*
* Реализации мапперов.
*
* Генератор - Acme.Wattle.CodeGeneration.Generators.Mappers.PostgreSqlMappersImplementsCodeGenerator
*
*/

#nullable enable

// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.ExceptionServices;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using NpgsqlTypes;
using Npgsql;
using System.Diagnostics.CodeAnalysis;
using Acme.Wattle.Mappers;
using Acme.Wattle.Mappers.PostgreSql;
using Acme.Wattle.Mappers.PostgreSql.Schema;
using Acme.Wattle.Utils;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Infrastructures.Interfaces.Monitors;
using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.Caching.Interfaces;
using Acme.Wattle.Primitives;
using Acme.Wattle.Mappers.Primitives;
using Acme.Wattle.Json.Extensions;
using Acme.Wattle.Common.Exceptions;
using Acme.DemoServer.Processing.Generated.Interface;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace Acme.DemoServer.Processing.Generated.PostgreSql.Implements
{
    public static class PostgreSqlSchemaQueriesProvider
    {
        public static readonly PostgreSqlSchemaQueries Schema;

        static PostgreSqlSchemaQueriesProvider()
        {
            Schema = new PostgreSqlSchemaQueries();

            #region Объект ChangeTracker

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Контроль изменений";
                schemaObjectQuey.Id = new Guid("cff5c7be-9f43-4c15-9038-55ce28e2c810");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Контроль изменений";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект ChangeTracker

            #region Объект SystemLog

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Системный лог";
                schemaObjectQuey.Id = new Guid("4f3f6ccb-47c7-4ad8-b0ff-c8cbc1af003f");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле CreateDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("fabb42ed-5c3a-4234-8bf6-0cffa10baa18");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле CreateDate

                #region Поле Code

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Код записи";
                    schemaObjectFieldQuey.Id = new Guid("e3d3d0f8-7e96-4979-bf73-b0b527e6f76c");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Code";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Code

                #region Поле Type

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Тип записи";
                    schemaObjectFieldQuey.Id = new Guid("ff1c3d22-44de-4488-8fd3-1e5925ffa40a");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Type";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Type

                #region Поле Message

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Сообщение";
                    schemaObjectFieldQuey.Id = new Guid("b446c595-7046-42ec-8b51-d67ac42328be");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Message";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Message

                #region Поле Data

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Данные";
                    schemaObjectFieldQuey.Id = new Guid("e4e2c27a-124d-44de-93e7-62b411c24d6a");
                    schemaObjectFieldQuey.Order = false;
                    schemaObjectFieldQuey.Where = false;
                    schemaObjectFieldQuey.Name = @"Data";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Data

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Системный лог";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект SystemLog

            #region Объект TablePartition

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Партиция таблицы БД";
                schemaObjectQuey.Id = new Guid("b426ed4e-b645-4c26-8edd-63b1e89e899c");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле CreateDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("e2b3ecf0-17b5-4212-9da0-3c05f17e5c3f");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле CreateDate

                #region Поле TableName

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Имя таблицы БД";
                    schemaObjectFieldQuey.Id = new Guid("0617eeaf-95c0-4e62-abc8-4f32fc81c0ef");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"TableName";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле TableName

                #region Поле PartitionName

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Имя партиции таблицы БД";
                    schemaObjectFieldQuey.Id = new Guid("1a062039-4a49-4d63-80c0-bcd0ac79b200");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"PartitionName";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле PartitionName

                #region Поле Day

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"День партиции таблицы БД";
                    schemaObjectFieldQuey.Id = new Guid("840edb69-c08f-4d64-a05a-440888cc7398");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Day";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Day

                #region Поле MinGroupId

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Минимальный идентификатор группы идентити хранимый в партиции";
                    schemaObjectFieldQuey.Id = new Guid("72889c90-73c2-4d41-82c1-c36c27ffd0a8");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"MinGroupId";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле MinGroupId

                #region Поле MaxNotIncludeGroupId

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Максимальный идентификатор группы идентити не хранимый в партиции";
                    schemaObjectFieldQuey.Id = new Guid("408730b7-2fa1-4b3e-a6a8-74e7efa0397b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"MaxNotIncludeGroupId";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле MaxNotIncludeGroupId

                #region Поле MinId

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Минимальный идентити хранимый в партиции";
                    schemaObjectFieldQuey.Id = new Guid("087d9636-4846-400b-8882-8d10b22339fb");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"MinId";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле MinId

                #region Поле MaxNotIncludeId

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Максимальный идентити не хранимый в партиции";
                    schemaObjectFieldQuey.Id = new Guid("621e6e67-b436-4767-b933-e4313b6cc80c");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"MaxNotIncludeId";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле MaxNotIncludeId

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Партиция таблицы БД";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект TablePartition

            #region Объект DemoObject

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Объект";
                schemaObjectQuey.Id = new Guid("86347ca3-b1ef-4c32-a9c0-e38e3b1d1c5d");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле CreateDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("19d14b24-d899-4ad9-b97b-ae7a7b12fff8");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле CreateDate

                #region Поле ModificationDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата модификации";
                    schemaObjectFieldQuey.Id = new Guid("f69bae78-0fbd-426a-971c-63dcc6d7f4f7");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"ModificationDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле ModificationDate

                #region Поле Name

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Название";
                    schemaObjectFieldQuey.Id = new Guid("c1dd6a57-d661-4487-9610-f6f35d78744f");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Name";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Name

                #region Поле Enabled

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Признак разрешения работы";
                    schemaObjectFieldQuey.Id = new Guid("51dbedef-4206-473d-85d2-b189426f5456");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Enabled";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Enabled

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект DemoObject

            #region Объект DemoObjectX

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Объект X";
                schemaObjectQuey.Id = new Guid("322d2242-c942-4643-ba8c-9e2e1e8a7828");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле CreateDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("cd109655-1dc8-4e88-aa24-5c27e3ef778f");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле CreateDate

                #region Поле ModificationDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата модификации";
                    schemaObjectFieldQuey.Id = new Guid("6862d6bb-3405-48c1-864c-46601da5726b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"ModificationDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле ModificationDate

                #region Поле Name

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Название";
                    schemaObjectFieldQuey.Id = new Guid("0c54e3f8-3754-4b99-a144-a8c3d5e15958");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Name";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Name

                #region Поле Enabled

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Признак разрешения работы";
                    schemaObjectFieldQuey.Id = new Guid("070ef35a-908f-450e-92b6-508e52dc5306");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Enabled";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Enabled

                #region Поле Key1

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Альтернативный ключ - часть №1";
                    schemaObjectFieldQuey.Id = new Guid("14367e40-cc94-47a7-8fbd-47e81c62b9bd");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Key1";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Key1

                #region Поле Key2

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Альтернативный ключ - часть №2";
                    schemaObjectFieldQuey.Id = new Guid("95d0bdf7-5420-4b5c-b89b-7c7979a05f99");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Key2";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Key2

                #region Поле group

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Номер группы";
                    schemaObjectFieldQuey.Id = new Guid("f8b8b8ce-11b8-4108-b811-a5fc7255238a");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"""group""";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле group

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект X";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект DemoObjectX

            #region Объект DemoDelayTask

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Задача с отложенным запуском";
                schemaObjectQuey.Id = new Guid("5f729000-5139-469f-90b8-74301e342df3");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле CreateDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("4437fa7d-5b09-4f22-9362-322c10e5a582");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле CreateDate

                #region Поле ModificationDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата модификации";
                    schemaObjectFieldQuey.Id = new Guid("83816a54-32eb-448f-a755-9d14accb048a");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"ModificationDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле ModificationDate

                #region Поле Scenario

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Сценарий";
                    schemaObjectFieldQuey.Id = new Guid("5cd4e196-ad21-4d0a-88e0-514f7f7874ad");
                    schemaObjectFieldQuey.Order = false;
                    schemaObjectFieldQuey.Where = false;
                    schemaObjectFieldQuey.Name = @"Scenario";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Scenario

                #region Поле ScenarioState

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Состояние сценария";
                    schemaObjectFieldQuey.Id = new Guid("2ce70876-f169-4129-ae06-dac87c5e2686");
                    schemaObjectFieldQuey.Order = false;
                    schemaObjectFieldQuey.Where = false;
                    schemaObjectFieldQuey.Name = @"ScenarioState";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле ScenarioState

                #region Поле StartDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата запуска";
                    schemaObjectFieldQuey.Id = new Guid("e2856719-2986-4958-8286-00ef8c2f254f");
                    schemaObjectFieldQuey.Order = false;
                    schemaObjectFieldQuey.Where = false;
                    schemaObjectFieldQuey.Name = @"StartDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле StartDate

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Задача с отложенным запуском";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект DemoDelayTask

        }
    }

    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    public partial class Mappers : BasePostgreSqlMappers
    {
        private readonly IPostgreSqlMapperSelectFilterFactory m_selectFilterFactory;
        private readonly Func<Guid, string>? m_getMapperDisplayName;

        [SuppressMessage("ReSharper", "RedundantCast")]
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        [SuppressMessage("ReSharper", "InvocationIsSkipped")]
        public Mappers(IMappersExceptionPolicy exceptionPolicy, string connectionString, ITimeService timeService, Guid id, string name, string description, int commandTimeout = CommandTimeoutInfinity, object? context = null)
            : base(exceptionPolicy, connectionString, timeService, id, name, description, commandTimeout)
        {
            m_getMapperDisplayName = null;

            OnEnterConstructor(context);

            if (m_selectFilterFactory == null)
            {
                var selectFilterContext = new PostgreSqlMapperSelectFilterContext(PostgreSqlSchemaQueriesProvider.Schema);
                m_selectFilterFactory = new PostgreSqlMapperSelectFilterFactory(selectFilterContext);
            }

            AddMapper(new MapperChangeTracker(exceptionPolicy, m_selectFilterFactory));

            AddMapper(new MapperSystemLog(exceptionPolicy, m_selectFilterFactory));

            AddMapper(new MapperTablePartition(exceptionPolicy, m_selectFilterFactory));

            AddMapper(new MapperDemoObject(exceptionPolicy, m_selectFilterFactory));

            AddMapper(new MapperDemoObjectX(exceptionPolicy, m_selectFilterFactory));

            AddMapper(new MapperDemoDelayTask(exceptionPolicy, m_selectFilterFactory));

            OnExitConstructor(context);
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        protected override string GetMapperDisplayName(Guid mapperId)
        {
            var result = m_getMapperDisplayName?.Invoke(mapperId);

            if (result == null)
            {
                result = WellknownMappers.GetDisplayName(mapperId);

                return (result);
            }

            return (result);
        }

        /// <summary>
        /// Начало конструктора реестра маппперов.
        /// </summary>
        partial void OnEnterConstructor(object? context);

        /// <summary>
        /// Конец конструктора реестра маппперов.
        /// </summary>
        partial void OnExitConstructor(object? context);
    }

    /// <summary>
    /// Поточный читатель данных записей для массовой вставки записей в БД.
    /// 
    /// Контроль изменений
    /// </summary>
    internal class BulkInsertDataReaderChangeTracker : BasePostgreSqlBulkInserter<ChangeTrackerDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, ChangeTrackerDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, ChangeTrackerDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY ChangeTracker (Id) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Контроль изменений
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.ChangeTracker)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperChangeTracker : BasePostgreSqlMapper<ChangeTrackerDtoActual>, IPartitionsMapper, IMapperInitializer, IMapperChangeTracker
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperChangeTracker(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Контроль изменений" + "' в БД", WellknownMappers.ChangeTracker, selectFilterFactory, exceptionPolicy)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"ChangeTracker", ComplexIdentity.Level.L2, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperChangeTracker(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper? infrastructureMonitor = null)
           : base("Маппер данных состояния доменного объекта '" + @"Контроль изменений" + "' в БД", WellknownMappers.ChangeTracker, selectFilterFactory, exceptionPolicy, infrastructureMonitor)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"ChangeTracker", ComplexIdentity.Level.L2, false);
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"ChangeTracker";

        /// <summary>
        /// Интерфейс управления партициями.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public IPartitionsManager Partitions { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] private set; }

        /// <summary>
        /// Обработка исключения мапппера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchException(IMappersSession session, Exception exception);

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Initialize"/>.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnInitialize(IMappers mappers, Exception exception);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        partial void DoInitialize(IMappers mappers);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        public virtual void Initialize(IMappers mappers)
        {
            if (mappers == null)
            {
                throw new ArgumentNullException(nameof(mappers));
            }
            try
            {
                DoInitialize(mappers);
            }
            catch (Exception exception)
            {

                CatchExceptionOnInitialize(mappers, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextId"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextId(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_ChangeTracker".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual long GetNextId(IMappersSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_ChangeTracker');";
                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextIds"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextIds(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_ChangeTracker".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        public virtual IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                cancellationToken.ThrowIfCancellationRequested();

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_ChangeTracker') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");

                        var result = new List<long>(count);
                        while (reader.Read())
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            var id = reader.GetInt64(indexId);
                            result.Add(id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextIds(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_ChangeTracker".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken" >Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual async ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_ChangeTracker');";
                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Exists"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExists(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual bool Exists(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM ChangeTracker WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual async ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM ChangeTracker WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM ChangeTracker WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM ChangeTracker WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId)
        {
            indexId = reader.GetOrdinal("Id");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId)
        {
            indexId = reader.GetOrdinal("Id");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ChangeTrackerDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new ChangeTrackerDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ChangeTrackerDtoActual Read(
            NpgsqlDataReader reader,
            int indexId)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new ChangeTrackerDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual ChangeTrackerDtoActual? Get(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId);

                            var result = Read(
                                reader,
                                indexId);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto?> GetAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId);

                            var result = Read(
                                reader,
                                indexId);

                            return ((IMapperDto)result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGetRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual ChangeTrackerDtoActual? GetRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId);

                            var result = ReadRaw(
                                reader,
                                indexId);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<ChangeTrackerDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId);

                            var result = ReadRaw(
                                reader,
                                indexId);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="BulkInsert"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnBulkInsert(IMappersSession session, Exception exception);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        public virtual void BulkInsert(
            IMappersSession session,
            IEnumerable<ChangeTrackerDtoNew> data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderChangeTracker();
                postgreSqlBulkInserter.Insert(typedSession, data);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask BulkInsertAsync(
            IMappersSession session,
            IEnumerable<ChangeTrackerDtoNew> data,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderChangeTracker();
                await postgreSqlBulkInserter.InsertAsync(typedSession, data, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="New"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Новая запись.</param>
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, ChangeTrackerDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual ChangeTrackerDtoActual New(IMappersSession session, ChangeTrackerDtoNew data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new ChangeTrackerDtoActual
                {
                    Id = data.Id,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO ChangeTracker
(
Id
)
VALUES
(
@Id
)";
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, ChangeTrackerDtoNew data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new ChangeTrackerDtoActual
                {
                    Id = data.Id,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO ChangeTracker
(
Id
)
VALUES
(
@Id
)";
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }

                return ((IMapperDto)result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<IMapperDto> IAbstractMapper.GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter);
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TMapperDto> IAbstractMapper.GetEnumerator<TMapperDto>(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter).Cast<TMapperDto>();
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumerator"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumerator(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<ChangeTrackerDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        ChangeTrackerDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<ChangeTrackerDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        ChangeTrackerDtoActual result;
                        try
                        {
                            var hasRecord = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    await reader.SilentDisposeAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                await command.SilentDisposeAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorRaw(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<ChangeTrackerDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter)
                    ;
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        ChangeTrackerDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = ReadRaw(
                                reader,
                                indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<ChangeTrackerDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        ChangeTrackerDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorIdentitiesPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorIdentitiesPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        public virtual IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id FROM ChangeTracker";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        long item;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }
                            item = reader.GetInt64(indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (item);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetCount"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetCount(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM ChangeTracker";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual async ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                await using (var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM ChangeTracker";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
    }

    /// <summary>
    /// Поточный читатель данных записей для массовой вставки записей в БД.
    /// 
    /// Системный лог
    /// </summary>
    internal class BulkInsertDataReaderSystemLog : BasePostgreSqlBulkInserter<SystemLogDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, SystemLogDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.CreateDate.ToUniversalTime(), NpgsqlDbType.TimestampTz, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Code, NpgsqlDbType.Integer, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Type, NpgsqlDbType.Integer, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Message, NpgsqlDbType.Varchar, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Data, NpgsqlDbType.Text, cancellationToken).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, SystemLogDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.CreateDate.ToUniversalTime(), NpgsqlDbType.TimestampTz);
            binaryImport.Write(instance.Code, NpgsqlDbType.Integer);
            binaryImport.Write(instance.Type, NpgsqlDbType.Integer);
            binaryImport.Write(instance.Message, NpgsqlDbType.Varchar);
            binaryImport.Write(instance.Data, NpgsqlDbType.Text);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY SystemLog (Id,
CreateDate,
Code,
Type,
Message,
Data) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Системный лог
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.SystemLog)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperSystemLog : BasePostgreSqlMapper<SystemLogDtoActual>, IPartitionsMapper, IMapperInitializer, IMapperSystemLog
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperSystemLog(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Системный лог" + "' в БД", WellknownMappers.SystemLog, selectFilterFactory, exceptionPolicy)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"SystemLog", ComplexIdentity.Level.L2, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperSystemLog(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper? infrastructureMonitor = null)
           : base("Маппер данных состояния доменного объекта '" + @"Системный лог" + "' в БД", WellknownMappers.SystemLog, selectFilterFactory, exceptionPolicy, infrastructureMonitor)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"SystemLog", ComplexIdentity.Level.L2, false);
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"SystemLog";

        /// <summary>
        /// Интерфейс управления партициями.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public IPartitionsManager Partitions { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] private set; }

        /// <summary>
        /// Обработка исключения мапппера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchException(IMappersSession session, Exception exception);

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Initialize"/>.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnInitialize(IMappers mappers, Exception exception);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        partial void DoInitialize(IMappers mappers);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        public virtual void Initialize(IMappers mappers)
        {
            if (mappers == null)
            {
                throw new ArgumentNullException(nameof(mappers));
            }
            try
            {
                DoInitialize(mappers);
            }
            catch (Exception exception)
            {

                CatchExceptionOnInitialize(mappers, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextId"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextId(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_SystemLog".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual long GetNextId(IMappersSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_SystemLog');";
                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextIds"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextIds(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_SystemLog".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        public virtual IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                cancellationToken.ThrowIfCancellationRequested();

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_SystemLog') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");

                        var result = new List<long>(count);
                        while (reader.Read())
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            var id = reader.GetInt64(indexId);
                            result.Add(id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextIds(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_SystemLog".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken" >Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual async ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_SystemLog');";
                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Exists"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExists(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual bool Exists(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM SystemLog WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual async ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM SystemLog WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM SystemLog WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM SystemLog WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexCode">Индекс колонки 'Code'.</param>
        /// <param name="indexType">Индекс колонки 'Type'.</param>
        /// <param name="indexMessage">Индекс колонки 'Message'.</param>
        /// <param name="indexData">Индекс колонки 'Data'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexCreateDate,
            out int indexCode,
            out int indexType,
            out int indexMessage,
            out int indexData)
        {
            indexId = reader.GetOrdinal("Id");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexCode = reader.GetOrdinal("Code");
            indexType = reader.GetOrdinal("Type");
            indexMessage = reader.GetOrdinal("Message");
            indexData = reader.GetOrdinal("Data");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexCode">Индекс колонки 'Code'.</param>
        /// <param name="indexType">Индекс колонки 'Type'.</param>
        /// <param name="indexMessage">Индекс колонки 'Message'.</param>
        /// <param name="indexData">Индекс колонки 'Data'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexCreateDate,
            out int indexCode,
            out int indexType,
            out int indexMessage,
            out int indexData)
        {
            indexId = reader.GetOrdinal("Id");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexCode = reader.GetOrdinal("Code");
            indexType = reader.GetOrdinal("Type");
            indexMessage = reader.GetOrdinal("Message");
            indexData = reader.GetOrdinal("Data");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexCode">Индекс колонки 'Code'.</param>
        /// <param name="indexType">Индекс колонки 'Type'.</param>
        /// <param name="indexMessage">Индекс колонки 'Message'.</param>
        /// <param name="indexData">Индекс колонки 'Data'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SystemLogDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexCreateDate,
            int indexCode,
            int indexType,
            int indexMessage,
            int indexData)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new SystemLogDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.CreateDate = reader.GetFieldValue<DateTimeOffset>(indexCreateDate);
            result.Code = reader.GetInt32(indexCode);
            result.Type = reader.GetInt32(indexType);
            result.Message = reader.GetString(indexMessage);
            result.Data = reader.GetString(indexData);

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexCode">Индекс колонки 'Code'.</param>
        /// <param name="indexType">Индекс колонки 'Type'.</param>
        /// <param name="indexMessage">Индекс колонки 'Message'.</param>
        /// <param name="indexData">Индекс колонки 'Data'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SystemLogDtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexCreateDate,
            int indexCode,
            int indexType,
            int indexMessage,
            int indexData)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new SystemLogDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.CreateDate = reader.GetFieldValue<DateTimeOffset>(indexCreateDate);
            result.Code = reader.GetInt32(indexCode);
            result.Type = reader.GetInt32(indexType);
            result.Message = reader.GetString(indexMessage);
            result.Data = reader.GetString(indexData);

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual SystemLogDtoActual? Get(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
Code,
Type,
Message,
Data
FROM SystemLog WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexCreateDate,
                                out var indexCode,
                                out var indexType,
                                out var indexMessage,
                                out var indexData);

                            var result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexCode,
                                indexType,
                                indexMessage,
                                indexData);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto?> GetAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
Code,
Type,
Message,
Data
FROM SystemLog WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexCreateDate,
                                out var indexCode,
                                out var indexType,
                                out var indexMessage,
                                out var indexData);

                            var result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexCode,
                                indexType,
                                indexMessage,
                                indexData);

                            return ((IMapperDto)result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGetRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual SystemLogDtoActual? GetRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
Code,
Type,
Message,
Data
FROM SystemLog WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexCreateDate,
                                out var indexCode,
                                out var indexType,
                                out var indexMessage,
                                out var indexData);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexCode,
                                indexType,
                                indexMessage,
                                indexData);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<SystemLogDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
Code,
Type,
Message,
Data
FROM SystemLog WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexCreateDate,
                                out var indexCode,
                                out var indexType,
                                out var indexMessage,
                                out var indexData);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexCode,
                                indexType,
                                indexMessage,
                                indexData);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="BulkInsert"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnBulkInsert(IMappersSession session, Exception exception);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        public virtual void BulkInsert(
            IMappersSession session,
            IEnumerable<SystemLogDtoNew> data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderSystemLog();
                postgreSqlBulkInserter.Insert(typedSession, data);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask BulkInsertAsync(
            IMappersSession session,
            IEnumerable<SystemLogDtoNew> data,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderSystemLog();
                await postgreSqlBulkInserter.InsertAsync(typedSession, data, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="New"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Новая запись.</param>
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, SystemLogDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual SystemLogDtoActual New(IMappersSession session, SystemLogDtoNew data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new SystemLogDtoActual
                {
                    Id = data.Id,
                    CreateDate = data.CreateDate,
                    Code = data.Code,
                    Type = data.Type,
                    Message = data.Message,
                    Data = data.Data,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO SystemLog
(
Id,
CreateDate,
Code,
Type,
Message,
Data
)
VALUES
(
@Id,
@CreateDate,
@Code,
@Type,
@Message,
@Data
)";
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@CreateDate", NpgsqlDbType.TimestampTz) { TypedValue = result.CreateDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>(@"@Code", NpgsqlDbType.Integer) { TypedValue = result.Code };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>(@"@Type", NpgsqlDbType.Integer) { TypedValue = result.Type };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Message", NpgsqlDbType.Varchar, 1024).Value = result.Message;
                    command.Parameters.Add(@"@Data", NpgsqlDbType.Text).Value = result.Data;
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, SystemLogDtoNew data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new SystemLogDtoActual
                {
                    Id = data.Id,
                    CreateDate = data.CreateDate,
                    Code = data.Code,
                    Type = data.Type,
                    Message = data.Message,
                    Data = data.Data,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO SystemLog
(
Id,
CreateDate,
Code,
Type,
Message,
Data
)
VALUES
(
@Id,
@CreateDate,
@Code,
@Type,
@Message,
@Data
)";
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@CreateDate", NpgsqlDbType.TimestampTz) { TypedValue = result.CreateDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>(@"@Code", NpgsqlDbType.Integer) { TypedValue = result.Code };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>(@"@Type", NpgsqlDbType.Integer) { TypedValue = result.Type };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Message", NpgsqlDbType.Varchar, 1024).Value = result.Message;
                    command.Parameters.Add(@"@Data", NpgsqlDbType.Text).Value = result.Data;
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }

                return ((IMapperDto)result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<IMapperDto> IAbstractMapper.GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter);
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TMapperDto> IAbstractMapper.GetEnumerator<TMapperDto>(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter).Cast<TMapperDto>();
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumerator"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumerator(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<SystemLogDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
Code,
Type,
Message,
Data
FROM SystemLog";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexCreateDate;
                    int indexCode;
                    int indexType;
                    int indexMessage;
                    int indexData;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexCreateDate,
                            out indexCode,
                            out indexType,
                            out indexMessage,
                            out indexData);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        SystemLogDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexCode,
                                indexType,
                                indexMessage,
                                indexData);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<SystemLogDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
Code,
Type,
Message,
Data
FROM SystemLog";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexCreateDate;
                    int indexCode;
                    int indexType;
                    int indexMessage;
                    int indexData;
                    try
                    {
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexCreateDate,
                            out indexCode,
                            out indexType,
                            out indexMessage,
                            out indexData);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        SystemLogDtoActual result;
                        try
                        {
                            var hasRecord = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexCode,
                                indexType,
                                indexMessage,
                                indexData);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    await reader.SilentDisposeAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                await command.SilentDisposeAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorRaw(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<SystemLogDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
Code,
Type,
Message,
Data
FROM SystemLog";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter)
                    ;
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexCreateDate;
                    int indexCode;
                    int indexType;
                    int indexMessage;
                    int indexData;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId,
                            out indexCreateDate,
                            out indexCode,
                            out indexType,
                            out indexMessage,
                            out indexData);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        SystemLogDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = ReadRaw(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexCode,
                                indexType,
                                indexMessage,
                                indexData);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<SystemLogDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
Code,
Type,
Message,
Data
FROM SystemLog";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexCreateDate;
                    int indexCode;
                    int indexType;
                    int indexMessage;
                    int indexData;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexCreateDate,
                            out indexCode,
                            out indexType,
                            out indexMessage,
                            out indexData);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        SystemLogDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexCode,
                                indexType,
                                indexMessage,
                                indexData);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorIdentitiesPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorIdentitiesPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        public virtual IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id FROM SystemLog";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        long item;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }
                            item = reader.GetInt64(indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (item);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetCount"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetCount(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM SystemLog";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual async ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                await using (var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM SystemLog";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
    }

    /// <summary>
    /// Поточный читатель данных записей для массовой вставки записей в БД.
    /// 
    /// Партиция таблицы БД
    /// </summary>
    internal class BulkInsertDataReaderTablePartition : BasePostgreSqlBulkInserter<TablePartitionDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, TablePartitionDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.CreateDate.ToUniversalTime(), NpgsqlDbType.TimestampTz, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.TableName, NpgsqlDbType.Text, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.PartitionName, NpgsqlDbType.Text, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Day, NpgsqlDbType.Date, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.MinGroupId, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.MaxNotIncludeGroupId, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.MinId, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.MaxNotIncludeId, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, TablePartitionDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.CreateDate.ToUniversalTime(), NpgsqlDbType.TimestampTz);
            binaryImport.Write(instance.TableName, NpgsqlDbType.Text);
            binaryImport.Write(instance.PartitionName, NpgsqlDbType.Text);
            binaryImport.Write(instance.Day, NpgsqlDbType.Date);
            binaryImport.Write(instance.MinGroupId, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.MaxNotIncludeGroupId, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.MinId, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.MaxNotIncludeId, NpgsqlDbType.Bigint);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY TablePartition (Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Партиция таблицы БД
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.TablePartition)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperTablePartition : BasePostgreSqlMapper<TablePartitionDtoActual>, IPartitionsMapper, IMapperInitializer, IMapperTablePartition
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperTablePartition(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Партиция таблицы БД" + "' в БД", WellknownMappers.TablePartition, selectFilterFactory, exceptionPolicy)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"TablePartition", ComplexIdentity.Level.L2, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperTablePartition(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper? infrastructureMonitor = null)
           : base("Маппер данных состояния доменного объекта '" + @"Партиция таблицы БД" + "' в БД", WellknownMappers.TablePartition, selectFilterFactory, exceptionPolicy, infrastructureMonitor)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"TablePartition", ComplexIdentity.Level.L2, false);
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"TablePartition";

        /// <summary>
        /// Интерфейс управления партициями.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public IPartitionsManager Partitions { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] private set; }

        /// <summary>
        /// Обработка исключения мапппера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchException(IMappersSession session, Exception exception);

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Initialize"/>.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnInitialize(IMappers mappers, Exception exception);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        partial void DoInitialize(IMappers mappers);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        public virtual void Initialize(IMappers mappers)
        {
            if (mappers == null)
            {
                throw new ArgumentNullException(nameof(mappers));
            }
            try
            {
                DoInitialize(mappers);
            }
            catch (Exception exception)
            {

                CatchExceptionOnInitialize(mappers, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextId"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextId(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_TablePartition".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual long GetNextId(IMappersSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_TablePartition');";
                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextIds"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextIds(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_TablePartition".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        public virtual IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                cancellationToken.ThrowIfCancellationRequested();

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_TablePartition') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");

                        var result = new List<long>(count);
                        while (reader.Read())
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            var id = reader.GetInt64(indexId);
                            result.Add(id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextIds(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_TablePartition".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken" >Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual async ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_TablePartition');";
                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Exists"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExists(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual bool Exists(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM TablePartition WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual async ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM TablePartition WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM TablePartition WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM TablePartition WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexTableName">Индекс колонки 'TableName'.</param>
        /// <param name="indexPartitionName">Индекс колонки 'PartitionName'.</param>
        /// <param name="indexDay">Индекс колонки 'Day'.</param>
        /// <param name="indexMinGroupId">Индекс колонки 'MinGroupId'.</param>
        /// <param name="indexMaxNotIncludeGroupId">Индекс колонки 'MaxNotIncludeGroupId'.</param>
        /// <param name="indexMinId">Индекс колонки 'MinId'.</param>
        /// <param name="indexMaxNotIncludeId">Индекс колонки 'MaxNotIncludeId'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexCreateDate,
            out int indexTableName,
            out int indexPartitionName,
            out int indexDay,
            out int indexMinGroupId,
            out int indexMaxNotIncludeGroupId,
            out int indexMinId,
            out int indexMaxNotIncludeId)
        {
            indexId = reader.GetOrdinal("Id");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexTableName = reader.GetOrdinal("TableName");
            indexPartitionName = reader.GetOrdinal("PartitionName");
            indexDay = reader.GetOrdinal("Day");
            indexMinGroupId = reader.GetOrdinal("MinGroupId");
            indexMaxNotIncludeGroupId = reader.GetOrdinal("MaxNotIncludeGroupId");
            indexMinId = reader.GetOrdinal("MinId");
            indexMaxNotIncludeId = reader.GetOrdinal("MaxNotIncludeId");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexTableName">Индекс колонки 'TableName'.</param>
        /// <param name="indexPartitionName">Индекс колонки 'PartitionName'.</param>
        /// <param name="indexDay">Индекс колонки 'Day'.</param>
        /// <param name="indexMinGroupId">Индекс колонки 'MinGroupId'.</param>
        /// <param name="indexMaxNotIncludeGroupId">Индекс колонки 'MaxNotIncludeGroupId'.</param>
        /// <param name="indexMinId">Индекс колонки 'MinId'.</param>
        /// <param name="indexMaxNotIncludeId">Индекс колонки 'MaxNotIncludeId'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexCreateDate,
            out int indexTableName,
            out int indexPartitionName,
            out int indexDay,
            out int indexMinGroupId,
            out int indexMaxNotIncludeGroupId,
            out int indexMinId,
            out int indexMaxNotIncludeId)
        {
            indexId = reader.GetOrdinal("Id");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexTableName = reader.GetOrdinal("TableName");
            indexPartitionName = reader.GetOrdinal("PartitionName");
            indexDay = reader.GetOrdinal("Day");
            indexMinGroupId = reader.GetOrdinal("MinGroupId");
            indexMaxNotIncludeGroupId = reader.GetOrdinal("MaxNotIncludeGroupId");
            indexMinId = reader.GetOrdinal("MinId");
            indexMaxNotIncludeId = reader.GetOrdinal("MaxNotIncludeId");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexTableName">Индекс колонки 'TableName'.</param>
        /// <param name="indexPartitionName">Индекс колонки 'PartitionName'.</param>
        /// <param name="indexDay">Индекс колонки 'Day'.</param>
        /// <param name="indexMinGroupId">Индекс колонки 'MinGroupId'.</param>
        /// <param name="indexMaxNotIncludeGroupId">Индекс колонки 'MaxNotIncludeGroupId'.</param>
        /// <param name="indexMinId">Индекс колонки 'MinId'.</param>
        /// <param name="indexMaxNotIncludeId">Индекс колонки 'MaxNotIncludeId'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TablePartitionDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexCreateDate,
            int indexTableName,
            int indexPartitionName,
            int indexDay,
            int indexMinGroupId,
            int indexMaxNotIncludeGroupId,
            int indexMinId,
            int indexMaxNotIncludeId)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new TablePartitionDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.CreateDate = reader.GetFieldValue<DateTimeOffset>(indexCreateDate);
            result.TableName = reader.GetString(indexTableName);
            result.PartitionName = reader.GetString(indexPartitionName);
            result.Day = reader.GetDateTime(indexDay);
            result.MinGroupId = reader.GetInt64(indexMinGroupId);
            result.MaxNotIncludeGroupId = reader.GetInt64(indexMaxNotIncludeGroupId);
            result.MinId = reader.GetInt64(indexMinId);
            result.MaxNotIncludeId = reader.GetInt64(indexMaxNotIncludeId);

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexTableName">Индекс колонки 'TableName'.</param>
        /// <param name="indexPartitionName">Индекс колонки 'PartitionName'.</param>
        /// <param name="indexDay">Индекс колонки 'Day'.</param>
        /// <param name="indexMinGroupId">Индекс колонки 'MinGroupId'.</param>
        /// <param name="indexMaxNotIncludeGroupId">Индекс колонки 'MaxNotIncludeGroupId'.</param>
        /// <param name="indexMinId">Индекс колонки 'MinId'.</param>
        /// <param name="indexMaxNotIncludeId">Индекс колонки 'MaxNotIncludeId'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TablePartitionDtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexCreateDate,
            int indexTableName,
            int indexPartitionName,
            int indexDay,
            int indexMinGroupId,
            int indexMaxNotIncludeGroupId,
            int indexMinId,
            int indexMaxNotIncludeId)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new TablePartitionDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.CreateDate = reader.GetFieldValue<DateTimeOffset>(indexCreateDate);
            result.TableName = reader.GetString(indexTableName);
            result.PartitionName = reader.GetString(indexPartitionName);
            result.Day = reader.GetDateTime(indexDay);
            result.MinGroupId = reader.GetInt64(indexMinGroupId);
            result.MaxNotIncludeGroupId = reader.GetInt64(indexMaxNotIncludeGroupId);
            result.MinId = reader.GetInt64(indexMinId);
            result.MaxNotIncludeId = reader.GetInt64(indexMaxNotIncludeId);

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual TablePartitionDtoActual? Get(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
FROM TablePartition WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexCreateDate,
                                out var indexTableName,
                                out var indexPartitionName,
                                out var indexDay,
                                out var indexMinGroupId,
                                out var indexMaxNotIncludeGroupId,
                                out var indexMinId,
                                out var indexMaxNotIncludeId);

                            var result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexTableName,
                                indexPartitionName,
                                indexDay,
                                indexMinGroupId,
                                indexMaxNotIncludeGroupId,
                                indexMinId,
                                indexMaxNotIncludeId);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto?> GetAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
FROM TablePartition WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexCreateDate,
                                out var indexTableName,
                                out var indexPartitionName,
                                out var indexDay,
                                out var indexMinGroupId,
                                out var indexMaxNotIncludeGroupId,
                                out var indexMinId,
                                out var indexMaxNotIncludeId);

                            var result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexTableName,
                                indexPartitionName,
                                indexDay,
                                indexMinGroupId,
                                indexMaxNotIncludeGroupId,
                                indexMinId,
                                indexMaxNotIncludeId);

                            return ((IMapperDto)result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGetRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual TablePartitionDtoActual? GetRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
FROM TablePartition WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexCreateDate,
                                out var indexTableName,
                                out var indexPartitionName,
                                out var indexDay,
                                out var indexMinGroupId,
                                out var indexMaxNotIncludeGroupId,
                                out var indexMinId,
                                out var indexMaxNotIncludeId);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexTableName,
                                indexPartitionName,
                                indexDay,
                                indexMinGroupId,
                                indexMaxNotIncludeGroupId,
                                indexMinId,
                                indexMaxNotIncludeId);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<TablePartitionDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
FROM TablePartition WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexCreateDate,
                                out var indexTableName,
                                out var indexPartitionName,
                                out var indexDay,
                                out var indexMinGroupId,
                                out var indexMaxNotIncludeGroupId,
                                out var indexMinId,
                                out var indexMaxNotIncludeId);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexTableName,
                                indexPartitionName,
                                indexDay,
                                indexMinGroupId,
                                indexMaxNotIncludeGroupId,
                                indexMinId,
                                indexMaxNotIncludeId);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="BulkInsert"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnBulkInsert(IMappersSession session, Exception exception);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        public virtual void BulkInsert(
            IMappersSession session,
            IEnumerable<TablePartitionDtoNew> data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderTablePartition();
                postgreSqlBulkInserter.Insert(typedSession, data);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask BulkInsertAsync(
            IMappersSession session,
            IEnumerable<TablePartitionDtoNew> data,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderTablePartition();
                await postgreSqlBulkInserter.InsertAsync(typedSession, data, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="New"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Новая запись.</param>
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, TablePartitionDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual TablePartitionDtoActual New(IMappersSession session, TablePartitionDtoNew data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new TablePartitionDtoActual
                {
                    Id = data.Id,
                    CreateDate = data.CreateDate,
                    TableName = data.TableName,
                    PartitionName = data.PartitionName,
                    Day = data.Day,
                    MinGroupId = data.MinGroupId,
                    MaxNotIncludeGroupId = data.MaxNotIncludeGroupId,
                    MinId = data.MinId,
                    MaxNotIncludeId = data.MaxNotIncludeId,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO TablePartition
(
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
)
VALUES
(
@Id,
@CreateDate,
@TableName,
@PartitionName,
@Day,
@MinGroupId,
@MaxNotIncludeGroupId,
@MinId,
@MaxNotIncludeId
)";
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@CreateDate", NpgsqlDbType.TimestampTz) { TypedValue = result.CreateDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@TableName", NpgsqlDbType.Text).Value = result.TableName;
                    command.Parameters.Add(@"@PartitionName", NpgsqlDbType.Text).Value = result.PartitionName;
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@Day", NpgsqlDbType.Date) { TypedValue = result.Day };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@MinGroupId", NpgsqlDbType.Bigint) { TypedValue = result.MinGroupId };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@MaxNotIncludeGroupId", NpgsqlDbType.Bigint) { TypedValue = result.MaxNotIncludeGroupId };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@MinId", NpgsqlDbType.Bigint) { TypedValue = result.MinId };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@MaxNotIncludeId", NpgsqlDbType.Bigint) { TypedValue = result.MaxNotIncludeId };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, TablePartitionDtoNew data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new TablePartitionDtoActual
                {
                    Id = data.Id,
                    CreateDate = data.CreateDate,
                    TableName = data.TableName,
                    PartitionName = data.PartitionName,
                    Day = data.Day,
                    MinGroupId = data.MinGroupId,
                    MaxNotIncludeGroupId = data.MaxNotIncludeGroupId,
                    MinId = data.MinId,
                    MaxNotIncludeId = data.MaxNotIncludeId,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO TablePartition
(
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
)
VALUES
(
@Id,
@CreateDate,
@TableName,
@PartitionName,
@Day,
@MinGroupId,
@MaxNotIncludeGroupId,
@MinId,
@MaxNotIncludeId
)";
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@CreateDate", NpgsqlDbType.TimestampTz) { TypedValue = result.CreateDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@TableName", NpgsqlDbType.Text).Value = result.TableName;
                    command.Parameters.Add(@"@PartitionName", NpgsqlDbType.Text).Value = result.PartitionName;
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@Day", NpgsqlDbType.Date) { TypedValue = result.Day };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@MinGroupId", NpgsqlDbType.Bigint) { TypedValue = result.MinGroupId };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@MaxNotIncludeGroupId", NpgsqlDbType.Bigint) { TypedValue = result.MaxNotIncludeGroupId };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@MinId", NpgsqlDbType.Bigint) { TypedValue = result.MinId };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@MaxNotIncludeId", NpgsqlDbType.Bigint) { TypedValue = result.MaxNotIncludeId };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }

                return ((IMapperDto)result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<IMapperDto> IAbstractMapper.GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter);
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TMapperDto> IAbstractMapper.GetEnumerator<TMapperDto>(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter).Cast<TMapperDto>();
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumerator"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumerator(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<TablePartitionDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
FROM TablePartition";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexCreateDate;
                    int indexTableName;
                    int indexPartitionName;
                    int indexDay;
                    int indexMinGroupId;
                    int indexMaxNotIncludeGroupId;
                    int indexMinId;
                    int indexMaxNotIncludeId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexCreateDate,
                            out indexTableName,
                            out indexPartitionName,
                            out indexDay,
                            out indexMinGroupId,
                            out indexMaxNotIncludeGroupId,
                            out indexMinId,
                            out indexMaxNotIncludeId);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        TablePartitionDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexTableName,
                                indexPartitionName,
                                indexDay,
                                indexMinGroupId,
                                indexMaxNotIncludeGroupId,
                                indexMinId,
                                indexMaxNotIncludeId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<TablePartitionDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
FROM TablePartition";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexCreateDate;
                    int indexTableName;
                    int indexPartitionName;
                    int indexDay;
                    int indexMinGroupId;
                    int indexMaxNotIncludeGroupId;
                    int indexMinId;
                    int indexMaxNotIncludeId;
                    try
                    {
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexCreateDate,
                            out indexTableName,
                            out indexPartitionName,
                            out indexDay,
                            out indexMinGroupId,
                            out indexMaxNotIncludeGroupId,
                            out indexMinId,
                            out indexMaxNotIncludeId);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        TablePartitionDtoActual result;
                        try
                        {
                            var hasRecord = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexTableName,
                                indexPartitionName,
                                indexDay,
                                indexMinGroupId,
                                indexMaxNotIncludeGroupId,
                                indexMinId,
                                indexMaxNotIncludeId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    await reader.SilentDisposeAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                await command.SilentDisposeAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorRaw(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<TablePartitionDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
FROM TablePartition";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter)
                    ;
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexCreateDate;
                    int indexTableName;
                    int indexPartitionName;
                    int indexDay;
                    int indexMinGroupId;
                    int indexMaxNotIncludeGroupId;
                    int indexMinId;
                    int indexMaxNotIncludeId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId,
                            out indexCreateDate,
                            out indexTableName,
                            out indexPartitionName,
                            out indexDay,
                            out indexMinGroupId,
                            out indexMaxNotIncludeGroupId,
                            out indexMinId,
                            out indexMaxNotIncludeId);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        TablePartitionDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = ReadRaw(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexTableName,
                                indexPartitionName,
                                indexDay,
                                indexMinGroupId,
                                indexMaxNotIncludeGroupId,
                                indexMinId,
                                indexMaxNotIncludeId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<TablePartitionDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
CreateDate,
TableName,
PartitionName,
Day,
MinGroupId,
MaxNotIncludeGroupId,
MinId,
MaxNotIncludeId
FROM TablePartition";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexCreateDate;
                    int indexTableName;
                    int indexPartitionName;
                    int indexDay;
                    int indexMinGroupId;
                    int indexMaxNotIncludeGroupId;
                    int indexMinId;
                    int indexMaxNotIncludeId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexCreateDate,
                            out indexTableName,
                            out indexPartitionName,
                            out indexDay,
                            out indexMinGroupId,
                            out indexMaxNotIncludeGroupId,
                            out indexMinId,
                            out indexMaxNotIncludeId);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        TablePartitionDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexCreateDate,
                                indexTableName,
                                indexPartitionName,
                                indexDay,
                                indexMinGroupId,
                                indexMaxNotIncludeGroupId,
                                indexMinId,
                                indexMaxNotIncludeId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorIdentitiesPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorIdentitiesPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        public virtual IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id FROM TablePartition";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        long item;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }
                            item = reader.GetInt64(indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (item);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetCount"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetCount(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM TablePartition";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual async ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                await using (var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM TablePartition";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
    }

    /// <summary>
    /// Поточный читатель данных записей для массовой вставки записей в БД.
    /// 
    /// Объект
    /// </summary>
    internal class BulkInsertDataReaderDemoObject : BasePostgreSqlBulkInserter<DemoObjectDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, DemoObjectDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(Constants.StartRevision, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.CreateDate, NpgsqlDbType.Timestamp, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.ModificationDate, NpgsqlDbType.Timestamp, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Name, NpgsqlDbType.Varchar, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Enabled, NpgsqlDbType.Boolean, cancellationToken).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, DemoObjectDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(Constants.StartRevision, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.CreateDate, NpgsqlDbType.Timestamp);
            binaryImport.Write(instance.ModificationDate, NpgsqlDbType.Timestamp);
            binaryImport.Write(instance.Name, NpgsqlDbType.Varchar);
            binaryImport.Write(instance.Enabled, NpgsqlDbType.Boolean);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY DemoObject (Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Объект
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.DemoObject)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperDemoObject : BasePostgreSqlMapper<DemoObjectDtoActual>, IPartitionsMapper, IMapperInitializer, IMapperDemoObject, IMapperActualDtoCache
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperDemoObject(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Объект" + "' в БД", WellknownMappers.DemoObject, selectFilterFactory, exceptionPolicy)
        {
            Options = Options | MapperOptions.OptimisticConcurrency;
            
            Partitions = new PartitionsManager(exceptionPolicy, @"DemoObject", ComplexIdentity.Level.L2, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperDemoObject(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper? infrastructureMonitor = null, IMemoryCache<DemoObjectDtoActual, long>? actualDtoMemoryCache = null)
           : base("Маппер данных состояния доменного объекта '" + @"Объект" + "' в БД", WellknownMappers.DemoObject, selectFilterFactory, exceptionPolicy, infrastructureMonitor, actualDtoMemoryCache)
        {
            Options = Options | MapperOptions.OptimisticConcurrency;
            
            Partitions = new PartitionsManager(exceptionPolicy, @"DemoObject", ComplexIdentity.Level.L2, false);
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"DemoObject";

        /// <summary>
        /// Интерфейс управления партициями.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public IPartitionsManager Partitions { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] private set; }

        /// <summary>
        /// Обработка исключения мапппера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchException(IMappersSession session, Exception exception);

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Initialize"/>.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnInitialize(IMappers mappers, Exception exception);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        partial void DoInitialize(IMappers mappers);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        public virtual void Initialize(IMappers mappers)
        {
            if (mappers == null)
            {
                throw new ArgumentNullException(nameof(mappers));
            }
            try
            {
                DoInitialize(mappers);
            }
            catch (Exception exception)
            {

                CatchExceptionOnInitialize(mappers, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextId"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextId(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoObject".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual long GetNextId(IMappersSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_DemoObject');";
                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextIds"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextIds(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_DemoObject".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        public virtual IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                cancellationToken.ThrowIfCancellationRequested();

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_DemoObject') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");

                        var result = new List<long>(count);
                        while (reader.Read())
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            var id = reader.GetInt64(indexId);
                            result.Add(id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextIds(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoObject".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken" >Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual async ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_DemoObject');";
                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Exists"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExists(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual bool Exists(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObject WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual async ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObject WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObject WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObject WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsRevision"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRevision(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRevision(IMappersSession session, long id, long revision)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObject WHERE (Id = @Id) AND (Revision = @Revision) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = revision };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        if (result)
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto!.Revision != revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }
                        else
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto!.Revision == revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRevision(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRevisionAsync(IMappersSession session, long id, long revision, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObject WHERE (Id = @Id) AND (Revision = @Revision) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = revision };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (result)
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto!.Revision != revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }
                        else
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto!.Revision == revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRevision(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexName">Индекс колонки 'Name'.</param>
        /// <param name="indexEnabled">Индекс колонки 'Enabled'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexName,
            out int indexEnabled)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexName = reader.GetOrdinal("Name");
            indexEnabled = reader.GetOrdinal("Enabled");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexName">Индекс колонки 'Name'.</param>
        /// <param name="indexEnabled">Индекс колонки 'Enabled'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexName,
            out int indexEnabled)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexName = reader.GetOrdinal("Name");
            indexEnabled = reader.GetOrdinal("Enabled");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexName">Индекс колонки 'Name'.</param>
        /// <param name="indexEnabled">Индекс колонки 'Enabled'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DemoObjectDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexName,
            int indexEnabled)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new DemoObjectDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetDateTime(indexCreateDate);
            result.ModificationDate = reader.GetDateTime(indexModificationDate);
            result.Name = reader.GetString(indexName);
            result.Enabled = reader.GetBoolean(indexEnabled);

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexName">Индекс колонки 'Name'.</param>
        /// <param name="indexEnabled">Индекс колонки 'Enabled'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DemoObjectDtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexName,
            int indexEnabled)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new DemoObjectDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetDateTime(indexCreateDate);
            result.ModificationDate = reader.GetDateTime(indexModificationDate);
            result.Name = reader.GetString(indexName);
            result.Enabled = reader.GetBoolean(indexEnabled);

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoObjectDtoActual? Get(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                if (TryGetFromCache(id, out var cacheResult))
                {
                    return (cacheResult);
                }

                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
FROM DemoObject WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled);

                            SeedRevision(result.Revision);

                            AddActualState(typedSession, result);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto?> GetAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                if (TryGetFromCache(id, out var cacheResult))
                {
                    return (cacheResult);
                }

                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
FROM DemoObject WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled);

                            SeedRevision(result.Revision);

                            AddActualState(typedSession, result);

                            return ((IMapperDto)result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGetRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoObjectDtoActual? GetRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
FROM DemoObject WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled);

                            SeedRevision(result.Revision);
                            AddActualState(typedSession, result);

                            return (result);
                        }
                        else
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<DemoObjectDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
FROM DemoObject WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled);

                            SeedRevision(result.Revision);
                            AddActualState(typedSession, result);

                            return (result);
                        }
                        else
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Update"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Измененная запись.</param>
        partial void CatchExceptionOnUpdate(IMappersSession session, Exception exception, DemoObjectDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual DemoObjectDtoActual Update(IMappersSession session, DemoObjectDtoChanged data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var result =
                new DemoObjectDtoActual
                {
                    Id = data.Id,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Name = data.Name.Value!,
                    Enabled = data.Enabled.Value!,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE DemoObject SET ");
                    commandText.AppendLine(@"Revision = @New_Revision");
                    
                    commandText.AppendLine(@", ModificationDate = @ModificationDate");
                    {
                        var parameter = new NpgsqlParameter<DateTime>("@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Name.IsChanged)
                    {
                        commandText.AppendLine(@", Name = @Name");
                        command.Parameters.Add("@Name", NpgsqlDbType.Varchar, 1024).Value = result.Name;
                    }
                    if (data.Enabled.IsChanged)
                    {
                        commandText.AppendLine(@", Enabled = @Enabled");
                        var parameter = new NpgsqlParameter<bool>("@Enabled", NpgsqlDbType.Boolean) { TypedValue = result.Enabled };
                        command.Parameters.Add(parameter);
                    }
                    commandText.Append(@" WHERE (Id = @Id) AND (Revision = @Old_Revision)");

                    command.CommandText = commandText.ToString();

                    {
                        var parameter = new NpgsqlParameter<long>("@Old_Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = command.ExecuteNonQuery();
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                AddActualState(typedSession, result);

                if (MappersFeatures.ValidateUpdateResults)
                {
                    var realDto = GetRaw(session, result.Id);
                    var realDtoText = realDto.ToJsonText(true);
                    var resultText = result.ToJsonText(true);
                    if (MappersFeatures.ValidateUpdateAction != null)
                    {
                        if (false == MappersFeatures.ValidateUpdateAction(realDto!, result))
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                    else
                    {
                        if (realDtoText != resultText)
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnUpdate(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual async ValueTask<IMapperDto> UpdateAsync(IMappersSession session, DemoObjectDtoChanged data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var result =
                new DemoObjectDtoActual
                {
                    Id = data.Id,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Name = data.Name.Value!,
                    Enabled = data.Enabled.Value!,
                };

                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE DemoObject SET ");
                    commandText.AppendLine(@"Revision = @New_Revision");
                    
                    commandText.AppendLine(@", ModificationDate = @ModificationDate");
                    {
                        var parameter = new NpgsqlParameter<DateTime>("@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Name.IsChanged)
                    {
                        commandText.AppendLine(@", Name = @Name");
                        command.Parameters.Add("@Name", NpgsqlDbType.Varchar, 1024).Value = result.Name;
                    }
                    if (data.Enabled.IsChanged)
                    {
                        commandText.AppendLine(@", Enabled = @Enabled");
                        var parameter = new NpgsqlParameter<bool>("@Enabled", NpgsqlDbType.Boolean) { TypedValue = result.Enabled };
                        command.Parameters.Add(parameter);
                    }
                    commandText.Append(@" WHERE (Id = @Id) AND (Revision = @Old_Revision)");

                    command.CommandText = commandText.ToString();

                    {
                        var parameter = new NpgsqlParameter<long>("@Old_Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                AddActualState(typedSession, result);

                if (MappersFeatures.ValidateUpdateResults)
                {
                    var realDto = GetRaw(session, result.Id);
                    var realDtoText = realDto.ToJsonText(true);
                    var resultText = result.ToJsonText(true);
                    if (MappersFeatures.ValidateUpdateAction != null)
                    {
                        if (false == MappersFeatures.ValidateUpdateAction(realDto!, result))
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                    else
                    {
                        if (realDtoText != resultText)
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                }

                return ((IMapperDto)result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnUpdate(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="BulkInsert"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnBulkInsert(IMappersSession session, Exception exception);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        public virtual void BulkInsert(
            IMappersSession session,
            IEnumerable<DemoObjectDtoNew> data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderDemoObject();
                postgreSqlBulkInserter.Insert(typedSession, data);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask BulkInsertAsync(
            IMappersSession session,
            IEnumerable<DemoObjectDtoNew> data,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderDemoObject();
                await postgreSqlBulkInserter.InsertAsync(typedSession, data, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="New"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Новая запись.</param>
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, DemoObjectDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoObjectDtoActual New(IMappersSession session, DemoObjectDtoNew data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new DemoObjectDtoActual
                {
                    Id = data.Id,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Name = data.Name,
                    Enabled = data.Enabled,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO DemoObject
(
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
)
VALUES
(
@Id,
@New_Revision,
@CreateDate,
@ModificationDate,
@Name,
@Enabled
)";
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@CreateDate", NpgsqlDbType.Timestamp) { TypedValue = result.CreateDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Name", NpgsqlDbType.Varchar, 1024).Value = result.Name;
                    {
                        var parameter = new NpgsqlParameter<bool>(@"@Enabled", NpgsqlDbType.Boolean) { TypedValue = result.Enabled };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }

                AddActualState(typedSession, result);

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, DemoObjectDtoNew data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new DemoObjectDtoActual
                {
                    Id = data.Id,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Name = data.Name,
                    Enabled = data.Enabled,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO DemoObject
(
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
)
VALUES
(
@Id,
@New_Revision,
@CreateDate,
@ModificationDate,
@Name,
@Enabled
)";
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@CreateDate", NpgsqlDbType.Timestamp) { TypedValue = result.CreateDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Name", NpgsqlDbType.Varchar, 1024).Value = result.Name;
                    {
                        var parameter = new NpgsqlParameter<bool>(@"@Enabled", NpgsqlDbType.Boolean) { TypedValue = result.Enabled };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
                        command.Parameters.Add(parameter);
                    }
                    await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }

                AddActualState(typedSession, result);

                return ((IMapperDto)result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<IMapperDto> IAbstractMapper.GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter);
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TMapperDto> IAbstractMapper.GetEnumerator<TMapperDto>(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter).Cast<TMapperDto>();
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumerator"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumerator(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoObjectDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
FROM DemoObject";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    IPostgreSqlMappersSession typedSession;
                    try
                    {
                        typedSession = (IPostgreSqlMappersSession) session;
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        AddActualState(typedSession, result);

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<DemoObjectDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
FROM DemoObject";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    IPostgreSqlMappersSession typedSession;
                    try
                    {
                        typedSession = (IPostgreSqlMappersSession) session;
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectDtoActual result;
                        try
                        {
                            var hasRecord = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        AddActualState(typedSession, result);

                        yield return (result);
                    }
                }
                finally
                {
                    await reader.SilentDisposeAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                await command.SilentDisposeAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorRaw(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoObjectDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
FROM DemoObject";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter)
                    ;
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoObjectDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled
FROM DemoObject";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    IPostgreSqlMappersSession typedSession;
                    try
                    {
                        typedSession = (IPostgreSqlMappersSession) session;
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        AddActualState(typedSession, result);

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorIdentitiesPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorIdentitiesPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        public virtual IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id FROM DemoObject";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        long item;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }
                            item = reader.GetInt64(indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (item);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetCount"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetCount(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM DemoObject";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual async ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                await using (var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM DemoObject";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
    }

    /// <summary>
    /// Поточный читатель данных записей для массовой вставки записей в БД.
    /// 
    /// Объект X
    /// </summary>
    internal class BulkInsertDataReaderDemoObjectX : BasePostgreSqlBulkInserter<DemoObjectXDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, DemoObjectXDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(Constants.StartRevision, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.CreateDate.ToUniversalTime(), NpgsqlDbType.TimestampTz, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.ModificationDate.ToUniversalTime(), NpgsqlDbType.TimestampTz, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Name, NpgsqlDbType.Varchar, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Enabled, NpgsqlDbType.Boolean, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Key1, NpgsqlDbType.Uuid, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Key2, NpgsqlDbType.Varchar, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Group, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, DemoObjectXDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(Constants.StartRevision, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.CreateDate.ToUniversalTime(), NpgsqlDbType.TimestampTz);
            binaryImport.Write(instance.ModificationDate.ToUniversalTime(), NpgsqlDbType.TimestampTz);
            binaryImport.Write(instance.Name, NpgsqlDbType.Varchar);
            binaryImport.Write(instance.Enabled, NpgsqlDbType.Boolean);
            binaryImport.Write(instance.Key1, NpgsqlDbType.Uuid);
            binaryImport.Write(instance.Key2, NpgsqlDbType.Varchar);
            binaryImport.Write(instance.Group, NpgsqlDbType.Bigint);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY DemoObjectX (Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group"") FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Объект X
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.DemoObjectX)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperDemoObjectX : BasePostgreSqlMapper<DemoObjectXDtoActual>, IMapperInitializer, IMapperDemoObjectX, IMapperActualDtoCache
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperDemoObjectX(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Объект X" + "' в БД", WellknownMappers.DemoObjectX, selectFilterFactory, exceptionPolicy)
        {
            Options = Options | MapperOptions.OptimisticConcurrency;
            
            Options = Options | MapperOptions.Delete;
            
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperDemoObjectX(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper? infrastructureMonitor = null, IMemoryCache<DemoObjectXDtoActual, long>? actualDtoMemoryCache = null)
           : base("Маппер данных состояния доменного объекта '" + @"Объект X" + "' в БД", WellknownMappers.DemoObjectX, selectFilterFactory, exceptionPolicy, infrastructureMonitor, actualDtoMemoryCache)
        {
            Options = Options | MapperOptions.OptimisticConcurrency;
            
            Options = Options | MapperOptions.Delete;
            
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"DemoObjectX";

        /// <summary>
        /// Обработка исключения мапппера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchException(IMappersSession session, Exception exception);

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Initialize"/>.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnInitialize(IMappers mappers, Exception exception);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        partial void DoInitialize(IMappers mappers);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        public virtual void Initialize(IMappers mappers)
        {
            if (mappers == null)
            {
                throw new ArgumentNullException(nameof(mappers));
            }
            try
            {
                DoInitialize(mappers);
            }
            catch (Exception exception)
            {

                CatchExceptionOnInitialize(mappers, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextId"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextId(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoObjectX".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual long GetNextId(IMappersSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_DemoObjectX');";
                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextIds"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextIds(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_DemoObjectX".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        public virtual IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                cancellationToken.ThrowIfCancellationRequested();

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_DemoObjectX') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");

                        var result = new List<long>(count);
                        while (reader.Read())
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            var id = reader.GetInt64(indexId);
                            result.Add(id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextIds(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoObjectX".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken" >Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual async ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_DemoObjectX');";
                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Exists"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExists(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual bool Exists(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObjectX WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsByKey"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        partial void CatchExceptionOnExistsByKey(IMappersSession session, Exception exception, Guid argKey1, string argKey2);

        /// <summary>
        /// Проверка существования записи по альтернативному ключу 'Уникальность по 'Альтернативный ключ - часть №1 и №2''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual bool ExistsByKey(IMappersSession session, Guid argKey1, string argKey2)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObjectX WHERE (Key1 = @Key1) AND (Key2 = @Key2) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<Guid>("@Key1", NpgsqlDbType.Uuid) { TypedValue = argKey1 };
                        command.Parameters.Add(parameter);
                    }

                    command.Parameters.Add("@Key2", NpgsqlDbType.Varchar).Value = argKey2;

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsByKey(session, exception, argKey1, argKey2);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual async ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObjectX WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записи по альтернативному ключу 'Уникальность по 'Альтернативный ключ - часть №1 и №2''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual async ValueTask<bool> ExistsByKeyAsync(IMappersSession session, Guid argKey1, string argKey2, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObjectX WHERE (Key1 = @Key1) AND (Key2 = @Key2) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<Guid>("@Key1", NpgsqlDbType.Uuid) { TypedValue = argKey1 };
                        command.Parameters.Add(parameter);
                    }

                    command.Parameters.Add("@Key2", NpgsqlDbType.Varchar).Value = argKey2;

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsByKey(session, exception, argKey1, argKey2);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObjectX WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObjectX WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsRevision"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRevision(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRevision(IMappersSession session, long id, long revision)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObjectX WHERE (Id = @Id) AND (Revision = @Revision) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = revision };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        if (result)
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto!.Revision != revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }
                        else
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto!.Revision == revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRevision(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRevisionAsync(IMappersSession session, long id, long revision, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoObjectX WHERE (Id = @Id) AND (Revision = @Revision) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = revision };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (result)
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto!.Revision != revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }
                        else
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto!.Revision == revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRevision(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexName">Индекс колонки 'Name'.</param>
        /// <param name="indexEnabled">Индекс колонки 'Enabled'.</param>
        /// <param name="indexKey1">Индекс колонки 'Key1'.</param>
        /// <param name="indexKey2">Индекс колонки 'Key2'.</param>
        /// <param name="indexGroup">Индекс колонки 'group'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexName,
            out int indexEnabled,
            out int indexKey1,
            out int indexKey2,
            out int indexGroup)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexName = reader.GetOrdinal("Name");
            indexEnabled = reader.GetOrdinal("Enabled");
            indexKey1 = reader.GetOrdinal("Key1");
            indexKey2 = reader.GetOrdinal("Key2");
            indexGroup = reader.GetOrdinal("group");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexName">Индекс колонки 'Name'.</param>
        /// <param name="indexEnabled">Индекс колонки 'Enabled'.</param>
        /// <param name="indexKey1">Индекс колонки 'Key1'.</param>
        /// <param name="indexKey2">Индекс колонки 'Key2'.</param>
        /// <param name="indexGroup">Индекс колонки 'group'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexName,
            out int indexEnabled,
            out int indexKey1,
            out int indexKey2,
            out int indexGroup)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexName = reader.GetOrdinal("Name");
            indexEnabled = reader.GetOrdinal("Enabled");
            indexKey1 = reader.GetOrdinal("Key1");
            indexKey2 = reader.GetOrdinal("Key2");
            indexGroup = reader.GetOrdinal("group");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexName">Индекс колонки 'Name'.</param>
        /// <param name="indexEnabled">Индекс колонки 'Enabled'.</param>
        /// <param name="indexKey1">Индекс колонки 'Key1'.</param>
        /// <param name="indexKey2">Индекс колонки 'Key2'.</param>
        /// <param name="indexGroup">Индекс колонки 'group'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DemoObjectXDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexName,
            int indexEnabled,
            int indexKey1,
            int indexKey2,
            int indexGroup)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new DemoObjectXDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetFieldValue<DateTimeOffset>(indexCreateDate);
            result.ModificationDate = reader.GetFieldValue<DateTimeOffset>(indexModificationDate);
            result.Name = reader.GetString(indexName);
            result.Enabled = reader.GetBoolean(indexEnabled);
            result.Key1 = reader.GetGuid(indexKey1);
            result.Key2 = reader.GetString(indexKey2);
            result.Group = reader.GetInt64(indexGroup);

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexName">Индекс колонки 'Name'.</param>
        /// <param name="indexEnabled">Индекс колонки 'Enabled'.</param>
        /// <param name="indexKey1">Индекс колонки 'Key1'.</param>
        /// <param name="indexKey2">Индекс колонки 'Key2'.</param>
        /// <param name="indexGroup">Индекс колонки 'group'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DemoObjectXDtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexName,
            int indexEnabled,
            int indexKey1,
            int indexKey2,
            int indexGroup)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new DemoObjectXDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetFieldValue<DateTimeOffset>(indexCreateDate);
            result.ModificationDate = reader.GetFieldValue<DateTimeOffset>(indexModificationDate);
            result.Name = reader.GetString(indexName);
            result.Enabled = reader.GetBoolean(indexEnabled);
            result.Key1 = reader.GetGuid(indexKey1);
            result.Key2 = reader.GetString(indexKey2);
            result.Group = reader.GetInt64(indexGroup);

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoObjectXDtoActual? Get(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                if (TryGetFromCache(id, out var cacheResult))
                {
                    return (cacheResult);
                }

                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled,
                                out var indexKey1,
                                out var indexKey2,
                                out var indexGroup);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);

                            AddActualState(typedSession, result);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetByKey"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        partial void CatchExceptionOnGetByKey(IMappersSession session, Exception exception, Guid argKey1, string argKey2);

        /// <summary>
        /// Получить запись с указаным альтернативным ключом 'Уникальность по 'Альтернативный ключ - часть №1 и №2''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoObjectXDtoActual? GetByKey(IMappersSession session, Guid argKey1, string argKey2)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX WHERE
(Key1 = @Key1)
AND (Key2 = @Key2)";

                    {
                        var parameter = new NpgsqlParameter<Guid>("@Key1", NpgsqlDbType.Uuid) { TypedValue = argKey1 };
                        command.Parameters.Add(parameter);
                    }

                    command.Parameters.Add("@Key2", NpgsqlDbType.Varchar).Value = argKey2;

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled,
                                out var indexKey1,
                                out var indexKey2,
                                out var indexGroup);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);

                            AddActualState(typedSession, result);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetByKey(session, exception, argKey1, argKey2);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto?> GetAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                if (TryGetFromCache(id, out var cacheResult))
                {
                    return (cacheResult);
                }

                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled,
                                out var indexKey1,
                                out var indexKey2,
                                out var indexGroup);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);

                            AddActualState(typedSession, result);

                            return ((IMapperDto)result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным альтернативным ключом 'Уникальность по 'Альтернативный ключ - часть №1 и №2''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argKey1">Альтернативный ключ - часть №1</param>
        /// <param name="argKey2">Альтернативный ключ - часть №2</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto?> GetByKeyAsync(IMappersSession session, Guid argKey1, string argKey2, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX WHERE
(Key1 = @Key1)
AND (Key2 = @Key2)";

                    {
                        var parameter = new NpgsqlParameter<Guid>("@Key1", NpgsqlDbType.Uuid) { TypedValue = argKey1 };
                        command.Parameters.Add(parameter);
                    }

                    command.Parameters.Add("@Key2", NpgsqlDbType.Varchar).Value = argKey2;

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled,
                                out var indexKey1,
                                out var indexKey2,
                                out var indexGroup);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);

                            AddActualState(typedSession, result);

                            return ((IMapperDto)result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetByKey(session, exception, argKey1, argKey2);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGetRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoObjectXDtoActual? GetRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled,
                                out var indexKey1,
                                out var indexKey2,
                                out var indexGroup);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);
                            AddActualState(typedSession, result);

                            return (result);
                        }
                        else
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<DemoObjectXDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexName,
                                out var indexEnabled,
                                out var indexKey1,
                                out var indexKey2,
                                out var indexGroup);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);
                            AddActualState(typedSession, result);

                            return (result);
                        }
                        else
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Update"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Измененная запись.</param>
        partial void CatchExceptionOnUpdate(IMappersSession session, Exception exception, DemoObjectXDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual DemoObjectXDtoActual Update(IMappersSession session, DemoObjectXDtoChanged data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var result =
                new DemoObjectXDtoActual
                {
                    Id = data.Id,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Name = data.Name.Value!,
                    Enabled = data.Enabled.Value!,
                    Key1 = data.Key1,
                    Key2 = data.Key2,
                    Group = data.Group,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE DemoObjectX SET ");
                    commandText.AppendLine(@"Revision = @New_Revision");
                    
                    commandText.AppendLine(@", ModificationDate = @ModificationDate");
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>("@ModificationDate", NpgsqlDbType.TimestampTz) { TypedValue = result.ModificationDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Name.IsChanged)
                    {
                        commandText.AppendLine(@", Name = @Name");
                        command.Parameters.Add("@Name", NpgsqlDbType.Varchar, 1024).Value = result.Name;
                    }
                    if (data.Enabled.IsChanged)
                    {
                        commandText.AppendLine(@", Enabled = @Enabled");
                        var parameter = new NpgsqlParameter<bool>("@Enabled", NpgsqlDbType.Boolean) { TypedValue = result.Enabled };
                        command.Parameters.Add(parameter);
                    }
                    commandText.Append(@" WHERE (Id = @Id) AND (Revision = @Old_Revision)");

                    command.CommandText = commandText.ToString();

                    {
                        var parameter = new NpgsqlParameter<long>("@Old_Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = command.ExecuteNonQuery();
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                AddActualState(typedSession, result);

                if (MappersFeatures.ValidateUpdateResults)
                {
                    var realDto = GetRaw(session, result.Id);
                    var realDtoText = realDto.ToJsonText(true);
                    var resultText = result.ToJsonText(true);
                    if (MappersFeatures.ValidateUpdateAction != null)
                    {
                        if (false == MappersFeatures.ValidateUpdateAction(realDto!, result))
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                    else
                    {
                        if (realDtoText != resultText)
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnUpdate(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual async ValueTask<IMapperDto> UpdateAsync(IMappersSession session, DemoObjectXDtoChanged data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var result =
                new DemoObjectXDtoActual
                {
                    Id = data.Id,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Name = data.Name.Value!,
                    Enabled = data.Enabled.Value!,
                    Key1 = data.Key1,
                    Key2 = data.Key2,
                    Group = data.Group,
                };

                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE DemoObjectX SET ");
                    commandText.AppendLine(@"Revision = @New_Revision");
                    
                    commandText.AppendLine(@", ModificationDate = @ModificationDate");
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>("@ModificationDate", NpgsqlDbType.TimestampTz) { TypedValue = result.ModificationDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Name.IsChanged)
                    {
                        commandText.AppendLine(@", Name = @Name");
                        command.Parameters.Add("@Name", NpgsqlDbType.Varchar, 1024).Value = result.Name;
                    }
                    if (data.Enabled.IsChanged)
                    {
                        commandText.AppendLine(@", Enabled = @Enabled");
                        var parameter = new NpgsqlParameter<bool>("@Enabled", NpgsqlDbType.Boolean) { TypedValue = result.Enabled };
                        command.Parameters.Add(parameter);
                    }
                    commandText.Append(@" WHERE (Id = @Id) AND (Revision = @Old_Revision)");

                    command.CommandText = commandText.ToString();

                    {
                        var parameter = new NpgsqlParameter<long>("@Old_Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                AddActualState(typedSession, result);

                if (MappersFeatures.ValidateUpdateResults)
                {
                    var realDto = GetRaw(session, result.Id);
                    var realDtoText = realDto.ToJsonText(true);
                    var resultText = result.ToJsonText(true);
                    if (MappersFeatures.ValidateUpdateAction != null)
                    {
                        if (false == MappersFeatures.ValidateUpdateAction(realDto!, result))
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                    else
                    {
                        if (realDtoText != resultText)
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                }

                return ((IMapperDto)result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnUpdate(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="BulkInsert"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnBulkInsert(IMappersSession session, Exception exception);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        public virtual void BulkInsert(
            IMappersSession session,
            IEnumerable<DemoObjectXDtoNew> data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderDemoObjectX();
                postgreSqlBulkInserter.Insert(typedSession, data);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask BulkInsertAsync(
            IMappersSession session,
            IEnumerable<DemoObjectXDtoNew> data,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderDemoObjectX();
                await postgreSqlBulkInserter.InsertAsync(typedSession, data, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="New"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Новая запись.</param>
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, DemoObjectXDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoObjectXDtoActual New(IMappersSession session, DemoObjectXDtoNew data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new DemoObjectXDtoActual
                {
                    Id = data.Id,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Name = data.Name,
                    Enabled = data.Enabled,
                    Key1 = data.Key1,
                    Key2 = data.Key2,
                    Group = data.Group,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO DemoObjectX
(
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
)
VALUES
(
@Id,
@New_Revision,
@CreateDate,
@ModificationDate,
@Name,
@Enabled,
@Key1,
@Key2,
@Group
)";
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@CreateDate", NpgsqlDbType.TimestampTz) { TypedValue = result.CreateDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@ModificationDate", NpgsqlDbType.TimestampTz) { TypedValue = result.ModificationDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Name", NpgsqlDbType.Varchar, 1024).Value = result.Name;
                    {
                        var parameter = new NpgsqlParameter<bool>(@"@Enabled", NpgsqlDbType.Boolean) { TypedValue = result.Enabled };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<Guid>(@"@Key1", NpgsqlDbType.Uuid) { TypedValue = result.Key1 };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Key2", NpgsqlDbType.Varchar, 10).Value = result.Key2;
                    {
                        var parameter = new NpgsqlParameter<long>(@"@Group", NpgsqlDbType.Bigint) { TypedValue = result.Group };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }

                AddActualState(typedSession, result);

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, DemoObjectXDtoNew data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new DemoObjectXDtoActual
                {
                    Id = data.Id,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Name = data.Name,
                    Enabled = data.Enabled,
                    Key1 = data.Key1,
                    Key2 = data.Key2,
                    Group = data.Group,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO DemoObjectX
(
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
)
VALUES
(
@Id,
@New_Revision,
@CreateDate,
@ModificationDate,
@Name,
@Enabled,
@Key1,
@Key2,
@Group
)";
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@CreateDate", NpgsqlDbType.TimestampTz) { TypedValue = result.CreateDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@ModificationDate", NpgsqlDbType.TimestampTz) { TypedValue = result.ModificationDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Name", NpgsqlDbType.Varchar, 1024).Value = result.Name;
                    {
                        var parameter = new NpgsqlParameter<bool>(@"@Enabled", NpgsqlDbType.Boolean) { TypedValue = result.Enabled };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<Guid>(@"@Key1", NpgsqlDbType.Uuid) { TypedValue = result.Key1 };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Key2", NpgsqlDbType.Varchar, 10).Value = result.Key2;
                    {
                        var parameter = new NpgsqlParameter<long>(@"@Group", NpgsqlDbType.Bigint) { TypedValue = result.Group };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
                        command.Parameters.Add(parameter);
                    }
                    await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }

                AddActualState(typedSession, result);

                return ((IMapperDto)result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Delete"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        partial void CatchExceptionOnDelete(IMappersSession session, Exception exception, DemoObjectXDtoDeleted data);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        public virtual void Delete(IMappersSession session, DemoObjectXDtoDeleted data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                RemoveActualState(typedSession, data.Id);

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE FROM DemoObjectX WHERE (Id = @Id) AND (Revision = @Revision)";
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    var deleteCount = command.ExecuteNonQuery();
                    if (deleteCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при удалении записи с идентификатором '{data.Id}' маппером '{MapperId}'.");
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnDelete(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask DeleteAsync(IMappersSession session, DemoObjectXDtoDeleted data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                RemoveActualState(typedSession, data.Id);

                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE FROM DemoObjectX WHERE (Id = @Id) AND (Revision = @Revision)";
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    var deleteCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (deleteCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при удалении записи с идентификатором '{data.Id}' маппером '{MapperId}'.");
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnDelete(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<IMapperDto> IAbstractMapper.GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter);
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TMapperDto> IAbstractMapper.GetEnumerator<TMapperDto>(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter).Cast<TMapperDto>();
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumerator"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumerator(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoObjectXDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    int indexKey1;
                    int indexKey2;
                    int indexGroup;
                    IPostgreSqlMappersSession typedSession;
                    try
                    {
                        typedSession = (IPostgreSqlMappersSession) session;
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled,
                            out indexKey1,
                            out indexKey2,
                            out indexGroup);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectXDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        AddActualState(typedSession, result);

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorAsGroup"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="argGroup">Номер группы</param>
        partial void CatchExceptionOnGetEnumeratorAsGroup(IMappersSession session, Exception exception, long argGroup);

        /// <summary>
        /// Получить итератор всех записей коллекции 'Группировка по 'Номер группы''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argGroup">Номер группы</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoObjectXDtoActual> GetEnumeratorAsGroup(IMappersSession session, long argGroup)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX WHERE
(""group"" = @Group)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Group", NpgsqlDbType.Bigint) { TypedValue = argGroup };
                        command.Parameters.Add(parameter);
                    }
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorAsGroup(session, exception, argGroup);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    int indexKey1;
                    int indexKey2;
                    int indexGroup;
                    IPostgreSqlMappersSession typedSession;
                    try
                    {
                        typedSession = (IPostgreSqlMappersSession) session;
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled,
                            out indexKey1,
                            out indexKey2,
                            out indexGroup);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorAsGroup(session, exception, argGroup);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectXDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorAsGroup(session, exception, argGroup);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        AddActualState(typedSession, result);

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<DemoObjectXDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    int indexKey1;
                    int indexKey2;
                    int indexGroup;
                    IPostgreSqlMappersSession typedSession;
                    try
                    {
                        typedSession = (IPostgreSqlMappersSession) session;
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled,
                            out indexKey1,
                            out indexKey2,
                            out indexGroup);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectXDtoActual result;
                        try
                        {
                            var hasRecord = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        AddActualState(typedSession, result);

                        yield return (result);
                    }
                }
                finally
                {
                    await reader.SilentDisposeAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                await command.SilentDisposeAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Получить итератор всех записей коллекции 'Группировка по 'Номер группы''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argGroup">Номер группы</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<DemoObjectXDtoActual> GetEnumeratorAsGroupAsync(IMappersSession session, long argGroup, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX WHERE
(""group"" = @Group)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Group", NpgsqlDbType.Bigint) { TypedValue = argGroup };
                        command.Parameters.Add(parameter);
                    }
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorAsGroup(session, exception, argGroup);
                    CatchException(session, exception);

                    var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    int indexKey1;
                    int indexKey2;
                    int indexGroup;
                    IPostgreSqlMappersSession typedSession;
                    try
                    {
                        typedSession = (IPostgreSqlMappersSession) session;
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled,
                            out indexKey1,
                            out indexKey2,
                            out indexGroup);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorAsGroup(session, exception, argGroup);
                        CatchException(session, exception);

                        var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectXDtoActual result;
                        try
                        {
                            var hasRecord = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorAsGroup(session, exception, argGroup);
                            CatchException(session, exception);

                            var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        AddActualState(typedSession, result);

                        yield return (result);
                    }
                }
                finally
                {
                    await reader.SilentDisposeAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                await command.SilentDisposeAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorRaw(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoObjectXDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter)
                    ;
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    int indexKey1;
                    int indexKey2;
                    int indexGroup;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled,
                            out indexKey1,
                            out indexKey2,
                            out indexGroup);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectXDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoObjectXDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Name,
Enabled,
Key1,
Key2,
""group""
FROM DemoObjectX";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexName;
                    int indexEnabled;
                    int indexKey1;
                    int indexKey2;
                    int indexGroup;
                    IPostgreSqlMappersSession typedSession;
                    try
                    {
                        typedSession = (IPostgreSqlMappersSession) session;
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexName,
                            out indexEnabled,
                            out indexKey1,
                            out indexKey2,
                            out indexGroup);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoObjectXDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexName,
                                indexEnabled,
                                indexKey1,
                                indexKey2,
                                indexGroup);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        AddActualState(typedSession, result);

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorIdentitiesPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorIdentitiesPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        public virtual IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id FROM DemoObjectX";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        long item;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }
                            item = reader.GetInt64(indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (item);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetCount"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetCount(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM DemoObjectX";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetCountByGroup"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="argGroup">Номер группы</param>
        partial void CatchExceptionOnGetCountByGroup(IMappersSession session, Exception exception, long argGroup);

        /// <summary>
        /// Получить количество записей коллекции 'Группировка по 'Номер группы''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argGroup">Номер группы</param>
        /// <returns>Возвращает количество записей коллекции.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual long GetCountByGroup(IMappersSession session, long argGroup)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM DemoObjectX WHERE
(""group"" = @Group)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Group", NpgsqlDbType.Bigint) { TypedValue = argGroup };
                        command.Parameters.Add(parameter);
                    }

                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCountByGroup(session, exception, argGroup);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual async ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                await using (var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM DemoObjectX";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
        /// <summary>
        /// Получить количество записей коллекции 'Группировка по 'Номер группы''.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="argGroup">Номер группы</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает количество записей коллекции.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<long> GetCountByGroupAsync(IMappersSession session, long argGroup, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM DemoObjectX WHERE
(""group"" = @Group)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Group", NpgsqlDbType.Bigint) { TypedValue = argGroup };
                        command.Parameters.Add(parameter);
                    }

                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCountByGroup(session, exception, argGroup);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

    }

    /// <summary>
    /// Поточный читатель данных записей для массовой вставки записей в БД.
    /// 
    /// Задача с отложенным запуском
    /// </summary>
    internal class BulkInsertDataReaderDemoDelayTask : BasePostgreSqlBulkInserter<DemoDelayTaskDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, DemoDelayTaskDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Available, NpgsqlDbType.Boolean, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(Constants.StartRevision, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.CreateDate.ToUniversalTime(), NpgsqlDbType.TimestampTz, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.ModificationDate.ToUniversalTime(), NpgsqlDbType.TimestampTz, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Scenario, NpgsqlDbType.Text, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.ScenarioState, NpgsqlDbType.Text, cancellationToken).ConfigureAwait(false);
            {
                if (instance.StartDate.HasValue == false)
                {
                    await binaryImport.WriteNullAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    await binaryImport.WriteAsync(instance.StartDate.Value.ToUniversalTime(), NpgsqlDbType.TimestampTz, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, DemoDelayTaskDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.Available, NpgsqlDbType.Boolean);
            binaryImport.Write(Constants.StartRevision, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.CreateDate.ToUniversalTime(), NpgsqlDbType.TimestampTz);
            binaryImport.Write(instance.ModificationDate.ToUniversalTime(), NpgsqlDbType.TimestampTz);
            binaryImport.Write(instance.Scenario, NpgsqlDbType.Text);
            binaryImport.Write(instance.ScenarioState, NpgsqlDbType.Text);
            {
                if (instance.StartDate.HasValue == false)
                {
                    binaryImport.WriteNull();
                }
                else
                {
                    binaryImport.Write(instance.StartDate.Value.ToUniversalTime(), NpgsqlDbType.TimestampTz);
                }
            }
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY DemoDelayTask (Id,
Available,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Задача с отложенным запуском
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.DemoDelayTask)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperDemoDelayTask : BasePostgreSqlMapper<DemoDelayTaskDtoActual>, IPartitionsMapper, IMapperInitializer, IMapperDemoDelayTask
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperDemoDelayTask(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Задача с отложенным запуском" + "' в БД", WellknownMappers.DemoDelayTask, selectFilterFactory, exceptionPolicy)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"DemoDelayTask", ComplexIdentity.Level.L2, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperDemoDelayTask(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper? infrastructureMonitor = null)
           : base("Маппер данных состояния доменного объекта '" + @"Задача с отложенным запуском" + "' в БД", WellknownMappers.DemoDelayTask, selectFilterFactory, exceptionPolicy, infrastructureMonitor)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"DemoDelayTask", ComplexIdentity.Level.L2, false);
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"DemoDelayTask";

        /// <summary>
        /// Интерфейс управления партициями.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public IPartitionsManager Partitions { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; [MethodImpl(MethodImplOptions.AggressiveInlining)] private set; }

        /// <summary>
        /// Обработка исключения мапппера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchException(IMappersSession session, Exception exception);

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Initialize"/>.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnInitialize(IMappers mappers, Exception exception);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        partial void DoInitialize(IMappers mappers);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        public virtual void Initialize(IMappers mappers)
        {
            if (mappers == null)
            {
                throw new ArgumentNullException(nameof(mappers));
            }
            try
            {
                DoInitialize(mappers);
            }
            catch (Exception exception)
            {

                CatchExceptionOnInitialize(mappers, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextId"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextId(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoDelayTask".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual long GetNextId(IMappersSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_DemoDelayTask');";
                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextIds"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextIds(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_DemoDelayTask".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        public virtual IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                cancellationToken.ThrowIfCancellationRequested();

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_DemoDelayTask') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");

                        var result = new List<long>(count);
                        while (reader.Read())
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            var id = reader.GetInt64(indexId);
                            result.Add(id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextIds(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_DemoDelayTask".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken" >Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual async ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_DemoDelayTask');";
                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Exists"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExists(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// ВАЖНО : Проверка не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует или скрыта.</returns>
        public virtual bool Exists(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoDelayTask WHERE (Id = @Id) AND (Available = @Available) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<bool>("@Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// ВАЖНО : Проверка не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует или скрыта.</returns>
        public virtual async ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoDelayTask WHERE (Id = @Id) AND (Available = @Available) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<bool>("@Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoDelayTask WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM DemoDelayTask WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexAvailable">Индекс колонки 'Available'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexScenario">Индекс колонки 'Scenario'.</param>
        /// <param name="indexScenarioState">Индекс колонки 'ScenarioState'.</param>
        /// <param name="indexStartDate">Индекс колонки 'StartDate'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexAvailable,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexScenario,
            out int indexScenarioState,
            out int indexStartDate)
        {
            indexId = reader.GetOrdinal("Id");
            indexAvailable = reader.GetOrdinal("Available");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexScenario = reader.GetOrdinal("Scenario");
            indexScenarioState = reader.GetOrdinal("ScenarioState");
            indexStartDate = reader.GetOrdinal("StartDate");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexScenario">Индекс колонки 'Scenario'.</param>
        /// <param name="indexScenarioState">Индекс колонки 'ScenarioState'.</param>
        /// <param name="indexStartDate">Индекс колонки 'StartDate'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexScenario,
            out int indexScenarioState,
            out int indexStartDate)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexScenario = reader.GetOrdinal("Scenario");
            indexScenarioState = reader.GetOrdinal("ScenarioState");
            indexStartDate = reader.GetOrdinal("StartDate");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexAvailable">Индекс колонки 'Available'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexScenario">Индекс колонки 'Scenario'.</param>
        /// <param name="indexScenarioState">Индекс колонки 'ScenarioState'.</param>
        /// <param name="indexStartDate">Индекс колонки 'StartDate'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DemoDelayTaskDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexAvailable,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexScenario,
            int indexScenarioState,
            int indexStartDate)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new DemoDelayTaskDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Available = reader.GetBoolean(indexAvailable);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetFieldValue<DateTimeOffset>(indexCreateDate);
            result.ModificationDate = reader.GetFieldValue<DateTimeOffset>(indexModificationDate);
            result.Scenario = reader.GetString(indexScenario);
            result.ScenarioState = reader.GetString(indexScenarioState);
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (reader.IsDBNull(indexStartDate))
            {
                result.StartDate = default!;
            }
            else
            {
                result.StartDate = reader.GetFieldValue<DateTimeOffset>(indexStartDate);
            }

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexScenario">Индекс колонки 'Scenario'.</param>
        /// <param name="indexScenarioState">Индекс колонки 'ScenarioState'.</param>
        /// <param name="indexStartDate">Индекс колонки 'StartDate'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DemoDelayTaskDtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexScenario,
            int indexScenarioState,
            int indexStartDate)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new DemoDelayTaskDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Available = true;
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetFieldValue<DateTimeOffset>(indexCreateDate);
            result.ModificationDate = reader.GetFieldValue<DateTimeOffset>(indexModificationDate);
            result.Scenario = reader.GetString(indexScenario);
            result.ScenarioState = reader.GetString(indexScenarioState);
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (reader.IsDBNull(indexStartDate))
            {
                result.StartDate = default!;
            }
            else
            {
                result.StartDate = reader.GetFieldValue<DateTimeOffset>(indexStartDate);
            }

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует или скрыта.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoDelayTaskDtoActual? Get(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
FROM DemoDelayTask WHERE
(Id = @Id)
AND (Available = @Old_Available)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexScenario,
                                out var indexScenarioState,
                                out var indexStartDate);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexScenario,
                                indexScenarioState,
                                indexStartDate);

                            SeedRevision(result.Revision);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует или скрыта.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto?> GetAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
FROM DemoDelayTask WHERE
(Id = @Id)
AND (Available = @Old_Available)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexScenario,
                                out var indexScenarioState,
                                out var indexStartDate);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexScenario,
                                indexScenarioState,
                                indexStartDate);

                            SeedRevision(result.Revision);

                            return ((IMapperDto)result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGetRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoDelayTaskDtoActual? GetRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Available,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
FROM DemoDelayTask WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexAvailable,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexScenario,
                                out var indexScenarioState,
                                out var indexStartDate);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexAvailable,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexScenario,
                                indexScenarioState,
                                indexStartDate);

                            SeedRevision(result.Revision);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<DemoDelayTaskDtoActual?> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Available,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
FROM DemoDelayTask WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexAvailable,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexScenario,
                                out var indexScenarioState,
                                out var indexStartDate);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexAvailable,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexScenario,
                                indexScenarioState,
                                indexStartDate);

                            SeedRevision(result.Revision);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Update"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Измененная запись.</param>
        partial void CatchExceptionOnUpdate(IMappersSession session, Exception exception, DemoDelayTaskDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual DemoDelayTaskDtoActual Update(IMappersSession session, DemoDelayTaskDtoChanged data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var result =
                new DemoDelayTaskDtoActual
                {
                    Id = data.Id,
                    Available = data.Available,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Scenario = data.Scenario,
                    ScenarioState = data.ScenarioState,
                    StartDate = data.StartDate,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE DemoDelayTask SET
Revision = @New_Revision,
Available = @New_Available,
ModificationDate = @ModificationDate,
ScenarioState = @ScenarioState,
StartDate = @StartDate
WHERE
(Id = @Id) AND (Revision < @New_Revision)
AND (Available = @Old_Available)";
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>("@ModificationDate", NpgsqlDbType.TimestampTz) { TypedValue = result.ModificationDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add("@ScenarioState", NpgsqlDbType.Text).Value = result.ScenarioState;
                    if (result.StartDate == null)
                    {
                        command.Parameters.Add("@StartDate", NpgsqlDbType.TimestampTz).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@StartDate", NpgsqlDbType.TimestampTz).Value = result.StartDate.Value.ToUniversalTime();
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@New_Available", NpgsqlDbType.Boolean) { TypedValue = result.Available };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = command.ExecuteNonQuery();
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                if (MappersFeatures.ValidateUpdateResults)
                {
                    var realDto = GetRaw(session, result.Id);
                    var realDtoText = realDto.ToJsonText(true);
                    var resultText = result.ToJsonText(true);
                    if (MappersFeatures.ValidateUpdateAction != null)
                    {
                        if (false == MappersFeatures.ValidateUpdateAction(realDto!, result))
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                    else
                    {
                        if (realDtoText != resultText)
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnUpdate(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обновить запись.
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual async ValueTask<IMapperDto> UpdateAsync(IMappersSession session, DemoDelayTaskDtoChanged data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var result =
                new DemoDelayTaskDtoActual
                {
                    Id = data.Id,
                    Available = data.Available,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Scenario = data.Scenario,
                    ScenarioState = data.ScenarioState,
                    StartDate = data.StartDate,
                };

                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE DemoDelayTask SET
Revision = @New_Revision,
Available = @New_Available,
ModificationDate = @ModificationDate,
ScenarioState = @ScenarioState,
StartDate = @StartDate
WHERE
(Id = @Id) AND (Revision < @New_Revision)
AND (Available = @Old_Available)";
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>("@ModificationDate", NpgsqlDbType.TimestampTz) { TypedValue = result.ModificationDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add("@ScenarioState", NpgsqlDbType.Text).Value = result.ScenarioState;
                    if (result.StartDate == null)
                    {
                        command.Parameters.Add("@StartDate", NpgsqlDbType.TimestampTz).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@StartDate", NpgsqlDbType.TimestampTz).Value = result.StartDate.Value.ToUniversalTime();
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@New_Available", NpgsqlDbType.Boolean) { TypedValue = result.Available };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                if (MappersFeatures.ValidateUpdateResults)
                {
                    var realDto = GetRaw(session, result.Id);
                    var realDtoText = realDto.ToJsonText(true);
                    var resultText = result.ToJsonText(true);
                    if (MappersFeatures.ValidateUpdateAction != null)
                    {
                        if (false == MappersFeatures.ValidateUpdateAction(realDto!, result))
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                    else
                    {
                        if (realDtoText != resultText)
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                }

                return ((IMapperDto)result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnUpdate(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="BulkInsert"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnBulkInsert(IMappersSession session, Exception exception);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        public virtual void BulkInsert(
            IMappersSession session,
            IEnumerable<DemoDelayTaskDtoNew> data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderDemoDelayTask();
                postgreSqlBulkInserter.Insert(typedSession, data);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask BulkInsertAsync(
            IMappersSession session,
            IEnumerable<DemoDelayTaskDtoNew> data,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderDemoDelayTask();
                await postgreSqlBulkInserter.InsertAsync(typedSession, data, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="New"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Новая запись.</param>
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, DemoDelayTaskDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DemoDelayTaskDtoActual New(IMappersSession session, DemoDelayTaskDtoNew data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new DemoDelayTaskDtoActual
                {
                    Id = data.Id,
                    Available = data.Available,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Scenario = data.Scenario,
                    ScenarioState = data.ScenarioState,
                    StartDate = data.StartDate,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO DemoDelayTask
(
Id,
Available,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
)
VALUES
(
@Id,
@New_Available,
@New_Revision,
@CreateDate,
@ModificationDate,
@Scenario,
@ScenarioState,
@StartDate
)";
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@CreateDate", NpgsqlDbType.TimestampTz) { TypedValue = result.CreateDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@ModificationDate", NpgsqlDbType.TimestampTz) { TypedValue = result.ModificationDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Scenario", NpgsqlDbType.Text).Value = result.Scenario;
                    command.Parameters.Add(@"@ScenarioState", NpgsqlDbType.Text).Value = result.ScenarioState;
                    if (result.StartDate == null)
                    {
                        command.Parameters.Add("@StartDate", NpgsqlDbType.TimestampTz).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add(@"@StartDate", NpgsqlDbType.TimestampTz).Value = result.StartDate.Value.ToUniversalTime();
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@New_Available", NpgsqlDbType.Boolean) { TypedValue = result.Available };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, DemoDelayTaskDtoNew data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new DemoDelayTaskDtoActual
                {
                    Id = data.Id,
                    Available = data.Available,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Scenario = data.Scenario,
                    ScenarioState = data.ScenarioState,
                    StartDate = data.StartDate,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO DemoDelayTask
(
Id,
Available,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
)
VALUES
(
@Id,
@New_Available,
@New_Revision,
@CreateDate,
@ModificationDate,
@Scenario,
@ScenarioState,
@StartDate
)";
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@CreateDate", NpgsqlDbType.TimestampTz) { TypedValue = result.CreateDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTimeOffset>(@"@ModificationDate", NpgsqlDbType.TimestampTz) { TypedValue = result.ModificationDate.ToUniversalTime() };
                        command.Parameters.Add(parameter);
                    }
                    command.Parameters.Add(@"@Scenario", NpgsqlDbType.Text).Value = result.Scenario;
                    command.Parameters.Add(@"@ScenarioState", NpgsqlDbType.Text).Value = result.ScenarioState;
                    if (result.StartDate == null)
                    {
                        command.Parameters.Add("@StartDate", NpgsqlDbType.TimestampTz).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add(@"@StartDate", NpgsqlDbType.TimestampTz).Value = result.StartDate.Value.ToUniversalTime();
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@New_Available", NpgsqlDbType.Boolean) { TypedValue = result.Available };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
                        command.Parameters.Add(parameter);
                    }
                    await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }

                return ((IMapperDto)result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        IEnumerable<IMapperDto> IAbstractMapper.GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter);
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        IEnumerable<TMapperDto> IAbstractMapper.GetEnumerator<TMapperDto>(IMappersSession session, IMapperSelectFilter? selectFilter)
        {
            return GetEnumerator(session, selectFilter).Cast<TMapperDto>();
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumerator"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumerator(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoDelayTaskDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
FROM DemoDelayTask";
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        @"(Available = @Old_Available)",
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexScenario;
                    int indexScenarioState;
                    int indexStartDate;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexScenario,
                            out indexScenarioState,
                            out indexStartDate);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoDelayTaskDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexScenario,
                                indexScenarioState,
                                indexStartDate);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<DemoDelayTaskDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
FROM DemoDelayTask";
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        @"(Available = @Old_Available)",
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexScenario;
                    int indexScenarioState;
                    int indexStartDate;
                    try
                    {
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexScenario,
                            out indexScenarioState,
                            out indexStartDate);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoDelayTaskDtoActual result;
                        try
                        {
                            var hasRecord = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexScenario,
                                indexScenarioState,
                                indexStartDate);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    await reader.SilentDisposeAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                await command.SilentDisposeAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorRaw(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoDelayTaskDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Available,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
FROM DemoDelayTask";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        selectFilter as IPostgreSqlMapperSelectFilter)
                    ;
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexAvailable;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexScenario;
                    int indexScenarioState;
                    int indexStartDate;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId,
                            out indexAvailable,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexScenario,
                            out indexScenarioState,
                            out indexStartDate);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoDelayTaskDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = ReadRaw(
                                reader,
                                indexId,
                                indexAvailable,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexScenario,
                                indexScenarioState,
                                indexStartDate);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<DemoDelayTaskDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Scenario,
ScenarioState,
StartDate
FROM DemoDelayTask";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        @"(Available = @Old_Available)",
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexScenario;
                    int indexScenarioState;
                    int indexStartDate;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexScenario,
                            out indexScenarioState,
                            out indexStartDate);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DemoDelayTaskDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexScenario,
                                indexScenarioState,
                                indexStartDate);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorIdentitiesPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorIdentitiesPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей кроме скрытых записей.</returns>
        public virtual IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null!;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id FROM DemoDelayTask";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        @"(Available = @Old_Available)",
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        selectFilter as IPostgreSqlMapperSelectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null!;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        long item;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }
                            item = reader.GetInt64(indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (item);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetCount"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetCount(IMappersSession session, Exception exception, IMapperSelectFilter? selectFilter);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки кроме скрытых записей.</returns>
        public virtual long GetCount(IMappersSession session, IMapperSelectFilter? selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM DemoDelayTask";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), @"(Available = @Available)");
                    {
                        var parameter = new NpgsqlParameter<bool>("@Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    var temp = command.ExecuteScalar();
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки кроме скрытых записей.</returns>
        public virtual async ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter? selectFilter = null, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                await using (var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM DemoDelayTask";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), @"(Available = @Available)");
                    {
                        var parameter = new NpgsqlParameter<bool>("@Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    var result = (long)temp!;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
    }

}
