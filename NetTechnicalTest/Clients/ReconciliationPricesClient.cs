using NetTechnicalTest.IClients;
using NetTechnicalTest.Utilities;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class ReconciliationPricesClient : IReconciliationPricesClient
    {
        public ReconciliationPricesClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.MBAOptions8Async(cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<ReconciliationPriceDTO>> ReconciliationPricesAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.ReconciliationPricesAsync(end.ToDateString(), mba, start.ToDateString(), cancellationToken ?? CancellationToken.None);
        }
    }
}
