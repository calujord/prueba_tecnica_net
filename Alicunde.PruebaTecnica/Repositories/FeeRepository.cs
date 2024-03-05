using Alicunde.PruebaTecnica.Models;

namespace Alicunde.PruebaTecnica.Repositories
{
    public class FeeRepository : IFeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Fee>> GetAllAsync()
        {
            return await _dbContext.Fees.ToListAsync();
        }

        public async Task AddAsync(Fee fee)
        {
            _dbContext.Fees.Add(fee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
