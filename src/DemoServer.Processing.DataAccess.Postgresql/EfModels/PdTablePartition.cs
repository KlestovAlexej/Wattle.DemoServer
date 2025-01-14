using System;
using System.Collections.Generic;

namespace Acme.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public partial class PdTablePartition
{
    public long Id { get; set; }

    public DateTime Createdate { get; set; }

    public string Tablename { get; set; } = null!;

    public string Partitionname { get; set; } = null!;

    public DateOnly Day { get; set; }

    public long Mingroupid { get; set; }

    public long Maxnotincludegroupid { get; set; }

    public long Minid { get; set; }

    public long Maxnotincludeid { get; set; }
}
