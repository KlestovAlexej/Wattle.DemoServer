using System;
using System.Collections.Generic;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public partial class PdDemoObject
{
    public long Id { get; set; }

    public long Revision { get; set; }

    public DateTime Createdate { get; set; }

    public DateTime Modificationdate { get; set; }

    public string Name { get; set; } = null!;

    public bool Enabled { get; set; }
}
