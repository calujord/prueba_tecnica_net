using Alicunde.PruebaTecnica.Models;
using Alicunde.PruebaTecnica.Repositories;
using Alicunde.PruebaTecnica.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Alicunde.PruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeesController : ControllerBase
    {
        private readonly FeeService _feeService;
        private readonly ILogger<FeesController> _logger;


        public FeesController(FeeService feeService, ILogger<FeesController> logger)
        {
            _feeService = feeService;
            _logger = logger;

        }

        /// <summary>
        /// Retrieves fees from an external API.
        /// </summary>
        /// <returns>An action result containing the fetched fees.</returns>
        [HttpGet(Name = "GetFees")]
        public async Task<IActionResult> GetFeesAsync()
        {
            try
            {
                var fees = await _feeService.GetFeesFromExternalApiAsync();
                return Ok(fees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching fees");
                return StatusCode(500, "Failed to fetch fees");
            }
        }

        /// <summary>
        /// Saves fees to the database by replacing existing data with new data fetched from an external API. 
        /// Note: This method is intended for demo purposes only and will delete existing data before inserting new data.
        /// </summary>
        /// <returns>An action result indicating the success of the operation.</returns>
        [HttpPost(Name = "SaveFees")]
        public async Task<IActionResult> SaveFees()
        {
            try
            {
                await _feeService.ProcessAndSaveFeesAsync();
                return Ok("Fees data saved successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving fees data");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retrieves a fee by its ID.
        /// </summary>
        /// <param name="id">The ID of the fee to retrieve.</param>
        /// <returns>An action result containing the retrieved fee.</returns>
        [HttpGet("{id}", Name = "GetFeeById")]
        public async Task<IActionResult> GetFeeById(int id)
        {
            try
            {
                var fee = await _feeService.GetFeeByIdAsync(id);
                if (fee == null)
                {
                    return NotFound(); // Return 404 Not Found if fee with the given ID is not found
                }
                return Ok(fee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving fee by ID");
                return StatusCode(500);
            }
        }

    }
}
