using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Volúmenes históricos de dos saldos (EXP09)
    /// </summary>
    public interface IHistoricalTwoBalanceVolumesClient
    {
        /// <summary>
        /// Devuelve la lista de volúmenes de desequilibrio históricos por MBA (dos saldos).
        /// </summary>
        /// <param name="end">Fecha de finalización</param>
        /// <param name="mba">Código de MBA</param>
        /// <param name="start">Fecha de inicio</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo AggregatedConsumptionDTO</returns>
        Task<ICollection<ImbalanceVolumeTwobalanceDTO>> ImbalancePowerVolumeAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve volúmenes de desequilibrio históricos por MBA (dos saldos).
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null);
    }
}