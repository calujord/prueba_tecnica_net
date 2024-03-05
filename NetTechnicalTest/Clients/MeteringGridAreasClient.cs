using NetTechnicalTest.IClients;
using NetTechnicalTest.Utilities;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class MeteringGridAreasClient : IMeteringGridAreasClient
    {
        public MeteringGridAreasClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<MeteringGridAreaDto>> MeteringGridAreasAsync(string dsoName, IEnumerable<string> mba, string mgaCode, string mgaName, string mgaType, CancellationToken? cancellationToken = null)
        {
            return await DemoClient.MeteringGridAreasAsync(dsoName, mba, mgaCode, mgaName, mgaType, cancellationToken ?? CancellationToken.None);
        }
    }
}
