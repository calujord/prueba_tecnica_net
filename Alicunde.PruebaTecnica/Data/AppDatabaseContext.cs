using Alicunde.PruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace Alicunde.PruebaTecnica.Data
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Fee> Fees { get; set; }
    }
}
