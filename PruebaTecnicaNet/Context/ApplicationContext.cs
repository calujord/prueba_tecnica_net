using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNet.Entities;

namespace PruebaTecnicaNet.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Mapeo de la tabla Fee.
        /// </summary>
        public DbSet<FeeDB> Fee { get; set; }
    }
}
