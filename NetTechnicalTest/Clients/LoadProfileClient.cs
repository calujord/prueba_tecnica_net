using NetTechnicalTest.IClients;
using NetTechnicalTest.Utilities;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class LoadProfileClient : ILoadProfileClient
    {
        public LoadProfileClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<MonthlyAggregationDTO>> AggregateAsync(DateTime end, IEnumerable<string> mba, string mga, DateTime start, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.AggregateAsync(end.ToDateString(), mba, mga, start.ToDateString(), cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<LoadProfileDTO>> LoadProfileAsync(DateTime end, IEnumerable<string> mba, string mga, DateTime start, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.LoadProfileAsync(end.ToDateString(), mba, mga, start.ToDateString(), cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<ICollection<MBAOptionsDTO>>> MBAOptionsAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.MBAOptions9Async(cancellationToken ?? CancellationToken.None);
        }
    }
}
