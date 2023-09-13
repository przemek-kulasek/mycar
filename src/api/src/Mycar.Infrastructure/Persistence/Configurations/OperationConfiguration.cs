using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mycar.Domain.Maintenance;

namespace Mycar.Infrastructure.Persistence.Configurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Operation)
                .HasForeignKey(x => x.Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
