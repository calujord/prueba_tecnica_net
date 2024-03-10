using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNet.Entities
{
    public class FeeDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Country { get; set; }
        public double? HourlyImbalanceFee { get; set; }
        public double? ImbalanceFee { get; set; }
        public double? PeakLoadFee { get; set; }
        public string? Timestamp { get; set; }
        public double? VolumeFee { get; set; }
        public double? WeeklyFee { get; set; }
    }
}
