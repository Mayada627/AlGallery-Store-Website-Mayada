using Microsoft.EntityFrameworkCore;
namespace AlGalleryStore.Data
{
    public class AlGalleryDbContext : DbContext
    {
        public AlGalleryDbContext(DbContextOptions<AlGalleryDbContext>options):base(options) 
        {
                
        }
    }
}
