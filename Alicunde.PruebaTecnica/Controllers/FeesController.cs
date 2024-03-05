using Alicunde.PruebaTecnica.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alicunde.PruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeesController : ControllerBase
    {
        private readonly EsettService _esettService;
        private readonly ILogger<FeesController> _logger;


        public FeesController(EsettService esettService, ILogger<FeesController> logger)
        {
            _esettService = esettService;
            _logger = logger;
        }

        [HttpGet(Name = "GetFees")]
        public async Task<IActionResult> GetFeesAsync()
        {
            try
            {
                var fees = await _esettService.GetFeesAsync();
                return Ok(fees);
            }
            catch (Exception ex)
        {
                _logger.LogError(ex, "Error fetching fees");
                return StatusCode(500, "Failed to fetch fees");
            }
        }
    }
}
