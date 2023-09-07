using Mycar.WebAPI.Middlewares;

namespace Mycar.WebAPI.Startup.Application
{
    public static class MiddlewaresConfiguration
    {
        public static WebApplication ConfigureMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
