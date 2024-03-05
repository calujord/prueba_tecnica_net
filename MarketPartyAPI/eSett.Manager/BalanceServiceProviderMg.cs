using eSett.Model;

namespace eSett.Manager
{
    public class BalanceServiceProviderMg : MarketPartyMg, I_Import
    {
        private static BalanceServiceProviderMg _mg;
        public static BalanceServiceProviderMg BSPMg { get { return _mg; } }

        private BalanceServiceProviderMg(string APIUri)
        {
            Api = new API.BalanceServiceProviderMg();
            Api.Open(APIUri);
        }
        public new static void Start(string APIUri)
        {
            _mg ??= new(APIUri);
        }

        public bool Import()
        {
            return BulkImport(this);
        }

        public void Add(I_MarketParty mp)
        {
            _db.BalanceServiceProvider.Add((BalanceServiceProvider)mp);
        }

        /// <summary>
        /// Get a BalanceServiceProvider by PrimaryKey
        /// </summary>
        /// <param name="id">PrimaryKey of BalanceServiceProvider table</param>
        /// <returns>BalanceServiceProvider object of id key.  null if not found</returns>
        public BalanceServiceProvider? Get(int id)
        {
            try
            {
                return _db.BalanceServiceProvider.Where(brp => brp.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                xLog.Logger.AddFailure(ex.Message);
                return null;
            }
        }

    }
}
