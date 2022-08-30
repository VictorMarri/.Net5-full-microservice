using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.API.Models;
using System.Linq;

namespace PlatformService.API.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                System.Console.WriteLine(" --> SEEDING DATA...");

                context.Platforms.AddRange(
                    new Platform { Name = ".Net", Publisher = "Microsoft", Cost = "Gratis"},
                    new Platform { Name = "Linux", Publisher = "Linus Torvalds", Cost = "Gratis" },
                    new Platform { Name = "SQLServer", Publisher = "Microsoft", Cost = "Gratis" },
                    new Platform { Name = "Kubernetes", Publisher = "CNCF Foundation", Cost = "Gratis" }
                );

                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine(" --> We already have data");
            }
        }
    }
}
