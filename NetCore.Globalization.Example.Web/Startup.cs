//  --------------------------------------------------------------------------------------
// NetCore.Globalization.Example.Web.Startup.cs
// 2018/03/05
//  --------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NetCore.Globalization.Example.Web
{
    public class Startup
    {
        // These strings are case-sensitive, matching up to the resource files.
        readonly IList<CultureInfo> supportedCultures = new List<CultureInfo> {new CultureInfo("en-US"), new CultureInfo("es-ES"), new CultureInfo("de-DE")};

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
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // Configure the application to use localization for requests
            app.UseRequestLocalization(new RequestLocalizationOptions
                                       {
                // Configure the default culture to be used for requests
                                           DefaultRequestCulture = new RequestCulture("en-US"),
                                           // Configure supported cultures and UI cultures
                                           SupportedCultures = supportedCultures,
                                           SupportedUICultures = supportedCultures,
                                           // Only use QueryStringCultureProvider and CookieCultureProvider
                                           RequestCultureProviders =
                                               new List<IRequestCultureProvider>
                                               {
                                                   new QueryStringRequestCultureProvider(),
                                                   new CookieRequestCultureProvider()
                                               }
                                       });

            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure localization service, specifying the root location where .resx files are stored.
            services.AddLocalization(p => { p.ResourcesPath = "Resources"; });

            // Configure dependency injection to inject a pre-configured RequestLocalizationOptions on request. (see _Layout.cshtml)
            services.Configure<RequestLocalizationOptions>(options =>
                                                           {
                                                               options.DefaultRequestCulture = new RequestCulture("en-US");
                                                               options.SupportedCultures = supportedCultures;
                                                               options.SupportedUICultures = supportedCultures;
                                                           });
            services.AddMvc();
        }
    }
}