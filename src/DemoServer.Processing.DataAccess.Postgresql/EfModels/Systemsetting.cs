using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

[Table("systemsetting")]
public class Systemsetting
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("value")]
    public string Value { get; set; } = null!;

    [Column("name")]
    [StringLength(1024)]
    public string Name { get; set; } = null!;
}
