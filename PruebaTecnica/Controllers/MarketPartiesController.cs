using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Servicio.Interfaz;
using System.Diagnostics.Metrics;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("MarketPartiesController")]
    public class MarketPartiesController : ControllerBase
    {
        private readonly ILogger<MarketPartiesController> _logger;
        private readonly IBalanceResponsiblePartyService _balance;

        public MarketPartiesController(ILogger<MarketPartiesController> logger, IBalanceResponsiblePartyService balance)
        {
            _logger = logger;
            _balance = balance;
        }


        [HttpGet("ObtenerDatosApi")]
        public IActionResult ObtenerDatosApi([FromQuery]string code=null, [FromQuery] string country=null, [FromQuery] string name=null)
        {
            _logger.LogInformation("Entramos en el metodo");
            var result = _balance.Save(code,country,name);
            if (result.Data.CodigoResultado == 0)
            {
                return Ok(result.Data.Mensaje);
            }
            else if (result.Data.CodigoResultado == 2)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Data/{id}")]
        public IActionResult GetDataById(int id)
        {
            _logger.LogInformation("Entramos en el método");

            var result = _balance.GetData(id);

            if (result.Data.CodigoResultado == 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NoContent();
            }

        }
    }
}
