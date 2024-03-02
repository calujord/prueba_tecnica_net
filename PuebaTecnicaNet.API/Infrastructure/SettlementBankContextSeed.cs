namespace PruebaTecnicaNet.API.Infrastructure;

using PruebaTecnicaNet.API;
using PruebaTecnicaNet.Domain.SettlementBankAggregate;
using PruebaTecnicaNet.Infraestructure;
using System.Threading.Tasks;

public class SettlementBankContextSeed : IDbSeeder<SettlementBankContext>
{
    public async Task SeedAsync(SettlementBankContext context)
    {
        await context.SaveChangesAsync();
    }
}
