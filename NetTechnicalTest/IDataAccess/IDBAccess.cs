using NetTechnicalTest.Model;

namespace NetTechnicalTest.IDataAccess
{
    /// <summary>
    /// Definición de los procesos de recuperación y persistencia del modelo
    /// </summary>
    public interface IDBAccess
    {
        /// <summary>
        /// Almacena una lista de minoristas
        /// </summary>
        /// <param name="retailers">Listado de objetos Retailer</param>
        /// <returns>Tarea asíncrona</returns>
        Task SaveRetailers(IEnumerable<Retailer> retailers);
        /// <summary>
        /// Recupera la lista de minoristas
        /// </summary>
        /// <returns>Tarea asíncrona que devuelve un listado de objetos Retailer</returns>
        Task<IEnumerable<Retailer>> AllRetailers();
        /// <summary>
        /// Recupera un minorista a partir de su código (PK)
        /// </summary>
        /// <param name="reCode">Código unico del minorista (PK)</param>
        /// <returns>Objeto Retailer</returns>
        Task<Retailer> GetRetailer(string reCode);

        /// <summary>
        /// Almacena una lista de precios
        /// </summary>
        /// <param name="singlebalancePrices">Listado de objetos SinglebalancePrice</param>
        /// <returns>Tarea asíncrona</returns>
        Task SaveSinglebalancePrices(IEnumerable<SinglebalancePrice> singlebalancePrices);
        /// <summary>
        /// Recupera la lista de precios
        /// </summary>
        /// <returns>Tarea asíncrona que devuelve un listado de objetos SinglebalancePrice</returns>
        Task<IEnumerable<SinglebalancePrice>> AllSinglebalancePrices();
    }
}