using eSettPruebatecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Application.Contracts.Persistence
{
    public interface IBalanceServiceProviderRepository : IAsyncRepository<BalanceServiceProvider>
    {
        Task<List<BalanceServiceProvider>> GetBalanceServiceProvider(string code, string country, string name);
    }
}
