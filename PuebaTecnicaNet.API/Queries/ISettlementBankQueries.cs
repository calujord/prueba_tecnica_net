namespace PruebaTecnicaNet.API.Queries;

public interface ISettlementBankQueries
{
    Task<SettlementBank> GetSettlementBankAsync(string id);
    Task<IEnumerable<SettlementBank>> GetSettlementBanksAsync();
    Task<IEnumerable<SettlementBank>> GetSettlementBanksFromEsettAsync();
}