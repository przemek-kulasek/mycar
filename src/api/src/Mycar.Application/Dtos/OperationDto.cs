using Mycar.Domain.Maintenance.Enums;

namespace Mycar.Application.Dtos;

public class OperationDto
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public OperationType OperationType { get; set; }
    public int Mileage { get; set; }
    public Guid CarId { get; set; }
}