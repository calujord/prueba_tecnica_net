using NetTechnicalTest.IClients;
using NetTechnicalTest.Model;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class MarketPartiesClient : IMarketPartiesClient
    {
        public MarketPartiesClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<BalanceResponsiblePartyDTO>> BalanceResponsiblePartiesAsync(string code, string country, string name, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.BalanceResponsiblePartiesAsync(code, country, name, cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<BalanceServiceProviderDTO>> BalanceServiceProvidersAsync(string code, string country, string name, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.BalanceServiceProvidersAsync(code, country, name, cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<DistributionSystemOperatorDTO>> DistributionSystemOperatorsAsync(string code, string country, string name, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.DistributionSystemOperatorsAsync(code, country, name, cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<RetailerDTO>> RetailersAsync(string? code, string country, string? name, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.RetailersAsync(code, country, name, cancellationToken ?? CancellationToken.None);
        }
    }
}
