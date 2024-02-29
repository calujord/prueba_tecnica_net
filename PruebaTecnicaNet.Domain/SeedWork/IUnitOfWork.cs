using System;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Domain.SeedWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}