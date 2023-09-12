namespace Mycar.WebAPI.Startup.Services
{
    public static class SwaggerSetup
    {
        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
