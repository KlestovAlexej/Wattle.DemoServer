using NUnit.Framework;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;
using ShtrihM.DemoServer.Processing.Generated.Tests;
using ShtrihM.DemoServer.Testing;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Testing;
using System;
using System.IO;
using ShtrihM.DemoServer.Processing.Model.Implements;

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

        var pathDataAccess = ProviderProjectBasePath.GetFullPath(@"src\DemoServer.Processing.DataAccess.Postgresql");
        var pathModel = ProviderProjectBasePath.GetFullPath(@"src\DemoServer.Processing.Model");

        Console.WriteLine();
        Console.WriteLine("В Package Manager Console выполнить команды :");
        Console.WriteLine();
        Console.WriteLine($"Rename-Item -Path \"{Path.Combine(pathDataAccess, "EfModels")}\" -NewName EfModels_old");
        Console.WriteLine($"Rename-Item -Path \"{Path.Combine(pathDataAccess, "EfModelsOptimized")}\" -NewName EfModelsOptimized_old");
        Console.WriteLine($@"Scaffold-DbContext -Connection ""{m_dbConnectionString}"" -Provider ""Npgsql.EntityFrameworkCore.PostgreSQL"" -OutputDir ""EfModels"" -ContextDir ""EfModels"" -Namespace ""ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels"" -ContextNamespace ""ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels"" -Context ""{nameof(ProcessingDbContext)}"" -NoOnConfiguring -Force -StartupProject DemoServer.Processing.DataAccess.Postgresql -Project DemoServer.Processing.DataAccess.Postgresql -NoPluralize");
        Console.WriteLine($"Remove-Item -LiteralPath \"{Path.Combine(pathDataAccess, "EfModels_old")}\" -Force -Recurse");
        Console.WriteLine($"Remove-Item -LiteralPath \"{Path.Combine(pathDataAccess, "EfModelsOptimized_old")}\" -Force -Recurse");

        var fileNameEntryPointExtensions = Path.Combine(Path.Combine(pathModel, "Implements"), $"{nameof(EntryPointExtensions)}.cs");
        Console.WriteLine($"(Get-Content \"{fileNameEntryPointExtensions}\").Replace('o.UseModel(DataAccess.PostgreSql.EfModelsOptimized.ProcessingDbContextModel.Instance);', '// o.UseModel(DataAccess.PostgreSql.EfModelsOptimized.ProcessingDbContextModel.Instance);') | Set-Content \"{fileNameEntryPointExtensions}\"");

        var fileNameProcessingDbContext = Path.Combine(Path.Combine(pathDataAccess, "EfModels"), $"{nameof(ProcessingDbContext)}.cs");
        Console.WriteLine($"(Get-Content \"{fileNameProcessingDbContext}\").Replace('$PD_', '') | Set-Content \"{fileNameProcessingDbContext}\"");
        Console.WriteLine($"(Get-Content \"{fileNameProcessingDbContext}\").Replace('entity.ToTable(\"', 'entity.ToTableLowerCase(\"') | Set-Content \"{fileNameProcessingDbContext}\"");
        Console.WriteLine($"(Get-Content \"{fileNameProcessingDbContext}\").Replace('entity.HasKey(', '// entity.HasKey(') | Set-Content \"{fileNameProcessingDbContext}\"");
        Console.WriteLine($"(Get-Content \"{fileNameProcessingDbContext}\").Replace('entity.HasIndex(', '// entity.HasIndex(') | Set-Content \"{fileNameProcessingDbContext}\"");
        Console.WriteLine($"Optimize-DbContext -OutputDir EfModelsOptimized -Verbose -Context {nameof(ProcessingDbContext)} -StartupProject DemoServer.Processing.DataAccess.Postgresql -Project DemoServer.Processing.DataAccess.Postgresql");
        Console.WriteLine($"(Get-Content \"{fileNameEntryPointExtensions}\").Replace('// o.UseModel(DataAccess.PostgreSql.EfModelsOptimized.ProcessingDbContextModel.Instance);', 'o.UseModel(DataAccess.PostgreSql.EfModelsOptimized.ProcessingDbContextModel.Instance);') | Set-Content \"{fileNameEntryPointExtensions}\"");
        Console.WriteLine();
    }
}

