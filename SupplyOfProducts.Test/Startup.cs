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
using SupplyOfProducts.BusinessLogic.Steps.Common;
using SupplyOfProducts.PersistanceDDBB;
using System;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;

namespace SupplyOfProducts.Test
{
    public class HelperStepConf
    {
        readonly IServiceProvider _service;
        public HelperStepConf(IServiceProvider service)
        {
            _service = service;
        }

        public IStep<T> Get<T>(IList<IStep<T>> list)
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

        public T GetService<T>()
        {
            return _service.GetRequiredService<T>();
        }
    }


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
            services.AddScoped<IPeriodConfigurationService, PeriodConfigurationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductSupplyService, ProductSupplyService>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IWorkerInWorkPlaceService, WorkerInWorkPlaceService>();
            services.AddScoped<IProductStockService, ProductStockService>();
            services.AddScoped<ISupplyScheduledService, SupplyScheduledService>();
            services.AddScoped<IWorkPlaceService, WorkPlaceService>();


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
                            new List<IStep<IProductSupplyRequest>>()
                            {
                                new StepUnitOfWork < IProductSupplyRequest > ( sp.GetService<ICreateUoW> () )
                                ,new ValidateRequestAndComplete<IProductSupplyRequest>(sp.GetService<IStep<IRequestMustBeCompleted>>() )
                                ,new ValidateWorkerCanBeSupplied(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>())
                                ,new AssignProductToWorker(sp.GetService<IProductSupplyService>(), sp.GetService<IProductStockService>())
                            }));

            //services.AddScoped(sp =>
            //{
            //    var helper = new HelperStepConf(sp);
            //    return helper.Get(
            //                  new List<IStep<IConfigSupplyRequest>>()
            //                      {
            //                    new StepUnitOfWork < IConfigSupplyRequest > ( helper.GetService<ICreateUoW> () )
            //                    ,new ValidateRequestAndComplete<IConfigSupplyRequest>(helper.GetService<IStep<IRequestMustBeCompleted>>())
            //                    ,new ValidateAndCompleteWorkerCanBeConfigured(helper.GetService<IProductSupplyService>(), helper.GetService<ISupplyScheduledService>())
            //                    ,new ScheduleConfigurationToWorker(helper.GetService<ISupplyScheduledService>())
            //                       });
            //});

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

        }

       

    }
}
