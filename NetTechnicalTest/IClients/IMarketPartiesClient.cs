using NetTechnicalTest.Model;
using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Partes de mercado (EXP01)
    /// </summary>
    public interface IMarketPartiesClient
    {
        /// <summary>
        /// Devuelve la lista de devoluciones de BRP
        /// </summary>
        /// <param name="code">Codigo BRP</param>
        /// <param name="country">Codigo ISO de 2 letras del país</param>
        /// <param name="name">Nombre del BRP, búsqueda de texto libre</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo BalanceResponsiblePartyDTO</returns>
        Task<ICollection<BalanceResponsiblePartyDTO>> BalanceResponsiblePartiesAsync(string code, string country, string name, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de BSP
        /// </summary>
        /// <param name="code">Codigo BRP</param>
        /// <param name="country">Codigo ISO de 2 letras del país</param>
        /// <param name="name">Nombre del BRP, búsqueda de texto libre</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo BalanceServiceProviderDTO</returns>
        Task<ICollection<BalanceServiceProviderDTO>> BalanceServiceProvidersAsync(string code, string country, string name, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de DSO
        /// </summary>
        /// <param name="code">Codigo BRP</param>
        /// <param name="country">Codigo ISO de 2 letras del país</param>
        /// <param name="name">Nombre del BRP, búsqueda de texto libre</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo DistributionSystemOperatorDTO</returns>
        Task<ICollection<DistributionSystemOperatorDTO>> DistributionSystemOperatorsAsync(string code, string country, string name, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Devuelve la lista de devoluciones de minoristas
        /// </summary>
        /// <param name="code">Codigo BRP</param>
        /// <param name="country">Codigo ISO de 2 letras del país</param>
        /// <param name="name">Nombre del BRP, búsqueda de texto libre</param>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Colección de objetos de tipo RetailerDTO</returns>
        Task<ICollection<RetailerDTO>> RetailersAsync(string? code, string country, string? name, CancellationToken? cancellationToken = null);
    }
}