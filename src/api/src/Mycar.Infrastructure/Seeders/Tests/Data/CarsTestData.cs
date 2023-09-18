using Mycar.Domain.Cars;
using Mycar.Domain.Maintenance;
using Mycar.Domain.Maintenance.Enums;

namespace Mycar.Infrastructure.Seeders.Tests.Data
{
    public class CarsTestData
    {
        public Car[] Cars => new[]
        {
            new Car(
                new Guid("45ce2cbf-1146-4329-b605-aa2b9fc8934e"),
                "ZARFAEBN4H75XXXXX",
                "Alfa Romeo",
                "Giulia",
                2016,
                2017,
                "White",
                "2L Turbo 280HP",
                operations: new Operation[]
                {
                    new(
                        new Guid("f12e1fef-1432-4a39-9434-0182e63e838b"),
                        "Initial service in Poland. Check carfax for history in US.",
                        OperationType.ExternalShop,
                        82766,
                        new Guid("45ce2cbf-1146-4329-b605-aa2b9fc8934e"),
                        items: new Item[] {
                                new(
                                    new Guid("b8c018a1-8526-4e04-a950-1b2cd34d020b"),
                                    "Olej w silniku i skrzyni biegów.",
                                    ItemType.Maintenance,
                                    new Guid("f12e1fef-1432-4a39-9434-0182e63e838b")
                                    ),
                                new(
                                    new Guid("801848d7-7296-4b68-8239-4d8e4e40c674"),
                                    "Klocki hamulcowe przód i tył.",
                                    ItemType.Maintenance,
                                    new Guid("f12e1fef-1432-4a39-9434-0182e63e838b")
                                    ),
                            new(
                                    new Guid("bb3bb91a-4734-4ac0-a793-60a8139e59c5"),
                                    "Komplet filtrów.",
                                    ItemType.Maintenance,
                                    new Guid("f12e1fef-1432-4a39-9434-0182e63e838b")
                                    ),
                            new(
                                    new Guid("960ec26f-56b1-47d6-8a1d-6bee7bdfb172"),
                                    "Serwis klimatyzacji.",
                                    ItemType.Maintenance,
                                    new Guid("f12e1fef-1432-4a39-9434-0182e63e838b")
                                    ),
                            new(
                                    new Guid("d3f67e01-ca13-4585-919f-4bf87cb55850"),
                                    "Wymiana akumulatora.",
                                    ItemType.Repair,
                                    new Guid("f12e1fef-1432-4a39-9434-0182e63e838b")
                                    )
                            }
                        )
                })
        };
    }
}
