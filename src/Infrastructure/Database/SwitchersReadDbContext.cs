using Application.Query;
using Microsoft.EntityFrameworkCore;
using ActionSettings = Application.Query.Domain.Settings.ActionSettings;
using CommunicationSettings = Application.Query.Domain.Settings.CommunicationSettings;

namespace Infrastructure.Database
{
    internal class SwitchersReadDbContext : DbContext
    {
        public SwitchersReadDbContext(DbContextOptions<SwitchersReadDbContext> options) : base(options)
        {
        }

        protected SwitchersReadDbContext()
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
                .Entity<ActionSettings>()
                .Property("SwitcherId");
            modelBuilder
                .Entity<ActionSettings>()
                .ToTable("ActionConfigurations")
                .HasKey("Type", "SwitcherId");

            modelBuilder
                .Entity<CommunicationSettings>()
                .Property("SwitcherId");
            modelBuilder
                .Entity<CommunicationSettings>()
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
                .HasForeignKey<CommunicationSettings>("SwitcherId");
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
