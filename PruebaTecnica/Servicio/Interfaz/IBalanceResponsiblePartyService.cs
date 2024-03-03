using PruebaTecnica.Genericos;
using PruebaTecnica.Models;

namespace PruebaTecnica.Servicio.Interfaz
{
    public interface IBalanceResponsiblePartyService
    {
        ServiceResult<BalanceReponsiblePartiesModels> Save(string code, string country, string name);
        ServiceResult<BalanceReponsiblePartiesModels> GetData(int id);
    }
}
