using Mycar.Application;

namespace Mycar.WebAPI.Startup.Services
{
    public static class ModulesSetup
    {
        public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationModule();
            return services;
        }
    }
}
