using Mycar.Domain.Maintenance;
using Mycar.Domain.Maintenance.Enums;

namespace Mycar.Infrastructure.Seeders.Tests.Data
{
    public class OperationsTestData
    {
        public Operation[] Operations => new[]
        {
            new Operation(
                new Guid("f12e1fef-1432-4a39-9434-0182e63e838b"),
                "Initial service in Poland. Check carfax for history in US.",
                OperationType.ExternalShop,
                82766,
                new Guid("45ce2cbf-1146-4329-b605-aa2b9fc8934e")
                )
        };
    }
}
