using PruebaTecnicaNet.API.Application.Queries;

namespace PruebaTecnicaNet.API;

public class SettlementBankServices
{
    public IMediator Mediator { get; set; }
    public ILogger<SettlementBankServices> Logger { get; }
    public ISettlementBankQueries Queries { get; }

    public SettlementBankServices(
        IMediator mediator,
        ISettlementBankQueries queries,
        ILogger<SettlementBankServices> logger)
    {
        Mediator= mediator;
        Logger= logger;
        Queries= queries;
    }
}