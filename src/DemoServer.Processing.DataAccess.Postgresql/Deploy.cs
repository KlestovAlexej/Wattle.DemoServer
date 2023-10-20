using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql;

public static class Deploy
{
    public static string GetSqlScript()
    {
        var result = typeof(Deploy).Assembly.GetResourceAsString("DemoServer.Processing.sql");

        return (result);
    }
}