using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eSettPruebatecnica.Application.MarketParties.Queries.DistributionSystemOperator
{
    public class GetDistributionSystemOperatorsListQuery : IRequest<List<DistributionSystemOperatorsVM>>
    {
        public string _Code { get; set; } = String.Empty;
        public string _Country { get; set; } = String.Empty;
        public string _Name { get; set; } = String.Empty;

        public GetDistributionSystemOperatorsListQuery(string Code, string Country, string Name)
        {
            _Code = Code;
            _Country = Country;
            _Name = Name;
        }
    }
}
