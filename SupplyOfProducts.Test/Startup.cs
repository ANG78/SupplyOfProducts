using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.BusinessLogic.Services;
using SupplyOfProducts.BusinessLogic.Steps;
using SupplyOfProducts.BusinessLogic.Steps.ConfigSupply;
using SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;
using SupplyOfProducts.Persistance;
using System.Collections.Generic;
using System.Linq;
using SupplyOfProducts.BusinessLogic.Steps.WorkerInfo;

namespace SupplyOfProducts.Test
{
    public class Startup
    {

        public void ConfigureRepositoryServices(IServiceCollection services)
        {
            // Add Repositories. 
            services.AddSingleton<MemoryContext, MemoryContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductSupplyRepository, ProductSupplyRepository>();
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddTransient<IWorkPlaceRepository, WorkPlaceRepository>();
            services.AddTransient<IProductStockRepository, ProductStockRepository>();
            services.AddTransient<ISupplyScheduledRepository, SupplyScheduledRepository>();

            // add Services
            services.AddTransient<IPeriodConfigurationService, PeriodConfigurationService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductSupplyService, ProductSupplyService>();
            services.AddTransient<IWorkerService, WorkerService>();
            services.AddTransient<IProductStockService, ProductStockService>();
            services.AddTransient<ISupplyScheduledService, SupplyScheduledService>();
            services.AddTransient<IWorkPlaceService, WorkPlaceService>();

           
            // common steps to validate and complete the request
            services.AddTransient(sp =>
                    HelperStepConfigurator(
                            new List<IStep<IRequestMustBeCompleted>>()
                            {
                                new ValidateAndCompleteWorker(sp.GetService<IWorkerService>()),
                                new ValidateAndCompleteProduct(sp.GetService<IProductService>()),
                                new ValidateAndCompleteWorkPlace(sp.GetService<IWorkPlaceService>()),
                                new ValidateAndCompleteWorkerInWorkPlace(sp.GetService<IWorkerService>()),
                                new ValidateAndCompleteDatePeriod(sp.GetService<IPeriodConfigurationService>())
                                }));

            /*IProductSupply*/
            services.AddTransient(sp =>
                    HelperStepConfigurator(
                            new List<IStep<IProductSupply>>()
                            {
                                new ValidateRequestAndComplete<IProductSupply>(sp.GetService<IStep<IRequestMustBeCompleted>>() ),
                                new ValidateWorkerCanBeSupplied(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>()),
                                new AssignProductToWorker(sp.GetService<IProductSupplyService>(), sp.GetService<IProductStockService>())
                            }));

            /*IConfigSupply*/
            services.AddTransient(sp =>
                  HelperStepConfigurator(
                          new List<IStep<IConfigSupply>>()
                          {
                                new ValidateRequestAndComplete<IConfigSupply>(sp.GetService<IStep<IRequestMustBeCompleted>>()),
                                new ValidateAndCompleteWorkerCanBeConfigured(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>()),
                                new ScheduleConfigurationToWorker(sp.GetService<ISupplyScheduledService>())
                          }));

            /*IWorkerInfo*/
            services.AddTransient(sp =>
                  HelperStepConfigurator(
                          new List<IStep<IWorkerInfo>>()
                          {
                              new ValidateRequestAndComplete<IWorkerInfo>(sp.GetService<IStep<IRequestMustBeCompleted>>()),
                              new GenerateWorkerReport(sp.GetService<IWorkerService> (), sp.GetService<IProductSupplyService>()),
                          }));

        }

        private IStep<T> HelperStepConfigurator<T>(IList<IStep<T>> list)
        {
            var result = list.First();
            list = list.Reverse().ToList();
            var current = list.FirstOrDefault();
            for(int i=1;i<list.Count; i++)
            {
                list[i].Next = current;
                current = list[i];
            }
            return result;
        }

    }
}
