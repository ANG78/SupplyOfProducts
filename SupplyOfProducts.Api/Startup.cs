﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.BusinessLogic.Services;
using SupplyOfProducts.BusinessLogic.Steps;
using SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.Interfaces.Repository;
using SupplyOfProducts.Persistance;
using Swashbuckle.AspNetCore.Swagger;
using SupplyOfProducts.BusinessLogic.Steps.ConfigSupply;
using System.Collections.Generic;
using System.Linq;
using SupplyOfProducts.BusinessLogic.Steps.WorkerInfo;
using Swashbuckle.AspNetCore.Filters;
using SupplyOfProducts.Api.Controllers.Examples;
using Microsoft.EntityFrameworkCore;
using SupplyOfProducts.PersistanceDDBB.Configuration;
using SupplyOfProducts.PersistanceDDBB;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;

namespace SupplyOfProducts.Api
{
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
                    Description = "Prueba",
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

            //services.AddDbContext<SupplyOfProductsContext>(options =>
            //    options.UseMySql(Configuration.GetConnectionString("DefaultConnection"))
            //    );

            ConfigureRepositoryServices(services);

        }

        public void ConfigureRepositoryServices(IServiceCollection services)
        {

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
            services.AddTransient<IPeriodConfigurationService, PeriodConfigurationService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductSupplyService, ProductSupplyService>();
            services.AddTransient<IWorkerService, WorkerService>();
            services.AddTransient<IProductStockService, ProductStockService>();
            services.AddTransient<ISupplyScheduledService, SupplyScheduledService>();
            services.AddTransient<IWorkPlaceService, WorkPlaceService>();

            // common steps in order to validate and complete the request
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


            services.AddTransient(sp =>
                    HelperStepConfigurator(
                            new List<IStep<IProductSupplyRequest>>()
                            {
                                new ValidateRequestAndComplete<IProductSupplyRequest>(sp.GetService<IStep<IRequestMustBeCompleted>>() ),
                                new ValidateWorkerCanBeSupplied(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>()),
                                new AssignProductToWorker(sp.GetService<IProductSupplyService>(), sp.GetService<IProductStockService>())
                            }));

            services.AddTransient(sp =>
                  HelperStepConfigurator(
                          new List<IStep<IConfigSupplyRequest>>()
                          {
                                new ValidateRequestAndComplete<IConfigSupplyRequest>(sp.GetService<IStep<IRequestMustBeCompleted>>()),
                                new ValidateAndCompleteWorkerCanBeConfigured(sp.GetService<IProductSupplyService>(), sp.GetService<ISupplyScheduledService>()),
                                new ScheduleConfigurationToWorker(sp.GetService<ISupplyScheduledService>())
                          }));

            /*IWorkerInfo*/
            services.AddTransient(sp =>
                  HelperStepConfigurator(
                          new List<IStep<IWorkerInfoRequest>>()
                          {
                              new ValidateRequestAndComplete<IWorkerInfoRequest>(sp.GetService<IStep<IRequestMustBeCompleted>>()),
                              new GenerateWorkerReport(sp.GetService<IWorkerInWorkPlaceService> (), sp.GetService<IProductSupplyService>()),
                          }));


            services.AddDbContext<SupplyOfProductsContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
               ));



        }

        private IStep<T> HelperStepConfigurator<T>(IList<IStep<T>> list)
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
