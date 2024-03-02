using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNet.Infraestructure;


namespace PruebaTecnicaNet.API.Queries;

public class SettlementBankQueries(SettlementBankContext context) : ISettlementBankQueries
{
    /// <summary>
    /// Get a settlement bank by its BIC
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<SettlementBank> GetSettlementBankAsync(string id)
    {
        var settlementBank = await context.SettlementBanks.FirstOrDefaultAsync(x => x.Bic == id);

        return settlementBank == null
            ? throw new KeyNotFoundException()
            : new SettlementBank
        {
            Bic = settlementBank.Bic,
            Country = settlementBank.Country,
            Name = settlementBank.Name,
        };
    }

    /// <summary>
    /// Get all settlement banks
    /// </summary>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
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
        return settlementBanks == null
            ? throw new KeyNotFoundException()
            : settlementBanks;
    }

    /// <summary>
    /// Get all settlement banks from eSett
    /// </summary>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<IEnumerable<SettlementBank>> GetSettlementBanksFromEsettAsync()
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://api.opendata.esett.com/EXP06/Banks");
        var eSettAPIClient = new eSettopendataAPIClient(httpClient);
        var banks = await eSettAPIClient.BanksAsync();

        return banks == null
            ? throw new KeyNotFoundException()
            : banks.Select(x => new SettlementBank
            {
                Bic = x.Bic,
                Country = x.Country,
                Name = x.Name,
            });
    }

}

