using HomeLab.Domain.Interfaces.Repositories;
using HomeLab.EF.Infra;
using HomeLab.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HomeLab.EF
{
    public static class Configuration
    {
        public static void ConfigureRepository(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.TryAddScoped<IRepository, Repository>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EfContext>(
                options =>
                options.UseInMemoryDatabase("HomeLab")
                    //options.UseNpgsql(
                    //    connectionString,
                    //   x => x.MigrationsAssembly("HomeLab.EF"))
                    );

        }
    }
}
