namespace Mycar.Infrastructure.Seeders;

public class SeedersConfiguration
{
    public TestConfiguration Test { get; set; } = null!;
}

public class TestConfiguration
{
    public bool Enabled { get; set; }
}