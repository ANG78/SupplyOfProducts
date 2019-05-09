using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.BusinessLogic.Services;
using SupplyOfProducts.BusinessLogic.Steps;
using SupplyOfProducts.BusinessLogic.Steps.ConfigSupply;
using SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using System.Collections.Generic;
using System.Linq;
using SupplyOfProducts.BusinessLogic.Steps.WorkerInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Test
{
    public class Startup
    {

        public IConfigurationRoot _configuration { get; }
        public bool _usingDDBB { get; set; } = false;

        public Startup(IConfigurationRoot configuration, bool usingDDBB )
        {
            _configuration = configuration;
            _usingDDBB = usingDDBB;
        }

        public void ConfigureRepositoryServices(IServiceCollection services)
        {
            // Add Repositories. 
            if (_usingDDBB)
            {
                new PersistanceDDBB.Startup(_configuration).ConfigureRepositoryServices(services);               
            }
            else
            {
                new Persistance.Startup(_configuration).ConfigureRepositoryServices(services);
            }

          

            // add Services
            services.AddTransient<IPeriodConfigurationService, PeriodConfigurationService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductSupplyService, ProductSupplyService>();
            services.AddTransient<IWorkerService, WorkerService>();
            services.AddTransient<IWorkerInWorkPlaceService, WorkerInWorkPlaceService>();
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
                                new ValidateAndCompleteWorkerInWorkPlace(sp.GetService<IWorkerInWorkPlaceService>()),
                                new ValidateAndCompleteDatePeriod(sp.GetService<IPeriodConfigurationService>())
                                }));

            /*IProductSupplyRequest*/
            services.AddTransient(sp =>
                    HelperStepConfigurator(
                            new List<IStep<IProductSupplyRequest>>()
                            {
                                new ValidateRequestAndComplete<IProductSupplyRequest>(sp.GetService<IStep<IRequestMustBeCompleted>>() ),
                                new ValidateWorkerCanBeSupplied(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>()),
                                new AssignProductToWorker(sp.GetService<IProductSupplyService>(), sp.GetService<IProductStockService>())
                            }));

            /*IConfigSupplyRequest*/
            services.AddTransient(sp =>
                  HelperStepConfigurator(
                          new List<IStep<IConfigSupplyRequest>>()
                          {
                                new ValidateRequestAndComplete<IConfigSupplyRequest>(sp.GetService<IStep<IRequestMustBeCompleted>>()),
                                new ValidateAndCompleteWorkerCanBeConfigured(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>()),
                                new ScheduleConfigurationToWorker(sp.GetService<ISupplyScheduledService>())
                          }));

            /*IWorkerInfoRequest*/
            services.AddTransient(sp =>
                  HelperStepConfigurator(
                          new List<IStep<IWorkerInfoRequest>>()
                          {
                              new ValidateRequestAndComplete<IWorkerInfoRequest>(sp.GetService<IStep<IRequestMustBeCompleted>>()),
                              new GenerateWorkerReport(sp.GetService<IWorkerInWorkPlaceService> (), sp.GetService<IProductSupplyService>()),
                          }));

        }

        public IStep<T> HelperStepConfigurator<T>(IList<IStep<T>> list)
        {
            var result = list.First();
            list = list.Reverse().ToList();
            var current = list.FirstOrDefault();
            for (int i = 1; i < list.Count; i++)
            {
                list[i].Next = current;
                current = list[i];
            }
            return result;
        }

    }
}
