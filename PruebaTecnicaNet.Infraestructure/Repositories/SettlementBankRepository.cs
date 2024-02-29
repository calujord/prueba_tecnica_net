namespace PruebaTecnicaNet.Infraestructure.Repositories
{
    internal class SettlementBankRepository : ISettlementBankRepository
    {
        private readonly SettlementBankContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public SettlementBank Add(SettlementBank settlementBank) => _context.SettlementBanks.Add(settlementBank).Entity;

        public Task<bool> ExistsAsync(int id) => _context.SettlementBanks.AnyAsync(e => e.Id == id);

        public Task<bool> ExistsByCodeAsync(string code) => _context.SettlementBanks.AnyAsync(e => e.Code == code);

        public Task<bool> ExistsByCodeAsync(string code, int id) => _context.SettlementBanks.AnyAsync(e => e.Code == code && e.Id != id);

        public Task<bool> ExistsByCodeAsync(string code, int? id) => _context.SettlementBanks.AnyAsync(e => e.Code == code && e.Id != id);

        public Task<bool> ExistsByCodeAsync(string code, int id, CancellationToken cancellationToken) => _context.SettlementBanks.AnyAsync(e => e.Code == code && e.Id != id, cancellationToken);

        public Task<bool> ExistsByCodeAsync(string code, int? id, CancellationToken cancellationToken) => _context.SettlementBanks.AnyAsync(e => e.Code == code && e.Id != id, cancellationToken);

        public Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken) => _context.SettlementBanks.AnyAsync(e => e.Code == code, cancellationToken);

        public Task<bool> ExistsByNameAsync(string name) => _context.SettlementBanks.AnyAsync(e => e.Name == name);

        public Task<List<SettlementBank>> FindAllAsync() => _context.SettlementBanks.ToListAsync();

        public async Task<SettlementBank> FindByIdAsync(int id) => await _context.SettlementBanks.FindAsync(id);

        public Task<SettlementBank> FindByNameAsync(string name) => _context.SettlementBanks.FirstOrDefaultAsync(e => e.Name == name);

        public void Update(SettlementBank settlementBank) => _context.SettlementBanks.Update(settlementBank);
    }
}
