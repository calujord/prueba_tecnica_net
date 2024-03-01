using PruebaTecnicaNet.Domain.SettlementBankAggregate;

namespace PruebaTecnicaNet.Domain.Events;

/// <summary>
/// Event used to notify when the name of a settlement bank is updated
/// </summary>
/// <param name="settlementBank"></param>
/// <param name="name"></param>
public class SettlementBankNameUpdatedDomainEvent(SettlementBank settlementBank, string name) : INotification
{
    public SettlementBank SettlementBank { get; } = settlementBank;
    public string Name { get; } = name;
}