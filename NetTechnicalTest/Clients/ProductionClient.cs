using NetTechnicalTest.IClients;
using NetTechnicalTest.Utilities;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class ProductionClient : IProductionClient
    {
        public ProductionClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.MBAOptions7Async(cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<ProductionVolumesDTO>> VolumesAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.VolumesAsync(end.ToDateString(), mba, start.ToDateString(), cancellationToken ?? CancellationToken.None);
        }
    }
}
