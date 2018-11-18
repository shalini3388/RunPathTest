using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Runpath.repository.Interface;
using Runpath.repository;
using Runpath.services.Interfaces;
using Runpath.services;
using System.ComponentModel;
using StructureMap;

namespace RunPathTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure the ASP.NET specific stuff.
            services.AddMvc();
            ConfigureIoC(services);


        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new StructureMap.Container();

            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Startup));
                    _.WithDefaultConventions();
                    _.AddAllTypesOf<IPhotoService>();
                    _.AddAllTypesOf<IAlbumService>();
                });
                services.AddScoped<IPhotoService, PhotoService>();
                services.AddScoped<IAlbumService, AlbumService>();
                services.Add(ServiceDescriptor.Transient(typeof(IRepository<>), typeof(Repository<>)));

                //Populate the container using the service collection
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
            
            
        }
    }
}
