using API_Laohaldus.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Laohaldus.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Kategooria> Kategooriad { get; set; }
        public DbSet<Toode> Tooted { get; set; }
        public DbSet<Tellimus> Tellimused { get; set; }
        public DbSet<Kasutaja> Kasutajad { get; set; }
        public DbSet<Arve> Arved { get; set; }
        public DbSet<TellimusArves> TellimusedArves { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
