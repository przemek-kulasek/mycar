using System.Text.Json.Serialization;

namespace Mycar.WebAPI.Startup.Services;

public static class ConvertersSetup
{
    public static IServiceCollection AddConverters(this IServiceCollection services)
    {
        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        return services;
    }
}