using HomeLab.Domain.Interfaces.Services;
using HomeLab.Ecosystem;
using HomeLab.EF;
using HomeLab.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HomeLab.Services
{
    public static class Configuration
    {
        public static void ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.TryAddScoped<IHealthChecksService, HealthChecksService>();

            services.ConfigureEcoSystemCommunicationService(configuration);
            services.ConfigureRepository(configuration);
        }
    }
}