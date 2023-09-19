namespace Mycar.Application.Dtos;

public class CarDto
{
    public Guid Id { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string Brand { get; set; }
    public required string Model { get; set; }
    public int YearOfProduction { get; set; }
    public int YearOfRegistration { get; set; }
    public string? ColorDescription { get; set; }
    public string? EngineDescription { get; set; }
    public string? AdditionalDescription { get; set; }
}