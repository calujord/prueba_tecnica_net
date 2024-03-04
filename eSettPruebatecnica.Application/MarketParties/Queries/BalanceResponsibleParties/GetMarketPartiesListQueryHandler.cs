using AutoMapper;
using eSettPruebatecnica.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Application.MarketParties.Queries.BalanceResponsibleParties
{
    internal class GetMarketPartiesListQueryHandler : IRequestHandler<GetMarketPartiesListQuery, List<BalanceResponsiblePartiesVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMarketPartiesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BalanceResponsiblePartiesVM>> Handle(GetMarketPartiesListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _unitOfWork.BalanceRespPartieRepository.GetBalanceResponsiblePartie(request._Code, request._Country, request._Name);

            return _mapper.Map<List<BalanceResponsiblePartiesVM>>(videoList);
        }
    }
}
