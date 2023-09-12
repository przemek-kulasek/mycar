using Microsoft.EntityFrameworkCore;

namespace Mycar.Common.Persistence
{
    public class ContextBase
    {
        private readonly DbContext _databaseContext;

        public ContextBase(DbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }

        public async Task AddAsync(object @object, CancellationToken cancellationToken = default)
        {
            await _databaseContext.AddAsync(@object, cancellationToken);
        }

        public async Task AddRangeAsync(IEnumerable<object> @object, CancellationToken cancellationToken = default)
        {
            await _databaseContext.AddRangeAsync(@object, cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }

        public async Task MigrateAsync(CancellationToken cancellationToken = default)
        {
            await _databaseContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
