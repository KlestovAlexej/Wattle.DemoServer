using Acme.Wattle.Primitives;

namespace Acme.DemoServer.Processing.DataAccess.PostgreSql;

public static class Deploy
{
    public static string GetSqlScript()
    {
        var result = typeof(Deploy).Assembly.GetResourceAsString("DemoServer.Processing.sql");

        return (result);
    }
}