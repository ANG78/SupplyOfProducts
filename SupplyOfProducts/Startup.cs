using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using SupplyOfProducts.Api.Common;
using SupplyOfProducts.BusinessLogic.Steps;
using SupplyOfProducts.Interfaces.BusinessLogic.Services;
using AutoMapper;
using SupplyOfProducts.Api.Controllers.Steps;

namespace SupplyOfProducts
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the cont  ainer.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false)
               .AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Supply of Products",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Jose Angel Naranjo Garcia",
                        Email = "angel290478@hotmail.com"
                    }
                });
            });


            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


            new Api.Common.Startup(Configuration).ConfigureRepositoryServices(services);

            /*
            services.AddScoped(sp =>
                   new CoRBuilder(sp).Get(
                               new WorkerClient(sp.GetService<IMapper>()),
                               new ValidateAndCompleteProduct(sp.GetService<IProductService>()),
                               new ValidateAndCompleteWorkPlace(sp.GetService<IWorkPlaceService>()),
                               new ValidateAndCompleteWorkerInWorkPlace(sp.GetService<IWorkerInWorkPlaceService>()),
                               new ValidateAndCompleteDatePeriod(sp.GetService<IPeriodConfigurationService>())
                           ));*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            //// Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //// specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupplyOfProducts API V1");
            });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
