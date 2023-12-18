using System;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public partial class PdSystemLog
{
    public long Id { get; set; }

    public DateTime Createdate { get; set; }

    public int Code { get; set; }

    public int Type { get; set; }

    public string Message { get; set; } = null!;

    public string Data { get; set; } = null!;
}
