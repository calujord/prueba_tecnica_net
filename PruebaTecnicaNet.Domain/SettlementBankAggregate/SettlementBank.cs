using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnicaNet.Domain.Exceptions;
using PruebaTecnicaNet.Domain.SeedWork;
using static PruebaTecnicaNet.Domain.Exceptions.SettlementBankException;

namespace PruebaTecnicaNet.Domain.SettlementBankAggregate
{
    public class SettlementBank : Entity, IAggregateRoot, ISettlementBankRepository
    {
        public string Bic { get; private set; }
        public string Country { get; private set; }
        public string Name { get; private set; }

        // Additional code

        public SettlementBank(string bic, string country, string name)
        {
            if (string.IsNullOrEmpty(bic) || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(name))
            {
                throw new InvalidSettlementBankException();
            }
            if (!IsBicValid(bic))
            {
                throw new InvalidBicException(bic);
            }
            Bic = bic;
            if (!IsCountryValid(country))
            {
                throw new InvalidCountryException(country);
            }
            Country = country;
            if (!IsNameValid(name))
            {
                throw new InvalidNameException(name);
            }
            Name = name;

            // If the SettlementBank is not valid, throw an exception
            if (!IsValid())
            {
                throw new InvalidSettlementBankException();
            }
        }

        // Some example methods to validate the properties of the SettlementBank

        public bool IsBicValid(string bic) => bic.Length == 8;

        public bool IsCountryValid(string country) => country.Length == 2;

        public bool IsNameValid(string name) => name.Length > 0;

        // Now we check only the properties of the SettlementBank but in the future we could add more validations
        public bool IsValid() => IsBicValid(Bic) && IsCountryValid(Country) && IsNameValid(Name);

    }
}
