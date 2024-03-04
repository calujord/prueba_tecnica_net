using AutoMapper;
using eSettPruebatecnica.Application.MarketParties.Queries;
using eSettPruebatecnica.Application.MarketParties.Queries.BalanceResponsibleParties;
using eSettPruebatecnica.Application.MarketParties.Queries.BalanceServiceProviders;
using eSettPruebatecnica.Application.MarketParties.Queries.DistributionSystemOperator;
using eSettPruebatecnica.Application.MarketParties.Queries.Retailer;
using eSettPruebatecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BalanceResponsiblePartie, BalanceResponsiblePartiesVM>();
            CreateMap<BalanceServiceProvider, BalanceServiceProvidersVM>();
            CreateMap<DistributionSystemOperator, DistributionSystemOperatorsVM>();
            CreateMap<Retailer, RetailersVM>();
        }
    }
}
