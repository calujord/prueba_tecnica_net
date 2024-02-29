namespace PruebaTecnicaNet.Domain.SettlementBankAggregate;

public interface ISettlementBankRepository : IRepository<SettlementBank>
{
    SettlementBank Add(SettlementBank settlementBank);
    void Update(SettlementBank settlementBank);
    Task<SettlementBank> FindByIdAsync(Guid id);
    Task<SettlementBank> FindByNameAsync(string name);
    Task<List<SettlementBank>> FindAllAsync();
    Task<bool> ExistsAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> ExistsByCodeAsync(string code);
    Task<bool> ExistsByCodeAsync(string code, Guid id);
    Task<bool> ExistsByCodeAsync(string code, Guid? id);
    Task<bool> ExistsByCodeAsync(string code, Guid id, CancellationToken cancellationToken);
    Task<bool> ExistsByCodeAsync(string code, Guid? id, CancellationToken cancellationToken);
    Task<bool> ExistsByCodeAsync(string code, CancellationToken cancellationToken);
}