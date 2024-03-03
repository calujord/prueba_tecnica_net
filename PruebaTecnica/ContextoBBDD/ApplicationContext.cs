using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace PruebaTecnica.ContextoBBDD
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        //Agregamos los modelos en esta parte
        public DbSet<BalanceResponsibleParty> BalanceResponsibles { get; set; }
    }
}
