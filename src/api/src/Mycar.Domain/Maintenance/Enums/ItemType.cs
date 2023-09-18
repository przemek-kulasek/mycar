using System.Text.Json.Serialization;

namespace Mycar.Domain.Maintenance.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ItemType
    {
        General = 0,
        Maintenance = 1,
        Repair = 2,
        Tuning = 3,
        Detailing = 4
    }
}
