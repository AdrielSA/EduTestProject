using EduTest.Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduTest.Services.Extensions
{
    public static class OptionsConfigExtension
    {
        public static IServiceCollection AddOptionsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(e => configuration.GetSection("PaginationOptions").Bind(e));

            return services;
        }
    }
}
