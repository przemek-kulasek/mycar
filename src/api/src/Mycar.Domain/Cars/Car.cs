using Mycar.Common.Types;
using Mycar.Domain.Maintenance;

namespace Mycar.Domain.Cars
{
    public class Car : BaseEntity
    {
        public Car() : base(Guid.Empty)
        {
            IdentificationNumber = string.Empty;
            Brand = string.Empty;
            Model = string.Empty;
            Operations = new List<Operation>();
        }

        public Car(Guid id,
            string identificationNumber,
            string brand,
            string model,
            int yearOfProduction,
            int yearOfRegistration,
            string? colorDescription = null,
            string? engineDescription = null,
            string? additionalDescription = null,
            ICollection<Operation>? operations = null) 
            : base(id)
        {
            IdentificationNumber = identificationNumber;
            Brand = brand;
            Model = model;
            YearOfProduction = yearOfProduction;
            YearOfRegistration = yearOfRegistration;
            ColorDescription = colorDescription;
            EngineDescription = engineDescription;
            AdditionalDescription = additionalDescription;
            Operations = operations ?? new List<Operation>();
        }

        public string IdentificationNumber { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int YearOfProduction { get; private set; }
        public int YearOfRegistration { get; private set; }
        public string? ColorDescription { get; private set; }
        public string? EngineDescription { get; private set; }
        public string? AdditionalDescription { get; private set; }

        public ICollection<Operation> Operations { get; private set; }
    }
}
