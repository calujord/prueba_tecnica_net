using PruebaTecnicaNet.EventBus.Events;

namespace PruebaTecnicaNet.API.Application.IntegrationEvents.Events;

public record SettlementBankUpdatedSucceedIntegrationEvent : IntegrationEvent
{ 
    public string Bic { get; init; }
    public string Name { get; init; }
    public string Country { get; init; }

    public SettlementBankUpdatedSucceedIntegrationEvent(string bic, string name, string country)
    {
        Bic = bic;
        Name = name;
        Country = country;
    }
}
