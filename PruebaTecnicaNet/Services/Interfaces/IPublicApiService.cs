using PruebaTecnicaNet.Models;

namespace PruebaTecnicaNet.Services.Interfaces
{
    /// <summary>
    /// Public API Service
    /// </summary>
    public interface IPublicApiService
    {
        /// <summary>
        /// Get all fees from the public API. 
        /// </summary>
        Task<List<Fee>?> GetDataOfPublicApi();
    }
}
