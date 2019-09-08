using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.Interfaces.Repository;

namespace SupplyOfProducts.Persistance
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureRepositoryServices(IServiceCollection services)
        {

            services.AddTransient<MemoryContext>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductSupplyRepository, ProductSupplyRepository>();
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddTransient<IWorkerInWorkPlaceRepository, WorkerInWorkPlaceRepository>();
            services.AddTransient<IWorkPlaceRepository, WorkPlaceRepository>();
            services.AddTransient<IProductStockRepository, ProductStockRepository>();
            services.AddTransient<ISupplyScheduledRepository, SupplyScheduledRepository>();
        }
    }
}
