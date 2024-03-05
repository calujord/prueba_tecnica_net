using Microsoft.AspNetCore.Mvc;
using NetTechnicalTest.IClients;
using NetTechnicalTest.IDataAccess;
using NetTechnicalTest.IServices;
using NetTechnicalTest.Model;
using OpenAPIClient;

namespace NetTechnicalTest.Controllers
{
    /// <summary>
    /// Controlador con la definición de los métodos/puntos de acceso desplegados en el servidor para la recuperación del modelo
    /// </summary>
    [ApiController]
    //Definimos como ruta el nombre de la interfaz que luego usaremos como servicio en el cliente.
    //De esta forma el servicio puede saber la ruta sin poner una cadena de texto.
    //Así evitamos que, en caso de refactorizar las clases, el cambio de nombre haga que deje de funcionar por no coincidir,
    //ya que de esta forma el cambio de nombre se hace a través de tipos y métodos que se compilan
    [Route(nameof(IDataService))]
    //Define que tipo devolverán los métodos expuestos, válido para la publicación de nuestra API Rest que vamos a publicar a partir de este controlador
    [Produces("application/json")]
    public class DataController : ControllerBase, IDataService //Implementa IDataService para que coincidan los nombres de los métodos con los del servicio que el cliente define y así evitar problemas en refactorizaciones
    {
        /// <summary>
        /// Cliente de Partes del mercado
        /// </summary>
        private IMarketPartiesClient MarketPartiesClient { get; }
        /// <summary>
        /// Cliente de Precios (saldo único)
        /// </summary>
        private IPricesClient PricesClient { get; }
        /// <summary>
        /// Acceso a la persistencia
        /// </summary>
        private IDBAccess DBAccess { get; }

        /// <summary>
        /// Controlador que expone los métodos que puede usar el cliente (además de exponer nuestra API Rest)
        /// </summary>
        /// <param name="marketPartiesClient">Cliente de Partes del mercado (recibido por inyección de dependencias)</param>
        /// <param name="pricesclient">Cliente de Precios (sáldo único) (recibido por inyección de dependencias)</param>
        /// <param name="dbAccess">Acceso a la persistencia (recibido por inyección de dependencias)</param>
        public DataController(IMarketPartiesClient marketPartiesClient, IPricesClient pricesclient, IDBAccess dbAccess)
        {
            MarketPartiesClient = marketPartiesClient;
            PricesClient = pricesclient;
            DBAccess = dbAccess;
        }

        private bool _retailersInitialized = false;
        /// <summary>
        /// Inicalia la lista de minoristas almacenandolos en la capa de persistencia
        /// </summary>
        /// <returns>Tarea asíncrona</returns>
        private async Task InitializeRetailers()
        {
            if (!_retailersInitialized)
            {
                //Recupera del cliente la lista de elementos
                ICollection<RetailerDTO> retailers = await MarketPartiesClient.RetailersAsync(null, "FI", null);
                //Guarda en la capa de persistencia los objetos recuperados
                await DBAccess.SaveRetailers(retailers.Select(dto => new Retailer(dto)));
                _retailersInitialized = true;
            }
        }

        /// <summary>
        /// Recupera el listado con todos los minoristas
        /// </summary>
        /// <returns>Array de objetos Retailer</returns>
        [HttpGet($"{nameof(GetAllRetailers)}()")] //Expone el mètodo usando el propio nombre del método para que así dependa en compilación y detectar posibles problemas en caso de refatorizaciones
        public async Task<Retailer[]> GetAllRetailers()
        {
            //Initializa los minoristas si no estaban ya inicializados en la capa de persistencia
            await InitializeRetailers();
            //Recupera de la capa de persistencia los minoristas
            return (await DBAccess.AllRetailers()).ToArray();
        }

        /// <summary>
        /// Recupera un minorista a partir de su código (clave primaria)
        /// </summary>
        /// <param name="reCode">Cadena correspondiente al código del minorista</param>
        /// <returns>Objeto Retailer</returns>
        [HttpGet($"{nameof(GetRetailer)}({{{nameof(reCode)}}})")] //Expone el mètodo y sus parámetros usando el propio nombre y parámetros del método para que así dependa en compilación y detectar posibles problemas en caso de refatorizaciones
        public async Task<Retailer> GetRetailer(string reCode)
        {
            //Initializa los minoristas si no estaban ya inicializados en la capa de persistencia
            await InitializeRetailers();
            //Recupera de la capa el minorista a partir de su código
            return await DBAccess.GetRetailer(reCode);
        }



        private bool _singlebalancedPriceInitialized = false;
        /// <summary>
        /// Inicalia la lista de precios almacenandolos en la capa de persistencia
        /// </summary>
        /// <returns>Tarea asíncrona</returns>
        private async Task InitializeSinglebalancedPrice()
        {
            if (!_singlebalancedPriceInitialized)
            {
                //Recupera del cliente la lista de elementos
                ICollection<SinglebalancePriceDTO> singlebalancedPrices = await PricesClient.PricesAsync(new DateTime(2022, 12, 1, 0, 0, 0, 0), new string[] { "10Y1001A1001A44P" }, new DateTime(2022, 11, 2, 0, 0, 0, 0));
                //Guarda en la capa de persistencia los objetos recuperados
                await DBAccess.SaveSinglebalancePrices(singlebalancedPrices.Select(dto => new SinglebalancePrice(dto)));
                _singlebalancedPriceInitialized = true;
            }
        }
        /// <summary>
        /// Recupera el listado con todos los precios
        /// </summary>
        /// <returns>Array de objetos SinglebalancePrice</returns>

        [HttpGet($"{nameof(GetAllPrices)}()")] //Expone el mètodo usando el propio nombre del método para que así dependa en compilación y detectar posibles problemas en caso de refatorizaciones
        public async Task<SinglebalancePrice[]> GetAllPrices()
        {
            //Initializa los precios si no estaban ya inicializados en la capa de persistencia
            await InitializeSinglebalancedPrice();
            //Recupera de la capa de persistencia los precios
            return (await DBAccess.AllSinglebalancePrices()).ToArray();
        }
    }
}
