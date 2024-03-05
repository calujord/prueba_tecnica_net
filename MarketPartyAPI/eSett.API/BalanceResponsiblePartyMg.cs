using eSett.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSett.API
{
    public class BalanceResponsiblePartyMg : eSettAPIMg, I_APIeSettMg
    {
        /// <summary>
        /// Retrieves a list of BalanceResponsibleParties from eSett API
        /// </summary>
        /// <param name="code">filter by bspCode</param>
        /// <param name="country">filter by bspCountry</param>
        /// <param name="name">filter by bspName</param>
        /// <returns>List of I_MarketParty</returns>
        public List<I_MarketParty> Get(string? code = "", string? country = "", string? name = "")
        {
            return base.Get<BalanceResponsiblePartyDTO>(_api.BalanceResponsiblePartiesAsync(code, country, name), Fill);
        }

        I_MarketParty Fill(BalanceResponsiblePartyDTO item)
        {
            return new BalanceResponsibleParty()
            {
                Code = item.BrpCode,
                Name = item.BrpName,
                country = item.Country,
                codingScheme = item.CodingScheme,
                bussinesId = item.BusinessId,
                validityEnd = item.ValidityEnd,
                validityStart = item.ValidityStart
            };
        }
    }
}
