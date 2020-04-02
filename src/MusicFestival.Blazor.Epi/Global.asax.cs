using MusicFestival.Blazor.Epi.Infrastructure.Routing;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicFestival.Blazor.Epi
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
        }

        protected override void RegisterRoutes(RouteCollection routes)
        {
            base.RegisterRoutes(routes);

            routes.IgnoreRoute("Blazor/dist/");

            routes.Add(new Route("settingshandler", new SettingsRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional });

        }
    }
}