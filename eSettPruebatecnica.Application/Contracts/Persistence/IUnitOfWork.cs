using eSettPruebatecnica.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace eSettPruebatecnica.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IBalanceRespPartieRepository BalanceRespPartieRepository { get; }
        IBalanceServiceProviderRepository BalanceServiceProviderRepository { get; }
        IDistributionSystemOperatorRepository DistributionSystemOperatorRepository { get; }
        IRetailerRepository RetailerRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
    }
}
