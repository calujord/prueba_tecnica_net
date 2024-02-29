namespace PruebaTecnicaNet.Domain.Exceptions;

/// <summary>
/// Exception for Settlement Bank
/// </summary>
public class SettlementBankException : Exception
{
    public SettlementBankException(string message) : base(message)
    {
    }

    // Invalid Bic
    public class InvalidBicException : SettlementBankException
    {
        public InvalidBicException(string bic) : base($"Invalid Bic: {bic}")
        {
        }
    }

    // Invalid Country
    public class InvalidCountryException : SettlementBankException
    {
        public InvalidCountryException(string country) : base($"Invalid Country: {country}")
        {
        }
    }

    // Invalid Name
    public class InvalidNameException : SettlementBankException
    {
        public InvalidNameException(string name) : base($"Invalid Name: {name}")
        {
        }
    }

    // Invalid Settlement Bank
    public class InvalidSettlementBankException : SettlementBankException
    {
        public InvalidSettlementBankException() : base("Invalid Settlement Bank")
        {
        }
    }

}

