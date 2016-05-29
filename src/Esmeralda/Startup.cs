using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Esmeralda.Models;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Authentication.Cookies;
using System.Net;

namespace Esmeralda
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public static IConfigurationRoot Configuration;
        public Startup(IApplicationEnvironment appEnv) //Se anadio paquete microsoft.framework.configuration
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddIdentity<ApplicationUser , IdentityRole>(config =>  //Agregando en identity
            {
                config.Password.RequireNonLetterOrDigit = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireDigit = false;
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 6;             
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
            })
           
                .AddEntityFrameworkStores<EsmeraldaContext>();
    
            services.AddEntityFramework() //model context services
                .AddSqlServer()
                .AddDbContext<EsmeraldaContext>();
            services.AddTransient<EsmeraldaContextSeedData>();
            services.AddScoped<IEsmeraldaRepository, EsmeraldaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline., EsmeraldaContextSeedData seed
        public async void Configure(IApplicationBuilder app, EsmeraldaContextSeedData seed)
        {
  
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(config =>
            {  
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                defaults: new { controller = "App", action = "Index" }
            );
            });
            await seed.EnsureSeedDataAsync();
            //app.UseIISPlatformHandler();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
