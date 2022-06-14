using KoBuApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace KoBuApp.Extensions
{
    public static class ConfigureServicesExtension
    {
        /// <summary>
        /// Add Entity Framework Core to DI
        /// </summary>
        /// <param name="connectionString">Connectionstring</param>
        public static void AddEntityFrameworkCore(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("YeetQuest"));
            });
        }

        /// <summary>
        /// Configure and add Swagger to DI
        /// </summary>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Yeet Quest API",
                    Description = "API backend for the Yeet Quest Application",
                    Version = "v1"
                });
            });
        }

        /// <summary>
        /// Configure and add Healthchecks to DI
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        public static void AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(connectionString: configuration.GetConnectionString("ApplicationDbConnection"), name: "database", failureStatus: HealthStatus.Unhealthy)
                .AddDbContextCheck<ApplicationDbContext>(name: "dbcontext", failureStatus: HealthStatus.Unhealthy);
        }
    }
}
