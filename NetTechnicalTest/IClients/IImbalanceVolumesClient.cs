using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Volúmenes de desequilibrio (EXP13)
    /// </summary>
    public interface IImbalanceVolumesClient
    {
        /// <summary>
        /// Devuelve la lista volúmenes de desequilibrio por MBA.
        /// </summary>
        /// <param name="end">Fecha de finalización</param>
        /// <param name="mba">Código de MBA</param>
        /// <param name="start">Fecha de inicio</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns></returns>
        Task<ICollection<ImbalanceVolumeDTO>> ImbalancePowerVolumeAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de opciones MBA
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null);
    }
}