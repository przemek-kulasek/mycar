using MediatR;
using Mycar.WebAPI.Pipelines;

namespace Mycar.WebAPI.Startup.Services
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterDependencyInjection(this  IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
            return services;
        }
    }
}
