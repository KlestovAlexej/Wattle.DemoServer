using System;

namespace Acme.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public partial class PdDemoDelayTask
{
    public long Id { get; set; }

    public long Revision { get; set; }

    public DateTime Createdate { get; set; }

    public DateTime Modificationdate { get; set; }

    public bool Available { get; set; }

    public DateTime? Startdate { get; set; }

    public string Scenario { get; set; } = null!;

    public string Scenariostate { get; set; } = null!;
}
