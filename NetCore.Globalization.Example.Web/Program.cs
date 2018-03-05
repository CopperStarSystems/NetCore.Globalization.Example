//  --------------------------------------------------------------------------------------
// NetCore.Globalization.Example.Web.Program.cs
// 2018/03/05
//  --------------------------------------------------------------------------------------

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace NetCore.Globalization.Example.Web
{
    public class Program
    {
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
        }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
    }
}