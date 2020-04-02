using System.Web;
using System.Web.Routing;

namespace MusicFestival.Blazor.Epi.Infrastructure.Routing
{
    public class SettingsRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SettingsHttpHandler();
        }
    }
}