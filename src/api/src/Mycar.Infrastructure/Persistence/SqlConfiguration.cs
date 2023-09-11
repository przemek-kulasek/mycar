namespace Mycar.Infrastructure.Persistence;

public class SqlConfiguration
{
    public string ConnectionString { get; set; } = null!;
    public bool SensitiveDataLogging { get; set; } = false;
}