using Mycar.Common.Types;
using Mycar.Domain.Cars;
using Mycar.Domain.Maintenance.Enums;

namespace Mycar.Domain.Maintenance
{
    public class Operation : BaseEntity
    {
        private Operation() : base(Guid.Empty)
        {
            Items = Array.Empty<Item>();
        }

        public Operation(Guid id, string description, OperationType operationType, int mileage, Guid carId, Car car = null!, ICollection<Item>? items = null)
            : base(id)
        {
            Description = description;
            OperationType = operationType;
            Mileage = mileage;
            CarId = carId;
            Car = car;
            Items = items ?? Array.Empty<Item>();
        }

        public string Description { get; private set; }
        public OperationType OperationType { get; private set; }
        public int Mileage { get; private set; }
        
        public ICollection<Item>? Items { get; private set; }
        
        public Guid CarId { get; private set; }
        public Car Car { get; private set; }
    }
}
