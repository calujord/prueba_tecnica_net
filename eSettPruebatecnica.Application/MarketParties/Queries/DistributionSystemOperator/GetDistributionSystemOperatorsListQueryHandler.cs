using AutoMapper;
using eSettPruebatecnica.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Application.MarketParties.Queries.DistributionSystemOperator
{
    public class GetDistributionSystemOperatorsListQueryHandler : IRequestHandler<GetDistributionSystemOperatorsListQuery, List<DistributionSystemOperatorsVM>>
    {
        private readonly IUnitOfWork _unitOfWork;      
        private readonly IMapper _mapper;

        public GetDistributionSystemOperatorsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {           
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DistributionSystemOperatorsVM>> Handle(GetDistributionSystemOperatorsListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _unitOfWork.DistributionSystemOperatorRepository.GetDistributionSystemOperator(request._Code, request._Country, request._Name);

            return _mapper.Map<List<DistributionSystemOperatorsVM>>(videoList);
        }
    }
}
