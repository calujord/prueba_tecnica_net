using System;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.Infraestructure.Idempotency;

public interface IRequestManager
{
    Task<bool> ExistAsync(Guid id);

    Task CreateRequestForCommandAsync<T>(Guid id);
}
