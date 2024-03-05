using eSett.API;

namespace TestAPI
{
    [TestClass]
    public class TesteSettAPI
    {
        [TestMethod]
        public void TestRetailers()
        {
            I_APIeSettMg APIMg = new RetailerMg();

            Assert.IsNotNull(APIMg, "Es null");

            Assert.IsTrue(APIMg.Open("https://api.opendata.esett.com/"), "No se ha iniciado");
            
            var result = APIMg.Get("", "ES", "");

            //Assert.IsTrue(result.IsCompletedSuccessfully);

            Assert.IsTrue(result.Count == 0, "No es cero");

            var result2 = APIMg.Get("", "FI", "");

            Assert.IsTrue(result2.Count > 0, "Es cero");

            Assert.IsInstanceOfType(result2.First(), new RetailerDTO().GetType(), "No es del mismo tipo");
            
        }
    }
}