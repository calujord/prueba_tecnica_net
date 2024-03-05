using NetTechnicalTest.Model;

namespace NetTechnicalTest.IServices
{
    /// <summary>
    /// Definición de los servicios accesibles para la recuperación del modelo
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Recupera de forma asíncrona la lista de todos los précios existentes
        /// </summary>
        /// <returns>Tarea asíncrona que devuelve un array de objetos SinglebalancePrice</returns>
        Task<SinglebalancePrice[]> GetAllPrices();
        /// <summary>
        /// Recupera de forma asíncrona la lista de todos los minoristas existentes
        /// </summary>
        /// <returns>Tarea asíncrona que devuelve un array de objetos Retailer</returns>
        Task<Retailer[]> GetAllRetailers();
        /// <summary>
        /// Busca el modelo del minorista a partir de su código (PK)
        /// </summary>
        /// <param name="reCode">Código del minorista (PK)</param>
        /// <returns>Tarea asíncrona que devuelve un objeto Retailer</returns>
        Task<Retailer> GetRetailer(string reCode);
    }
}