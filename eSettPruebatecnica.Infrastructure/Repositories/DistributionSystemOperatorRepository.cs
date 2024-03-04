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
    public class DistributionSystemOperatorRepository : RepositoryBase<DistributionSystemOperator>, IDistributionSystemOperatorRepository
    {
        public DistributionSystemOperatorRepository(eSettDbContext context) : base(context)
        {
        }
        public async Task<List<DistributionSystemOperator>> GetDistributionSystemOperator(string code, string country, string name)
        {
            IQueryable<DistributionSystemOperator> query = _context.DistributionSystemOperators!.AsQueryable();

            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(x => x.dsoName == code);
            }
            if (!string.IsNullOrEmpty(country))
            {
                query = query.Where(x => x.country == country);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.dsoName == name);
            }

            List<DistributionSystemOperator> response = await query.ToListAsync();
            return response;
        }
    }
}
