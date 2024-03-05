using NetTechnicalTest.IClients;
using NetTechnicalTest.Utilities;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class HistoricalTwoBalanceVolumesClient : IHistoricalTwoBalanceVolumesClient
    {
        public HistoricalTwoBalanceVolumesClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.MBAOptions3Async(cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<ImbalanceVolumeTwobalanceDTO>> ImbalancePowerVolumeAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.ImbalancePowerVolumeAsync(end.ToDateString(), mba, start.ToDateString(), cancellationToken ?? CancellationToken.None);
        }
    }
}
