using Application.Services;
using Infrastructure.Database;
using Infrastructure.Interface;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionInfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services
                .AddDatabaseServices()
                .AddConnectionServices();
        }

        static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            var dir = Directory.GetParent(Directory.GetCurrentDirectory());

            // TODO: ...
            var dbPath = $"{dir}/Infrastructure/Database/VideoSwitchers.Development.db";

            var readMaterializer = new SwitcherReadConnectionStatusMaterializer();
            var writeMaterializer = new SwitcherWriteConnectionStatusMaterializer();
            services.AddDbContext<VideoSwitchersReadContext>(options => options.UseSqlite($"Data Source={dbPath}").AddInterceptors(interceptors: readMaterializer));
            services.AddDbContext<VideoSwitchersWriteContext>(options => options.UseSqlite($"Data Source={dbPath}").AddInterceptors(interceptors: writeMaterializer));

            return services;
        }

        static IServiceCollection AddConnectionServices(this IServiceCollection services)
        { 
            services.AddSingleton<SwitcherRuntimeConnectionService>();
            services.AddSingleton<ISwitcherManagedConnectionService>(services => services.GetService<SwitcherRuntimeConnectionService>() ?? throw new NullReferenceException());
            services.AddSingleton<ISwitcherConnectionStatusService>(services => services.GetService<SwitcherRuntimeConnectionService>() ?? throw new NullReferenceException());
            services.AddSingleton<ISwitcherConnectionProviderService>(services => services.GetService<SwitcherRuntimeConnectionService>() ?? throw new NullReferenceException());
            return services;

        }
    }
}
