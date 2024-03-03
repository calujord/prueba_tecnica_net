using Newtonsoft.Json;
using PruebaTecnica.DTO;
using PruebaTecnica.Models;
using PruebaTecnica.Servicio.Interfaz;
using System.Diagnostics.Metrics;
using System.Text;

namespace PruebaTecnica.Servicio
{
    public class WebApiExterna: IWebApiExterna
    {
        public DatoApiModels TraerDatosApi(string code,string country,string name)
        {
            var httpClient = new HttpClient();
            var api = "https://api.opendata.esett.com/EXP01/BalanceResponsibleParties";

            var urlBuilder = new StringBuilder(api);

            if (!string.IsNullOrEmpty(code))
            {
                urlBuilder.Append("?code=");
                urlBuilder.Append(Uri.EscapeDataString(code));
            }

            if (!string.IsNullOrEmpty(country))
            {
                urlBuilder.Append(urlBuilder.ToString().Contains("?") ? "&" : "?");
                urlBuilder.Append("country=");
                urlBuilder.Append(Uri.EscapeDataString(country));
            }

            if (!string.IsNullOrEmpty(name))
            {
                urlBuilder.Append(urlBuilder.ToString().Contains("?") ? "&" : "?");
                urlBuilder.Append("name=");
                urlBuilder.Append(Uri.EscapeDataString(name));
            }

            var finalUrl = urlBuilder.ToString();

            var request = new HttpRequestMessage(HttpMethod.Get, finalUrl);

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
