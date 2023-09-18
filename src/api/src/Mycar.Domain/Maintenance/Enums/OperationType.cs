using System.Text.Json.Serialization;

namespace Mycar.Domain.Maintenance.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OperationType
    {
        SelfMaintenance = 0,
        ExternalShop = 1
    }
}
