using OpenAPIClient;

namespace NetTechnicalTest.IClients
{
    /// <summary>
    /// Cliente de Banco de liquidaciones (EXP06)
    /// </summary>
    public interface ISettlementBanksClient
    {
        /// <summary>
        /// Devuelve la lista de devoluciones de Bancos
        /// </summary>
        /// <param name="cancellationToken">Notificación de que la operación debe cancelarse</param>
        /// <returns>Un objeto de tipo SettlementBankDTO</returns>
        Task<ICollection<SettlementBankDTO>> BanksAsync(CancellationToken? cancellationToken = null);
    }
}