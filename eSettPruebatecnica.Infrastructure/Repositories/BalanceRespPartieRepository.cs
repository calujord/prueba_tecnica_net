using eSettPruebatecnica.Application.Contracts.Persistence;
using eSettPruebatecnica.Domain.Entities;
using eSettPruebatecnica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Infrastructure.Repositories
{
    public class BalanceRespPartieRepository : RepositoryBase<BalanceResponsiblePartie>, IBalanceRespPartieRepository
    {
        public BalanceRespPartieRepository(eSettDbContext context) : base(context)
        {
        }
        public async Task<List<BalanceResponsiblePartie>> GetBalanceResponsiblePartie(string code, string country, string name)
        {
            IQueryable<BalanceResponsiblePartie> query = _context.BalanceResponsibleParties!.AsQueryable();

            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(x => x.brpCode == code);
            }
            if (!string.IsNullOrEmpty(country))
            {
                query = query.Where(x => x.country == country);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.brpName == name);
            }

            List<BalanceResponsiblePartie> response = await query.ToListAsync();
            return response;          
        }  
    }
}
