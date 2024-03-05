using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Áreas de la red de medición (EXP03)
    /// </summary>
    public interface IMeteringGridAreasClient
    {
        /// <summary>
        /// Devuelve la lista de devoluciones de MGA
        /// </summary>
        /// <param name="dsoName">Nombre de DSO, búsqueda de texto libre</param>
        /// <param name="mba">Codigo MBA</param>
        /// <param name="mgaCode">Codigo MGA</param>
        /// <param name="mgaName">Nombre MGA</param>
        /// <param name="mgaType">Tipo MGA</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<MeteringGridAreaDto>> MeteringGridAreasAsync(string dsoName, IEnumerable<string> mba, string mgaCode, string mgaName, string mgaType, CancellationToken? cancellationToken = null);
    }
}