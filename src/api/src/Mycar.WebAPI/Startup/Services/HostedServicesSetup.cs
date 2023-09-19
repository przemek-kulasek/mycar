using Mycar.WebAPI.Bootstrappers;

namespace Mycar.WebAPI.Startup.Services;

public static class HostedServicesSetup
{
    public static IServiceCollection AddHostedServices(this IServiceCollection services)
    {
        services.AddHostedService<MycarBootstrapper>();
        return services;
    }
}