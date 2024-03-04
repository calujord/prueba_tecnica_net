using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using eSettPruebatecnica.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Reflection.Emit;

namespace eSettPruebatecnica.Infrastructure.Persistence
{
    public class eSettDbContext: DbContext
    {
        private readonly ILogger<eSettDbContextSeed> _logger;
        public eSettDbContext(DbContextOptions<eSettDbContext> options, ILogger<eSettDbContextSeed> logger) : base(options)
        {
            _logger = logger;
            Database.EnsureCreated();
            SeedDatabase();                     
        }               
       
        public DbSet<BalanceResponsiblePartie>? BalanceResponsibleParties { get; set; }
        public DbSet<BalanceServiceProvider>? BalanceServiceProviders { get; set; }
        public DbSet<DistributionSystemOperator>? DistributionSystemOperators { get; set; }
        public DbSet<Retailer>? Retailers { get; set; }
        private void SeedDatabase()
        {
            try
            {
                eSettDbContextSeed.SeedAsync(this, _logger).Wait();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al sembrar la base de datos");
            }
        }
    }
}
