using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Infraestructure.Repositories
{
    internal class SettlementBankRepository : ISettlementBankRepository
    {
        private readonly SettlementBankContext _context = default!;

        public IUnitOfWork UnitOfWork => _context;

        public SettlementBank Add(SettlementBank settlementBank) => _context.SettlementBanks.Add(settlementBank).Entity;

        public async Task<SettlementBank> GetAsync(int id) => await _context.SettlementBanks.FindAsync(id);

        public void Update(SettlementBank settlementBank) => _context.SettlementBanks.Update(settlementBank);
    }
}
