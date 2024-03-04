using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Application.MarketParties.Queries.BalanceServiceProviders
{
    public class BalanceServiceProvidersVM
    {
        public string bspCode { get; set; } = String.Empty;
        public string bspName { get; set; } = String.Empty;
        public string country { get; set; } = String.Empty;
        public string businessId { get; set; } = String.Empty;
        public string codingScheme { get; set; } = String.Empty;
    }
}
