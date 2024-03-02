using PruebaTecnicaNet.EventBus.Events;

namespace PruebaTecnicaNet.API.Application.IntegrationEvents;

public interface ISettlementBankIntegrationEventService
{
    Task PublishEventsThroughEventBusAsync(Guid transactionId);
    Task AddAndSaveEventAsync(IntegrationEvent evt);
}