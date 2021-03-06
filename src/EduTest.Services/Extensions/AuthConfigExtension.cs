using EduTest.Domain.Enums;
using EduTest.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace EduTest.Services.Extensions
{
    public static class AuthConfigExtension
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            }).AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<EduTestDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };

                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = false;
            });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRequire", policy =>
                    policy.RequireRole(nameof(Roles.Administrator)));
            });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("StudentRequire", policy =>
                    policy.RequireRole(nameof(Roles.Student)));
            });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("StudentOrAdminRequire", policy =>
                    policy.RequireRole(nameof(Roles.Administrator), nameof(Roles.Student)));
            });

            return services;
        }
    }
}
