using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.Api.Common;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using System;

namespace ConsoleApp1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var conf = new ConfigurationBuilder();
            conf.AddJsonFile("appsettings.json");

            var services = new ServiceCollection();
            Startup start = new Startup(conf.Build());
            start.ConfigureRepositoryServices(services);

            var ProviderDB = services.BuildServiceProvider();
            var _businessLogic = ProviderDB.GetService<IStep<IManagementModelRequest<IWorker>>>();
            var worker = new Worker();
            worker.Code = "W01" + DateTime.Now.Millisecond;
            worker.Name = worker.Code;
            var request = new ManagementModelRequest<IWorker>
            {
                Item = worker,
                Type = Operation.NEW
            };

            var result = _businessLogic.Execute(request);
            if (result.ComputeResult().IsOk())
            {
                Console.WriteLine(result.Message());
            }
            else
            {
                Console.WriteLine(result.Message());
            }
        }

    }
}
