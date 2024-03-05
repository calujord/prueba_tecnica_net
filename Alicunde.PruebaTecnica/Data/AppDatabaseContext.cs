using Alicunde.PruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace Alicunde.PruebaTecnica.Data
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<Fee> Fees { get; set; }
    }
}
