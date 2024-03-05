namespace Alicunde.PruebaTecnica.Models
{
    public class FeesRS
    {
        public  List<Fee> Fees = new List<Fee> { };
    }

    public class Fee
    {
        public DateTime Timestamp { get; set; }
        public string Country { get; set; }
        public decimal? ImbalanceFee { get; set; }
        public decimal? HourlyImbalanceFee { get; set; }
        public decimal? PeakLoadFee { get; set; }
        public decimal? VolumeFee { get; set; }
        public decimal? WeeklyFee { get; set; }
    }
}
