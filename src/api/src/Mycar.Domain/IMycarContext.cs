using Mycar.Domain.Cars;

namespace Mycar.Domain
{
    public interface IMycarContext : IDisposable
    {
        IQueryable<Car> Cars { get; }

        Task AddAsync(object @object, CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task MigrateAsync(CancellationToken cancellationToken = default);
    }
}
