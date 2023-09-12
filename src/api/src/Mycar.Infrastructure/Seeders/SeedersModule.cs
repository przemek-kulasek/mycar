using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mycar.Common.Extensions;
using Mycar.Infrastructure.Seeders.Tests;

namespace Mycar.Infrastructure.Seeders
{
    public static class SeedersModule
    {
        public static IServiceCollection AddSeedersModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddConfiguration<SeedersConfiguration>(configuration)
                .AddTestSeederModule();
        }
    }
}
