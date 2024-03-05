using eSett.Model;

namespace eSett.Manager
{
    public class RetailerMg : MarketPartyMg, I_Import
    {
        private static RetailerMg _mg;
        public static RetailerMg RMg { get { return _mg; } }

        private RetailerMg(string APIUri)
        {
            Api = new API.RetailerMg();
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
            _db.Retailer.Add((Retailer)mp);
        }

        /// <summary>
        /// Get a Retailer by PrimaryKey
        /// </summary>
        /// <param name="id">PrimaryKey of Retailer table</param>
        /// <returns>Retailer object of id key.  null if not found</returns>
        public Retailer? Get(int id)
        {
            try
            {
                return _db.Retailer.Where(brp => brp.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                xLog.Logger.AddFailure(ex.Message);
                return null;
            }
        }

    }
}
