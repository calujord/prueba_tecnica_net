using eSett.Model;

namespace eSett.API
{
    public class BalanceServiceProviderMg : eSettAPIMg, I_APIeSettMg
    {
        /// <summary>
        /// Retrieves a list of BalanceServiceProviders from eSett API
        /// </summary>
        /// <param name="code">filter by bspCode</param>
        /// <param name="country">filter by bspCountry</param>
        /// <param name="name">filter by bspName</param>
        /// <returns>List of I_MarketParty</returns>
        public List<I_MarketParty> Get(string? code = "", string? country = "", string? name = "")
        {
            return base.Get<BalanceServiceProviderDTO>(_api.BalanceServiceProvidersAsync(code, country, name), Fill);
        }

        I_MarketParty Fill(BalanceServiceProviderDTO item)
        {
            return new BalanceServiceProvider()
            {
                Code = item.BspCode,
                Name = item.BspName,
                country = item.Country,
                codingScheme = item.CodingScheme,
                bussinesId = item.BusinessId
            };
        }
    }
}
