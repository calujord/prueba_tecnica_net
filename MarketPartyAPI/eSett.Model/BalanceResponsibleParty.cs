using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSett.Model
{
    public class BalanceResponsibleParty : MarketParty, I_MarketParty
    {
        public string bussinesId { get; set; }

        public string validityEnd { get; set; }

        public string validityStart { get; set; }
    }
}
