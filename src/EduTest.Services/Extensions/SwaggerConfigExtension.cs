using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EduTest.Services.Extensions
{
    public static class SwaggerConfigExtension
    {
        public static IServiceCollection AddSwagguerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EduTest.API", Version = "v1" });
            });

            return services;
        }
    }
}
