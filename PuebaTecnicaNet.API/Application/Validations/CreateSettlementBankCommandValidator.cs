using PruebaTecnicaNet.API.Application.Commands;

namespace PruebaTecnicaNet.API.Application.Validations;

public class CreateSettlementBankCommandValidator : AbstractValidator<CreateSettlementBankCommand>
{
    public CreateSettlementBankCommandValidator(ILogger<CreateSettlementBankCommandValidator> logger)
    {
        RuleFor(x => x.Bic).NotEmpty().Length(8);
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Country).NotEmpty().Length(2);

        if (logger.IsEnabled(LogLevel.Trace))
        {
            logger.LogTrace("INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}