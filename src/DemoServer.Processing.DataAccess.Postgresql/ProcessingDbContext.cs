using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Design;

// ReSharper disable once CheckNamespace
namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

/// <summary>
/// Контекст.
/// <remarks>
/// Для перегенерации контекста надо запустить руками тест <code>ShtrihM.DemoServer.Processing.Tests.DataAccess.PostgreSql.TestsCreateEntityFrameworkDbContext</code>
/// </remarks>
///  </summary>
public partial class ProcessingDbContext
{
    // ReSharper disable once UnusedType.Global
    public class ProcessingDbContextFactory : IDesignTimeDbContextFactory<ProcessingDbContext>
    {
        public ProcessingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProcessingDbContext>();
            optionsBuilder.UseNpgsql();

            return new(optionsBuilder.Options);
        }
    }

    private DatabaseFacade m_database;

    public void SetDbConnection(
        DbConnection connection,
        DbTransaction transaction)
    {
        m_database = Database;
        m_database.SetDbConnection(connection);

        if (transaction != null)
        {
            m_database.UseTransaction(transaction);
        }
    }
}
