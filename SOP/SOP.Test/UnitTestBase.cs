using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.Api.Controllers.ViewModels;
using System;

namespace SupplyOfProducts.Test
{
    public class UnitTestBase
    {
        protected static ServiceProvider Provider = null;
        protected static ServiceProvider ProviderDB = null;
        private static object referenceLocking = new object();

        protected UnitTestBase()
        {

            if (Provider == null)
            {
                lock (referenceLocking)
                {
                    var conf = new ConfigurationBuilder();
                   
                    var services = new ServiceCollection();

                    Api.Common.Startup start = new SupplyOfProducts.Api.Common.Startup(conf.Build());
                    start.ConfigureRepositoryServices(services);

                    Provider = services.BuildServiceProvider();
                }
            }

            if (ProviderDB == null)
            {
                lock (referenceLocking)
                {
                    var conf = new ConfigurationBuilder();

                    var services = new ServiceCollection();

                    Api.Common.Startup start = new SupplyOfProducts.Api.Common.Startup(conf.Build());
                    start.ConfigureRepositoryServices(services);

                    ProviderDB = services.BuildServiceProvider();

                }
            }

        }


        protected ConfigSupplyViewModel MockConfigSupplyViewModel(string codPr, string codW, string codWP, DateTime date, int amount)
        {
            return new ConfigSupplyViewModel
            { ProductCode = codPr,
              WorkerCode = codW,
              WorkPlaceCode = codWP,
              Date = date,
              Amount = amount
            };
        }

        protected ProductSupplyViewModel MockProductSupplyViewModel(string codPr, string codW, string codWP, DateTime date, int amount)
        {
            return new ProductSupplyViewModel
            {
                ProductCode = codPr,
                WorkerCode = codW,
                WorkPlaceCode = codWP,
                Date = date
            };
        }

        protected ConfigSupplyViewModel MockRequestConfigViewModel(string codPr, string codW, string codWP, DateTime date, int amount)
        {
            return new ConfigSupplyViewModel() { ProductCode = codPr, WorkerCode = codW, WorkPlaceCode = codWP, Date = date, Amount = amount };
        }

        public void Reset()
        {
          //  Provider.GetService<MemoryContext>()?.LoadDataConfiguration();
        }

        protected T GetRepository<T>(bool database = true)
        {
            if (database)
            {
                return ProviderDB.GetService<T>();
            }
            return Provider.GetService<T>();
        }
    }
}
