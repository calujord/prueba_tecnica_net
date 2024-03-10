using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNet.Context;
using PruebaTecnicaNet.Helpers;
using PruebaTecnicaNet.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNet.Controllers
{
    /// <summary>
    /// The fees controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FeeController : ControllerBase
    {
        /// <summary>
        /// The fees service.
        /// </summary>
        private readonly IFeeService _feeService;

        /// <summary>
        /// Constructor of controller.
        /// </summary>
        public FeeController(IFeeService feeService)
        {
            _feeService = feeService;
        }

        /// <summary>
        /// Gets all the fees in the database.
        /// </summary>
        /// <returns>List of all the fees in the database.</returns>
        /// <response code="200">Returns 200 and the list fees.</response>
        /// <response code="204">Returns 204 if there are no fees in the database.</response>
        /// <response code="400">Returns 400 if there has been any problem.</response>
        [HttpGet("GetAllFees")]
        public async Task<IActionResult> GetFees()
        {
            try
            {
                var result = await _feeService.GetAllFees();
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Gets the Fee data by searching by identifier.
        /// </summary>
        /// <param name="feeId">Fee identity.</param>
        /// <returns>The data of the fee searched.</returns>
        /// <response code="200">Returns 200 and the fee data searched.</response>
        /// <response code="204">Returns 204 if have not found the fee.</response>
        /// <response code="400">Returns 400 if there has been any problem.</response>
        [HttpGet("GetFee/{feeId}")]
        public async Task<IActionResult> GetFee([Required] int feeId)
        {
            try
            {
                var result = await _feeService.GetFee(feeId);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Gets the fees from the public api and stores them in the database.
        /// </summary>
        /// <returns>Operation result message.</returns>
        /// <response code="200">Returns 200 and a message of success.</response>
        /// <response code="204">Returns 204 if there are no fees in the public API.</response>
        /// <response code="400">Returns 400 if there has been any problem.</response>
        [HttpGet("SaveDataOfAPI")]
        public async Task<IActionResult> SaveDataOfAPI()
        {
            try
            {
                var result = await _feeService.SaveFees();

                switch (result)
                {
                    case ResultState.Success:
                        return Ok("The fees obtained from the public API have been saved successfully !");
                    case ResultState.NoData:
                        return NoContent();
                    default:
                        return BadRequest();
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
