using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Application.MarketParties.Queries.BalanceResponsibleParties
{
    public class BalanceResponsiblePartiesVM
    {
        public string? brpCode { get; set; }
        public string? brpName { get; set; }
        public string? country { get; set; }
        public string? businessId { get; set; }
        public string? codingScheme { get; set; }
        public string? validityStart { get; set; }
        public string? validityEnd { get; set; }
    }
}
