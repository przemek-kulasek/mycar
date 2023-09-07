﻿using Mycar.Common.Types;

namespace Mycar.Domain.Cars
{
    public class Car : BaseEntity
    {
        public Car(Guid id,
            string identificationNumber,
            string brand,
            string model,
            int yearOfProduction,
            int yearOfRegistration,
            string? colorDescription = null,
            string? engineDescription = null,
            string? additionalDescription = null) 
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
        }

        public string IdentificationNumber { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int YearOfProduction { get; private set; }
        public int YearOfRegistration { get; private set; }
        public string? ColorDescription { get; private set; }
        public string? EngineDescription { get; private set; }
        public string? AdditionalDescription { get; private set; }
    }
}