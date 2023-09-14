using Mycar.Domain.Maintenance.Enums;

namespace Mycar.Application.Dtos
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public required string Description { get; set; }
        public ItemType ItemType { get; set; }
        public Guid OperationId { get; set; }
    }
}
