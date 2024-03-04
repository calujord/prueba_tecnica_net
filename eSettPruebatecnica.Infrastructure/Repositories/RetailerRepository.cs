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
    public class RetailerRepository : RepositoryBase<Retailer>, IRetailerRepository
    {
        public RetailerRepository(eSettDbContext context) : base(context)
        {
        }
        public async Task<List<Retailer>> GetRetailer(string code, string country, string name)
        {
            IQueryable<Retailer> query = _context.Retailers!.AsQueryable();

            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(x => x.reCode == code);
            }
            if (!string.IsNullOrEmpty(country))
            {
                query = query.Where(x => x.country == country);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.reName == name);
            }

            List<Retailer> response = await query.ToListAsync();
            return response;
        }
    }
}
