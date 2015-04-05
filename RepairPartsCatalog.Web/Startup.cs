using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Security.Cookies;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using RepairPartsCatalog.Web.Models;

namespace RepairPartsCatalog.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add EF services to the services container.
            services.AddEntityFramework(Configuration)
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>();

            // Add Identity services to the services container.
            services.AddIdentity<ApplicationUser, IdentityRole>(Configuration)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add MVC services to the services container.
            services.AddMvc();

            ConfigureSocialNetworksServices(services);

            // Uncomment the following line to add Web API servcies which makes it easier to port Web API 2 controllers.
            // You need to add Microsoft.AspNet.Mvc.WebApiCompatShim package to project.json
            // services.AddWebApiConventions();

        }

        private void ConfigureSocialNetworksServices(IServiceCollection services)
        {
            // TODO: all params to config!
            // https://developers.facebook.com/apps/1428235794143782/dashboard/
            services.ConfigureFacebookAuthentication(options =>
            {
                options.ClientId = "1428235794143782";
                options.ClientSecret = "ae7fef315e5ab62ee17bd5ff47f85daf";
            });

            // https://console.developers.google.com/project/gromilich/apiui/credential?clientType#
            services.ConfigureGoogleAuthentication(options =>
            {
                options.ClientId = "658509644882-tqcupomu1d3kq48922t4l0ne49a5jvo3.apps.googleusercontent.com";
                options.ClientSecret = "TvlidK2X5YsGha3iiC-6gRkB";
            });

            // https://account.live.com/developers/applications/appsettings/000000004c14c58d
            services.ConfigureMicrosoftAccountAuthentication(options =>
            {
                options.ClientId = "000000004C14C58D";
                options.ClientSecret = "18t6DBWscDyaAnErLMJbfIi6HXjORL11";
            });

            // https://apps.twitter.com/app/8154774/keys
            services.ConfigureTwitterAuthentication(options =>
            {
                options.ConsumerKey = "DsLCUQYcUBY5NQBsKO74Fogcy";
                options.ConsumerSecret = "VWtTNYMc9gvCUC8osCwk5Em98xWTtBeW0sxrj3avcl9qhWeNVd";
            });
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            // Configure the HTTP request pipeline.
            // Add the console logger.
            loggerfactory.AddConsole();

            // Add the following to the request pipeline only in development environment.
            if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseErrorHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            // Social networks authentication.
            ConfigureSocialNetworks(app);

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });
        }

        private void ConfigureSocialNetworks(IApplicationBuilder app)
        {
            app.UseGoogleAuthentication();
            app.UseTwitterAuthentication();
            app.UseFacebookAuthentication();
            app.UseMicrosoftAccountAuthentication();
        }
    }
}
