using NUnit.Framework;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Generated.Tests;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Testing;
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

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
    /// </summary>
    [Test]
    [Explicit]
    [Timeout(TestTimeout.Short)]
    [Category(TestCategory.Short)]
    [Description("Создание БД")]
    public void Test()
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

        var path = ProviderProjectBasePath.GetFullPath(@"src\DemoServer.Processing.DataAccess.Postgresql");

        Console.WriteLine();
        Console.WriteLine("В Package Manager Console выполнить команды :");
        Console.WriteLine();
        Console.WriteLine($"Rename-Item -Path \"{Path.Combine(path, "EfModels")}\" -NewName EfModels_old");
        Console.WriteLine($"Rename-Item -Path \"{Path.Combine(path, "EfModelsOptimized")}\" -NewName EfModelsOptimized_old");
        Console.WriteLine($@"Scaffold-DbContext -Connection ""{m_dbConnectionString}"" -Provider ""Npgsql.EntityFrameworkCore.PostgreSQL"" -OutputDir ""EfModels"" -ContextDir ""EfModels"" -Namespace ""ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels"" -ContextNamespace ""ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels"" -Context ""{nameof(ProcessingDbContext)}"" -NoOnConfiguring -Force -StartupProject DemoServer.Processing.DataAccess.Postgresql -Project DemoServer.Processing.DataAccess.Postgresql -NoPluralize");
        Console.WriteLine($"Remove-Item -LiteralPath \"{Path.Combine(path, "EfModels_old")}\" -Force -Recurse");

        var fileName = Path.Combine(Path.Combine(path, "EfModels"), $"{nameof(ProcessingDbContext)}.cs");
        Console.WriteLine($"(Get-Content \"{fileName}\").Replace('$PD_', '') | Set-Content \"{fileName}\"");
        Console.WriteLine($"(Get-Content \"{fileName}\").Replace('entity.ToTable(\"', 'entity.ToTableLowerCase(\"') | Set-Content \"{fileName}\"");
        Console.WriteLine($"(Get-Content \"{fileName}\").Replace('entity.HasKey(', '// entity.HasKey(') | Set-Content \"{fileName}\"");
        Console.WriteLine($"(Get-Content \"{fileName}\").Replace('entity.HasIndex(', '// entity.HasIndex(') | Set-Content \"{fileName}\"");
        Console.WriteLine($"Optimize-DbContext -OutputDir EfModelsOptimized -Verbose -Context {nameof(ProcessingDbContext)} -StartupProject DemoServer.Processing.DataAccess.Postgresql -Project DemoServer.Processing.DataAccess.Postgresql");
        Console.WriteLine($"Remove-Item -LiteralPath \"{Path.Combine(path, "EfModelsOptimized_old")}\" -Force -Recurse");
        Console.WriteLine();
    }
}

