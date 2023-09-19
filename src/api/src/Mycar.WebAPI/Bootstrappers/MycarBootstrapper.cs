using Mycar.Domain;
using Mycar.Infrastructure.Seeders;
using Mycar.Infrastructure.Seeders.Tests;

namespace Mycar.WebAPI.Bootstrappers;

public class MycarBootstrapper : IHostedService
{
    private readonly IServiceProvider _provider;

    public MycarBootstrapper(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _provider.CreateScope();

        await MigrateAsync(scope, cancellationToken);
        await SeedAsync(scope.ServiceProvider, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private static async Task MigrateAsync(IServiceScope scope, CancellationToken cancellationToken)
    {
        var ctx = scope.ServiceProvider.GetRequiredService<IMycarContext>();
        await ctx.MigrateAsync(cancellationToken);
    }

    private static async Task SeedAsync(
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken = default)
    {
        var configuration = serviceProvider.GetRequiredService<SeedersConfiguration>();

        if (configuration.Test.Enabled)
        {
            var seeder = serviceProvider.GetRequiredService<ITestDataSeeder>();
            await seeder.SeedAsync(cancellationToken);
        }
    }
}