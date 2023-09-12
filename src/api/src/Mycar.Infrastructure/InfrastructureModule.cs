using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mycar.Infrastructure.Persistence;
using Mycar.Infrastructure.Seeders;

namespace Mycar.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddPersistenceModule(configuration)
                .AddSeedersModule(configuration);
        }
    }
}
