using Newtonsoft.Json;
using PruebaTecnica.DTO;
using PruebaTecnica.Models;
using PruebaTecnica.Servicio.Interfaz;

namespace PruebaTecnica.Servicio
{
    public class WebApiExterna: IWebApiExterna
    {
        public DatoApiModels TraerDatosApi()
        {
            var httpClient = new HttpClient();
            var api = "https://api.opendata.esett.com/EXP01/BalanceResponsibleParties";

            var request = new HttpRequestMessage(HttpMethod.Get, api);

            var response = httpClient.SendAsync(request).Result;

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = response.Content.ReadAsStringAsync().Result;
                return new DatoApiModels { CodigoResultado = 1 };
            }

            var body = response.Content.ReadAsStringAsync().Result;
            List<BalanceReponsiblePartiesDTO> datosList = JsonConvert.DeserializeObject<List<BalanceReponsiblePartiesDTO>>(body);
            var result = new DatoApiModels
            { 
                CodigoResultado=0,
                responsiblePartyDTOs=datosList
            };

            return result;
        }
    }
}
