using Newtonsoft.Json;

namespace PruebaTecnicaNet.Models
{
    public class Fee
    {
        public int Id { get; set; }

        [JsonProperty("timestamp")]
        public string? Timestamp { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("imbalanceFee")]
        public double? ImbalanceFee { get; set; }

        [JsonProperty("hourlyImbalanceFee")]
        public double? HourlyImbalanceFee { get; set; }

        [JsonProperty("peakLoadFee")]
        public double? PeakLoadFee { get; set; }

        [JsonProperty("volumeFee")]
        public double? VolumeFee { get; set; }

        [JsonProperty("weeklyFee")]
        public double? WeeklyFee { get; set; }

        public Fee() { }
    }
}
