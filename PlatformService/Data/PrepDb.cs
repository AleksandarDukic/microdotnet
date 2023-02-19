using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var context = new AppDbContext())
            {
                SeedData(context);
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                var platforms = new List<Platform>
                {
                new Platform
                {
                    Name = "Linux",
                    Publisher = "Finac",
                    Cost = "0.0"
                },
                new Platform
                {
                    Name = "Windows",
                    Publisher = "Bill Gejtc",
                    Cost = "167.99"
                }
                };
                context.Platforms.AddRange(platforms);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}