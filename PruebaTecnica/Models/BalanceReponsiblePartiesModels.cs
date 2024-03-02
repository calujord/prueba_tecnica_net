using Newtonsoft.Json;
using PruebaTecnica.DTO;

namespace PruebaTecnica.Models
{
    public class BalanceReponsiblePartiesModels
    {
        [JsonProperty("CodigoResultado")]
        public int CodigoResultado { get; set; }

        [JsonProperty("BalanceResponsible")]
        public BalanceReponsiblePartiesDTO BalanceResponsible { get; set; }
    }
}
