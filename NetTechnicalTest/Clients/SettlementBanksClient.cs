using NetTechnicalTest.IClients;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class SettlementBanksClient : ISettlementBanksClient
    {
        public SettlementBanksClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<SettlementBankDTO>> BanksAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.BanksAsync(cancellationToken ?? CancellationToken.None);
        }
    }
}
