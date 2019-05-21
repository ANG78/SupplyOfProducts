using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.BusinessLogic.Services;
using SupplyOfProducts.BusinessLogic.Steps;
using SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using Swashbuckle.AspNetCore.Swagger;
using SupplyOfProducts.BusinessLogic.Steps.ConfigSupply;
using System.Collections.Generic;
using System.Linq;
using SupplyOfProducts.BusinessLogic.Steps.WorkerInfo;
using Swashbuckle.AspNetCore.Filters;
using SupplyOfProducts.Api.Controllers.Examples;
using Microsoft.EntityFrameworkCore;
using SupplyOfProducts.PersistanceDDBB;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using System;
using AutoMapper;

namespace SupplyOfProducts.Api
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "Product",
                    Description = "Cadena de Responsabilidad, UoW",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Jose Angel Naranjo Garcia",
                        Email = "angel290478@hotmail.com"
                    },
                    License = new License
                    {

                    }


                });

                // Set the comments path for the Swagger JSON and UI.
                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // c.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<ExampleRequestConfigSupplyViewModel>();
            services.AddSwaggerExamplesFromAssemblyOf<ExampleRequestSupplyViewModel>();

            ConfigureRepositoryServices(services);

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
                                new StepUnitOfWork < IProductSupplyRequest > ( sp.GetService<IGenericContext> () )
                                ,new ValidateRequestAndComplete<IProductSupplyRequest>(sp.GetService<IStep<IRequestMustBeCompleted>>() )
                                ,new ValidateWorkerCanBeSupplied(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>())
                                ,new AssignProductToWorker(sp.GetService<IProductSupplyService>(), sp.GetService<IProductStockService>())
                            }));

            services.AddScoped(sp =>
            {
                var helper = new HelperStepConf(sp);
                return helper.Get(
                              new List<IStep<IConfigSupplyRequest>>()
                                  {
                                new StepUnitOfWork < IConfigSupplyRequest > ( helper.GetService<IGenericContext> () )
                                ,new ValidateRequestAndComplete<IConfigSupplyRequest>(helper.GetService<IStep<IRequestMustBeCompleted>>())
                                ,new ValidateAndCompleteWorkerCanBeConfigured(helper.GetService<IProductSupplyService>(), helper.GetService<ISupplyScheduledService>())
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
                              new StepUnitOfWork < IManagementModelRequest<IWorker> > ( helper.GetService<IGenericContext> () )
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
                              new StepUnitOfWork < IManagementModelRequest<IWorkPlace> > ( helper.GetService<IGenericContext> () )
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
                              new StepUnitOfWork < IManagementModelRequest<IProduct> > ( helper.GetService<IGenericContext> () )
                              ,new StepSaveModel < IProduct > ( helper.GetService<IProductService>() )
                         });
            }
                );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();



            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupplyOfProducts Api V1");
            });

            app.UseMvc();


        }
    }
}
