//  --------------------------------------------------------------------------------------
// NetCore.Globalization.Example.Web.HomeController.cs
// 2018/03/05
//  --------------------------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Globalization.Example.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            // Store the selected culture to a cookie
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                                    new CookieOptions {Expires = DateTimeOffset.UtcNow.AddYears(1)});

            return LocalRedirect(returnUrl);
        }
    }
}