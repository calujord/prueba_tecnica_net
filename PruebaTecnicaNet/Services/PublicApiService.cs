using Newtonsoft.Json;
using PruebaTecnicaNet.Models;
using PruebaTecnicaNet.Repository.Interfaces;
using PruebaTecnicaNet.Services.Interfaces;

namespace PruebaTecnicaNet.Services
{
    public class PublicApiService : IPublicApiService
    {
        /// <summary>
        /// Url that obtains the list of Fees from the public API.
        /// </summary>
        private readonly string _urlGetFees = "https://api.opendata.esett.com/EXP05/Fees";

        /// <summary>
        /// Get all fees from the public API.
        /// </summary>
        public async Task<List<Fee>?> GetDataOfPublicApi()
        {
            try
            {
                var httpClient = new HttpClient();
                var jsonResponse = await httpClient.GetStringAsync(this._urlGetFees);
                var result = JsonConvert.DeserializeObject<List<Fee>>(jsonResponse);

                return result;
            }
            catch (Exception execption)
            {
                return null;
            }
        }
    }
}
