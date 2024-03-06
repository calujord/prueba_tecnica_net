using Alicunde.PruebaTecnica.Data;
using Alicunde.PruebaTecnica.Models;

namespace Alicunde.PruebaTecnica.Repositories
{
    public interface IFeeRepository
    {
        Task<IEnumerable<Fee>> GetAllAsync();
        Task AddAsync(Fee fee);
        Task AddRangeAsync(IEnumerable<Fee> fee);
        Task<Fee?> GetByIdAsync(int id);
    }
}
