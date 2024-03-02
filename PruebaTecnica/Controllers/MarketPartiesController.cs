using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Servicio.Interfaz;

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
        public IActionResult ObtenerDatosApi()
        {
            _logger.LogInformation("Entramos en el metodo");
            var result = _balance.Save();
            if (result.Data.CodigoResultado == 0)
            {
                return Ok(result.Data.Mensaje);
            }
            else if (result.Data.CodigoResultado==2) 
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
                return NotFound();
            }

        }
    }
}
