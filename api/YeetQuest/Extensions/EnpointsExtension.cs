using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Mime;
using System.Text.Json;

namespace KoBuApp.Extensions
{
    public static class EnpointsExtension
    {
        /// <summary>
        ///  Extension Method for MapHealtchChecks enables basic and detailed view of application and system health status
        /// </summary>
        /// <param name="pattern">Where the endpoint can be reached</param>
        public static void MapHealthChecksExtension(this IEndpointRouteBuilder endpoints, string pattern)
        {
            endpoints.MapHealthChecks(pattern);

            endpoints.MapHealthChecks($"{pattern}-details",
            new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonSerializer.Serialize(
                        new
                        {
                            status = report.Status.ToString(),
                            monitors = report.Entries.Select(e => new { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status) })
                        });
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            }
        );

        }
    }
}
