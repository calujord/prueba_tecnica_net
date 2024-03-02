namespace PruebaTecnicaNet.API.Application.Commands;

using PruebaTecnicaNet.Domain.SettlementBankAggregate;
using PruebaTecnicaNet.Infraestructure.Idempotency;

// Regular CommandHandler
public class CreateSettlementBankCommandHandler : IRequestHandler<CreateSettlementBankCommand, bool>
{
    private readonly ISettlementBankRepository _settlementBankRepository;
    private readonly ILogger<CreateSettlementBankCommandHandler> _logger;

    // Using DI to inject infrastructure persistence Repositories
    public CreateSettlementBankCommandHandler(
           ISettlementBankRepository settlementBankRepository,
           ILogger<CreateSettlementBankCommandHandler> logger)
    {
        _settlementBankRepository = settlementBankRepository ?? throw new ArgumentNullException(nameof(settlementBankRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(CreateSettlementBankCommand message, CancellationToken cancellationToken)
    {
        // TODO: Add Integration event

        // Add/Update the SettlementBank AggregateRoot
        // DDD patterns comment: Add child entities and value-objects through the SettlementBank Aggregate-Root
        // methods and constructor so validations, invariants and business logic 
        // make sure that consistency is preserved across the whole aggregate
        var settlementBank = new SettlementBank(message.Bic, message.Country, message.Name);

        _logger.LogInformation("----- Creating SettlementBank - SettlementBank: {@SettlementBank}", settlementBank);
        if (_settlementBankRepository.GetAsync(settlementBank.Bic) != null)
            return true;

        _settlementBankRepository.Add(settlementBank);

        return await _settlementBankRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}

// Use for Idempotency in Command process
public class CreateSettlementBankIdentifiedCommandHandler : IdentifiedCommandHandler<CreateSettlementBankCommand, bool>
{
    public CreateSettlementBankIdentifiedCommandHandler(
        IMediator mediator,
        IRequestManager requestManager,
        ILogger<IdentifiedCommandHandler<CreateSettlementBankCommand, bool>> logger)
        : base(mediator, requestManager, logger)
    {
    }

    protected override bool CreateResultForDuplicateRequest()
    {
        return true;
    }
}

