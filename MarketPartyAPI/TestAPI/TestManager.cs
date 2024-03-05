using eSett.Manager;

namespace TestAPI
{
    [TestClass]
    public class TestManager
    {
        string uri = "https://api.opendata.esett.com/";

        [TestMethod]
        public void TestImport()
        {
            MarketPartyMg.Start(uri);

            Assert.IsTrue(RetailerMg.RMg.Import(), "No se recuperaron los retailers");

            Assert.IsTrue(DistributionSystemOperatorMg.DSOMg.Import(), "No se recuperaron los DSO");

            Assert.IsTrue(BalanceResponsiblePartyMg.BRPMg.Import(), "Fallaron los BRP");

            Assert.IsTrue(BalanceServiceProviderMg.BSPMg.Import(), "No se importaron los BalanceService");
        }

        [TestMethod]
        public void TestRead()
        {

        }
    }
}
