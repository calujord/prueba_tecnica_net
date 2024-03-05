using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Precios históricos de dos saldos (EXP08)
    /// </summary>
    public interface IHistoricalTwoBalancePricesClient
    {
        /// <summary>
        /// Devuelve volúmenes de desequilibrio históricos por MBA (dos saldos).
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de desequilibrios
        /// </summary>
        /// <param name="end">Fecha de finalización</param>
        /// <param name="mba">Código de MBA</param>
        /// <param name="start">Fecha de inicio</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo TwobalancePriceDTO</returns>
        Task<ICollection<TwobalancePriceDTO>> PricesAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null);
    }
}