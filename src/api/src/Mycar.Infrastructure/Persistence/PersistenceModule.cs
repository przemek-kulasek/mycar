using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mycar.Common.Extensions;
using Mycar.Domain;

namespace Mycar.Infrastructure.Persistence;

internal static class PersistenceModule
{
    public static IServiceCollection AddPersistenceModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddConfiguration<SqlConfiguration>(configuration)
            .AddScoped<IMycarContext, MycarDomainContext>()
            .AddDbContextPool<MycarDatabaseContext>((provider, settings) =>
            {
                var sqlConfiguration = provider.GetRequiredService<SqlConfiguration>();
                settings.UseNpgsql(sqlConfiguration.ConnectionString);
                settings.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                settings.EnableSensitiveDataLogging(sqlConfiguration.SensitiveDataLogging);
            });
    }
}