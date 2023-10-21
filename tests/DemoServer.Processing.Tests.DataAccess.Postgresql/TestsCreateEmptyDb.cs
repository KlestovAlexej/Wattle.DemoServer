using NUnit.Framework;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Generated.Tests;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Testing;
using System;
using System.IO;
using System.Text;

namespace ShtrihM.DemoServer.Processing.Tests.DataAccess.PostgreSql;

[TestFixture]
public class TestsCreateEmptyDb : BaseAutoTestsMapper
{
    protected override void DoPreCreateDb()
    {
        base.DoPreCreateDb();

        m_addTags = false;
    }

    /// <summary>
    /// Создание пустой БД и скрипта генерации контекста Entity Framework Core.
    ///
    /// !!!!!!!!!!!!!
    /// Сделать проект стартовым DemoServer.Processing.DataAccess.Postgresql.
    /// !!!!!!!!!!!!!
    /// 
    /// </summary>
    [Test]
    [Explicit]
    [Timeout(TestTimeout.Short)]
    [Category(TestCategory.Short)]
    [Description("Создание БД")]
    public void Test_Step_1()
    {
        m_dropDb = false;

        using (var session = m_mappers.OpenSession())
        {
            foreach (var mapper in m_mappers)
            {
                if (mapper is IPartitionsMapper partitionsMapper)
                {
                    partitionsMapper.Partitions.CreatedDefaultPartition(session);
                }
            }

            session.Commit();
        }

        Console.WriteLine();
        Console.WriteLine(@"Шаг №1 - выполнить команду :");
        Console.WriteLine($@"Scaffold-DbContext -Connection ""{m_dbConnectionString}"" -Provider ""Npgsql.EntityFrameworkCore.PostgreSQL"" -OutputDir ""EfModels"" -ContextDir ""EfModels"" -Namespace ""ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels"" -ContextNamespace ""ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels"" -Context ""{nameof(ProcessingDbContext)}"" -NoOnConfiguring -Force -Project DemoServer.Processing.DataAccess.Postgresql -NoPluralize");
        Console.WriteLine();
        Console.WriteLine(@"Шаг №2 :");
        Console.WriteLine("Выполнить тест Test_Step_2");
        Console.WriteLine();
        Console.WriteLine(@"Шаг №3 - выполнить команду :");
        Console.WriteLine($"Optimize-DbContext -OutputDir EfModelsOptimized -Verbose -Context {nameof(ProcessingDbContext)} -StartupProject DemoServer.Processing.DataAccess.Postgresql -Project DemoServer.Processing.DataAccess.Postgresql");
        Console.WriteLine();
    }

    [Test]
    [Explicit]
    [Timeout(TestTimeout.Short)]
    [Category(TestCategory.Short)]
    [Description("Корректировка DbContext")]
    public void Test_Step_2()
    {
        var fileName = Path.Combine(ProviderProjectBasePath.GetFullPath(@"src\DemoServer.Processing.DataAccess.Postgresql\EfModels"), $"{nameof(ProcessingDbContext)}.cs");
        var text = File.ReadAllText(fileName);
        text = text.Replace("$PD_", "");
        text = text.Replace(@"entity.ToTable(""", "entity.ToTableLowerCase(\"");
        text = text.Replace("entity.HasKey(", "// entity.HasKey(");
        text = text.Replace("entity.HasIndex(", "// entity.HasIndex(");
        File.WriteAllText(fileName, text, Encoding.Unicode);
    }
}

