using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mycar.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration<TConfiguration>(this IServiceCollection serviceCollection,
            IConfiguration configuration) where TConfiguration : class
        {
            var configurationType = typeof(TConfiguration);
            var configurationInstance = (TConfiguration)Activator.CreateInstance(configurationType)!;
            var section = configurationType.Name.Replace("Configuration", "");
            configuration.Bind(section, configurationInstance);

            return serviceCollection.AddSingleton(configurationInstance);
        }
    }
}
