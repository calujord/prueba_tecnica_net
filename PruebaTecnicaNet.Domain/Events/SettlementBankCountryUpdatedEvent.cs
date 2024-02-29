using PruebaTecnicaNet.Domain.SettlementBankAggregate;

namespace PruebaTecnicaNet.Domain.Events;

/// <summary>
/// Event used to notify when the country of a settlement bank is updated
/// </summary>
/// <param name="settlementBank"></param>
/// <param name="country"></param>
public class SettlementBankCountryUpdatedEvent(SettlementBank settlementBank, string country) : INotification
{
    public SettlementBank SettlementBank { get; } = settlementBank;
    public string Country { get; } = country;
}