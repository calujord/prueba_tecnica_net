using eSettPruebatecnica.Application.MarketParties.Queries;
using eSettPruebatecnica.Application.MarketParties.Queries.BalanceResponsibleParties;
using eSettPruebatecnica.Application.MarketParties.Queries.BalanceServiceProviders;
using eSettPruebatecnica.Application.MarketParties.Queries.DistributionSystemOperator;
using eSettPruebatecnica.Application.MarketParties.Queries.Retailer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace eSettPruebatecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketPartiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MarketPartiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetBalanceRespParties")]
        [ProducesResponseType(typeof(IEnumerable<BalanceResponsiblePartiesVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BalanceResponsiblePartiesVM>>> GetBalanceRespParties(string? code = null, string? country = null, string? name = null)
        {
            var query = new GetMarketPartiesListQuery(code,country,name);
            var response = await _mediator.Send(query);
            
            return Ok(response);
        }
       
        [HttpGet]
        [Route("GetBalanceServiceProviders")]
        [ProducesResponseType(typeof(IEnumerable<BalanceServiceProvidersVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BalanceServiceProvidersVM>>> GetBalanceServiceProviders(string? code = null, string? country = null, string? name = null)
        {
            var query = new GetBalanceServiceProvidersListQuery(code, country, name);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetDistributionSystemOperators")]
        [ProducesResponseType(typeof(IEnumerable<BalanceServiceProvidersVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BalanceServiceProvidersVM>>> GetDistributionSystemOperators(string? code = null, string? country = null, string? name = null)
        {
            var query = new GetDistributionSystemOperatorsListQuery(code, country, name);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetRetailers")]
        [ProducesResponseType(typeof(IEnumerable<RetailersVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<RetailersVM>>> GetRetailers(string? code = null, string? country = null, string? name = null)
        {
            var query = new GetRetailersListQuery(code, country, name);
            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
