using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

[Table("$PD_DemoObject")]
public class PdDemoObject
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("revision")]
    public long Revision { get; set; }

    [Column("createdate", TypeName = "timestamp without time zone")]
    public DateTime Createdate { get; set; }

    [Column("modificationdate", TypeName = "timestamp without time zone")]
    public DateTime Modificationdate { get; set; }

    [Column("name")]
    [StringLength(1024)]
    public string Name { get; set; } = null!;

    [Column("enabled")]
    public bool Enabled { get; set; }
}
