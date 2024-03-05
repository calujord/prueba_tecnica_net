using eSett.Model;

namespace eSett.Manager
{
    public class DistributionSystemOperatorMg : MarketPartyMg, I_Import
    {
        private static DistributionSystemOperatorMg _mg;
        public static DistributionSystemOperatorMg DSOMg { get { return _mg; } }

        private DistributionSystemOperatorMg(string APIUri)
        {
            Api = new API.DistributionSystemOperatorMg();
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
            _db.DistributionSystemOperator.Add((DistributionSystemOperator)mp);
        }

        /// <summary>
        /// Get a DistributionSystemOperator by PrimaryKey
        /// </summary>
        /// <param name="id">PrimaryKey of DistributionSystemOperator table</param>
        /// <returns>DistributionSystemOperator object of id key.  null if not found</returns>
        public DistributionSystemOperator? Get(int id)
        {
            try
            {
                return _db.DistributionSystemOperator.Where(brp => brp.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                xLog.Logger.AddFailure(ex.Message);
                return null;
            }
        }

    }
}
