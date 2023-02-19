using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        //private readonly AppDbContext _context;

        public PlatformRepo()
        {

        }
        public void CreatePlatform(Platform plat)
        {
            using (var context = new AppDbContext())
            {
                if(plat == null) 
                {
                    throw new ArgumentNullException(nameof(plat));
                }

                context.Platforms.Add(plat);
                context.SaveChanges();
            }
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            using (var context = new AppDbContext())
            {
                return context.Platforms.ToList();
            }
        }

        public Platform GetPlatformById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Platforms.FirstOrDefault(p => p.Id == id);

            }
        }


        /* Ovo nam izgleda ne treba jer ne uvezuje kontekste iz kontrolera, zato sto ne cuvamo kontekst u konstruktoru */
        public bool SaveChanges()
        {
            using (var context = new AppDbContext())
            {
                return (context.SaveChanges() >= 0);
            }
        }
    }
}