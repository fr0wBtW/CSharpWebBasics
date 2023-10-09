using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
        }
        public void Configure(List<Route> routeTable)
        {
            routeTable.Add(new Route("/", SUS.HTTP.HttpMethod.GET, new HomeController().Index));
            routeTable.Add(new Route("/favicon.ico", SUS.HTTP.HttpMethod.GET, new StaticFilesController().Favicon));
            routeTable.Add(new Route("/users/login", SUS.HTTP.HttpMethod.GET, new UsersController().Login));
            routeTable.Add(new Route("/users/login", SUS.HTTP.HttpMethod.POST, new UsersController().DoLogin));
            routeTable.Add(new Route("/users/register", SUS.HTTP.HttpMethod.GET, new UsersController().Register));
            routeTable.Add(new Route("/cards/all", SUS.HTTP.HttpMethod.GET, new CardsController().All));
            routeTable.Add(new Route("/cards/add", SUS.HTTP.HttpMethod.GET, new CardsController().Add));
            routeTable.Add(new Route("/cards/collection", SUS.HTTP.HttpMethod.GET, new CardsController().Collection));



            routeTable.Add(new Route("/css/bootstrap.min.css", SUS.HTTP.HttpMethod.GET, new StaticFilesController().BootstrapCss));
            routeTable.Add(new Route("/css/custom.css", SUS.HTTP.HttpMethod.GET, new StaticFilesController().CustomCss));
            routeTable.Add(new Route("/js/custom.js", SUS.HTTP.HttpMethod.GET, new StaticFilesController().CustomJs));
            routeTable.Add(new Route("/js/bootstrap.bumdle.min.js", SUS.HTTP.HttpMethod.GET, new StaticFilesController().BootstrapJs));


            routeTable.Add(new Route("/joro", SUS.HTTP.HttpMethod.GET, (request) =>
            {
                return new HttpResponse("text/html", new byte[] { 0x4d, 0x42, 0x2d, 0x42, 0x45, 0x4e, 0x5a });
            }));

        }
    }
}
