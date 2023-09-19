using Mycar.Common.Types.Abstractions;
using Mycar.Infrastructure.Persistence;
using Mycar.Infrastructure.Seeders.Tests.Data;

namespace Mycar.Infrastructure.Seeders.Tests;

public interface ITestDataSeeder
{
    Task SeedAsync(CancellationToken cancellationToken = default);
}

internal class TestDataSeeder : ITestDataSeeder
{
    private readonly CarsTestData _carsTestData;
    private readonly SeedersConfiguration _configuration;

    private readonly MycarDatabaseContext _context;

    public TestDataSeeder(CarsTestData carsTestData,
        MycarDatabaseContext context, SeedersConfiguration configuration)
    {
        _carsTestData = carsTestData;
        _context = context;
        _configuration = configuration;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        await AddAsync(CarsTestData.Cars);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task AddAsync<TModel>(params TModel[] entities)
        where TModel : class, IIdentity
    {
        var ids = entities.Select(x => x.Id);
        var existed = _context.Set<TModel>().Where(x => ids.Contains(x.Id));
        var toInsert = entities.Where(x => existed.All(e => e.Id != x.Id));

        await _context.AddRangeAsync(toInsert);
    }
}