namespace PROJECT.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using PROJECT.Data;
    using PROJECT.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

  
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);
          //  SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Currencies.Any())
            {
                return;
            }

            data.Currencies.AddRange(new[]
            {
                new Currency { Name = "EUR" },
               new Currency { Name = "BGN" },
              new Currency { Name = "USD" },
              
            });

            data.SaveChanges();
        }

    //    private static void SeedAdministrator(IServiceProvider services)
    //    {
    //        var userManager = services.GetRequiredService<UserManager<User>>();
    //        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    //        Task
    //            .Run(async () =>
    //            {
    //                if (await roleManager.RoleExistsAsync(AdministratorRoleName))
    //                {
    //                    return;
    //                }

    //                var role = new IdentityRole { Name = AdministratorRoleName };

    //                await roleManager.CreateAsync(role);

    //                const string adminEmail = "admin@crs.com";
    //                const string adminPassword = "admin12";

    //                var user = new User
    //                {
    //                    Email = adminEmail,
    //                    UserName = adminEmail,
    //                    FullName = "Admin"
    //                };

    //                await userManager.CreateAsync(user, adminPassword);

    //                await userManager.AddToRoleAsync(user, role.Name);
    //            })
    //            .GetAwaiter()
    //            .GetResult();
    //    }
    
    }
}
