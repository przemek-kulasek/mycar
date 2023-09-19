using Mycar.Common.Persistence;
using Mycar.Domain;
using Mycar.Domain.Cars;
using Mycar.Domain.Maintenance;

namespace Mycar.Infrastructure.Persistence;

public class MycarDomainContext : ContextBase, IMycarContext
{
    private readonly MycarDatabaseContext _databaseContext;

    public MycarDomainContext(MycarDatabaseContext databaseContext) : base(databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IQueryable<Car> Cars => _databaseContext.Cars;
    public IQueryable<Operation> Operations => _databaseContext.Operations;
    public IQueryable<Item> Items => _databaseContext.Items;
}