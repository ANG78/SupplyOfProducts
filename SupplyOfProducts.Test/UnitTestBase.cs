using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Persistance;
using System;

namespace SupplyOfProducts.Test
{
    public class UnitTestBase
    {
        protected static ServiceProvider Provider = null;
        protected static ServiceProvider ProviderDB = null;
        private static object referenceLocking = new object(); 

        protected string userMocked = "W01";

        protected UnitTestBase()
        {
            var conf = new ConfigurationBuilder();
            conf.AddJsonFile("appsettings.json");

            if (Provider == null)
            {
                lock (referenceLocking)
                {
                    var services = new ServiceCollection();
                    Startup start = new Startup(conf.Build(),false);
                    start.ConfigureRepositoryServices(services);

                    Provider = services.BuildServiceProvider();
                }
            }

            if (ProviderDB == null)
            {
                lock (referenceLocking)
                {
                    var services = new ServiceCollection();
                    Startup start = new Startup(conf.Build(), true);
                    start.ConfigureRepositoryServices(services);

                    ProviderDB = services.BuildServiceProvider();
                }
            }

        }


        protected RequestSupplyViewModel MockRequestSupplyViewModel(string codPr, string codW, string codWP, DateTime date)
        {
            return new RequestSupplyViewModel() { CodeProduct = codPr, CodeWorker = codW, CodeWorkPlace = codWP, Date = date };
        }

        protected ConfigSupplyViewModel MockRequestConfigViewModel(string codPr, string codW, string codWP, DateTime date, int amount)
        {
            return new ConfigSupplyViewModel() { ProductCode = codPr, WorkerCode = codW, WorkPlaceCode = codWP, Date = date, Amount = amount };
        }

        public void Reset()
        {
            Provider.GetService<MemoryContext>()?.LoadDataConfiguration();
        }

        protected T GetRepository<T>(bool database =  true)
        {
            if (database)
            {
                return ProviderDB.GetService<T>();
            }
            return Provider.GetService<T>();
        }
    }
}
