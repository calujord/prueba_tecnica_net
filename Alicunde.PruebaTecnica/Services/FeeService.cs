using Alicunde.PruebaTecnica.Data;
using Alicunde.PruebaTecnica.Models;
using Alicunde.PruebaTecnica.Repositories;
using AutoMapper;
using Newtonsoft.Json;

namespace Alicunde.PruebaTecnica.Services
{
    public interface IFeeService
    {
        Task<IEnumerable<FeeDTO>> GetFeesFromExternalApiAsync();
        Task ProcessAndSaveFeesAsync();
        Task<FeeDTO> GetFeeByIdAsync(int id);
    }

    public class FeeService : IFeeService
    {
        private readonly IFeeRepository _feeRepository;
        private readonly EsettService _esettService;
        private readonly IMapper _mapper;
        public FeeService(IFeeRepository feeRepository, EsettService esettService, IMapper mapper)
        {
            _feeRepository = feeRepository ?? throw new ArgumentNullException(nameof(feeRepository));
            _esettService = esettService ?? throw new ArgumentNullException(nameof(esettService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Retrieves fees from an external API asynchronously.
        /// </summary>
        /// <returns>An enumerable collection of fee DTOs.</returns>
        public async Task<IEnumerable<FeeDTO>> GetFeesFromExternalApiAsync()
        {
            // Call external API to get fees
            var response = await _esettService.GetFeesAsync();

            
            var feesResponse = JsonConvert.DeserializeObject<List<FeeDTO>>(response)!;

            // Return the mapped fee DTOs
            return feesResponse;
        }

        /// <summary>
        /// Retrieves fees from an external API, processes them, and saves them to the database asynchronously.
        /// </summary>
        /// <remarks>
        /// This method fetches fees from an external API, processes them if needed, and saves them to the database.
        /// </remarks>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ProcessAndSaveFeesAsync()
        {
            // Fetch fees from external API
            var fees = await GetFeesFromExternalApiAsync();

            // Map fee DTOs to domain entities
            var feeEntities = _mapper.Map<IEnumerable<Fee>>(fees);

            // Save fees to the database
            await _feeRepository.AddRangeAsync(feeEntities);
        }

        /// <summary>
        /// Retrieves a fee by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the fee to retrieve.</param>
        /// <returns>The DTO of the fee corresponding to the provided ID.</returns>
        public async Task<FeeDTO> GetFeeByIdAsync(int id)
        {
            // Fetch fee from the repository by its ID
            var feeEntity = await _feeRepository.GetByIdAsync(id);

            // Map fee entity to DTO
            var feeDTO = _mapper.Map<FeeDTO>(feeEntity);

            return feeDTO;
        }
    }
}
