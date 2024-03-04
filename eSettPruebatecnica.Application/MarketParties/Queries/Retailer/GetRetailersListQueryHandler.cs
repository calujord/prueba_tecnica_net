using AutoMapper;
using eSettPruebatecnica.Application.Contracts.Persistence;
using eSettPruebatecnica.Application.MarketParties.Queries.Retailer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Application.MarketParties.Queries.Retailer
{
    public class GetRetailersListQueryHandler : IRequestHandler<GetRetailersListQuery, List<RetailersVM>>
    {
        private readonly IUnitOfWork _unitOfWork;      
        private readonly IMapper _mapper;

        public GetRetailersListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {           
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<RetailersVM>> Handle(GetRetailersListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _unitOfWork.RetailerRepository.GetRetailer(request._Code, request._Country, request._Name);

            return _mapper.Map<List<RetailersVM>>(videoList);
        }
    }
}
