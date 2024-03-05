using NetTechnicalTest.IClients;
using NetTechnicalTest.Model;
using NetTechnicalTest.Utilities;
using OpenAPIClient;

namespace NetTechnicalTest.Clients
{
    public class PricesClient : IPricesClient
    {
        public PricesClient(DemoClient demoClient)
        {
            DemoClient = demoClient;
        }

        private DemoClient DemoClient { get; }

        public async Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null)
        {
            return await DemoClient.MBAOptions5Async(cancellationToken ?? CancellationToken.None);
        }

        public async Task<ICollection<SinglebalancePriceDTO>> PricesAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null)
        {
            //ATENCIÓN: La difinición del cliente OpenAPI proporcionado esba mal (defína no nulables los campos
            //          incentivisingComponent y valueOfAvoidedActivation pero los datos devueltos eran nulos y fallaba al deserializarlos)
            //          y se ha tenido que cambiar a Required = Newtonsoft.Json.Required.AllowNull para que se pudiese deserializar bien.
            return await DemoClient.Prices2Async(end.ToDateString(), mba, start.ToDateString(), cancellationToken ?? CancellationToken.None);
        }
    }
}
