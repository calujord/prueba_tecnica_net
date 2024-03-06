﻿namespace Alicunde.PruebaTecnica.Data
{
    public class Fee
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Country { get; set; }
        public decimal? ImbalanceFee { get; set; }
        public decimal? HourlyImbalanceFee { get; set; }
        public decimal? PeakLoadFee { get; set; }
        public decimal? VolumeFee { get; set; }
        public decimal? WeeklyFee { get; set; }
    }
}
