namespace PruebaTecnicaNet.Domain.SettlementBankAggregate;

public interface ISettlementBankRepository : IRepository<SettlementBank>
{
    SettlementBank Add(SettlementBank settlementBank);
    void Update(SettlementBank settlementBank);
    Task<SettlementBank> FindByIdAsync(int id);
    Task<SettlementBank> FindByNameAsync(string name);
    Task<List<SettlementBank>> FindAllAsync();
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> ExistsByCodeAsync(string code);
    Task<bool> ExistsByCodeAsync(string code, int id);
    Task<bool> ExistsByCodeAsync(string code, int? id);
    Task<bool> ExistsByCodeAsync(string code, int id, CancellationToken cancellationToken);
    Task<bool> ExistsByCodeAsync(string code, int? id, CancellationToken cancellationToken);
    Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken);
}