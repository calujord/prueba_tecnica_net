using eSett.Model;

namespace eSett.API
{
    public class DistributionSystemOperatorMg : eSettAPIMg, I_APIeSettMg
    {
        /// <summary>
        /// Retrieves a list of DistributionSystemOperators from eSett API
        /// </summary>
        /// <param name="code">filter by bspCode</param>
        /// <param name="country">filter by bspCountry</param>
        /// <param name="name">filter by bspName</param>
        /// <returns>List of I_MarketParty</returns>
        public List<I_MarketParty> Get(string? code = "", string? country = "", string? name = "")
        {
            return base.Get<DistributionSystemOperatorDTO>(_api.DistributionSystemOperatorsAsync(code, country, name), Fill);
        }

        I_MarketParty Fill(DistributionSystemOperatorDTO item)
        {
            return new DistributionSystemOperator()
            {
                Code = item.DsoCode,
                Name = item.DsoName,
                country = item.Country,
                codingScheme = item.CodingScheme
            };
        }
    }
}
