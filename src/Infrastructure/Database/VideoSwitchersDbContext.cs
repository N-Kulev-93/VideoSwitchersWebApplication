using Application.Command.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database
{
    public class VideoSwitchersDbContext : DbContext
    {
        readonly static string DbPath = GetDbPath();

        public DbSet<VideoSwitcher> VideoSwitchers { get; set; }
        public DbSet<VideoInput> VideoInputs { get; set; }
        public DbSet<VideoOutput> VideoOutputs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoSwitcher>()
                .ToTable("VideoSwitchers")
                .HasKey("Id");

            modelBuilder.Entity<VideoSwitcher>()
                .HasMany(s => s.Inputs)
                .WithOne()
                .HasForeignKey("SwitcherId");

            modelBuilder.Entity<VideoSwitcher>()
                .HasMany(s => s.Outputs)
                .WithOne()
                .HasForeignKey("SwitcherId");

            modelBuilder.Entity<VideoInput>()
                .ToTable("VideoInputs")
                .HasKey("Position", "SwitcherId");

            modelBuilder.Entity<VideoOutput>()
                .ToTable("VideoOutputs")
                .HasKey("Position", "SwitcherId");

        }

        private static string GetDbPath()
        {
            //TODO: investigate proper place for storing sqlite db 
            var sourcePath = Directory.GetParent(path: Directory.GetCurrentDirectory());

            //TODO: db file per environment...
            var subPath = "\\Infrastructure\\Database\\VideoSwitchers.Development.db";

            return $"{sourcePath}{subPath}";
        }
    }
}
