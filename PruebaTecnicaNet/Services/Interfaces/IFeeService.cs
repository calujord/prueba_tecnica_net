using PruebaTecnicaNet.Helpers;
using PruebaTecnicaNet.Models;

namespace PruebaTecnicaNet.Services.Interfaces
{
    /// <summary>
    /// Fee Service
    /// </summary>
    public interface IFeeService
    {
        /// <summary>
        /// Save fees obtained from the public API.
        /// </summary>
        Task<ResultState> SaveFees();

        /// <summary>
        /// Get all fees. 
        /// </summary>
        Task<List<Fee>?> GetAllFees();

        /// <summary>
        /// Get the Fee by its identifier.
        /// </summary>
        Task<Fee?> GetFee(int id);
    }
}
