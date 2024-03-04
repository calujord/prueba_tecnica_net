using AutoMapper;
using eSettPruebatecnica.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Application.MarketParties.Queries.BalanceServiceProviders
{
    internal class GetBalanceServiceProvidersListQueryHandler : IRequestHandler<GetBalanceServiceProvidersListQuery, List<BalanceServiceProvidersVM>>
    {
        private readonly IUnitOfWork _unitOfWork;      
        private readonly IMapper _mapper;

        public GetBalanceServiceProvidersListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {           
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BalanceServiceProvidersVM>> Handle(GetBalanceServiceProvidersListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _unitOfWork.BalanceServiceProviderRepository.GetBalanceServiceProvider(request._Code, request._Country, request._Name);

            return _mapper.Map<List<BalanceServiceProvidersVM>>(videoList);
        }
    }
}
