using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

[Table("$PD_TablePartition")]
public class PdTablePartition
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("createdate")]
    public DateTime Createdate { get; set; }

    [Column("tablename", TypeName = "character varying")]
    public string Tablename { get; set; } = null!;

    [Column("partitionname", TypeName = "character varying")]
    public string Partitionname { get; set; } = null!;

    [Column("day")]
    public DateOnly Day { get; set; }

    [Column("mingroupid")]
    public long Mingroupid { get; set; }

    [Column("maxnotincludegroupid")]
    public long Maxnotincludegroupid { get; set; }

    [Column("minid")]
    public long Minid { get; set; }

    [Column("maxnotincludeid")]
    public long Maxnotincludeid { get; set; }
}
