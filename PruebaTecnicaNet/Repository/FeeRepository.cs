using Microsoft.EntityFrameworkCore;
using PruebaTecnicaNet.Context;
using PruebaTecnicaNet.Entities;
using PruebaTecnicaNet.Models;
using PruebaTecnicaNet.Repository.Interfaces;

namespace PruebaTecnicaNet.Repository
{
    public class FeeRepository : IFeeRepository
    {
        protected readonly ApplicationContext _context;

        public FeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Add(List<Fee> fees)
        {
            var feesDB = fees
                .Select(x => new FeeDB()
                {
                    Timestamp = x.Timestamp,
                    Country = x.Country,
                    ImbalanceFee = x.ImbalanceFee,
                    HourlyImbalanceFee = x.HourlyImbalanceFee,
                    PeakLoadFee = x.PeakLoadFee,
                    VolumeFee = x.VolumeFee,
                    WeeklyFee = x.WeeklyFee
                }).ToList();

            _context.Fee.AddRange(feesDB);
            return await _context.SaveChangesAsync();
        }

        public async Task<Fee?> Get(int id)
        {
            var feeDB = await _context.Fee.FindAsync(id);

            return feeDB != null ? new Fee()
            {
                Id = feeDB.Id,
                Timestamp = feeDB.Timestamp,
                Country = feeDB.Country,
                ImbalanceFee = feeDB.ImbalanceFee,
                HourlyImbalanceFee = feeDB.HourlyImbalanceFee,
                PeakLoadFee = feeDB.PeakLoadFee,
                VolumeFee = feeDB.VolumeFee,
                WeeklyFee = feeDB.WeeklyFee
            } : null;
        }

        public async Task<List<Fee>?> GetAll()
        {
            var feesDB = await _context.Fee.ToListAsync();
            return feesDB != null ? feesDB
                .Select(x => new Fee()
                {
                    Id = x.Id,
                    Timestamp = x.Timestamp,
                    Country = x.Country,
                    ImbalanceFee = x.ImbalanceFee,
                    HourlyImbalanceFee = x.HourlyImbalanceFee,
                    PeakLoadFee = x.PeakLoadFee,
                    VolumeFee = x.VolumeFee,
                    WeeklyFee = x.WeeklyFee
                }).ToList() : null;
        }
    }
}
