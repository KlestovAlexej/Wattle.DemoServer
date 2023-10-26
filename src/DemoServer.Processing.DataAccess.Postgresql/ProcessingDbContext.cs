using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;

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

#if DEBUG
        var dependencies = (((IDatabaseFacadeDependenciesAccessor)m_database).Dependencies as IRelationalDatabaseFacadeDependencies);
        Debug.Assert(dependencies != null, "dependencies != null");
        Debug.Assert(dependencies.RelationalConnection.ConnectionString == null, "dependencies.RelationalConnection.ConnectionString == null");
        Debug.Assert(dependencies.RelationalConnection.CurrentTransaction == null, "dependencies.RelationalConnection.CurrentTransaction == null");
#endif

        m_database.SetDbConnection(connection);

        if (transaction != null)
        {
            m_database.UseTransaction(transaction);
        }

#if DEBUG
        Debug.Assert(dependencies != null, "dependencies != null");
        Debug.Assert(dependencies.RelationalConnection.ConnectionString != null, "dependencies.RelationalConnection.ConnectionString != null");

        if (transaction != null)
        {
            Debug.Assert(dependencies.RelationalConnection.CurrentTransaction != null, "dependencies.RelationalConnection.CurrentTransaction != null");
        }
        else
        {
            Debug.Assert(dependencies.RelationalConnection.CurrentTransaction == null, "dependencies.RelationalConnection.CurrentTransaction == null");
        }
#endif
    }

    public override void Dispose()
    {
        base.Dispose();

        if (m_database != null)
        {
            m_database.SetDbConnection(null);
            m_database.UseTransaction(null);
        }
    }

    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync().ConfigureAwait(false);

        if (m_database != null)
        {
            m_database.SetDbConnection(null);
            await m_database.UseTransactionAsync(null).ConfigureAwait(false);
        }
    }
}
