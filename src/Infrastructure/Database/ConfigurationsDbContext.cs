using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infrastructure.Database
{
    internal class ConfigurationsDbContext : DbContext
    {
        public ConfigurationsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ConfigurationsDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder<ActionConfi
        }
    }
}
