using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Perfil de carag (EXP18)
    /// </summary>
    public interface ILoadProfileClient
    {
        /// <summary>
        /// Devuelve la lista de perfiles de carga de retorno por MGA agregado
        /// </summary>
        /// <param name="end">Fecha de finalización</param>
        /// <param name="mba">Código de MBA</param>
        /// <param name="mga">Código de MBA</param>
        /// <param name="start">Fecha de inicio</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MonthlyAggregationDTO</returns>
        Task<ICollection<MonthlyAggregationDTO>> AggregateAsync(DateTime end, IEnumerable<string> mba, string mga, DateTime start, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de perfiles de carga de retorno por MGA
        /// </summary>
        /// <param name="end">Fecha de finalización</param>
        /// <param name="mba">Código de MBA</param>
        /// <param name="mga">Código de MBA</param>
        /// <param name="start">Fecha de inicio</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo LoadProfileDTO</returns>
        Task<ICollection<LoadProfileDTO>> LoadProfileAsync(DateTime end, IEnumerable<string> mba, string mga, DateTime start, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de opciones MBA
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<ICollection<MBAOptionsDTO>>> MBAOptionsAsync(CancellationToken? cancellationToken = null);
    }
}