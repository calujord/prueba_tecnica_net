using eSettPruebatecnica.Application.Contracts.Persistence;
using eSettPruebatecnica.Infrastructure.Persistence;
using eSettPruebatecnica.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eSettPruebatecnica.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<eSettDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IBalanceRespPartieRepository, BalanceRespPartieRepository>();
            services.AddScoped<IBalanceServiceProviderRepository, BalanceServiceProviderRepository>();
            services.AddScoped<IDistributionSystemOperatorRepository, DistributionSystemOperatorRepository>();

            return services;
        }
    }
}
