using Newtonsoft.Json;

namespace PruebaTecnica.DTO
{
    public class BalanceReponsiblePartiesDTO
    {
        [JsonProperty("BrpCode")]
        public string BrpCode { get; set; }
        [JsonProperty("BrpName")]
        public string BrpName { get; set; }
        [JsonProperty("BusinessId")]
        public string BusinessId { get; set; }
        [JsonProperty("CodingScheme")]
        public string CodingScheme { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("ValidityStart")]
        public string ValidityStart { get; set; }
        [JsonProperty("ValidityEnd")]
        public string ValidityEnd { get; set; }

        [JsonProperty]
        public int CodigoResultado { get; set; }
    }
}
