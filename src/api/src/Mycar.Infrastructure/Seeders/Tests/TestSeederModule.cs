using Microsoft.Extensions.DependencyInjection;
using Mycar.Infrastructure.Seeders.Tests.Data;

namespace Mycar.Infrastructure.Seeders.Tests
{
    public static class TestSeederModule
    {
        public static IServiceCollection AddTestSeederModule(this IServiceCollection services)
        {
            return services
                .AddScoped<ITestDataSeeder, TestDataSeeder>()
                .AddScoped<CarsTestData>()
                .AddScoped<OperationsTestData>();
        }
    }
}
