using Mycar.Domain.Cars;

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
                "2L Turbo 280HP")
        };
    }
}
