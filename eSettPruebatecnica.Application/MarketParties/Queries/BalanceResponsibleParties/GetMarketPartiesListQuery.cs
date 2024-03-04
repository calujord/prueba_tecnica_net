using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eSettPruebatecnica.Application.MarketParties.Queries.BalanceResponsibleParties
{
    public class GetMarketPartiesListQuery : IRequest<List<BalanceResponsiblePartiesVM>>
    {
        public string _Code { get; set; } = string.Empty;
        public string _Country { get; set; } = string.Empty;
        public string _Name { get; set; } = string.Empty;

        public GetMarketPartiesListQuery(string Code, string Country, string Name)
        {
            _Code = Code;
            _Country = Country;
            _Name = Name;
        }
    }
}
