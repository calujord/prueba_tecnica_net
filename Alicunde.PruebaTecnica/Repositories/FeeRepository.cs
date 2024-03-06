using Alicunde.PruebaTecnica.Data;
using Alicunde.PruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace Alicunde.PruebaTecnica.Repositories
{
    /// <summary>
    /// Repository implementation for managing Fee entities.
    /// </summary>
    public class FeeRepository : IFeeRepository
    {
        private readonly AppDatabaseContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeeRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public FeeRepository(AppDatabaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Adds a collection of fees to the database asynchronously.
        /// </summary>
        /// <param name="fees">The collection of fees to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddRangeAsync(IEnumerable<Fee> fees)
        {
            _dbContext.Fees.AddRange(fees);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all fees from the database asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with the collection of fees.</returns>
        public async Task<IEnumerable<Fee>> GetAllAsync()
        {
            return await _dbContext.Fees.ToListAsync();
        }

        /// <summary>
        /// Adds a single fee to the database asynchronously.
        /// </summary>
        /// <param name="fee">The fee to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(Fee fee)
        {
            _dbContext.Fees.Add(fee);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a fee by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the fee to retrieve.</param>
        /// <returns>A task representing the asynchronous operation with the retrieved fee.</returns>
        public async Task<Fee?> GetByIdAsync(int id)
        {
            return await _dbContext.Fees.FindAsync(id);
        }
    }
}
