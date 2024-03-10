using PruebaTecnicaNet.Models;

namespace PruebaTecnicaNet.Repository.Interfaces
{
    public interface IFeeRepository
    {
        /// <summary>
        /// Get all Fees.
        /// </summary>
        Task<List<Fee>?> GetAll();

        /// <summary>
        /// Get the Fee by its identifier.
        /// </summary>
        Task<Fee?> Get(int id);

        /// <summary>
        /// Saves the entered fee.
        /// </summary>
        Task<int> Add(List<Fee> fees);
    }
}
