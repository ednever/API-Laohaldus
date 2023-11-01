using Microsoft.EntityFrameworkCore;

namespace API_Laohaldus.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public DbSet<Soiduauto> Soiduautod { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
