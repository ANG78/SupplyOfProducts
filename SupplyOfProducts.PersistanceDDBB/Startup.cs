using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Repository;
using SupplyOfProducts.PersistanceDDBB.Repository;

namespace SupplyOfProducts.PersistanceDDBB
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

            services.AddDbContext<SupplyOfProductsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
            ));

            // Add Repositories. 
            services.AddSingleton<IGenericContext, SupplyOfProductsContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductSupplyRepository, ProductSupplyRepository>();
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddTransient<IWorkerInWorkPlaceRepository, WorkerInWorkPlaceRepository>();
            services.AddTransient<IWorkPlaceRepository, WorkPlaceRepository>();
            services.AddTransient<IProductStockRepository, ProductStockRepository>();
            services.AddTransient<ISupplyScheduledRepository, SupplyScheduledRepository>();
            services.AddTransient<IConfigSupplyRepository, ConfigSupplyRepository>();

        }
    }

    public partial class StartupWeb
    {
        public IConfiguration Configuration { get; }

        public StartupWeb(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureRepositoryServices(IServiceCollection services)
        {

            services.AddDbContext<SupplyOfProductsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
            ));

            // Add Repositories. 
            services.AddScoped<IGenericContext, SupplyOfProductsContext>();
            //services.AddSingleton<IGenericContext, SupplyOfProductsContext>();
            services.AddScoped<ICreateUoW, DecoratorICreateUoW>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductSupplyRepository, ProductSupplyRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            services.AddScoped<IWorkerInWorkPlaceRepository, WorkerInWorkPlaceRepository>();
            services.AddScoped<IWorkPlaceRepository, WorkPlaceRepository>();
            services.AddScoped<IProductStockRepository, ProductStockRepository>();
            services.AddScoped<ISupplyScheduledRepository, SupplyScheduledRepository>();
            services.AddScoped<IConfigSupplyRepository, ConfigSupplyRepository>();

        }

    }
}
