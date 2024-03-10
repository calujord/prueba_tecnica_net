using PruebaTecnicaNet.Helpers;
using PruebaTecnicaNet.Models;
using PruebaTecnicaNet.Repository.Interfaces;
using PruebaTecnicaNet.Services.Interfaces;

namespace PruebaTecnicaNet.Services
{
    public class FeeService : IFeeService
    {
        /// <summary>
        /// The Fee repository
        /// </summary>
        private readonly IFeeRepository _feeRepository;

        /// <summary>
        /// The Public Api sevice
        /// </summary>
        private readonly IPublicApiService _publicApiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeeService"/> and the <see cref="PublicApiService"/>.
        /// </summary>
        /// <param name="feeRepository">The fee repository.</param>
        /// <param name="publicApiService">The public Api service.</param>
        public FeeService(IFeeRepository feeRepository, IPublicApiService publicApiService)
        {
            _feeRepository = feeRepository;
            _publicApiService = publicApiService;
        }

        /// <summary>
        /// Get all fees. 
        /// </summary>
        public async Task<List<Fee>?> GetAllFees()
        {
            return await _feeRepository.GetAll();
        }

        /// <summary>
        /// Get the Fee by its identifier.
        /// </summary>
        public async Task<Fee?> GetFee(int id)
        {
            return await _feeRepository.Get(id);
        }

        /// <summary>
        /// Save fees obtained from the public API.
        /// </summary>
        public async Task<ResultState> SaveFees()
        {
            var result = await _publicApiService.GetDataOfPublicApi();
            if (result == null)
            {
                return ResultState.Error;
            }
            else if (result.Count == 0)
            {
                return ResultState.NoData;
            }

            await _feeRepository.Add(result);
            return ResultState.Success;
        }
    }
}
