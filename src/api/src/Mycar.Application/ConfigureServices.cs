using Microsoft.Extensions.DependencyInjection;

namespace Mycar.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            return services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly));
        }
    }
}
