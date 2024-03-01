namespace SettlementBank.UnitTests.Domain;

using PruebaTecnicaNet.Domain.SettlementBankAggregate;

public class SettlementBankBuilder
{
    private readonly SettlementBank _settlementBank;

    public SettlementBankBuilder()
    {
        string bic = "SPTRNO22";
        string name = "Sparebank 1 SMN";
        string country = "NO";
        _settlementBank = new SettlementBank(bic, country, name);
    }

    public SettlementBankBuilder Update(string bic, string country, string name)
    {
        _settlementBank.UpdateBic(bic);
        _settlementBank.UpdateCountry(country);
        _settlementBank.UpdateName(name);
        return this;
    }

    public SettlementBank Build()
    {
        return _settlementBank;
    }
}
