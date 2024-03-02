using PruebaTecnica.ContextoBBDD;
using PruebaTecnica.DTO;
using PruebaTecnica.Genericos;
using PruebaTecnica.Models;
using PruebaTecnica.Servicio.Interfaz;

namespace PruebaTecnica.Servicio
{
    public class BalanceResponsibleService : IBalanceResponsiblePartyService
    {
        private readonly ApplicationContext _context;

        public BalanceResponsibleService(ApplicationContext context) 
        {
            _context = context;
        }

        public ServiceResult<BalanceReponsiblePartiesModels> GetData(int id)
        {
            var result = new ServiceResult<BalanceReponsiblePartiesModels>();

            var data = _context.BalanceResponsibles.FirstOrDefault(x => x.Id == id);

            if (data == null) 
            {
                result.Data = new BalanceReponsiblePartiesModels()
                {
                    CodigoResultado = 1,
                    BalanceResponsible = null
                };
                return result;
            }

            var dataDto = new BalanceReponsiblePartiesDTO
            {
                BrpCode=data.BrpCode,
                BrpName=data.BrpName,
                BusinessId=data.BusinessId,
                CodingScheme=data.CodingScheme,
                Country=data.Country,
                ValidityEnd= data.ValidityEnd,
                ValidityStart= data.ValidityStart
            };

            result.Data = new BalanceReponsiblePartiesModels()
            {
                CodigoResultado = 0,
                BalanceResponsible = dataDto
            };

            return result;
        }

        public ServiceResult<BalanceReponsiblePartiesModels> Save()
        {
            throw new NotImplementedException();
        }
    }
}
