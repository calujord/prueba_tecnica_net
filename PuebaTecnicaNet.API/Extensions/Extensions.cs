using PruebaTecnicaNet.Infraestructure;
using PruebaTecnicaNet.IntegrationEventLogEF.Services;
using PruebaTecnicaNet.API.Application.IntegrationEvents;
using PruebaTecnicaNet.API.Infrastructure;
using PruebaTecnicaNet.API;
using PruebaTecnicaNet.API.Application.Commands;
using PruebaTecnicaNet.API.Application.Validations;
using PruebaTecnicaNet.API.Application.Queries;
using PruebaTecnicaNet.Domain.SettlementBankAggregate;
using PruebaTecnicaNet.Infraestructure.Repositories;
using PruebaTecnicaNet.Infraestructure.Idempotency;
using PruebaTecnicaNet.API.Application.IntegrationEvents.EventHandling;
using PruebaTecnicaNet.API.Application.IntegrationEvents.Events;
using PruebaTecnicaNet.API.Application.Behaviors;
using PruebaTecnicaNet.Application.Behaviors;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        
        // Add the authentication services to DI
        // builder.AddDefaultAuthentication();

        // Pooling is disabled because of the following error:
        // Unhandled exception. System.InvalidOperationException:
        // The DbContext of type 'SettlementBankContext' cannot be pooled because it does not have a public constructor accepting a single parameter of type DbContextOptions or has more than one constructor.
        builder.AddNpgsqlDbContext<SettlementBankContext>("settlementBankdb", settings => settings.DbContextPooling = false);

        services.AddMigration<SettlementBankContext, SettlementBankContextSeed>();

        // Add the integration services that consume the DbContext
        services.AddTransient<IIntegrationEventLogService, IntegrationEventLogService<SettlementBankContext>>();

        services.AddTransient<ISettlementBankIntegrationEventService, SettlementBankIntegrationEventService>();

        builder.AddRabbitMqEventBus("eventbus")
               .AddEventBusSubscriptions();

        services.AddHttpContextAccessor();
        // services.AddTransient<IIdentityService, IdentityService>();

        // Configure mediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(Program));

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
            // cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        // Register the command validators for the validator behavior (validators based on FluentValidation library)
        services.AddSingleton<IValidator<CreateSettlementBankCommand>, CreateSettlementBankCommandValidator>();

        services.AddScoped<ISettlementBankQueries, SettlementBankQueries>();
        services.AddScoped<ISettlementBankRepository, SettlementBankRepository>();
        services.AddScoped<IRequestManager, RequestManager>();
        // services.AddScoped<SettlementBankServices>();

    }

    private static void AddEventBusSubscriptions(this IEventBusBuilder eventBus)
    {
        eventBus.AddSubscription<SettlementBankUpdatedSucceedIntegrationEvent, SettlementBankUpdatedSucceedIntegrationEventHandler>();
    }
}
