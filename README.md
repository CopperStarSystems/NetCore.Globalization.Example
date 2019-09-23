# Stuck?  Want to learn more about these technologies?
**Contact me on CodeMentor for Live 1:1 Help!**

[![Contact me on Codementor](https://cdn.codementor.io/badges/contact_me_github.svg)](https://www.codementor.io/copperstarconsulting?utm_source=github&utm_medium=button&utm_term=copperstarconsulting&utm_campaign=github)

# NetCore.Globalization.Example
A brief example that I built for a student to illustrate techniques for localizing ASP.NET Core 2.0 ViewComponents.

# Quick Overview
* Resource files (*.resx) follow a specific naming convention
  * Resources are specific to a given component (i.e. GreetingViewComponent in this example)
  * If the component's source file exists in a subfolder hierarchy, the resource filename must reflect this:
    * Given a component called GreetingViewComponent that does not live in a subfolder, the Resource filename should be GreetingViewComponent.[language].resx
        * Given a component called GreetingViewComponent that lives in a Components subfolder, the Resource filename should be Components.GreetingViewComponent.[language].resx
  * Each component should also have a default .resx file that does not specify a language.  It doesn't need to contain any values (assuming you set a DefaultRequestCulture in `Startup.Configure()`) - it exists as a workaround to an issue with .NET Core resources.
* The ASP.NET Core MVC application needs to be configured to use resources in Startup.cs:

```
// In Configuration method:
app.UseRequestLocalization(new RequestLocalizationOptions
                                       {
                                           DefaultRequestCulture = new RequestCulture("en-US"),
                                           SupportedCultures = supportedCultures,
                                           SupportedUICultures = supportedCultures,
                                           // Disable Accept-Language provider (See notes section)
                                           RequestCultureProviders =
                                               new List<IRequestCultureProvider>
                                               {
                                                   new QueryStringRequestCultureProvider(),
                                                   new CookieRequestCultureProvider()
                                               }
                                       });

            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
```

```
// In ConfigureServices method:
services.AddLocalization(p => { p.ResourcesPath = "Resources"; });
            services.Configure<RequestLocalizationOptions>(options =>
                                                           {
                                                               options.DefaultRequestCulture = new RequestCulture("en-US");
                                                               options.SupportedCultures = supportedCultures;
                                                               options.SupportedUICultures = supportedCultures;
                                                           });
            services.AddMvc();
```
* The application must be configured with a list of supported cultures, which are injected when we configure the RequestLocalizationOptions.

# Fun Stuff:
* After you build the project, if you look in the bin folder, you'll see one folder for each supported language.  Each folder contains a .dll containing the resources for that specific language.
* You can also change the culture that is used for a given request by appending a `culture` URL parameter, i.e. http://localhost:28645/?culture=en-US

# Notes
This project explicitly disables MVC's handler for `Accept-Language` headers in order to make it easier to override the current culture configured in the user's browser.
