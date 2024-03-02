using Microsoft.AspNetCore.Http.HttpResults;
using PruebaTecnicaNet.API.Application.Commands;
using SettlementBank = PruebaTecnicaNet.API.Application.Queries.SettlementBank;

namespace PruebaTecnicaNet.API;

[Route("/api/settlementbanks")]
public static class PruebaTecnicaNetApi
{
    public static RouteGroupBuilder MapPruebaTecnicaNetApi(this RouteGroupBuilder app)
    {
        app.MapGet("/api/settlementbanks", GetsettlementbanksAsync);
        app.MapGet("/api/settlementbanks/{id}", GetsettlementbankAsync);
        // This end point is to load the settlement banks from the esett API and save them in the database
        app.MapGet("/api/settlementbanks/esett", GetSettlementBanksFromEsettAsync);

        return app;
    }

    /// <summary>
    /// Get all the settlement banks
    /// </summary>
    /// <param name="services"></param>
    /// <returns> A list of settlement banks </returns>
    /// <response code="200">Returns a list of settlement banks</response>
    /// <response code="404">If there are no settlement banks</response>
    /// <response code="500">If there was an error</response>
    [HttpGet]
    [Route("/api/settlementbanks")]
    [ProducesResponseType(typeof (IEnumerable<SettlementBank>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    private static async Task<Ok<IEnumerable<SettlementBank>>> GetsettlementbanksAsync([AsParameters] SettlementBankServices services)
    {
        var settlementBanks = await services.Queries.GetSettlementBanksAsync();
        return TypedResults.Ok(settlementBanks);
    }

    /// <summary>
    /// Get a settlement bank by its id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="services"></param>
    /// <returns> A settlement bank </returns>
    /// <response code="200">Returns a settlement bank</response>
    /// <response code="404">If the settlement bank was not found</response>
    /// <response code="500">If there was an error</response>
    [HttpGet]
    [Route("/api/settlementbanks/{id}")]
    [ProducesResponseType(typeof (SettlementBank), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    private static async Task<Results<Ok<SettlementBank>, NotFound>> GetsettlementbankAsync([FromRoute] string id, [AsParameters] SettlementBankServices services)
    {
        try
        { 
            var settlementBank = await services.Queries.GetSettlementBankAsync(id);
            return TypedResults.Ok(settlementBank);
        }
        catch 
        {
            return TypedResults.NotFound();
        }
    }

    /// <summary>
    /// Load the settlement banks from the esett API and save them in the database
    /// </summary>
    /// <param name="services"></param>
    /// <returns> A list of settlement banks </returns>
    /// <response code="200">Returns a list of settlement banks</response>
    /// <response code="500">If there was an error</response>
    [HttpGet]
    [Route("/api/settlementbanks/esett")]
    [ProducesResponseType(typeof (IEnumerable<SettlementBank>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    private static async Task<Ok<IEnumerable<SettlementBank>>> GetSettlementBanksFromEsettAsync([AsParameters] SettlementBankServices services)
    {
        var settlementBanks = await services.Queries.GetSettlementBanksFromEsettAsync();
        // Save the settlement banks in the database with one command per bank
        foreach (var bank in settlementBanks)
        {
            var command = new CreateSettlementBankCommand(bank.Bic, bank.Name, bank.Country);
            await services.Mediator.Send(command);
        }


        return TypedResults.Ok(settlementBanks);
    }
}
