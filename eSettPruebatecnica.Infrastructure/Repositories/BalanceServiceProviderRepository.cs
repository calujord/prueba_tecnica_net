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
    public class BalanceServiceProviderRepository : RepositoryBase<BalanceServiceProvider>, IBalanceServiceProviderRepository
    {
        public BalanceServiceProviderRepository(eSettDbContext context) : base(context)
        {
        }
        public async Task<List<BalanceServiceProvider>> GetBalanceServiceProvider(string code, string country, string name)
        {
            IQueryable<BalanceServiceProvider> query = _context.BalanceServiceProviders!.AsQueryable();

            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(x => x.bspCode == code);
            }
            if (!string.IsNullOrEmpty(country))
            {
                query = query.Where(x => x.country == country);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.bspName == name);
            }

            List<BalanceServiceProvider> response = await query.ToListAsync();
            return response;          
        }      
    }
}
