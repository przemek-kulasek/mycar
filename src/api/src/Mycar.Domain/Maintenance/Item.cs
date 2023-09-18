using Mycar.Common.Types;
using Mycar.Domain.Maintenance.Enums;

namespace Mycar.Domain.Maintenance
{
    public class Item : BaseEntity
    {
        private Item() : base(Guid.Empty)
        {
            Description = string.Empty;
            Operation = new Operation(Guid.Empty, string.Empty, OperationType.SelfMaintenance, 0, Guid.Empty);
        }

        public Item(Guid id, string description, ItemType itemType, Guid operationId, Operation operation = null!) 
            : base(id)
        {
            Description = description;
            ItemType = itemType;
            OperationId = operationId;
            Operation = operation;
        }

        public string Description { get; private set; }
        public ItemType ItemType { get; private set; }
        public Guid OperationId { get; private set; }
        public Operation Operation { get; private set; }
    }
}
