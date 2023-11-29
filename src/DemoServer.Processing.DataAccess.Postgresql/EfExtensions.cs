using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql;

public static class EfExtensions
{
    public static void ToTableLowerCase<TEntity>(
        this EntityTypeBuilder<TEntity> entityTypeBuilder,
        string name)
        where TEntity : class
        => entityTypeBuilder.ToTable(name.ToLower());
}

