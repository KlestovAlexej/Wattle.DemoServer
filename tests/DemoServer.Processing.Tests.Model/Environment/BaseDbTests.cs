using Npgsql;
using NUnit.Framework;
using ShtrihM.DemoServer.Common;
using ShtrihM.DemoServer.Processing.DataAccess.PostgreSql;
using ShtrihM.Wattle3.Testing;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace ShtrihM.DemoServer.Processing.Tests.Model.Environment;

public abstract class BaseDbTests : Testing.BaseDbTests
{
    protected override string DoGetDbName()
    {
        return $"test_{Constants.ProductTag.ToLower()}";
    }

    protected override string DoGetSqlScript()
    {
        return Deploy.GetSqlScript();
    }

    protected override void DoPostCreateDb()
    {
        DefineRandomDbSequences(m_dbConnectionString);
    }

    private static IEnumerable<string> GetDbSequences(string connectionString)
    {
        var result = new List<string>();

        using var conn = new NpgsqlConnection(connectionString);
        conn.Open();

        var sql = "SELECT c.relname FROM pg_class c WHERE c.relkind = 'S';";

        using var command = new NpgsqlCommand(sql, conn);

        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(reader["relname"].ToString()!);
        }

        return result;
    }

    private static void DefineDbSequence(NpgsqlConnection connection, string name, int value)
    {
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.Text;
        command.CommandText = $"ALTER SEQUENCE {name} RESTART WITH {value.ToString(CultureInfo.InvariantCulture)}";
        command.ExecuteNonQuery();
    }

    public static void DefineRandomDbSequences(string dbConnectionString)
    {
        using var connection = new NpgsqlConnection(dbConnectionString);
        connection.Open();

        var count = 0;
        foreach (var sequenceName in GetDbSequences(dbConnectionString))
        {
            DefineDbSequence(connection, sequenceName, ProviderRandomValues.Random.Next(1, 100_000_000));
            ++count;
        }
        Assert.Less(1, count);
    }
}