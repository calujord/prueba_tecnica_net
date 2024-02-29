using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Bic = bic;
            Country = country;
            Name = name;
            if (!IsValid())
            {
                throw new Exception("Invalid Settlement Bank");
            }
        }

        public bool IsBicValid(string bic) =>
            bic.Length == 8;

        public bool IsCountryValid(string country)
        {
            return country.Length == 2;
        }

        public bool IsNameValid(string name)
        {
            return name.Length > 0;
        }

        public bool IsValid()
        {
            return IsBicValid(Bic) && IsCountryValid(Country) && IsNameValid(Name);
        }

    }
}
