using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;

// ReSharper disable once CheckNamespace
namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

/// <summary>
/// Контекст.
/// <remarks>
/// Для перегенерации контекста надо запустить руками тест <code>ShtrihM.DemoServer.Processing.Tests.DataAccess.PostgreSql.TestsCreateEntityFrameworkDbContext</code>
/// </remarks>
///  </summary>
public partial class ProcessingDbContext : IDbContext
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

    public void SetDbConnection(
        DbConnection connection,
        DbTransaction? transaction)
    {
        Database.SetDbConnection(connection);
        Database.UseTransaction(transaction);

#if DEBUG
        var dependencies = (((IDatabaseFacadeDependenciesAccessor)Database).Dependencies as IRelationalDatabaseFacadeDependencies);
        Debug.Assert(dependencies != null, "dependencies != null");
        Debug.Assert(ReferenceEquals(dependencies.RelationalConnection.DbConnection, connection), "dependencies.RelationalConnection.ConnectionString != null");

        if (transaction != null)
        {
            Debug.Assert(ReferenceEquals(((IInfrastructure<DbTransaction>)dependencies.RelationalConnection.CurrentTransaction!).Instance, transaction), "dependencies.RelationalConnection.CurrentTransaction != null");
        }
        else
        {
            Debug.Assert(dependencies.RelationalConnection.CurrentTransaction == null, "dependencies.RelationalConnection.CurrentTransaction == null");
        }
#endif
    }
}