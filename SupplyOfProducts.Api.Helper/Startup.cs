using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.BusinessLogic.Services;
using SupplyOfProducts.BusinessLogic.Steps;
using SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.BusinessLogic.Steps.ConfigSupply;
using System.Collections.Generic;
using SupplyOfProducts.BusinessLogic.Steps.WorkerInfo;
using Microsoft.EntityFrameworkCore;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using AutoMapper;
using System.Reflection;

namespace SupplyOfProducts.Api.Common
{


    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

       // public bool UsingDDBB { get; set; } = true;

        public void ConfigureRepositoryServices(IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.Load("SupplyOfProducts.Api.Common"), 
                                   Assembly.Load("SupplyOfProducts.PersistanceDDBB"));

           // services.AddAutoMapper();


            // Add Repositories. 
         //   if (UsingDDBB)
            {
                new PersistanceDDBB.StartupWeb(Configuration).ConfigureRepositoryServices(services);
            }
            //  else
            {
                //    new Persistance.Startup(_configuration).ConfigureRepositoryServices(services);
            }
            /*
            // Add Repositories. 
            services.AddSingleton<MemoryContext, MemoryContext>();
            services.AddTransient<SupplyOfProductsContext, SupplyOfProductsContext>();
            // services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductRepository, SupplyOfProducts.PersistanceDDBB.Repository.ProductRepository>();
            services.AddTransient<IProductSupplyRepository, ProductSupplyRepository>();
            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddTransient<IWorkPlaceRepository, WorkPlaceRepository>();
            services.AddTransient<IProductStockRepository, ProductStockRepository>();
            services.AddTransient<ISupplyScheduledRepository, SupplyScheduledRepository>();
            */

            // add Services
            services.AddScoped<IPeriodConfigurationService, PeriodConfigurationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductSupplyService, ProductSupplyService>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IProductStockService, ProductStockService>();
            services.AddScoped<ISupplyScheduledService, SupplyScheduledService>();
            services.AddScoped<IWorkPlaceService, WorkPlaceService>();
            services.AddScoped<IWorkerInWorkPlaceService, WorkerInWorkPlaceService>();
            services.AddScoped<IConfigSupplyService, ConfigSupplyService>();

            /*Retrievers*/
            services.AddScoped<IStep<IManagementModelRetrieverRequest<IWorker>> , RetrieverGeneric<IWorker, IWorkerService>> ();
            services.AddScoped<IStep<IManagementModelRetrieverRequest<IWorkPlace>>, RetrieverGeneric<IWorkPlace, IWorkPlaceService>>();
            services.AddScoped<IStep<IManagementModelRetrieverRequest<IProduct>>, RetrieverGeneric<IProduct, IProductService>>();
            services.AddScoped<IStep<IManagementModelRetrieverRequest<IProductStock>>, RetrieverGeneric<IProductStock, IProductStockService>>();
            services.AddScoped<IStep<IManagementModelRetrieverRequest<IConfigSupply>>, RetrieverByWorkerGeneric<IConfigSupply, IConfigSupplyService>>();
            services.AddScoped<IStep<IManagementModelRetrieverRequest<IProductSupply>>, RetrieverByWorkerGeneric<IProductSupply, IProductSupplyService>>();


            // common steps in order to validate and complete the request
            services.AddScoped(sp =>
                    new CoRBuilder(sp).Get(
                                new ValidateAndCompleteWorker(sp.GetService<IWorkerService>()),
                                new ValidateAndCompleteProduct(sp.GetService<IProductService>()),
                                new ValidateAndCompleteWorkPlace(sp.GetService<IWorkPlaceService>()),
                                new ValidateAndCompleteWorkerInWorkPlace(sp.GetService<IWorkerInWorkPlaceService>()),
                                new ValidateAndCompleteDatePeriod(sp.GetService<IPeriodConfigurationService>())
                            ));

            /*ProductSupply*/
            services.AddScoped(sp =>
                     new CoRBuilder(sp).Get(
                                new StepUnitOfWork<IManagementModelRequest<IProductSupply>>(sp.GetService<ICreateUoW>())
                                , new ValidateRequestAndComplete<IManagementModelRequest<IProductSupply>>(sp.GetService<IStep<IRequestMustBeCompleted>>())
                                , new ValidateWorkerCanBeSupplied(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>())
                                , new AssignProductToWorker(sp.GetService<IProductSupplyService>(), sp.GetService<IProductStockService>())
                            ));

            /*ConfigSupply*/
            services.AddScoped(sp =>
            {
                var helper = new CoRBuilder(sp);
                return helper.Get(
                                new StepUnitOfWork<IManagementModelRequest<IConfigSupply>>(helper.GetService<ICreateUoW>())
                                , new ValidateRequestAndComplete<IManagementModelRequest<IConfigSupply>>(helper.GetService<IStep<IRequestMustBeCompleted>>())
                                , new ValidateAndCompleteWorkerCanBeConfigured(helper.GetService<IProductSupplyService>(), helper.GetService<ISupplyScheduledService>())
                                , new ScheduleConfigurationToWorker(helper.GetService<ISupplyScheduledService>())
                                   );
            });

            /*IWorkerInfo*/
            services.AddScoped(sp =>
            {
                var helper = new CoRBuilder(sp);
                return helper.Get(
                                      new ValidateRequestAndComplete<IWorkerInfoRequest>(helper.GetService<IStep<IRequestMustBeCompleted>>()),
                                      new GenerateWorkerReport(helper.GetService<IWorkerInWorkPlaceService>(),
                                                               helper.GetService<IProductSupplyService>())
                                 );
            });


            /*IWorker*/
            services.AddScoped(sp =>
            {
                var helper = new CoRBuilder(sp);
                return helper.Get(
                              new StepUnitOfWork<IManagementModelRequest<IWorker>>(helper.GetService<ICreateUoW>())
                              , new StepSaveModel<IWorker>(helper.GetService<IWorkerService>())
                        );
            });

            /*IWorkPlace*/
            services.AddScoped(sp =>
            {
                var helper = new CoRBuilder(sp);
                return helper.Get(
                              new StepUnitOfWork<IManagementModelRequest<IWorkPlace>>(helper.GetService<ICreateUoW>())
                              , new StepSaveModel<IWorkPlace>(helper.GetService<IWorkPlaceService>())
                       );
            });

            /*IProduct*/
            services.AddScoped(sp =>
            {
                var helper = new CoRBuilder(sp);
                return helper.Get(
                              new StepUnitOfWork<IManagementModelRequest<IProduct>>(helper.GetService<ICreateUoW>())
                              , new StepSaveModel<IProduct>(helper.GetService<IProductService>())
                         );
            });


            /*IProductStock*/
            services.AddScoped(sp =>
            {
                var helper = new CoRBuilder(sp);
                return helper.Get(
                              new StepUnitOfWork<IManagementModelRequest<IProductStock>>(helper.GetService<ICreateUoW>())
                              , new ValidateRequestAndComplete<IManagementModelRequest<IProductStock>>(helper.GetService<IStep<IRequestMustBeCompleted>>())
                              , new StepSaveModel<IProductStock>(helper.GetService<IProductStockService>())
                         );
            });

        }

    }
}
