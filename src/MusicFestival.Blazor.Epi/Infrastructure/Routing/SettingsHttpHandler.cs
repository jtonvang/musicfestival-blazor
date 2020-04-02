using System.Web;

namespace MusicFestival.Blazor.Epi.Infrastructure.Routing
{
    public class SettingsHttpHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            string baseUrl = context.Request.Url.Scheme + "://"
                             + context.Request.Url.Authority
                             + context.Request.ApplicationPath.TrimEnd('/') + "/";

            context.Response.Write("{\"apiBaseUrl\": \"" + baseUrl + "\" }");
            context.Response.ContentType = "application/json";

        }
    }
}