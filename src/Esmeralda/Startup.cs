using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Esmeralda.Models;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Esmeralda.Configuration;
using Stripe;

namespace Esmeralda
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env) //Se anadio paquete microsoft.framework.configuration
        {
            
            var builder = new ConfigurationBuilder()
                //.SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            StripeConfiguration.SetApiKey("sk_test_rGmtFLtkiqDCALoAo719CL2J");
            services.Configure<PaymentSettings>(Configuration.GetSection("PaymentSettings")); //Added for payment
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
        public void Configure(IApplicationBuilder app)
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
            //await seed.EnsureSeedDataAsync();
           
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
