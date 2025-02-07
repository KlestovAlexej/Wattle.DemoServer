/*
* Файл создан автоматически. Не редактировать вручную.
*
* Тесты реализаций мапперов.
*
* Генератор - Acme.Wattle.CodeGeneration.Generators.Mappers.PostgreSqlMappersTestsCodeGenerator
*
*/
// ReSharper disable RedundantUsingDirective
using System;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using NpgsqlTypes;
using Newtonsoft.Json;
using NUnit.Framework;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Utils;
using Acme.Wattle.DomainObjects.Common;
using Acme.Wattle.Mappers;
using Acme.Wattle.Mappers.PostgreSql;
using Acme.Wattle.Testing;
using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.CodeGeneration.Generators;
using Acme.Wattle.Common.Interfaces;
using Acme.DemoServer.Processing.Generated.Interface;
using __Mappers = Acme.DemoServer.Processing.Generated.PostgreSql.Implements.Mappers;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace Acme.DemoServer.Processing.Generated.Tests
{
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMappersContext : BaseAutoTestsMappersContext
    {
        /// <summary>
        /// Объект тестовой среды.
        /// Контроль изменений
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected ChangeTrackerDtoActual m_changeTrackerDtoActual;

        /// <summary>
        /// Признак процесса создания объекта тестовой среды.
        /// Контроль изменений
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected bool m_initChangeTrackerDtoActual;

        /// <summary>
        /// Объект тестовой среды.
        /// Системный лог
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected SystemLogDtoActual m_systemLogDtoActual;

        /// <summary>
        /// Признак процесса создания объекта тестовой среды.
        /// Системный лог
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected bool m_initSystemLogDtoActual;

        /// <summary>
        /// Объект тестовой среды.
        /// Партиция таблицы БД
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected TablePartitionDtoActual m_tablePartitionDtoActual;

        /// <summary>
        /// Признак процесса создания объекта тестовой среды.
        /// Партиция таблицы БД
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected bool m_initTablePartitionDtoActual;

        /// <summary>
        /// Объект тестовой среды.
        /// Объект
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected DemoObjectDtoActual m_demoObjectDtoActual;

        /// <summary>
        /// Признак процесса создания объекта тестовой среды.
        /// Объект
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected bool m_initDemoObjectDtoActual;

        /// <summary>
        /// Объект тестовой среды.
        /// Объект X
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected DemoObjectXDtoActual m_demoObjectXDtoActual;

        /// <summary>
        /// Признак процесса создания объекта тестовой среды.
        /// Объект X
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected bool m_initDemoObjectXDtoActual;

        /// <summary>
        /// Объект тестовой среды.
        /// Задача с отложенным запуском
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected DemoDelayTaskDtoActual m_demoDelayTaskDtoActual;

        /// <summary>
        /// Признак процесса создания объекта тестовой среды.
        /// Задача с отложенным запуском
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected bool m_initDemoDelayTaskDtoActual;

        public AutoTestsMappersContext(IMappers mappers) : base(mappers)
        {
            /* NONE */
        }

        /// <summary>
        /// Cтратегия обработки параметров создания объекта тестовой среды.
        /// Контроль изменений
        /// </summary>
        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNewChangeTrackerDtoNew(ChangeTrackerDtoNew dto, AutoTestsMappersContext context);

        /// <summary>
        /// Получение/Установка объекта тестовой среды.
        /// Контроль изменений
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public virtual ChangeTrackerDtoActual ChangeTrackerDtoActual
        {
            get
            {
                lock (m_lockObject)
                {
                    if (m_initChangeTrackerDtoActual)
                    {
                        throw new InvalidOperationException("Рекуcия для 'ChangeTrackerDtoActual'.");
                    }

                    m_initChangeTrackerDtoActual = true;
                    try
                    {
                        if (m_changeTrackerDtoActual == null)
                        {
                            var dtoNew = AutoTestsMapperChangeTracker.GetRandomNew(this);
                            DoGetRandomNewChangeTrackerDtoNew(dtoNew, this);
                            // ReSharper disable once ConvertToUsingDeclaration
                            using (var session = Mappers.OpenSession())
                            {
                                var mapper = Mappers.GetMapper<IMapperChangeTracker>();
                                m_changeTrackerDtoActual = mapper.New(session, dtoNew);
                                
                                session.Commit();
                            }
                        }

                        return (m_changeTrackerDtoActual);
                    }
                    finally
                    {
                        m_initChangeTrackerDtoActual = false;
                    }
                }
            }
            set
            {
                lock (m_lockObject)
                {
                    m_changeTrackerDtoActual = value;
                }
            }
        }

        /// <summary>
        /// Cтратегия обработки параметров создания объекта тестовой среды.
        /// Системный лог
        /// </summary>
        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNewSystemLogDtoNew(SystemLogDtoNew dto, AutoTestsMappersContext context);

        /// <summary>
        /// Получение/Установка объекта тестовой среды.
        /// Системный лог
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public virtual SystemLogDtoActual SystemLogDtoActual
        {
            get
            {
                lock (m_lockObject)
                {
                    if (m_initSystemLogDtoActual)
                    {
                        throw new InvalidOperationException("Рекуcия для 'SystemLogDtoActual'.");
                    }

                    m_initSystemLogDtoActual = true;
                    try
                    {
                        if (m_systemLogDtoActual == null)
                        {
                            var dtoNew = AutoTestsMapperSystemLog.GetRandomNew(this);
                            DoGetRandomNewSystemLogDtoNew(dtoNew, this);
                            // ReSharper disable once ConvertToUsingDeclaration
                            using (var session = Mappers.OpenSession())
                            {
                                var mapper = Mappers.GetMapper<IMapperSystemLog>();
                                m_systemLogDtoActual = mapper.New(session, dtoNew);
                                
                                session.Commit();
                            }
                        }

                        return (m_systemLogDtoActual);
                    }
                    finally
                    {
                        m_initSystemLogDtoActual = false;
                    }
                }
            }
            set
            {
                lock (m_lockObject)
                {
                    m_systemLogDtoActual = value;
                }
            }
        }

        /// <summary>
        /// Cтратегия обработки параметров создания объекта тестовой среды.
        /// Партиция таблицы БД
        /// </summary>
        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNewTablePartitionDtoNew(TablePartitionDtoNew dto, AutoTestsMappersContext context);

        /// <summary>
        /// Получение/Установка объекта тестовой среды.
        /// Партиция таблицы БД
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public virtual TablePartitionDtoActual TablePartitionDtoActual
        {
            get
            {
                lock (m_lockObject)
                {
                    if (m_initTablePartitionDtoActual)
                    {
                        throw new InvalidOperationException("Рекуcия для 'TablePartitionDtoActual'.");
                    }

                    m_initTablePartitionDtoActual = true;
                    try
                    {
                        if (m_tablePartitionDtoActual == null)
                        {
                            var dtoNew = AutoTestsMapperTablePartition.GetRandomNew(this);
                            DoGetRandomNewTablePartitionDtoNew(dtoNew, this);
                            // ReSharper disable once ConvertToUsingDeclaration
                            using (var session = Mappers.OpenSession())
                            {
                                var mapper = Mappers.GetMapper<IMapperTablePartition>();
                                m_tablePartitionDtoActual = mapper.New(session, dtoNew);
                                
                                session.Commit();
                            }
                        }

                        return (m_tablePartitionDtoActual);
                    }
                    finally
                    {
                        m_initTablePartitionDtoActual = false;
                    }
                }
            }
            set
            {
                lock (m_lockObject)
                {
                    m_tablePartitionDtoActual = value;
                }
            }
        }

        /// <summary>
        /// Cтратегия обработки параметров создания объекта тестовой среды.
        /// Объект
        /// </summary>
        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNewDemoObjectDtoNew(DemoObjectDtoNew dto, AutoTestsMappersContext context);

        /// <summary>
        /// Получение/Установка объекта тестовой среды.
        /// Объект
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public virtual DemoObjectDtoActual DemoObjectDtoActual
        {
            get
            {
                lock (m_lockObject)
                {
                    if (m_initDemoObjectDtoActual)
                    {
                        throw new InvalidOperationException("Рекуcия для 'DemoObjectDtoActual'.");
                    }

                    m_initDemoObjectDtoActual = true;
                    try
                    {
                        if (m_demoObjectDtoActual == null)
                        {
                            var dtoNew = AutoTestsMapperDemoObject.GetRandomNew(this);
                            DoGetRandomNewDemoObjectDtoNew(dtoNew, this);
                            // ReSharper disable once ConvertToUsingDeclaration
                            using (var session = Mappers.OpenSession())
                            {
                                var mapper = Mappers.GetMapper<IMapperDemoObject>();
                                m_demoObjectDtoActual = mapper.New(session, dtoNew);
                                
                                session.Commit();
                            }
                        }

                        return (m_demoObjectDtoActual);
                    }
                    finally
                    {
                        m_initDemoObjectDtoActual = false;
                    }
                }
            }
            set
            {
                lock (m_lockObject)
                {
                    m_demoObjectDtoActual = value;
                }
            }
        }

        /// <summary>
        /// Cтратегия обработки параметров создания объекта тестовой среды.
        /// Объект X
        /// </summary>
        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNewDemoObjectXDtoNew(DemoObjectXDtoNew dto, AutoTestsMappersContext context);

        /// <summary>
        /// Получение/Установка объекта тестовой среды.
        /// Объект X
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public virtual DemoObjectXDtoActual DemoObjectXDtoActual
        {
            get
            {
                lock (m_lockObject)
                {
                    if (m_initDemoObjectXDtoActual)
                    {
                        throw new InvalidOperationException("Рекуcия для 'DemoObjectXDtoActual'.");
                    }

                    m_initDemoObjectXDtoActual = true;
                    try
                    {
                        if (m_demoObjectXDtoActual == null)
                        {
                            var dtoNew = AutoTestsMapperDemoObjectX.GetRandomNew(this);
                            DoGetRandomNewDemoObjectXDtoNew(dtoNew, this);
                            // ReSharper disable once ConvertToUsingDeclaration
                            using (var session = Mappers.OpenSession())
                            {
                                var mapper = Mappers.GetMapper<IMapperDemoObjectX>();
                                m_demoObjectXDtoActual = mapper.New(session, dtoNew);
                                
                                session.Commit();
                            }
                        }

                        return (m_demoObjectXDtoActual);
                    }
                    finally
                    {
                        m_initDemoObjectXDtoActual = false;
                    }
                }
            }
            set
            {
                lock (m_lockObject)
                {
                    m_demoObjectXDtoActual = value;
                }
            }
        }

        /// <summary>
        /// Cтратегия обработки параметров создания объекта тестовой среды.
        /// Задача с отложенным запуском
        /// </summary>
        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNewDemoDelayTaskDtoNew(DemoDelayTaskDtoNew dto, AutoTestsMappersContext context);

        /// <summary>
        /// Получение/Установка объекта тестовой среды.
        /// Задача с отложенным запуском
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public virtual DemoDelayTaskDtoActual DemoDelayTaskDtoActual
        {
            get
            {
                lock (m_lockObject)
                {
                    if (m_initDemoDelayTaskDtoActual)
                    {
                        throw new InvalidOperationException("Рекуcия для 'DemoDelayTaskDtoActual'.");
                    }

                    m_initDemoDelayTaskDtoActual = true;
                    try
                    {
                        if (m_demoDelayTaskDtoActual == null)
                        {
                            var dtoNew = AutoTestsMapperDemoDelayTask.GetRandomNew(this);
                            DoGetRandomNewDemoDelayTaskDtoNew(dtoNew, this);
                            // ReSharper disable once ConvertToUsingDeclaration
                            using (var session = Mappers.OpenSession())
                            {
                                var mapper = Mappers.GetMapper<IMapperDemoDelayTask>();
                                m_demoDelayTaskDtoActual = mapper.New(session, dtoNew);
                                
                                session.Commit();
                            }
                        }

                        return (m_demoDelayTaskDtoActual);
                    }
                    finally
                    {
                        m_initDemoDelayTaskDtoActual = false;
                    }
                }
            }
            set
            {
                lock (m_lockObject)
                {
                    m_demoDelayTaskDtoActual = value;
                }
            }
        }

    }

    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class BaseAutoTestsMapper
    {
        // ReSharper disable once UnusedMember.Global
        public static readonly ThreadLocal<Random> Random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

        protected IMappers m_mappers;
        protected string m_dbConnectionString;
        protected IMappersExceptionPolicy m_mappersExceptionPolicy;
        protected ITimeService m_timeService;
        protected object m_context;
        protected object m_contextMappers;

        [SetUp]
        public void Base_SetUp()
        {
            DoBase_BeginSetUp();
            if (m_timeService == null)
            {
                m_timeService = new TimeService();
            }
            if (m_mappersExceptionPolicy == null)
            {
                m_mappersExceptionPolicy = new MappersExceptionPolicy();
            }
            if (m_mappers == null)
            {
                m_mappers = new __Mappers(m_mappersExceptionPolicy, m_dbConnectionString, m_timeService, WellknownInfrastructureMonitors.Mappers, WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers), WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers), context: m_contextMappers);
            }
            (m_mappers as IMappersInitializer)?.Initialize();
            if (m_context == null)
            {
                m_context = new AutoTestsMappersContext(m_mappers);
            }
            DoBase_EndSetUp();
        }

        [TearDown]
        public void Base_TearDown()
        {
            DoBase_TearDown();
            (m_context as IDisposable).SilentDispose();
            m_context = null;
            m_mappers.SilentDispose();
            m_mappers = null;
            m_mappersExceptionPolicy.SilentDispose();
            m_mappersExceptionPolicy = null;
            m_timeService.SilentDispose();
            m_timeService = null;
        }

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoBase_BeginSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoBase_EndSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoBase_TearDown();
    }

    /// <summary>
    /// Контроль изменений
    /// </summary>
    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMapperChangeTracker : BaseAutoTestsMapper
    {
        #region Private Class PostgreSqlColumnInfo

        private class PostgreSqlColumnInfo
        {
            public string ColumnName;
            public bool IsNullable;
            public int? MaxLength;
        }

        #endregion

        protected string m_tableName;
        protected IMapperChangeTracker m_mapper;

        [SetUp]
        public void SetUp()
        {
            m_mapper = (IMapperChangeTracker) m_mappers.GetMapper(WellknownMappers.ChangeTracker);
            m_tableName = "changetracker";
            DoSetUp();

            {
                var partitions = ((IPartitionsMapper)m_mapper).Partitions;
                using var session = m_mappers.OpenSession();
                if (false == partitions.GetHasDefaultPartition(session))
                {
                    partitions.CreatedDefaultPartition(session);
                    session.Commit();
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            DoTearDown();
        }

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNew(ChangeTrackerDtoNew dto, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoBulkInsert(List<ChangeTrackerDtoNew> dtos, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(ChangeTrackerDtoNew expected, ChangeTrackerDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(ChangeTrackerDtoActual expected, ChangeTrackerDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTearDown();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTest_New_Get();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoValidate_Columns(Dictionary<string, PostgreSqlColumnInfo> columns);

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(20)]
        [Description("Массовая вставка записей")]
        public void Test_BulkInsert(int size)
        {
            var templates = new List<ChangeTrackerDtoNew>();
            for (var i = 0; i < size; i++)
            {
                var template = GetRandomNew(m_context);
                template.Id = i + 1;
                templates.Add(template);
            }

            DoBulkInsert(templates, m_context);

            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                m_mapper.BulkInsert(session, templates);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                foreach (var template in templates)
                {
                    var data = m_mapper.Get(mappersSession, template.Id);
                    AssertAreEqual(template, data, m_context);
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Создание и Получение")]
        public void Test_New_Get()
        {
            DoTest_New_Get();

            var template = GetRandomNew(m_context);
            ChangeTrackerDtoActual dataNew;
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                dataNew = m_mapper.New(session, template);
                AssertAreEqual(template, dataNew, m_context);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                var data = m_mapper.Get(mappersSession, template.Id);
                AssertAreEqual(template, data, m_context);
                AssertAreEqual(dataNew, data, m_context);
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Получение следующего значения идентити из последовательности")]
        public void Test_GetNextId()
        {
            long baseValue;
            using (var session = m_mappers.OpenSession())
            {
                baseValue = m_mapper.GetNextId(session);
            }

            for (var i = 0; i < 3; i++)
            {
                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 1 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 2 + i * 4, m_mapper.GetNextId(session));
                }

                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 3 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 4 + i * 4, m_mapper.GetNextId(session));

                    session.Commit();
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Проверка совпадения колонок маппера с реальной БД")]
        public void Test_Validate_Columns()
        {
            var columns = new Dictionary<string, PostgreSqlColumnInfo>();
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = (IPostgreSqlMappersSession) m_mappers.OpenSession())
            {
                using (var command = session.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{m_tableName}'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var indexMaxLength = reader.GetOrdinal(@"character_maximum_length");
                            var columnInfo =
                                new PostgreSqlColumnInfo
                                {
                                    ColumnName = reader.GetString(reader.GetOrdinal(@"column_name")),
                                    IsNullable = (reader.GetString(reader.GetOrdinal(@"is_nullable")) == @"YES"),
                                    MaxLength = reader.IsDBNull(indexMaxLength) ? (int?) null : reader.GetInt32(indexMaxLength),
                                };
                            columns.Add(columnInfo.ColumnName, columnInfo);
                        }
                    }
                }
            }

            DoValidate_Columns(columns);

            var columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";

            #region Id

            {
                Assert.IsTrue(columns.ContainsKey(@"id"), @"Id" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"id"];
                columns.Remove(@"id");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";
            Assert.AreEqual(0, columns.Count, columnsText);
        }

        public static ChangeTrackerDtoNew GetRandomNew(object context)
        {
            var result = new ChangeTrackerDtoNew
            {
                Id = long.MinValue,
            };

            DoGetRandomNew(result, context);

            return (result);
        }

        public static void AssertAreEqual(ChangeTrackerDtoNew expected, ChangeTrackerDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);


            DoAssertAreEqual(expected, actual, context);
        }

        public static void AssertAreEqual(ChangeTrackerDtoActual expected, ChangeTrackerDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);


            DoAssertAreEqual(expected, actual, context);
        }
    }

    /// <summary>
    /// Системный лог
    /// </summary>
    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMapperSystemLog : BaseAutoTestsMapper
    {
        #region Private Class PostgreSqlColumnInfo

        private class PostgreSqlColumnInfo
        {
            public string ColumnName;
            public bool IsNullable;
            public int? MaxLength;
        }

        #endregion

        protected string m_tableName;
        protected IMapperSystemLog m_mapper;

        [SetUp]
        public void SetUp()
        {
            m_mapper = (IMapperSystemLog) m_mappers.GetMapper(WellknownMappers.SystemLog);
            m_tableName = "systemlog";
            DoSetUp();

            {
                var partitions = ((IPartitionsMapper)m_mapper).Partitions;
                using var session = m_mappers.OpenSession();
                if (false == partitions.GetHasDefaultPartition(session))
                {
                    partitions.CreatedDefaultPartition(session);
                    session.Commit();
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            DoTearDown();
        }

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNew(SystemLogDtoNew dto, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoBulkInsert(List<SystemLogDtoNew> dtos, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(SystemLogDtoNew expected, SystemLogDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(SystemLogDtoActual expected, SystemLogDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTearDown();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTest_New_Get();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoValidate_Columns(Dictionary<string, PostgreSqlColumnInfo> columns);

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(20)]
        [Description("Массовая вставка записей")]
        public void Test_BulkInsert(int size)
        {
            var templates = new List<SystemLogDtoNew>();
            for (var i = 0; i < size; i++)
            {
                var template = GetRandomNew(m_context);
                template.Id = i + 1;
                templates.Add(template);
            }

            DoBulkInsert(templates, m_context);

            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                m_mapper.BulkInsert(session, templates);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                foreach (var template in templates)
                {
                    var data = m_mapper.Get(mappersSession, template.Id);
                    AssertAreEqual(template, data, m_context);
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Создание и Получение")]
        public void Test_New_Get()
        {
            DoTest_New_Get();

            var template = GetRandomNew(m_context);
            SystemLogDtoActual dataNew;
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                dataNew = m_mapper.New(session, template);
                AssertAreEqual(template, dataNew, m_context);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                var data = m_mapper.Get(mappersSession, template.Id);
                AssertAreEqual(template, data, m_context);
                AssertAreEqual(dataNew, data, m_context);
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Получение следующего значения идентити из последовательности")]
        public void Test_GetNextId()
        {
            long baseValue;
            using (var session = m_mappers.OpenSession())
            {
                baseValue = m_mapper.GetNextId(session);
            }

            for (var i = 0; i < 3; i++)
            {
                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 1 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 2 + i * 4, m_mapper.GetNextId(session));
                }

                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 3 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 4 + i * 4, m_mapper.GetNextId(session));

                    session.Commit();
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Проверка совпадения колонок маппера с реальной БД")]
        public void Test_Validate_Columns()
        {
            var columns = new Dictionary<string, PostgreSqlColumnInfo>();
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = (IPostgreSqlMappersSession) m_mappers.OpenSession())
            {
                using (var command = session.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{m_tableName}'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var indexMaxLength = reader.GetOrdinal(@"character_maximum_length");
                            var columnInfo =
                                new PostgreSqlColumnInfo
                                {
                                    ColumnName = reader.GetString(reader.GetOrdinal(@"column_name")),
                                    IsNullable = (reader.GetString(reader.GetOrdinal(@"is_nullable")) == @"YES"),
                                    MaxLength = reader.IsDBNull(indexMaxLength) ? (int?) null : reader.GetInt32(indexMaxLength),
                                };
                            columns.Add(columnInfo.ColumnName, columnInfo);
                        }
                    }
                }
            }

            DoValidate_Columns(columns);

            var columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";

            #region CreateDate

            {
                Assert.IsTrue(columns.ContainsKey(@"createdate"), @"CreateDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"createdate"];
                columns.Remove(@"createdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Code

            {
                Assert.IsTrue(columns.ContainsKey(@"code"), @"Code" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"code"];
                columns.Remove(@"code");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Type

            {
                Assert.IsTrue(columns.ContainsKey(@"type"), @"Type" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"type"];
                columns.Remove(@"type");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Message

            {
                Assert.IsTrue(columns.ContainsKey(@"message"), @"Message" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"message"];
                columns.Remove(@"message");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNotNull(columnInfo.MaxLength, columnsText);
                Assert.AreEqual(1024, columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Data

            {
                Assert.IsTrue(columns.ContainsKey(@"data"), @"Data" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"data"];
                columns.Remove(@"data");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Id

            {
                Assert.IsTrue(columns.ContainsKey(@"id"), @"Id" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"id"];
                columns.Remove(@"id");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";
            Assert.AreEqual(0, columns.Count, columnsText);
        }

        public static SystemLogDtoNew GetRandomNew(object context)
        {
            var result = new SystemLogDtoNew
            {
                Id = long.MinValue,
                CreateDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTimeOffset>(LocalNpgsqlDbType.TimestampTz),
                Code = PostgreSqlRandomValuesProvider.GetRandomValue<int>(LocalNpgsqlDbType.Integer),
                Type = PostgreSqlRandomValuesProvider.GetRandomValue<int>(LocalNpgsqlDbType.Integer),
                Message = PostgreSqlRandomValuesProvider.GetRandomValue<string>(LocalNpgsqlDbType.Varchar, size: 1024),
                Data = PostgreSqlRandomValuesProvider.GetRandomValue<string>(LocalNpgsqlDbType.Text),
            };

            DoGetRandomNew(result, context);

            return (result);
        }

        public static void AssertAreEqual(SystemLogDtoNew expected, SystemLogDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.Code, actual.Code);
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);

            DoAssertAreEqual(expected, actual, context);
        }

        public static void AssertAreEqual(SystemLogDtoActual expected, SystemLogDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.Code, actual.Code);
            Assert.AreEqual(expected.Type, actual.Type);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Data, actual.Data);

            DoAssertAreEqual(expected, actual, context);
        }
    }

    /// <summary>
    /// Партиция таблицы БД
    /// </summary>
    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMapperTablePartition : BaseAutoTestsMapper
    {
        #region Private Class PostgreSqlColumnInfo

        private class PostgreSqlColumnInfo
        {
            public string ColumnName;
            public bool IsNullable;
            public int? MaxLength;
        }

        #endregion

        protected string m_tableName;
        protected IMapperTablePartition m_mapper;

        [SetUp]
        public void SetUp()
        {
            m_mapper = (IMapperTablePartition) m_mappers.GetMapper(WellknownMappers.TablePartition);
            m_tableName = "tablepartition";
            DoSetUp();

            {
                var partitions = ((IPartitionsMapper)m_mapper).Partitions;
                using var session = m_mappers.OpenSession();
                if (false == partitions.GetHasDefaultPartition(session))
                {
                    partitions.CreatedDefaultPartition(session);
                    session.Commit();
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            DoTearDown();
        }

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNew(TablePartitionDtoNew dto, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoBulkInsert(List<TablePartitionDtoNew> dtos, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(TablePartitionDtoNew expected, TablePartitionDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(TablePartitionDtoActual expected, TablePartitionDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTearDown();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTest_New_Get();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoValidate_Columns(Dictionary<string, PostgreSqlColumnInfo> columns);

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(20)]
        [Description("Массовая вставка записей")]
        public void Test_BulkInsert(int size)
        {
            var templates = new List<TablePartitionDtoNew>();
            for (var i = 0; i < size; i++)
            {
                var template = GetRandomNew(m_context);
                template.Id = i + 1;
                templates.Add(template);
            }

            DoBulkInsert(templates, m_context);

            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                m_mapper.BulkInsert(session, templates);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                foreach (var template in templates)
                {
                    var data = m_mapper.Get(mappersSession, template.Id);
                    AssertAreEqual(template, data, m_context);
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Создание и Получение")]
        public void Test_New_Get()
        {
            DoTest_New_Get();

            var template = GetRandomNew(m_context);
            TablePartitionDtoActual dataNew;
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                dataNew = m_mapper.New(session, template);
                AssertAreEqual(template, dataNew, m_context);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                var data = m_mapper.Get(mappersSession, template.Id);
                AssertAreEqual(template, data, m_context);
                AssertAreEqual(dataNew, data, m_context);
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Получение следующего значения идентити из последовательности")]
        public void Test_GetNextId()
        {
            long baseValue;
            using (var session = m_mappers.OpenSession())
            {
                baseValue = m_mapper.GetNextId(session);
            }

            for (var i = 0; i < 3; i++)
            {
                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 1 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 2 + i * 4, m_mapper.GetNextId(session));
                }

                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 3 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 4 + i * 4, m_mapper.GetNextId(session));

                    session.Commit();
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Проверка совпадения колонок маппера с реальной БД")]
        public void Test_Validate_Columns()
        {
            var columns = new Dictionary<string, PostgreSqlColumnInfo>();
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = (IPostgreSqlMappersSession) m_mappers.OpenSession())
            {
                using (var command = session.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{m_tableName}'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var indexMaxLength = reader.GetOrdinal(@"character_maximum_length");
                            var columnInfo =
                                new PostgreSqlColumnInfo
                                {
                                    ColumnName = reader.GetString(reader.GetOrdinal(@"column_name")),
                                    IsNullable = (reader.GetString(reader.GetOrdinal(@"is_nullable")) == @"YES"),
                                    MaxLength = reader.IsDBNull(indexMaxLength) ? (int?) null : reader.GetInt32(indexMaxLength),
                                };
                            columns.Add(columnInfo.ColumnName, columnInfo);
                        }
                    }
                }
            }

            DoValidate_Columns(columns);

            var columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";

            #region CreateDate

            {
                Assert.IsTrue(columns.ContainsKey(@"createdate"), @"CreateDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"createdate"];
                columns.Remove(@"createdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region TableName

            {
                Assert.IsTrue(columns.ContainsKey(@"tablename"), @"TableName" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"tablename"];
                columns.Remove(@"tablename");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region PartitionName

            {
                Assert.IsTrue(columns.ContainsKey(@"partitionname"), @"PartitionName" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"partitionname"];
                columns.Remove(@"partitionname");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Day

            {
                Assert.IsTrue(columns.ContainsKey(@"day"), @"Day" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"day"];
                columns.Remove(@"day");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region MinGroupId

            {
                Assert.IsTrue(columns.ContainsKey(@"mingroupid"), @"MinGroupId" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"mingroupid"];
                columns.Remove(@"mingroupid");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region MaxNotIncludeGroupId

            {
                Assert.IsTrue(columns.ContainsKey(@"maxnotincludegroupid"), @"MaxNotIncludeGroupId" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"maxnotincludegroupid"];
                columns.Remove(@"maxnotincludegroupid");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region MinId

            {
                Assert.IsTrue(columns.ContainsKey(@"minid"), @"MinId" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"minid"];
                columns.Remove(@"minid");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region MaxNotIncludeId

            {
                Assert.IsTrue(columns.ContainsKey(@"maxnotincludeid"), @"MaxNotIncludeId" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"maxnotincludeid"];
                columns.Remove(@"maxnotincludeid");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Id

            {
                Assert.IsTrue(columns.ContainsKey(@"id"), @"Id" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"id"];
                columns.Remove(@"id");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";
            Assert.AreEqual(0, columns.Count, columnsText);
        }

        public static TablePartitionDtoNew GetRandomNew(object context)
        {
            var result = new TablePartitionDtoNew
            {
                Id = long.MinValue,
                CreateDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTimeOffset>(LocalNpgsqlDbType.TimestampTz),
                TableName = PostgreSqlRandomValuesProvider.GetRandomValue<string>(LocalNpgsqlDbType.Text),
                PartitionName = PostgreSqlRandomValuesProvider.GetRandomValue<string>(LocalNpgsqlDbType.Text),
                Day = PostgreSqlRandomValuesProvider.GetRandomValue<DateTime>(LocalNpgsqlDbType.Date),
                MinGroupId = PostgreSqlRandomValuesProvider.GetRandomValue<long>(LocalNpgsqlDbType.Bigint),
                MaxNotIncludeGroupId = PostgreSqlRandomValuesProvider.GetRandomValue<long>(LocalNpgsqlDbType.Bigint),
                MinId = PostgreSqlRandomValuesProvider.GetRandomValue<long>(LocalNpgsqlDbType.Bigint),
                MaxNotIncludeId = PostgreSqlRandomValuesProvider.GetRandomValue<long>(LocalNpgsqlDbType.Bigint),
            };

            DoGetRandomNew(result, context);

            return (result);
        }

        public static void AssertAreEqual(TablePartitionDtoNew expected, TablePartitionDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.TableName, actual.TableName);
            Assert.AreEqual(expected.PartitionName, actual.PartitionName);
            Assert.AreEqual(expected.Day, actual.Day);
            Assert.AreEqual(expected.MinGroupId, actual.MinGroupId);
            Assert.AreEqual(expected.MaxNotIncludeGroupId, actual.MaxNotIncludeGroupId);
            Assert.AreEqual(expected.MinId, actual.MinId);
            Assert.AreEqual(expected.MaxNotIncludeId, actual.MaxNotIncludeId);

            DoAssertAreEqual(expected, actual, context);
        }

        public static void AssertAreEqual(TablePartitionDtoActual expected, TablePartitionDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.TableName, actual.TableName);
            Assert.AreEqual(expected.PartitionName, actual.PartitionName);
            Assert.AreEqual(expected.Day, actual.Day);
            Assert.AreEqual(expected.MinGroupId, actual.MinGroupId);
            Assert.AreEqual(expected.MaxNotIncludeGroupId, actual.MaxNotIncludeGroupId);
            Assert.AreEqual(expected.MinId, actual.MinId);
            Assert.AreEqual(expected.MaxNotIncludeId, actual.MaxNotIncludeId);

            DoAssertAreEqual(expected, actual, context);
        }
    }

    /// <summary>
    /// Объект
    /// </summary>
    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMapperDemoObject : BaseAutoTestsMapper
    {
        #region Private Class PostgreSqlColumnInfo

        private class PostgreSqlColumnInfo
        {
            public string ColumnName;
            public bool IsNullable;
            public int? MaxLength;
        }

        #endregion

        protected string m_tableName;
        protected IMapperDemoObject m_mapper;

        [SetUp]
        public void SetUp()
        {
            m_mapper = (IMapperDemoObject) m_mappers.GetMapper(WellknownMappers.DemoObject);
            m_tableName = "demoobject";
            DoSetUp();

            {
                var partitions = ((IPartitionsMapper)m_mapper).Partitions;
                using var session = m_mappers.OpenSession();
                if (false == partitions.GetHasDefaultPartition(session))
                {
                    partitions.CreatedDefaultPartition(session);
                    session.Commit();
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            DoTearDown();
        }

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNew(DemoObjectDtoNew dto, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoBulkInsert(List<DemoObjectDtoNew> dtos, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(DemoObjectDtoNew expected, DemoObjectDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(DemoObjectDtoActual expected, DemoObjectDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTearDown();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTest_New_Get();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoValidate_Columns(Dictionary<string, PostgreSqlColumnInfo> columns);

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(20)]
        [Description("Массовая вставка записей")]
        public void Test_BulkInsert(int size)
        {
            var templates = new List<DemoObjectDtoNew>();
            for (var i = 0; i < size; i++)
            {
                var template = GetRandomNew(m_context);
                template.Id = i + 1;
                templates.Add(template);
            }

            DoBulkInsert(templates, m_context);

            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                m_mapper.BulkInsert(session, templates);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                foreach (var template in templates)
                {
                    var data = m_mapper.Get(mappersSession, template.Id);
                    AssertAreEqual(template, data, m_context);
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Создание и Получение")]
        public void Test_New_Get()
        {
            DoTest_New_Get();

            var template = GetRandomNew(m_context);
            DemoObjectDtoActual dataNew;
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                dataNew = m_mapper.New(session, template);
                AssertAreEqual(template, dataNew, m_context);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                var data = m_mapper.Get(mappersSession, template.Id);
                AssertAreEqual(template, data, m_context);
                AssertAreEqual(dataNew, data, m_context);
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Получение следующего значения идентити из последовательности")]
        public void Test_GetNextId()
        {
            long baseValue;
            using (var session = m_mappers.OpenSession())
            {
                baseValue = m_mapper.GetNextId(session);
            }

            for (var i = 0; i < 3; i++)
            {
                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 1 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 2 + i * 4, m_mapper.GetNextId(session));
                }

                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 3 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 4 + i * 4, m_mapper.GetNextId(session));

                    session.Commit();
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Проверка совпадения колонок маппера с реальной БД")]
        public void Test_Validate_Columns()
        {
            var columns = new Dictionary<string, PostgreSqlColumnInfo>();
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = (IPostgreSqlMappersSession) m_mappers.OpenSession())
            {
                using (var command = session.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{m_tableName}'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var indexMaxLength = reader.GetOrdinal(@"character_maximum_length");
                            var columnInfo =
                                new PostgreSqlColumnInfo
                                {
                                    ColumnName = reader.GetString(reader.GetOrdinal(@"column_name")),
                                    IsNullable = (reader.GetString(reader.GetOrdinal(@"is_nullable")) == @"YES"),
                                    MaxLength = reader.IsDBNull(indexMaxLength) ? (int?) null : reader.GetInt32(indexMaxLength),
                                };
                            columns.Add(columnInfo.ColumnName, columnInfo);
                        }
                    }
                }
            }

            DoValidate_Columns(columns);

            var columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";

            #region CreateDate

            {
                Assert.IsTrue(columns.ContainsKey(@"createdate"), @"CreateDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"createdate"];
                columns.Remove(@"createdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region ModificationDate

            {
                Assert.IsTrue(columns.ContainsKey(@"modificationdate"), @"ModificationDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"modificationdate"];
                columns.Remove(@"modificationdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Name

            {
                Assert.IsTrue(columns.ContainsKey(@"name"), @"Name" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"name"];
                columns.Remove(@"name");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNotNull(columnInfo.MaxLength, columnsText);
                Assert.AreEqual(1024, columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Enabled

            {
                Assert.IsTrue(columns.ContainsKey(@"enabled"), @"Enabled" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"enabled"];
                columns.Remove(@"enabled");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Id

            {
                Assert.IsTrue(columns.ContainsKey(@"id"), @"Id" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"id"];
                columns.Remove(@"id");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Revision

            {
                Assert.IsTrue(columns.ContainsKey(@"revision"), @"Revision" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"revision"];
                columns.Remove(@"revision");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";
            Assert.AreEqual(0, columns.Count, columnsText);
        }

        public static DemoObjectDtoNew GetRandomNew(object context)
        {
            var result = new DemoObjectDtoNew
            {
                Id = long.MinValue,
                CreateDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTime>(LocalNpgsqlDbType.Timestamp),
                ModificationDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTime>(LocalNpgsqlDbType.Timestamp),
                Name = PostgreSqlRandomValuesProvider.GetRandomValue<string>(LocalNpgsqlDbType.Varchar, size: 1024),
                Enabled = PostgreSqlRandomValuesProvider.GetRandomValue<bool>(LocalNpgsqlDbType.Boolean),
            };

            DoGetRandomNew(result, context);

            return (result);
        }

        public static void AssertAreEqual(DemoObjectDtoNew expected, DemoObjectDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.ModificationDate, actual.ModificationDate);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Enabled, actual.Enabled);

            DoAssertAreEqual(expected, actual, context);
        }

        public static void AssertAreEqual(DemoObjectDtoActual expected, DemoObjectDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.ModificationDate, actual.ModificationDate);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Enabled, actual.Enabled);

            DoAssertAreEqual(expected, actual, context);
        }
    }

    /// <summary>
    /// Объект X
    /// </summary>
    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMapperDemoObjectX : BaseAutoTestsMapper
    {
        #region Private Class PostgreSqlColumnInfo

        private class PostgreSqlColumnInfo
        {
            public string ColumnName;
            public bool IsNullable;
            public int? MaxLength;
        }

        #endregion

        protected string m_tableName;
        protected IMapperDemoObjectX m_mapper;

        [SetUp]
        public void SetUp()
        {
            m_mapper = (IMapperDemoObjectX) m_mappers.GetMapper(WellknownMappers.DemoObjectX);
            m_tableName = "demoobjectx";
            DoSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            DoTearDown();
        }

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNew(DemoObjectXDtoNew dto, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoBulkInsert(List<DemoObjectXDtoNew> dtos, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(DemoObjectXDtoNew expected, DemoObjectXDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(DemoObjectXDtoActual expected, DemoObjectXDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTearDown();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTest_New_Get();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoValidate_Columns(Dictionary<string, PostgreSqlColumnInfo> columns);

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(20)]
        [Description("Массовая вставка записей")]
        public void Test_BulkInsert(int size)
        {
            var templates = new List<DemoObjectXDtoNew>();
            for (var i = 0; i < size; i++)
            {
                var template = GetRandomNew(m_context);
                template.Id = i + 1;
                templates.Add(template);
            }

            DoBulkInsert(templates, m_context);

            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                m_mapper.BulkInsert(session, templates);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                foreach (var template in templates)
                {
                    var data = m_mapper.Get(mappersSession, template.Id);
                    AssertAreEqual(template, data, m_context);
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Создание и Получение")]
        public void Test_New_Get()
        {
            DoTest_New_Get();

            var template = GetRandomNew(m_context);
            DemoObjectXDtoActual dataNew;
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                dataNew = m_mapper.New(session, template);
                AssertAreEqual(template, dataNew, m_context);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                var data = m_mapper.Get(mappersSession, template.Id);
                AssertAreEqual(template, data, m_context);
                AssertAreEqual(dataNew, data, m_context);
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Получение следующего значения идентити из последовательности")]
        public void Test_GetNextId()
        {
            long baseValue;
            using (var session = m_mappers.OpenSession())
            {
                baseValue = m_mapper.GetNextId(session);
            }

            for (var i = 0; i < 3; i++)
            {
                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 1 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 2 + i * 4, m_mapper.GetNextId(session));
                }

                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 3 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 4 + i * 4, m_mapper.GetNextId(session));

                    session.Commit();
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Проверка совпадения колонок маппера с реальной БД")]
        public void Test_Validate_Columns()
        {
            var columns = new Dictionary<string, PostgreSqlColumnInfo>();
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = (IPostgreSqlMappersSession) m_mappers.OpenSession())
            {
                using (var command = session.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{m_tableName}'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var indexMaxLength = reader.GetOrdinal(@"character_maximum_length");
                            var columnInfo =
                                new PostgreSqlColumnInfo
                                {
                                    ColumnName = reader.GetString(reader.GetOrdinal(@"column_name")),
                                    IsNullable = (reader.GetString(reader.GetOrdinal(@"is_nullable")) == @"YES"),
                                    MaxLength = reader.IsDBNull(indexMaxLength) ? (int?) null : reader.GetInt32(indexMaxLength),
                                };
                            columns.Add(columnInfo.ColumnName, columnInfo);
                        }
                    }
                }
            }

            DoValidate_Columns(columns);

            var columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";

            #region CreateDate

            {
                Assert.IsTrue(columns.ContainsKey(@"createdate"), @"CreateDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"createdate"];
                columns.Remove(@"createdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region ModificationDate

            {
                Assert.IsTrue(columns.ContainsKey(@"modificationdate"), @"ModificationDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"modificationdate"];
                columns.Remove(@"modificationdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Name

            {
                Assert.IsTrue(columns.ContainsKey(@"name"), @"Name" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"name"];
                columns.Remove(@"name");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNotNull(columnInfo.MaxLength, columnsText);
                Assert.AreEqual(1024, columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Enabled

            {
                Assert.IsTrue(columns.ContainsKey(@"enabled"), @"Enabled" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"enabled"];
                columns.Remove(@"enabled");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Key1

            {
                Assert.IsTrue(columns.ContainsKey(@"key1"), @"Key1" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"key1"];
                columns.Remove(@"key1");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Key2

            {
                Assert.IsTrue(columns.ContainsKey(@"key2"), @"Key2" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"key2"];
                columns.Remove(@"key2");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNotNull(columnInfo.MaxLength, columnsText);
                Assert.AreEqual(10, columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region group

            {
                Assert.IsTrue(columns.ContainsKey(@"group"), @"group" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"group"];
                columns.Remove(@"group");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Id

            {
                Assert.IsTrue(columns.ContainsKey(@"id"), @"Id" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"id"];
                columns.Remove(@"id");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Revision

            {
                Assert.IsTrue(columns.ContainsKey(@"revision"), @"Revision" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"revision"];
                columns.Remove(@"revision");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";
            Assert.AreEqual(0, columns.Count, columnsText);
        }

        public static DemoObjectXDtoNew GetRandomNew(object context)
        {
            var result = new DemoObjectXDtoNew
            {
                Id = long.MinValue,
                CreateDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTimeOffset>(LocalNpgsqlDbType.TimestampTz),
                ModificationDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTimeOffset>(LocalNpgsqlDbType.TimestampTz),
                Name = PostgreSqlRandomValuesProvider.GetRandomValue<string>(LocalNpgsqlDbType.Varchar, size: 1024),
                Enabled = PostgreSqlRandomValuesProvider.GetRandomValue<bool>(LocalNpgsqlDbType.Boolean),
                Key1 = PostgreSqlRandomValuesProvider.GetRandomValue<Guid>(LocalNpgsqlDbType.Uuid),
                Key2 = PostgreSqlRandomValuesProvider.GetRandomValue<string>(LocalNpgsqlDbType.Varchar, size: 10),
                Group = PostgreSqlRandomValuesProvider.GetRandomValue<long>(LocalNpgsqlDbType.Bigint),
            };

            DoGetRandomNew(result, context);

            return (result);
        }

        public static void AssertAreEqual(DemoObjectXDtoNew expected, DemoObjectXDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.ModificationDate, actual.ModificationDate);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Enabled, actual.Enabled);
            Assert.AreEqual(expected.Key1, actual.Key1);
            Assert.AreEqual(expected.Key2, actual.Key2);
            Assert.AreEqual(expected.Group, actual.Group);

            DoAssertAreEqual(expected, actual, context);
        }

        public static void AssertAreEqual(DemoObjectXDtoActual expected, DemoObjectXDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.ModificationDate, actual.ModificationDate);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Enabled, actual.Enabled);
            Assert.AreEqual(expected.Key1, actual.Key1);
            Assert.AreEqual(expected.Key2, actual.Key2);
            Assert.AreEqual(expected.Group, actual.Group);

            DoAssertAreEqual(expected, actual, context);
        }
    }

    /// <summary>
    /// Задача с отложенным запуском
    /// </summary>
    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMapperDemoDelayTask : BaseAutoTestsMapper
    {
        #region Private Class PostgreSqlColumnInfo

        private class PostgreSqlColumnInfo
        {
            public string ColumnName;
            public bool IsNullable;
            public int? MaxLength;
        }

        #endregion

        protected string m_tableName;
        protected IMapperDemoDelayTask m_mapper;

        [SetUp]
        public void SetUp()
        {
            m_mapper = (IMapperDemoDelayTask) m_mappers.GetMapper(WellknownMappers.DemoDelayTask);
            m_tableName = "demodelaytask";
            DoSetUp();

            {
                var partitions = ((IPartitionsMapper)m_mapper).Partitions;
                using var session = m_mappers.OpenSession();
                if (false == partitions.GetHasDefaultPartition(session))
                {
                    partitions.CreatedDefaultPartition(session);
                    session.Commit();
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            DoTearDown();
        }

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNew(DemoDelayTaskDtoNew dto, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoBulkInsert(List<DemoDelayTaskDtoNew> dtos, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(DemoDelayTaskDtoNew expected, DemoDelayTaskDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(DemoDelayTaskDtoActual expected, DemoDelayTaskDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTearDown();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTest_New_Get();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoValidate_Columns(Dictionary<string, PostgreSqlColumnInfo> columns);

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(20)]
        [Description("Массовая вставка записей")]
        public void Test_BulkInsert(int size)
        {
            var templates = new List<DemoDelayTaskDtoNew>();
            for (var i = 0; i < size; i++)
            {
                var template = GetRandomNew(m_context);
                template.Id = i + 1;
                templates.Add(template);
            }

            DoBulkInsert(templates, m_context);

            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                m_mapper.BulkInsert(session, templates);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                foreach (var template in templates)
                {
                    var data = m_mapper.Get(mappersSession, template.Id);
                    AssertAreEqual(template, data, m_context);
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Создание и Получение")]
        public void Test_New_Get()
        {
            DoTest_New_Get();

            var template = GetRandomNew(m_context);
            DemoDelayTaskDtoActual dataNew;
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                dataNew = m_mapper.New(session, template);
                AssertAreEqual(template, dataNew, m_context);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var mappersSession = m_mappers.OpenSession())
            {
                var data = m_mapper.Get(mappersSession, template.Id);
                AssertAreEqual(template, data, m_context);
                AssertAreEqual(dataNew, data, m_context);
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Получение следующего значения идентити из последовательности")]
        public void Test_GetNextId()
        {
            long baseValue;
            using (var session = m_mappers.OpenSession())
            {
                baseValue = m_mapper.GetNextId(session);
            }

            for (var i = 0; i < 3; i++)
            {
                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 1 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 2 + i * 4, m_mapper.GetNextId(session));
                }

                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 3 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 4 + i * 4, m_mapper.GetNextId(session));

                    session.Commit();
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Проверка совпадения колонок маппера с реальной БД")]
        public void Test_Validate_Columns()
        {
            var columns = new Dictionary<string, PostgreSqlColumnInfo>();
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = (IPostgreSqlMappersSession) m_mappers.OpenSession())
            {
                using (var command = session.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{m_tableName}'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var indexMaxLength = reader.GetOrdinal(@"character_maximum_length");
                            var columnInfo =
                                new PostgreSqlColumnInfo
                                {
                                    ColumnName = reader.GetString(reader.GetOrdinal(@"column_name")),
                                    IsNullable = (reader.GetString(reader.GetOrdinal(@"is_nullable")) == @"YES"),
                                    MaxLength = reader.IsDBNull(indexMaxLength) ? (int?) null : reader.GetInt32(indexMaxLength),
                                };
                            columns.Add(columnInfo.ColumnName, columnInfo);
                        }
                    }
                }
            }

            DoValidate_Columns(columns);

            var columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";

            #region CreateDate

            {
                Assert.IsTrue(columns.ContainsKey(@"createdate"), @"CreateDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"createdate"];
                columns.Remove(@"createdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region ModificationDate

            {
                Assert.IsTrue(columns.ContainsKey(@"modificationdate"), @"ModificationDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"modificationdate"];
                columns.Remove(@"modificationdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Scenario

            {
                Assert.IsTrue(columns.ContainsKey(@"scenario"), @"Scenario" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"scenario"];
                columns.Remove(@"scenario");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region ScenarioState

            {
                Assert.IsTrue(columns.ContainsKey(@"scenariostate"), @"ScenarioState" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"scenariostate"];
                columns.Remove(@"scenariostate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region StartDate

            {
                Assert.IsTrue(columns.ContainsKey(@"startdate"), @"StartDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"startdate"];
                columns.Remove(@"startdate");
                Assert.IsTrue(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Id

            {
                Assert.IsTrue(columns.ContainsKey(@"id"), @"Id" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"id"];
                columns.Remove(@"id");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Available

            {
                Assert.IsTrue(columns.ContainsKey(@"available"), @"Available" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"available"];
                columns.Remove(@"available");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Revision

            {
                Assert.IsTrue(columns.ContainsKey(@"revision"), @"Revision" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"revision"];
                columns.Remove(@"revision");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";
            Assert.AreEqual(0, columns.Count, columnsText);
        }

        public static DemoDelayTaskDtoNew GetRandomNew(object context)
        {
            var result = new DemoDelayTaskDtoNew
            {
                Id = long.MinValue,
                CreateDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTimeOffset>(LocalNpgsqlDbType.TimestampTz),
                ModificationDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTimeOffset>(LocalNpgsqlDbType.TimestampTz),
                Scenario = PostgreSqlRandomValuesProvider.GetRandomValue<string>(LocalNpgsqlDbType.Text),
                ScenarioState = PostgreSqlRandomValuesProvider.GetRandomValue<string>(LocalNpgsqlDbType.Text),
                StartDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTimeOffset?>(LocalNpgsqlDbType.TimestampTz, true),
                Available = true,
            };

            DoGetRandomNew(result, context);

            return (result);
        }

        public static void AssertAreEqual(DemoDelayTaskDtoNew expected, DemoDelayTaskDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.ModificationDate, actual.ModificationDate);
            Assert.AreEqual(expected.Scenario, actual.Scenario);
            Assert.AreEqual(expected.ScenarioState, actual.ScenarioState);
            Assert.AreEqual(expected.StartDate, actual.StartDate);
            Assert.AreEqual(expected.Available, actual.Available);

            DoAssertAreEqual(expected, actual, context);
        }

        public static void AssertAreEqual(DemoDelayTaskDtoActual expected, DemoDelayTaskDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.ModificationDate, actual.ModificationDate);
            Assert.AreEqual(expected.Scenario, actual.Scenario);
            Assert.AreEqual(expected.ScenarioState, actual.ScenarioState);
            Assert.AreEqual(expected.StartDate, actual.StartDate);
            Assert.AreEqual(expected.Available, actual.Available);

            DoAssertAreEqual(expected, actual, context);
        }
    }

}
