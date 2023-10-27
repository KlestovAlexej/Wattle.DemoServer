using Microsoft.EntityFrameworkCore;

namespace ShtrihM.DemoServer.Processing.DataAccess.PostgreSql.EfModels;

public partial class ProcessingDbContext : DbContext
{
    public ProcessingDbContext(DbContextOptions<ProcessingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Demoobjectx> Demoobjectx { get; set; }

    public virtual DbSet<PdChangeTracker> PdChangeTracker { get; set; }

    public virtual DbSet<PdDemoObject> PdDemoObject { get; set; }

    public virtual DbSet<PdSystemLog> PdSystemLog { get; set; }

    public virtual DbSet<PdTablePartition> PdTablePartition { get; set; }

    public virtual DbSet<Systemsetting> Systemsetting { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Demoobjectx>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("demoobjectx_pkey");

            entity.ToTableLowerCase("demoobjectx");

            // entity.HasIndex(e => e.Group, "demoobjectx_group_idx");

            // entity.HasIndex(e => new { e.Key1, e.Key2 }, "demoobjectx_key_u_idx").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdate");
            entity.Property(e => e.Enabled).HasColumnName("enabled");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Key1).HasColumnName("key1");
            entity.Property(e => e.Key2)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("key2");
            entity.Property(e => e.Modificationdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modificationdate");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(1024)
                .HasColumnName("name");
            entity.Property(e => e.Revision).HasColumnName("revision");
        });

        modelBuilder.Entity<PdChangeTracker>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("ChangeTracker_pkey");

            entity.ToTableLowerCase("ChangeTracker");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        modelBuilder.Entity<PdDemoObject>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("DemoObject_pkey");

            entity.ToTableLowerCase("DemoObject");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdate");
            entity.Property(e => e.Enabled).HasColumnName("enabled");
            entity.Property(e => e.Modificationdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modificationdate");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(1024)
                .HasColumnName("name");
            entity.Property(e => e.Revision).HasColumnName("revision");
        });

        modelBuilder.Entity<PdSystemLog>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("SystemLog_pkey");

            entity.ToTableLowerCase("SystemLog");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Createdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdate");
            entity.Property(e => e.Data)
                .IsRequired()
                .HasColumnName("data");
            entity.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(1024)
                .HasColumnName("message");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<PdTablePartition>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("TablePartition_pkey");

            entity.ToTableLowerCase("TablePartition");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdate");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.Maxnotincludegroupid).HasColumnName("maxnotincludegroupid");
            entity.Property(e => e.Maxnotincludeid).HasColumnName("maxnotincludeid");
            entity.Property(e => e.Mingroupid).HasColumnName("mingroupid");
            entity.Property(e => e.Minid).HasColumnName("minid");
            entity.Property(e => e.Partitionname)
                .IsRequired()
                .HasColumnType("character varying")
                .HasColumnName("partitionname");
            entity.Property(e => e.Tablename)
                .IsRequired()
                .HasColumnType("character varying")
                .HasColumnName("tablename");
        });

        modelBuilder.Entity<Systemsetting>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("Primary key systemsetting");

            entity.ToTableLowerCase("systemsetting");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(1024)
                .HasColumnName("name");
            entity.Property(e => e.Value)
                .IsRequired()
                .HasColumnName("value");
        });
        modelBuilder.HasSequence("sequence_changetracker");
        modelBuilder.HasSequence("sequence_demoobject");
        modelBuilder.HasSequence("sequence_demoobjectx");
        modelBuilder.HasSequence("sequence_systemlog");
        modelBuilder.HasSequence("sequence_tablepartition");
    }
}
