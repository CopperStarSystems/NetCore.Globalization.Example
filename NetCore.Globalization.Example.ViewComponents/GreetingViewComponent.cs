//  --------------------------------------------------------------------------------------
// NetCore.Globalization.Example.ViewComponents.GreetingViewComponent.cs
// 2018/03/05
//  --------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace NetCore.Globalization.Example.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        readonly IStringLocalizer<GreetingViewComponent> localizer;

        public GreetingViewComponent(IStringLocalizer<GreetingViewComponent> localizer)
        {
            this.localizer = localizer;
        }

        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            var localizedGreeting = localizer.GetString("Greeting");
            var greeting = $"{localizedGreeting} {name}!";
            return View("Default", greeting);
        }
    }
}