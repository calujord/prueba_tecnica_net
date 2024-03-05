using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Honorarios (EXP05)
    /// </summary>
    public interface IFeesClient
    {
        /// <summary>
        /// Devuelve la lista de honorarios
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo FeesDTO</returns>
        Task<ICollection<FeesDTO>> FeesAsync(CancellationToken? cancellationToken = null);
    }
}