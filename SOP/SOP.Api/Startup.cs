﻿
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;


namespace SupplyOfProducts.Api
{

    public class Startup
    {
        
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            //    {
            //        Version = "v1",
            //        Title = "Product",
            //        Description = "Cadena de Responsabilidad, UoW",
            //        TermsOfService = "None",
            //        Contact = new Contact
            //        {
            //            Name = "Jose Angel Naranjo Garcia",
            //            Email = "angel290478@hotmail.com"
            //        },
            //        License = new License
            //        {

            //        }


            //    });

            //    // Set the comments path for the Swagger JSON and UI.
            //    // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    // c.IncludeXmlComments(xmlPath);
            //});

            //services.AddSwaggerExamplesFromAssemblyOf<ExampleRequestConfigSupplyViewModel>();
            ////services.AddSwaggerExamplesFromAssemblyOf<ExampleRequestSupplyViewModel>();

            new SupplyOfProducts.Api.Common.Startup(Configuration).ConfigureRepositoryServices(services);

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    // Enable middleware to serve generated Swagger as a JSON endpoint.
        //    app.UseSwagger();



        //    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
        //    // specifying the Swagger JSON endpoint.
        //    app.UseSwaggerUI(c =>
        //    {

        //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupplyOfProducts Api V1");
        //    });

        //    app.UseMvc( 
        //       // terminar de arreglar config x => x.MapRoute("DefaultApi", "api/{controller}/{id}"/*, new { id = RouteAttribute.Optional }*/)
        //        );


        //}
    }
}
