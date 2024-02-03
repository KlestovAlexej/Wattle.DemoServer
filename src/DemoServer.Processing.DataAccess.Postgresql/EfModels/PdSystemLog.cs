using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

[Table("$PD_SystemLog")]
public class PdSystemLog
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("createdate")]
    public DateTime Createdate { get; set; }

    [Column("code")]
    public int Code { get; set; }

    [Column("type")]
    public int Type { get; set; }

    [Column("message")]
    [StringLength(1024)]
    public string Message { get; set; } = null!;

    [Column("data")]
    public string Data { get; set; } = null!;
}
