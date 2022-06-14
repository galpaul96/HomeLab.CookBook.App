using HomeLab.Domain.Interfaces.Services;
using HomeLab.Ecosystem.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HomeLab.Ecosystem
{
    public static class Configuration
    {
        public static void ConfigureEcoSystemCommunicationService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpClient();

            services.TryAddScoped<IApiClient, ApiClient>();

        }
    }
}
