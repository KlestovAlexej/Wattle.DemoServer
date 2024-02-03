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

    public virtual DbSet<PdDemoDelayTask> PdDemoDelayTask { get; set; }

    public virtual DbSet<PdDemoObject> PdDemoObject { get; set; }

    public virtual DbSet<PdSystemLog> PdSystemLog { get; set; }

    public virtual DbSet<PdTablePartition> PdTablePartition { get; set; }

    public virtual DbSet<Systemsetting> Systemsetting { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Demoobjectx>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("demoobjectx_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PdChangeTracker>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("ChangeTracker_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PdDemoDelayTask>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("DemoDelayTask_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PdDemoObject>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("DemoObject_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PdSystemLog>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("SystemLog_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<PdTablePartition>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("TablePartition_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Systemsetting>(entity =>
        {
            // entity.HasKey(e => e.Id).HasName("Primary key systemsetting");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });
        modelBuilder.HasSequence("sequence_changetracker");
        modelBuilder.HasSequence("sequence_demodelaytask");
        modelBuilder.HasSequence("sequence_demoobject");
        modelBuilder.HasSequence("sequence_demoobjectx");
        modelBuilder.HasSequence("sequence_systemlog");
        modelBuilder.HasSequence("sequence_tablepartition");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
