using eSettPruebatecnica.Application.Contracts.Persistence;
using eSettPruebatecnica.Domain.Common;
using eSettPruebatecnica.Infrastructure.Persistence;
using System.Collections;


namespace eSettPruebatecnica.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly eSettDbContext _context;

        private IBalanceRespPartieRepository _balanceRespPartieRepository;
        private IBalanceServiceProviderRepository _balanceServiceProviderRepository;
        private IDistributionSystemOperatorRepository _distributionSystemOperatorRepository;
        private RetailerRepository _retailerRepository;
        public IBalanceRespPartieRepository BalanceRespPartieRepository => _balanceRespPartieRepository ??= new BalanceRespPartieRepository(_context);
        public IBalanceServiceProviderRepository BalanceServiceProviderRepository => _balanceServiceProviderRepository ??= new BalanceServiceProviderRepository(_context);
        public IDistributionSystemOperatorRepository DistributionSystemOperatorRepository => _distributionSystemOperatorRepository ??= new DistributionSystemOperatorRepository(_context);
        public IRetailerRepository RetailerRepository => _retailerRepository ??= new RetailerRepository(_context);

        public UnitOfWork(eSettDbContext context)
        {
            _context = context;
        }

        public eSettDbContext eSettDbContext => _context;

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Err");
            }

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }


    }
}
