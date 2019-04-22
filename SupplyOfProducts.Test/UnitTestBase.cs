using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.Api.Controllers.ViewModels;
using SupplyOfProducts.Persistance;
using System;

namespace SupplyOfProducts.Test
{
    public class UnitTestBase
    {
        protected static ServiceProvider Provider = null;

        protected string userMocked = "W01";

        protected UnitTestBase()
        {
            if (Provider == null)
            {
                var services = new ServiceCollection();

                Startup start = new Startup();
                start.ConfigureRepositoryServices(services);

                Provider = services.BuildServiceProvider();
            }
        }


        protected RequestSupplyViewModel MockRequestSupplyViewModel(string codPr, string codW, string codWP, DateTime date)
        {
            return new RequestSupplyViewModel() { CodeProduct = codPr, CodeWorker = codW, CodeWorkPlace = codWP, Date = date };
        }

        protected RequestConfigSupplyViewModel MockRequestConfigViewModel(string codPr, string codW, string codWP, DateTime date, uint amount)
        {
            return new RequestConfigSupplyViewModel() { CodeProduct = codPr, CodeWorker = codW, CodeWorkPlace = codWP, Date = date, Amount = amount };
        }

        public void Reset()
        {
            Provider.GetService<MemoryContext>().LoadDataConfiguration();
        }
    }
}
