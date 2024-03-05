using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Responsabilidad del Precios de conciliación (EXP17)
    /// </summary>
    public interface IReconciliationPricesClient
    {
        /// <summary>
        /// Devuelve la lista de opciones MBA
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de precios de conciliación por MBA en la zona horaria SNT.
        /// </summary>
        /// <param name="end">Fecha de finalización</param>
        /// <param name="mba">Código de MBA</param>
        /// <param name="start">Fecha de inicio</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo ReconciliationPriceDTO</returns>
        Task<ICollection<ReconciliationPriceDTO>> ReconciliationPricesAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null);
    }
}