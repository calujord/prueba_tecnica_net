using System.Threading.Tasks;

namespace PruebaTecnicaNet.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event);
}
