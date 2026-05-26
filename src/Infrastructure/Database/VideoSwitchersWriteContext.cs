using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{

    public class VideoSwitchersWriteContext : DbContext
    {
        public VideoSwitchersWriteContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VideoSwitcher> VideoSwitchers { get; set; }
        public DbSet<VideoInput> VideoInputs { get; set; }
        public DbSet<VideoOutput> VideoOutputs { get; set; }
        public DbSet<ActionSettings> ActionsSettings { get; set; }
        public DbSet<ConnectionSettings> ConnectionSettings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class VideoSwitchersQueryContext : VideoSwitchersWriteContext
    {
        public VideoSwitchersQueryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoSwitcher>()
                .HasMany(s => s.Inputs)
                .WithOne()
                .HasForeignKey("SwitcherId")
                .IsRequired();

            modelBuilder.Entity<VideoSwitcher>()
                .HasMany(s => s.Outputs)
                .WithOne()
                .HasForeignKey("SwitcherId")
                .IsRequired();

            modelBuilder.Entity<VideoSwitcher>()
                .HasOne(s => s.ConnectionSettings)
                .WithOne()
                .HasForeignKey("Id")
                .HasPrincipalKey("ConnectionSettingsId")
                .IsRequired();

            modelBuilder.Entity<VideoSwitcher>()
                .HasMany(s => s.ActionsSettings)
                .WithOne()
                .HasForeignKey("SwitcherId")
                .IsRequired();
        }
    }

    public class VideoSwitchersWriteContext : DbContext
    {
        public VideoSwitchersWriteContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VideoSwitcher> VideoSwitchers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoSwitcher>()
                .ToTable("VideoSwitchers")
                .HasKey("Id");

            modelBuilder.Entity<VideoInput>()
                .ToTable("VideoInputs")
                .HasKey("Position", "SwitcherId");

            modelBuilder.Entity<VideoOutput>()
                .ToTable("VideoOutputs")
                .HasKey("Position", "SwitcherId");

            modelBuilder.Entity<ConnectionSettings>()
                .ToTable("ConnectionSettings")
                .HasKey("Id");
            
            modelBuilder.Entity<ActionSettings>()
                .ToTable("ActionsSettings")
                .HasKey("Id");
        }
    }

}
