using SupplyOfProducts.BusinessLogic.Services;
using SupplyOfProducts.BusinessLogic.Steps;
using SupplyOfProducts.BusinessLogic.Steps.ProcessProductSupply;
using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using SupplyOfProducts.BusinessLogic.Steps.ConfigSupply;
using SupplyOfProducts.BusinessLogic.Steps.WorkerInfo;
using SupplyOfProducts.Interfaces.BusinessLogic.Services.Request;
using SupplyOfProducts.Interfaces.BusinessLogic.Entities;
using SupplyOfProducts.BusinessLogic.Steps.Common;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SupplyOfProducts.Entities.BusinessLogic.Entities.Configuration;
using SupplyOfProducts.Api.Controllers.ViewModels;

namespace SupplyOfProducts.Api.Common
{


    public class Startup
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public void ConfigureRepositoryServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            Registration.Autofac();
            services.AddSingleton<IMapper>(sp=>  Mapper.Instance);

            


            new PersistenceDDBB.StartupWeb(Configuration).ConfigureRepositoryServices(services);

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
            services.AddScoped<IStep<IManagementModelRetrieverRequest<IWorker>>, RetrieverGeneric<IWorker, IWorkerService>>();
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


    internal class Registration
    {
        private static object WorkerViewModel;

        public static IContainer Autofac()
        {
            var containerBuilder = new ContainerBuilder();

            // Register the convertor which is injected in the `MyProfile`
            //containerBuilder.RegisterType<Convertor>().As<IConvertor>();
            //containerBuilder.RegisterType<Startup>().As<IStartup>();

            var loadedProfiles = RetrieveProfiles();
            containerBuilder.RegisterTypes(loadedProfiles.ToArray());

            var container = containerBuilder.Build();

            RegisterAutoMapper(container, loadedProfiles);

            return container;
        }

        /// <summary>
        /// Scan all referenced assemblies to retrieve all `Profile` types.
        /// </summary>
        /// <returns>A collection of <see cref="AutoMapper.Profile"/> types.</returns>
        internal static List<Type> RetrieveProfiles()
        {


            List<Assembly> assemblies = new List<Assembly>
            {
                Assembly.Load("SOP.Api.Common"),
                Assembly.Load("SOP.PersistenceDDBB")
            };


            var loadedProfiles = ExtractProfiles(assemblies);
            return loadedProfiles;
        }

        private static List<Type> ExtractProfiles(IEnumerable<Assembly> assemblies)
        {
            var profiles = new List<Type>();
            foreach (var assembly in assemblies)
            {
                var assemblyProfiles = assembly.ExportedTypes.Where(type => type.IsSubclassOf(typeof(Profile) ) && !type.IsAbstract);
                profiles.AddRange(assemblyProfiles);
            }
            return profiles;
        }

        /// <summary>
        /// This is how you actually want to register your <see cref="Profile"/> types from all assemblies.
        /// Also uses Autofac to resolve services.
        /// </summary>
        private static void RegisterAutomapperDefault(IContainer container, IEnumerable<Assembly> assemblies)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ConstructServicesUsing(container.Resolve);

                //This is the easiest way. You just have to make sure all MappingProfiles have got an empty constructor. (recommended)
                cfg.AddProfiles(assemblies);
            });
        }


        private static bool Initialized = false;
        /// <summary>
        /// Over here we iterate over all <see cref="Profile"/> types and resolve them via the <see cref="IContainer"/>.
        /// This way the `AddProfile` method will receive an instance of the found <see cref="Profile"/> type, which means
        /// all dependencies will be resolved via the <see cref="IContainer"/>.
        /// </summary>
        private static void RegisterAutoMapper(IContainer container, IEnumerable<Type> loadedProfiles)
        {
            if (!Initialized)
            {
                AutoMapper.Mapper.Initialize(cfg =>
                {
                    cfg.ConstructServicesUsing(container.Resolve);

                    foreach (var profile in loadedProfiles)
                    {
                        var resolvedProfile = container.Resolve(profile) as Profile;
                        if (resolvedProfile != null)
                        {
                            cfg.AddProfile(resolvedProfile);
                        }

                    }

                });

                Initialized = true;
            }
            

        }


    }
}
