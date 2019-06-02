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

namespace SupplyOfProducts.Api.Common
{


    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public void ConfigureRepositoryServices(IServiceCollection services)
        {

            services.AddAutoMapper();


            // Add Repositories. 
            //if (_usingDDBB)
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

            // common steps in order to validate and complete the request
            services.AddScoped(sp =>
                    new HelperStepConf(sp).Get(
                            new List<IStep<IRequestMustBeCompleted>>()
                            {
                                new ValidateAndCompleteWorker(sp.GetService<IWorkerService>()),
                                new ValidateAndCompleteProduct(sp.GetService<IProductService>()),
                                new ValidateAndCompleteWorkPlace(sp.GetService<IWorkPlaceService>()),
                                new ValidateAndCompleteWorkerInWorkPlace(sp.GetService<IWorkerInWorkPlaceService>()),
                                new ValidateAndCompleteDatePeriod(sp.GetService<IPeriodConfigurationService>())
                                }));


            services.AddScoped(sp =>
                     new HelperStepConf(sp).Get(
                            new List<IStep<IManagementModelRequest<IProductSupply>>>()
                            {
                                new StepUnitOfWork< IManagementModelRequest<IProductSupply> > ( sp.GetService<ICreateUoW> () )
                                ,new ValidateRequestAndComplete< IManagementModelRequest<IProductSupply> >(sp.GetService<IStep<IRequestMustBeCompleted>>() )
                                ,new ValidateWorkerCanBeSupplied(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>())
                                ,new AssignProductToWorker(sp.GetService<IProductSupplyService>(), sp.GetService<IProductStockService>())
                            }));

            services.AddScoped(sp =>
            {
                var helper = new HelperStepConf(sp);
                return helper.Get(
                              new List<IStep<IManagementModelRequest<IConfigSupply>>>()
                                  {
                                new StepUnitOfWork < IManagementModelRequest<IConfigSupply> > ( helper.GetService<ICreateUoW> () )
                                ,new ValidateRequestAndComplete< IManagementModelRequest<IConfigSupply> >(helper.GetService<IStep<IRequestMustBeCompleted>>())
                                ,new ValidateAndCompleteWorkerCanBeConfigured( helper.GetService<IProductSupplyService>(), helper.GetService<ISupplyScheduledService>())
                                ,new ScheduleConfigurationToWorker(helper.GetService<ISupplyScheduledService>())
                                   });
            });

            /*IWorkerInfo*/
            services.AddScoped(sp =>
            {
                var helper = new HelperStepConf(sp);
                return helper.Get(
                                 new List<IStep<IWorkerInfoRequest>>()
                                 {
                                      new ValidateRequestAndComplete<IWorkerInfoRequest>(helper.GetService<IStep<IRequestMustBeCompleted>>()),
                                      new GenerateWorkerReport(helper.GetService<IWorkerInWorkPlaceService> (),
                                                               helper.GetService<IProductSupplyService>())
                                 });
            });


            /*IWorker*/
            services.AddScoped(sp =>
            {
                var helper = new HelperStepConf(sp);
                return helper.Get(
                         new List<IStep<IManagementModelRequest<IWorker>>>()
                         {
                              new StepUnitOfWork < IManagementModelRequest<IWorker> > ( helper.GetService<ICreateUoW> () )
                              ,new StepSaveModel < IWorker > ( helper.GetService<IWorkerService>() )
                         });
            }
                );

            /*IWorkPlace*/
            services.AddScoped(sp =>
            {
                var helper = new HelperStepConf(sp);
                return helper.Get(
                         new List<IStep<IManagementModelRequest<IWorkPlace>>>()
                         {
                              new StepUnitOfWork < IManagementModelRequest<IWorkPlace> > ( helper.GetService<ICreateUoW> () )
                              ,new StepSaveModel < IWorkPlace > ( helper.GetService<IWorkPlaceService>() )
                         });
            }
                );

            /*IProduct*/
            services.AddScoped(sp =>
            {
                var helper = new HelperStepConf(sp);
                return helper.Get(
                         new List<IStep<IManagementModelRequest<IProduct>>>()
                         {
                              new StepUnitOfWork < IManagementModelRequest<IProduct> > ( helper.GetService<ICreateUoW> () )
                              ,new StepSaveModel < IProduct > ( helper.GetService<IProductService>() )
                         });
            }
                );


            /*IProductStock*/
            services.AddScoped(sp =>
            {
                var helper = new HelperStepConf(sp);
                return helper.Get(
                         new List<IStep<IManagementModelRequest<IProductStock>>>()
                         {
                              new StepUnitOfWork < IManagementModelRequest<IProductStock> > ( helper.GetService<ICreateUoW> () )
                              ,new ValidateRequestAndComplete< IManagementModelRequest<IProductStock> >(helper.GetService<IStep<IRequestMustBeCompleted>>())
                              ,new StepSaveModel < IProductStock > ( helper.GetService<IProductStockService>() )
                         });
            }
                );

        }

    }
}
