using System.Web.Mvc;
using MusicFestival.Blazor.Epi.Models.Pages;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using EPiServer;
using EPiServer.Framework.Web.Resources;

namespace MusicFestival.Blazor.Epi.Controllers
{
    public class DefaultPageController : PageController<BasePage>
    {
        public RedirectResult Index(BasePage currentPage)
        {
            // Because of our URL rewrite rules, this controller
            // is only hit when accessing the page through edit mode.
            // For the OPE to work - instead of returning a view, we
            // redirect to the non-edit-mode friendly URL

            var userCanEdit = currentPage.ACL.QueryDistinctAccess(EPiServer.Security.AccessLevel.Edit);

            var url = UrlResolver.Current.GetUrl(
                currentPage.ContentLink,
                currentPage.Language.TwoLetterISOLanguageName,
                new VirtualPathArguments
                {
                    ContextMode = EPiServer.Web.ContextMode.Default
                });

            url += $"?epieditmode=true&iseditable={userCanEdit}";


            return new RedirectResult(url);
        }
    }
}