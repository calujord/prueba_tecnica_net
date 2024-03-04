using eSettPruebatecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Application.Contracts.Persistence
{
    public interface IRetailerRepository
    {
        Task<List<Retailer>> GetRetailer(string code, string country, string name);
    }
}
