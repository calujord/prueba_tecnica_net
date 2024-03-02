using PruebaTecnica.Genericos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Servicio.Interfaz
{
    public interface IBalanceResponsiblePartyService
    {
        ServiceResult<BalanceReponsiblePartiesModels> Save();
        ServiceResult<BalanceReponsiblePartiesModels> GetData(int id);
    }
}
