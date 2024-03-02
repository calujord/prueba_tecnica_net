using Newtonsoft.Json;
using PruebaTecnica.DTO;

namespace PruebaTecnica.Models
{
    public class BalanceReponsiblePartiesModels
    {
        [JsonProperty("CodigoResultado")]
        public int CodigoResultado { get; set; }

        [JsonProperty("Parties")]
        public List<BalanceReponsiblePartiesDTO> Parties { get; set; }
    }
}
