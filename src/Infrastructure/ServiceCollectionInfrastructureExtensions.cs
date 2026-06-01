using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class ServiceCollectionInfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            var dir = Directory.GetParent(Directory.GetCurrentDirectory());

            // TODO: ...
            var dbPath = $"{dir}/Infrastructure/Database/VideoSwitchers.Development.db";
            services.AddDbContext<VideoSwitchersReadContext>(options => options.UseSqlite($"Data Source={dbPath}"));
            services.AddDbContext<VideoSwitchersWriteContext>(options => options.UseSqlite($"Data Source={dbPath}"));
            return services;
        }
    }
}
