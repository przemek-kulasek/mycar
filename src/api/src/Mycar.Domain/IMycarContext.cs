using Mycar.Domain.Cars;
using Mycar.Domain.Maintenance;

namespace Mycar.Domain;

public interface IMycarContext : IDisposable
{
    IQueryable<Car> Cars { get; }
    IQueryable<Operation> Operations { get; }
    IQueryable<Item> Items { get; }

    Task AddAsync(object @object, CancellationToken cancellationToken = default);
    void Remove(object @object);
    void RemoveRange(IEnumerable<object> @object);
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task MigrateAsync(CancellationToken cancellationToken = default);
}