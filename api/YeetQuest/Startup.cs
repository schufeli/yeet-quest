using KoBuApp.Extensions;
using System.Text.Json.Serialization;

namespace KoBuApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddEntityFrameworkCore(_configuration.GetConnectionString("ApplicationDbConnection"));

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            services.AddSwagger();

            services.AddHealthChecks(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        { 
            if (env.IsDevelopment())
            {
                app.InitDevelopmentEnvironment();
                app.InitDatabases();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecksExtension("healthcheck");
            });
        }
    }
}
