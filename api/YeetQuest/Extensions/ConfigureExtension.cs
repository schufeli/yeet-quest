using KoBuApp.Entities;
using Serilog;
using YeetQuest.Data;

namespace KoBuApp.Extensions
{
    public static class ConfigureExtension
    {
        /// <summary>
        /// Configure and initialize the development environment
        /// </summary>
        public static void InitDevelopmentEnvironment(this IApplicationBuilder app)
        {
            Log.Warning("Running in development environment!");

            app.UseDeveloperExceptionPage();

            // Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }

        /// <summary>
        /// Initialize the necessary databases
        /// </summary>
        public static void InitDatabases(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.EnsureCreated();
            var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            DbSeeder.Seed(context);
        }
    }
}
