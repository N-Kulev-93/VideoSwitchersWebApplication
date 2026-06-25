using Application.Command;
using Application.Command.Domain.Settings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    internal class SwitchersWriteDbContext : DbContext
    {
        public SwitchersWriteDbContext(DbContextOptions<SwitchersWriteDbContext> options) : base(options)
        {
        }

        protected SwitchersWriteDbContext()
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
                .Entity<SwitcherAction>()
                .Property("SwitcherId");
            modelBuilder
                .Entity<SwitcherAction>()
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
                .HasMany(vs => vs.Actions)
                .WithOne()
                .HasForeignKey("SwitcherId");
            modelBuilder
                .Entity<VideoSwitcher>()
                .Ignore(vs => vs.IsOnline);
        }
    }
}
