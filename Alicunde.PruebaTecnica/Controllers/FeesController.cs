using Alicunde.PruebaTecnica.Models;
using Alicunde.PruebaTecnica.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        [HttpPost(Name = "SaveFees")]
        public async Task<IActionResult> SaveFees()
        {
            try
            {
                var feesData = await _esettService.GetFeesAsync();

                try
                {
                    FeesRS feesResponse = JsonSerializer.Deserialize<FeesRS>(feesData)!;

                }
                catch (Exception)
                {

                    throw;
                }

               

                    _dbContext.Fees.AddRange(feesResponse.);
                }

                await _dbContext.SaveChangesAsync();

                return Ok("Fees data saved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving fees data");
                return StatusCode(500, "Failed to save fees data");
            }
        }
    }
}
}
