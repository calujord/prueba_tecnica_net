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
        private readonly IWebApiExterna _webApiExterna;

        public BalanceResponsibleService(ApplicationContext context, IWebApiExterna webApiExterna)
        {
            _context = context;
            _webApiExterna = webApiExterna;
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
            var result = new ServiceResult<BalanceReponsiblePartiesModels>();
            var datosApi = _webApiExterna.TraerDatosApi();
            if (!datosApi.responsiblePartyDTOs.Any()) 
            {
                result.Data.CodigoResultado = 2;
                result.Data.Mensaje = "No hay elementos en la búsqueda";
                return result;
            };

            var dataEntidad=datosApi.responsiblePartyDTOs.Select(x => new BalanceResponsibleParty
            {
                BrpCode=x.BrpCode,
                BrpName=x.BrpName,
                BusinessId=x.BusinessId,
                CodingScheme = x.CodingScheme,
                Country=x.Country,
                ValidityEnd = x.ValidityEnd,
                ValidityStart= x.ValidityStart
            });

            _context.AddRange(dataEntidad);

            result.Data.CodigoResultado = 0;
            result.Data.Mensaje = "Datos Guardados";

            return result;

        }
    }
}
