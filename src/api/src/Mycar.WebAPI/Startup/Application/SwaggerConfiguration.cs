namespace Mycar.WebAPI.Startup.Application
{
    public static class SwaggerConfiguration
    {
        public static WebApplication ConfigureSwagger(this WebApplication application)
        {
            if(application.Environment.IsDevelopment())
            {
                application.UseSwagger();
                application.UseSwaggerUI();
            }

            return application;
        }
    }
}
