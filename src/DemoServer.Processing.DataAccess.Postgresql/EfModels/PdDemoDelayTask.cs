using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

[Table("$PD_DemoDelayTask")]
public class PdDemoDelayTask
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("revision")]
    public long Revision { get; set; }

    [Column("createdate")]
    public DateTime Createdate { get; set; }

    [Column("modificationdate")]
    public DateTime Modificationdate { get; set; }

    [Column("available")]
    public bool Available { get; set; }

    [Column("startdate")]
    public DateTime? Startdate { get; set; }

    [Column("scenario")]
    public string Scenario { get; set; } = null!;
}
