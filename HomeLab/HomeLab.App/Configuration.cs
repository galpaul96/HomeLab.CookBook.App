using AutoMapper;
using HomeLab.Api.Infra;
using HomeLab.App.Data;
using HomeLab.App.Models;
using HomeLab.Domain.Settings;
using HomeLab.Services;
using HomeLab.Services.Infra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HomeLab.App
{
    /// <summary>
    /// Configuration class
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Configure General Services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureGeneralServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureAppSettings(configuration);

            services.ConfigureIdentity(configuration);
            services.ConfigureSwagger(configuration);
            services.ConfigureAutoMapper(configuration);

            services.AddControllersWithViews();
            services.AddRazorPages();

            //services.ConfigureServices(configuration);
        }

        internal static void ConfigureAutoMapper(this IServiceCollection services,
            IConfiguration configuration)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApiMappingProfile());
                mc.AddProfile(new ServiceMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        internal static void ConfigureAppSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<IdentitySettings>(configuration.GetSection(nameof(IdentitySettings)));
            services.Configure<Configs>(configuration.GetSection(nameof(Configs)));
        }

        internal static void ConfigureSwagger(this IServiceCollection services,
            IConfiguration configuration)
        {
            var settings = new Configs();
            configuration.Bind(nameof(Configs), settings);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = settings.ServiceName, Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        internal static void ConfigureIdentity(this IServiceCollection services,
            IConfiguration configuration)
        {
            //var settings = new IdentitySettings();
            //configuration.Bind(nameof(IdentitySettings), settings);

            // Add services to the container.
            //var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("Users");
            });
            //options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer(options =>
            {
                options.IssuerUri = "https://localhost:44459";
            })
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();


        }
    }
}
