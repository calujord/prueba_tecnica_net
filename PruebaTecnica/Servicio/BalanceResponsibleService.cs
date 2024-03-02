using PruebaTecnica.ContextoBBDD;
using PruebaTecnica.DTO;
using PruebaTecnica.Genericos;
using PruebaTecnica.Models;
using PruebaTecnica.Servicio.Interfaz;
using System.Diagnostics.Metrics;

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
                    BalanceResponsible = null,
                    Mensaje="El dato no existe"
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
                BalanceResponsible = dataDto,
                Mensaje="Dato encontrado"
            };

            return result;
        }

        public ServiceResult<BalanceReponsiblePartiesModels> Save(string code, string country, string name)
        {
            var result = new ServiceResult<BalanceReponsiblePartiesModels>();
            var datosApi = _webApiExterna.TraerDatosApi(code, country, name);
            if (!datosApi.responsiblePartyDTOs.Any()) 
            {
                result.Data = new BalanceReponsiblePartiesModels()
                {
                    CodigoResultado = 2,
                    Mensaje = "No hay datos"
                };
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
            _context.SaveChanges();

            result.Data = new BalanceReponsiblePartiesModels()
            {
                CodigoResultado = 0,
                Mensaje = "Datos Guardados"
            };

            return result;

        }
    }
}
