using System;

namespace SettlementBank.UnitTests.Domain;

using PruebaTecnicaNet.Domain.SettlementBankAggregate;

public class SettlementBankAggregateTest
{
    public SettlementBankAggregateTest()
    {
    }

    [Fact]
    public void Create_SettlementBank()
    {
        // Arrange
        string bic = "SPTRNO22";
        string name = "Sparebank 1 SMN";
        string country = "NO";

        // Act
        SettlementBank settlementBank = new(bic, country, name);

        // Assert
        Assert.NotNull(settlementBank);
    }

    [Fact]
    public void Update_SettlementBank_Bic()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NO";
        SettlementBank settlementBank = new(bic, country, name);
        var newBic = "SPTRNO23";

        // Act
        settlementBank.UpdateBic(newBic);

        // Assert
        Assert.Equal(newBic, settlementBank.Bic);
    }

    [Fact]
    public void Update_SettlementBank_Bic_Invalid()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NO";
        SettlementBank settlementBank = new(bic, country, name);
        var newBic = "SPTRNO";

        // Act
        Action act = () => settlementBank.UpdateBic(newBic);

        // Assert
        Assert.Throws<SettlementBankException.InvalidBicException>(act);
    }

    [Fact]
    public void Update_SettlementBank_Country()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NO";
        SettlementBank settlementBank = new(bic, country, name);
        var newCountry = "SE";

        // Act
        settlementBank.UpdateCountry(newCountry);

        // Assert
        Assert.Equal(newCountry, settlementBank.Country);
    }

    [Fact]
    public void Update_SettlementBank_Country_Invalid()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NO";
        SettlementBank settlementBank = new(bic, country, name);
        var newCountry = "SWE";

        // Act
        Action act = () => settlementBank.UpdateCountry(newCountry);

        // Assert
        Assert.Throws<SettlementBankException.InvalidCountryException>(act);
    }

    [Fact]
    public void Update_SettlementBank_Name()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NO";
        SettlementBank settlementBank = new(bic, country, name);
        var newName = "Sparebank 1 SMN";

        // Act
        settlementBank.UpdateName(newName);

        // Assert
        Assert.Equal(newName, settlementBank.Name);
    }

    [Fact]
    public void Update_SettlementBank_Name_Invalid()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NO";
        SettlementBank settlementBank = new(bic, country, name);
        var newName = "";

        // Act
        Action act = () => settlementBank.UpdateName(newName);

        // Assert
        Assert.Throws<SettlementBankException.InvalidNameException>(act);
    }

    [Fact]
    public void Invalid_SettlementBank_Bic()
    {
        // Arrange
        var bic = "SPTRNO";
        var name = "Sparebank 1 SMN";
        var country = "NO";

        // Act - Assert
        Assert.Throws<SettlementBankException.InvalidBicException>(() => new SettlementBank(bic, country, name));
    }

    [Fact]
    public void Invalid_SettlementBank_Country()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NOR";

        // Act - Assert
        Assert.Throws<SettlementBankException.InvalidCountryException>(() => new SettlementBank(bic, country, name));
    }

    [Fact]
    public void Invalid_SettlementBank_Name()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "";
        var country = "NO";

        // Act - Assert
        Assert.Throws<SettlementBankException.InvalidSettlementBankException>(() => new SettlementBank(bic, country, name));
    }

    [Fact]
    public void Update_SettlementBank_Bic_raises_new_event()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NO";
        SettlementBank settlementBank = new(bic, country, name);
        var newBic = "SPTRNO23";

        // Act
        settlementBank.UpdateBic(newBic);

        // Assert
        Assert.Single(settlementBank.DomainEvents);
    }

    [Fact]
    public void Update_SettlementBank_Country_raises_new_event()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NO";
        SettlementBank settlementBank = new(bic, country, name);
        var newCountry = "SE";

        // Act
        settlementBank.UpdateCountry(newCountry);

        // Assert
        Assert.Single(settlementBank.DomainEvents);
    }

    [Fact]
    public void Update_SettlementBank_Name_raises_new_event()
    {
        // Arrange
        var bic = "SPTRNO22";
        var name = "Sparebank 1 SMN";
        var country = "NO";
        SettlementBank settlementBank = new(bic, country, name);
        var newName = "Sparebank 1 SMN";

        // Act
        settlementBank.UpdateName(newName);

        // Assert
        Assert.Single(settlementBank.DomainEvents);
    }
}
