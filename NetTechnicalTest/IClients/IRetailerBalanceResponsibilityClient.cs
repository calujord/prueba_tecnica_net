using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Responsabilidad del Saldo del Minorista (EXP04)
    /// </summary>
    public interface IRetailerBalanceResponsibilityClient
    {
        /// <summary>
        /// Devuelve la lista de opciones MBA
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve las lista de las responsabilidades del saldo del minorista; los resultados están limitados a 10000 filas
        /// </summary>
        /// <param name="brpName">Nombre BRP</param>
        /// <param name="mba">Códigos MBA</param>
        /// <param name="mga">Nombre MGA</param>
        /// <param name="retailerName">Mombre del minorista</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo RetailerBalanceResponsibilityDTO</returns>
        Task<ICollection<RetailerBalanceResponsibilityDTO>> RetailerBalanceResponsibilityAsync(string brpName, IEnumerable<string> mba, string mga, string retailerName, CancellationToken? cancellationToken = null);
    }
}