using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
/*         public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) 
        {

        } 
 */

        protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "InMem");
        }
        public DbSet<Platform> Platforms {get; set;} 

    }
}

