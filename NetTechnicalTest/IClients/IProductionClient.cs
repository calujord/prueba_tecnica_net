using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Producción (EXP16)
    /// </summary>
    public interface IProductionClient
    {
        /// <summary>
        /// Devuelve la lista de opciones MBA
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de producción agregada por MBA y tipo de unidad de producción.
        /// </summary>
        /// <param name="end">Fecha de finalización</param>
        /// <param name="mba">Código de MBA</param>
        /// <param name="start">Fecha de inicio</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo ProductionVolumesDTO</returns>
        Task<ICollection<ProductionVolumesDTO>> VolumesAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null);
    }
}