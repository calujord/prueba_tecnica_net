using NetTechnicalTest.IClients;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class RetailerBalanceResponsibilityClient : IRetailerBalanceResponsibilityClient
    {
        public RetailerBalanceResponsibilityClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.MBAOptionsAsync(cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<RetailerBalanceResponsibilityDTO>> RetailerBalanceResponsibilityAsync(string brpName, IEnumerable<string> mba, string mga, string retailerName, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.RetailerBalanceResponsibilityAsync(brpName, mba, mga, retailerName, cancellationToken ?? CancellationToken.None);
        }
    }
}
