using NetTechnicalTest.IClients;
using NetTechnicalTest.Utilities;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class ConsumptionClient : IConsumptionClient
    {
        public ConsumptionClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.MBAOptions6Async(cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<AggregatedConsumptionDTO>> ConsumptionAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.ConsumptionAsync(end.ToDateString(), mba, start.ToDateString(), cancellationToken ?? CancellationToken.None);
        }
    }
}
