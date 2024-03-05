using NetTechnicalTest.Model;
using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Precios (saldo único) (EXP14)
    /// </summary>
    public interface IPricesClient
    {
        /// <summary>
        /// Devuelve la lista de opciones MBA
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo MBAOptionsDTO</returns>
        Task<ICollection<MBAOptionsDTO>> MBAOptionsAsync(CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de precios de saldo único por MBA.
        /// </summary>
        /// <param name="end">Fecha de finalización</param>
        /// <param name="mba">Código de MBA</param>
        /// <param name="start">Fecha de inicio</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo SinglebalancePriceDTO</returns>
        Task<ICollection<SinglebalancePriceDTO>> PricesAsync(DateTime end, IEnumerable<string> mba, DateTime start, CancellationToken? cancellationToken = null);
    }
}