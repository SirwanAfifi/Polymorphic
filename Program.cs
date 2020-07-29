using Microsoft.Extensions.DependencyInjection;
using Polymorphic.Data;

namespace Polymorphic
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<MyDbContext>();

            var faker = new Bogus.Faker();
            
            
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>();
        }
    }
}