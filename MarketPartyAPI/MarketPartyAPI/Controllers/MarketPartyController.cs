using eSett.Model;
using Microsoft.AspNetCore.Mvc;

using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketPartyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarketPartyController : ControllerBase
    {
        [ActionName("ImportRetailer")]
        [HttpGet]
        public HttpStatusCode ImportRetailer()
        {
            if (eSett.Manager.RetailerMg.RMg.Import())
                return HttpStatusCode.OK;
            else
                return HttpStatusCode.InternalServerError;
        }
        [ActionName("GetRetailer")]
        [HttpGet("{id}")]
        public Retailer? GetRetailer(int id)
        {
            return eSett.Manager.RetailerMg.RMg.Get(id) ?? new Retailer() { Code = HttpStatusCode.NoContent.ToString() };
        }


        [ActionName("ImportDistributionSystemOperator")]
        [HttpGet]
        public HttpStatusCode ImportDSO()
        {
            if (eSett.Manager.DistributionSystemOperatorMg.DSOMg.Import())
                return HttpStatusCode.OK;
            else
                return HttpStatusCode.InternalServerError;
        }
        [ActionName("GetDistributionSystemOperator")]
        [HttpGet("{id}")]
        public DistributionSystemOperator? GetDSO(int id)
        {
            return eSett.Manager.DistributionSystemOperatorMg.DSOMg.Get(id) ?? new DistributionSystemOperator() { Code = HttpStatusCode.NoContent.ToString() };
        }


        [ActionName("ImportBalanceServiceProvider")]
        [HttpGet]
        public HttpStatusCode ImportBSP()
        {
            if (eSett.Manager.BalanceServiceProviderMg.BSPMg.Import())
                return HttpStatusCode.OK;
            else
                return HttpStatusCode.InternalServerError;
        }
        [ActionName("GetBalanceServiceProvider")]
        [HttpGet("{id}")]
        public BalanceServiceProvider? GetBSP(int id)
        {
            return eSett.Manager.BalanceServiceProviderMg.BSPMg.Get(id) ?? new BalanceServiceProvider() { Code = HttpStatusCode.NoContent.ToString() };
        }


        [ActionName("ImportBalanceResponsibleParty")]
        [HttpGet]
        public HttpStatusCode ImportBRP()
        {
            if (eSett.Manager.BalanceResponsiblePartyMg.BRPMg.Import())
                return HttpStatusCode.OK;
            else
                return HttpStatusCode.InternalServerError;
        }
        [ActionName("GetBalanceResponsibleParty")]
        [HttpGet("{id}")]
        public BalanceResponsibleParty? GetBRP(int id)
        {
            return eSett.Manager.BalanceResponsiblePartyMg.BRPMg.Get(id) ?? new BalanceResponsibleParty() { Code = HttpStatusCode.NoContent.ToString() };
        }

    }
}
