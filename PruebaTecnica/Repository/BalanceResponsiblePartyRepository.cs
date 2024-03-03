using PruebaTecnica.ContextoBBDD;
using PruebaTecnica.Repository.Impl;

namespace PruebaTecnica.Repository
{
    public class BalanceResponsiblePartyRepository : Repository<BalanceResponsibleParty>, IBalanceResponsiblePartyRepository
    {
        /*
         Al no existir operaciones especiales, no hace falta definir métodos porque ya se encuentran
        en el repository generico
         */
        public BalanceResponsiblePartyRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
