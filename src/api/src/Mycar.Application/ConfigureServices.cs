using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Mycar.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        return services
            .AddValidatorsFromAssembly(typeof(ConfigureServices).Assembly)
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly))
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}