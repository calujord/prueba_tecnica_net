using Alicunde.PruebaTecnica.Models;

namespace Alicunde.PruebaTecnica.Repositories
{
    public interface IFeeRepository
    {
        public interface IFeeRepository
        {
            Task<IEnumerable<Fee>> GetAllAsync();
            Task AddAsync(Fee fee);
            Task GetByIdAsync(Fee fee);
        }
    }
}
