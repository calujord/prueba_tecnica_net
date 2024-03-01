using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Domain.SettlementBankAggregate;

public interface ISettlementBankRepository : IRepository<SettlementBank>
{
    SettlementBank Add(SettlementBank settlementBank);
    void Update(SettlementBank settlementBank);
    Task<SettlementBank> GetAsync(int id);
}