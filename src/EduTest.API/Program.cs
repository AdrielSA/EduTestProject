using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace EduTest.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;



            //    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            //    var alfonso = new IdentityUser { Email = "alfonso.evangelista@intec.edu.do", UserName = "alfonso", EmailConfirmed = true };
            //    var juan = new IdentityUser { Email = "juan.perez@intec.edu.do", UserName = "juan", EmailConfirmed = true };
            //    await userManager.CreateAsync(alfonso, "Km8291(*)");
            //    await userManager.CreateAsync(juan, "Km8291(*)");



            //    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            //    await roleManager.CreateAsync(new IdentityRole { Name = "Adm" });
            //    await roleManager.CreateAsync(new IdentityRole { Name = "Stu" });



            //    await userManager.AddToRoleAsync(alfonso, "Adm");
            //    await userManager.AddToRoleAsync(juan, "Stu");
            //}

            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
