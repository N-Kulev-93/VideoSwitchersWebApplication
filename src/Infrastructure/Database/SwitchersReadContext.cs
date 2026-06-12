using Application.Query;
using Microsoft.EntityFrameworkCore;
using ActionConfiguration = Application.Query.ActionConfiguration;
using ConnectionConfiguration = Application.Query.ConnectionConfiguration;

namespace Infrastructure.Database
{
    internal class SwitchersReadContext : DbContext
    {
        public SwitchersReadContext(DbContextOptions<SwitchersReadContext> options) : base(options)
        {
        }

        protected SwitchersReadContext()
        {
        }

        public DbSet<VideoSwitcher> VideoSwitchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<VideoOutput>()
                .Property("SwitcherId");
            modelBuilder
                .Entity<VideoOutput>()
                .ToTable("VideoOutputs")
                .HasKey("SwitcherId", "Position");

            modelBuilder
                .Entity<VideoInput>()
                .Property("SwitcherId");
            modelBuilder
                .Entity<VideoInput>()
                .ToTable("VideoInputs")
                .HasKey("SwitcherId", "Position");

            modelBuilder
                .Entity<ActionConfiguration>()
                .Property("SwitcherId");
            modelBuilder
                .Entity<ActionConfiguration>()
                .ToTable("ActionConfigurations")
                .HasKey("Type", "SwitcherId");

            modelBuilder
                .Entity<ConnectionConfiguration>()
                .Property("SwitcherId");
            modelBuilder
                .Entity<ConnectionConfiguration>()
                .ToTable("ConnectionConfigurations")
                .HasKey("Type", "SwitcherId");

            modelBuilder
                .Entity<VideoSwitcher>()
                .ToTable("VideoSwitchers")
                .HasKey("Id");
            modelBuilder
                .Entity<VideoSwitcher>()
                .HasMany(vs => vs.Inputs)
                .WithOne()
                .HasForeignKey("SwitcherId");
            modelBuilder
                .Entity<VideoSwitcher>()
                .HasMany(vs => vs.Outputs)
                .WithOne()
                .HasForeignKey("SwitcherId");
            modelBuilder
                .Entity<VideoSwitcher>()
                .HasOne(vs => vs.ConnectionConfiguration)
                .WithOne()
                .HasForeignKey<ConnectionConfiguration>("SwitcherId");
            modelBuilder
                .Entity<VideoSwitcher>()
                .HasMany(vs => vs.ActionConfigurations)
                .WithOne()
                .HasForeignKey("SwitcherId");
            modelBuilder
                .Entity<VideoSwitcher>()
                .Ignore(vs => vs.IsOnline);
        }
    }
}
