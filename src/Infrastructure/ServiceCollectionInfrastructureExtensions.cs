using Application.Services;
using Infrastructure.Database;
using Infrastructure.Interface;
using Infrastructure.Services;
using JJConsulting.Infisical.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            services.AddDbContext<SwitchersReadDbContext>(options => options.UseSqlite($"Data Source={dbPath}").AddInterceptors(interceptors: readMaterializer));
            services.AddDbContext<SwitchersWriteDbContext>(options => options.UseSqlite($"Data Source={dbPath}").AddInterceptors(interceptors: writeMaterializer));

            return services;
        }

        static IServiceCollection AddConnectionServices(this IServiceCollection services)
        { 
            services.AddSingleton<ClientCommandRuntimeConnectionService>();
            services.AddSingleton<IClientCommunicationStorage>(services => services.GetService<ClientCommandRuntimeConnectionService>() ?? throw new NullReferenceException());
            services.AddSingleton<IClientConnectionStatusService>(services => services.GetService<ClientCommandRuntimeConnectionService>() ?? throw new NullReferenceException());
            services.AddSingleton<IClientCommandConnectionProviderService>(services => services.GetService<ClientCommandRuntimeConnectionService>() ?? throw new NullReferenceException());
            return services;

        }

        static IServiceCollection AddVaultServices(this IServiceCollection services, IConfiguration configuration)
        {
            var config = MachineIdentityInfisicalConfig.FromConfiguration(configuration.GetSection("Vault"));
            
            return services;
        }
    }
}
