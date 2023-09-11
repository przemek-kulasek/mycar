using Microsoft.EntityFrameworkCore;
using Mycar.Domain.Cars;

namespace Mycar.Infrastructure.Persistence;

public class MycarDatabaseContext : DbContext
{
    public DbSet<Car> Cars { get; set; } = null!;

    public MycarDatabaseContext(DbContextOptions options) : base(options) { }
}