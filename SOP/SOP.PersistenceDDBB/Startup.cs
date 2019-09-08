using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Repository;
using SupplyOfProducts.PersistenceDDBB.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity.SqlServer;

namespace SupplyOfProducts.PersistenceDDBB
{
    public class Startup
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureRepositoryServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {

            //services.AddDbContext<SupplyOfProductsContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
            //));

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
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public StartupWeb(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureRepositoryServices(IServiceCollection services)
        {

            //services.AddSingleton<SupplyOfProductsContext>();
                
            //    DbContext<>(
            //    options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")

            //),ServiceLifetime.Transient);

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
