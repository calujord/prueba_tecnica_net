using eSett.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSett.API
{
    public class RetailerMg : eSettAPIMg, I_APIeSettMg
    {
        /// <summary>
        /// Retrieves a list of Retailers from eSett API
        /// </summary>
        /// <param name="code">filter by bspCode</param>
        /// <param name="country">filter by bspCountry</param>
        /// <param name="name">filter by bspName</param>
        /// <returns>List of I_MarketParty</returns>
        public List<I_MarketParty> Get(string? code = "", string? country = "", string? name = "")
        {
            return base.Get<RetailerDTO>(_api.RetailersAsync(code, country, name), Fill);
        }

        I_MarketParty Fill(RetailerDTO item)
        {
            return new Retailer()
            {
                Code = item.ReCode,
                Name = item.ReName,
                country = item.Country,
                codingScheme = item.CodingScheme
            };
        }
    }
}
