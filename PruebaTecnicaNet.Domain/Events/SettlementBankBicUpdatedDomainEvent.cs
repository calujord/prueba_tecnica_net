using PruebaTecnicaNet.Domain.SettlementBankAggregate;

namespace PruebaTecnicaNet.Domain.Events;

/// <summary>
/// Event used to notify when the BIC of a settlement bank is updated
/// </summary>
/// <param name="settlementBank"></param>
/// <param name="bic"></param>
public class SettlementBankBicUpdatedDomainEvent(SettlementBank settlementBank, string bic) : INotification
{
    public SettlementBank SettlementBank { get; } = settlementBank;
    public string Bic { get; } = bic;
}