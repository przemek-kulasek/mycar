using Mycar.Application;
using Mycar.Infrastructure;

namespace Mycar.WebAPI.Startup.Services;

public static class ModulesSetup
{
    public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationModule();
        services.AddInfrastructureModule(configuration);
        return services;
    }
}