using eSett.Data;
using eSett.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace eSett.Manager
{
    public abstract class MarketPartyMg
    {
        protected API.I_APIeSettMg Api;

        protected MarketPartyData _db;

        public MarketPartyMg()
        {
            _db = new MarketPartyData();
        }

        public static void Start(string uri)
        {
            RetailerMg.Start(uri);
            DistributionSystemOperatorMg.Start(uri);
            BalanceServiceProviderMg.Start(uri);
            BalanceResponsiblePartyMg.Start(uri);
        }

        protected bool BulkImport(I_Import caller)
        {
            var lista = Api.Get();

            foreach (I_MarketParty retail in lista)
            {
                try
                {
                   caller.Add(retail);
                }
                catch (Exception ex)
                {
                    xLog.Logger.AddFailure(retail.Code + ": " + ex.Message);
                }
            }
            return _db.SaveChanges() == lista.Count;
        }

    }
}
