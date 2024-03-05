using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Consumo (EXP15)
    /// </summary>
    public interface IConsumptionClient
    {
        /// <summary>
        /// Devuelve la lista de consumo agregado
        /// </summary>
        /// <param name="end">Fecha de finalización</param>
        /// <param name="mba">Código de MBA</param>
        /// <param name="start">Fecha de inicio</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo AggregatedConsumptionDTO</returns>
        Task<ICollection<AggregatedConsumptionDTO>> ConsumptionAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de opciones MBA
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null);
    }
}