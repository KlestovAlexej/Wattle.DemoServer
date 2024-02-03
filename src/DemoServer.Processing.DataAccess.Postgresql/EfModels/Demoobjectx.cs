using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

[Table("demoobjectx")]
[Index("Group", Name = "demoobjectx_group_idx")]
[Index("Key1", "Key2", Name = "demoobjectx_key_u_idx", IsUnique = true)]
public partial class Demoobjectx
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

    [Column("name")]
    [StringLength(1024)]
    public string Name { get; set; } = null!;

    [Column("enabled")]
    public bool Enabled { get; set; }

    [Column("key1")]
    public Guid Key1 { get; set; }

    [Column("key2")]
    [StringLength(10)]
    public string Key2 { get; set; } = null!;

    [Column("group")]
    public long Group { get; set; }
}
