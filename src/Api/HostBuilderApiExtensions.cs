using Infrastructure.Logger;
using JJConsulting.Infisical.Configuration;

namespace Api
{
    public static class HostBuilderApiExtensions
    {
        public static IHostBuilder AddHostServices(this IHostBuilder builder, IConfiguration configuration)
        {
            return builder.AddVault(configuration).AddLogger(configuration);
        }

        static IHostBuilder AddVault(this IHostBuilder builder, IConfiguration configuration)
        {
            var config = MachineIdentityInfisicalConfig.FromConfiguration(configuration.GetSection("Vault"));

            builder.AddInfisical(config);

            return builder;
        }

        static IHostBuilder AddLogger(this IHostBuilder builder, IConfiguration configuration)
        {
            builder.ConfigureLogging(configureLogging: (loggingBuilder) =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.Services.AddLoggerServices(configuration);
            });

            return builder;
        }
    }
}
