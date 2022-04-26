using EduTest.Infrastructure.Interfaces;
using EduTest.Infrastructure.Repositories;
using EduTest.Infrastructure.UnitOfWork;
using EduTest.Services.Interfaces;
using EduTest.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EduTest.Services.Extensions
{
    public static class InversionOfControlsExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IMatterService, MatterService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient(typeof(IUriService<>), typeof(UriService<>));
            services.AddTransient<IAuthService, AuthService>();

            return services;
        }
    }
}
