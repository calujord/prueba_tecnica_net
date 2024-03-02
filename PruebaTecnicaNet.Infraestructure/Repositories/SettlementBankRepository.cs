using System;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Infraestructure.Repositories;

public class SettlementBankRepository(SettlementBankContext context) : ISettlementBankRepository
{
    private readonly SettlementBankContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public IUnitOfWork UnitOfWork => _context;

    public SettlementBank Add(SettlementBank settlementBank) => _context.SettlementBanks.Add(settlementBank).Entity;

    public async Task<SettlementBank> GetAsync(string Bic) => await _context.SettlementBanks.FindAsync(Bic);

    public void Update(SettlementBank settlementBank) => _context.SettlementBanks.Update(settlementBank);
}
