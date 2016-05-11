using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using FishTank.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using FishTank.Options;

namespace FishTank
{
    public class Startup
    {
        private IHostingEnvironment hostingEnvironment;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("alertThresholds.json")
                .AddJsonFile($"alertThresholds{hostingEnvironment.EnvironmentName}.json", optional: true);
            var config = configBuilder.Build();

            services.Configure<ThresholdOptions>(config);
            services.AddMvc();
            services.AddSingleton<IViewModelService, ViewModelService>();
            services.AddSingleton<ISensorDataService, SensorDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            if (hostingEnvironment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            var logger = loggerFactory.CreateLogger("info");

            app.UseIISPlatformHandler();

            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.UseStatusCodePages();

            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name:"default",
            //        template:"{controller}/{action}/{id?}",
            //        defaults: new {controller="Home", actoin="Index"}    
            //    );
            //});
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
