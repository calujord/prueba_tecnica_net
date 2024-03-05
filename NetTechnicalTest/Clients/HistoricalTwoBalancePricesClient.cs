using NetTechnicalTest.IClients;
using NetTechnicalTest.Utilities;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class HistoricalTwoBalancePricesClient : IHistoricalTwoBalancePricesClient
    {
        public HistoricalTwoBalancePricesClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.MBAOptions3Async(cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<TwobalancePriceDTO>> PricesAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.PricesAsync(end.ToDateString(), mba, start.ToDateString(), cancellationToken ?? CancellationToken.None);
        }
    }
}
