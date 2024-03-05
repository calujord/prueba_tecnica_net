using eSett.Model;

namespace eSett.Manager
{
    public class BalanceResponsiblePartyMg : MarketPartyMg, I_Import
    {
        private static BalanceResponsiblePartyMg _mg;
        public static BalanceResponsiblePartyMg BRPMg { get { return _mg; } }

        private BalanceResponsiblePartyMg(string APIUri)
        {
            Api = new API.BalanceResponsiblePartyMg();
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
            _db.BalanceResponsibleParty.Add((BalanceResponsibleParty)mp);
        }

        /// <summary>
        /// Get a BalanceResponsibleParty by PrimaryKey
        /// </summary>
        /// <param name="id">PrimaryKey of BalanceResponsibleParty table</param>
        /// <returns>BalanceResponsibleParty object of id key.  null if not found</returns>
        public BalanceResponsibleParty? Get(int id)
        {
            try
            {
                return _db.BalanceResponsibleParty.Where(brp => brp.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                xLog.Logger.AddFailure(ex.Message);
                return null;
            }
        }

    }
}
