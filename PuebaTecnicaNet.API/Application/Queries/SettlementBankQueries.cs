using PruebaTecnicaNet.Infraestructure;

namespace PruebaTecnicaNet.API.Application.Queries;

public class SettlementBankQueries(SettlementBankContext context) : ISettlementBankQueries
{
    public async Task<SettlementBank> GetSettlementBankAsync(string id)
    {
        var settlementBank = await context.SettlementBanks.FirstOrDefaultAsync(x => x.Bic == id);

        return settlementBank == null ? throw new KeyNotFoundException() : new SettlementBank
        {
            Bic = settlementBank.Bic,
            Country = settlementBank.Country,
            Name = settlementBank.Name,
        };
    }

    public async Task<IEnumerable<SettlementBank>> GetSettlementBanksAsync()
    {
        var settlementBanks = await context.SettlementBanks
            .Select(x => new SettlementBank
            {
                Bic = x.Bic,
                Country = x.Country,
                Name = x.Name,
            })
            .ToListAsync();

        return settlementBanks == null ? throw new KeyNotFoundException() : (IEnumerable<SettlementBank>)settlementBanks;
    }

    public async Task<IEnumerable<SettlementBank>> GetSettlementBanksFromEsettAsync()
    {
        var eSettAPIClient = new eSettopendataAPIClient(new HttpClient());
        // eSettAPIClient.BaseUrl = new Uri("https://api.opendata.esett.com");
        var banks = await eSettAPIClient.BanksAsync();

        return banks == null ? throw new KeyNotFoundException() : banks.Select(x => new SettlementBank
        {
            Bic = x.Bic,
            Country = x.Country,
            Name = x.Name,
        });
    }
}
