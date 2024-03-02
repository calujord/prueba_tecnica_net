using PruebaTecnicaNet.API.Application.Commands;
using PruebaTecnicaNet.API.Application.IntegrationEvents.Events;
using PruebaTecnicaNet.EventBus.Abstractions;
using PruebaTecnicaNet.EventBus.Extensions;

namespace PruebaTecnicaNet.API.Application.IntegrationEvents.EventHandling;

public class SettlementBankUpdatedSucceedIntegrationEventHandler(
    IMediator mediator,
    ILogger<SettlementBankUpdatedSucceedIntegrationEventHandler> logger) :
    IIntegrationEventHandler<SettlementBankUpdatedSucceedIntegrationEvent>
{
    public async Task Handle(SettlementBankUpdatedSucceedIntegrationEvent @event)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - ({@IntegrationEvent})", @event.Id, @event);

        var command = new CreateSettlementBankCommand(@event.Bic, @event.Name, @event.Country);

        logger.LogInformation("----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})", 
            @command.GetType().GetGenericTypeName(), 
            nameof(@command.Bic),
            @command.Bic,
            command);

        await mediator.Send(command);
    }
}
