namespace PruebaTecnicaNet.API.Queries;

public record SettlementBank
{
    public string Bic { get; init; }
    public string Country { get; init; }
    public string Name { get; init; }
}



