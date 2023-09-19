using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mycar.Domain.Cars;

namespace Mycar.Infrastructure.Persistence.Configurations;

internal class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.IdentificationNumber);
        builder.HasQueryFilter(c => !c.IsDeleted);

        builder.HasMany(x => x.Operations)
            .WithOne(x => x.Car)
            .HasForeignKey(x => x.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}