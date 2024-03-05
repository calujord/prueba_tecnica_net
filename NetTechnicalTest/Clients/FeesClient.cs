using NetTechnicalTest.IClients;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class FeesClient : IFeesClient
    {
        public FeesClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<FeesDTO>> FeesAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.FeesAsync(cancellationToken ?? CancellationToken.None);
        }
    }
}
