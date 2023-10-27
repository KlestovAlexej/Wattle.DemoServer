using System;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public class PdTablePartition
{
    public long Id { get; set; }

    public DateTime Createdate { get; set; }

    public string Tablename { get; set; }

    public string Partitionname { get; set; }

    public DateOnly Day { get; set; }

    public long Mingroupid { get; set; }

    public long Maxnotincludegroupid { get; set; }

    public long Minid { get; set; }

    public long Maxnotincludeid { get; set; }
}
