using NetTechnicalTest.IServices;
using NetTechnicalTest.Model;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NetTechnicalTest.Services
{
    /// <summary>
    /// Implementación de los servicios accesibles para la recuperación del modelo
    /// </summary>
    public class DataService : IDataService
    {
        /// <summary>
        /// Construye un objeto de acceso a los servicios de recuperación del modelo.
        /// </summary>
        /// <param name="httpClient">Cliente HTTP necesario para las conexiones cliente servidor (recibido por inyección de dependencias)</param>
        public DataService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        /// <summary>
        /// Cliente HTTP
        /// </summary>
        protected HttpClient HttpClient { get; }

        /// <summary>
        /// Recupera de forma asíncrona la lista de todos los précios existentes
        /// </summary>
        /// <returns>Tarea asíncrona que devuelve un array de objetos SinglebalancePrice</returns>
        public async Task<SinglebalancePrice[]> GetAllPrices()
        {
            return await Get<SinglebalancePrice[]>();
        }

        /// <summary>
        /// Recupera de forma asíncrona la lista de todos los minoristas existentes
        /// </summary>
        /// <returns>Tarea asíncrona que devuelve un array de objetos Retailer</returns>
        public async Task<Retailer[]> GetAllRetailers()
        {
            return await Get<Retailer[]>();
        }

        /// <summary>
        /// Busca el modelo del minorista a partir de su código (PK)
        /// </summary>
        /// <param name="reCode">Código del minorista (PK)</param>
        /// <returns>Tarea asíncrona que devuelve un objeto Retailer</returns>
        public async Task<Retailer> GetRetailer(string reCode)
        {
            return await Get<Retailer>(parameters: reCode);
        }

        /// <summary>
        /// Nombre del controlador del servidor al que se invoca (usamos el mismo nombre que la interfaz del servicio para poder hacer dependiente del código la ruta que se construye para la invocación)
        /// </summary>
        private const string CONTROLLER_NAME = nameof(IDataService);

        /// <summary>
        /// Método auxiliar que proporciona una llamada estandar para cualquier a de los métodos Get del controlador a los que se quiera invocar
        /// </summary>
        /// <typeparam name="T">Tioo de dato devuelto por el método del controlador que se invoque</typeparam>
        /// <param name="methodName">Nombre del método que se invoca (no es necesario proporcionarlo si se invoca desde un método cuyo nombre coincida con el definido en la ruta del controlador)</param>
        /// <param name="parameters">Paráetros que necesita el método del controlador</param>
        /// <returns></returns>
        protected async Task<T> Get<T>([CallerMemberName] string methodName = "", params object[] parameters)
        {
            try
            {
                //Ruta "estandar" definida del controlador al que queremos invocar
                string path = $"http://localhost:5245/{CONTROLLER_NAME}/{methodName}({string.Join(", ", parameters)})";
                //Llamada al servidor recuperando los objetos a través de Json
                return (await HttpClient.GetFromJsonAsync<T>(path))!;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error en la llamada JSON al servidor." + e);
                throw;
            }
        }
    }
}
