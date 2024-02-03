using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

[Table("$PD_ChangeTracker")]
public class PdChangeTracker
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
}
