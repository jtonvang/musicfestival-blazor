using MusicFestival.Blazor.Template.Components.Blocks;
using MusicFestival.Blazor.Template.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicFestival.Blazor.Template.Helpers
{
    public static class ContentTypeHelper
    {
        private static readonly Dictionary<string, Type> _componentTypeMap = new Dictionary<string, Type>
        {
            { "LandingPage", typeof(LandingPage) },
            { "ArtistContainerPage", typeof(ArtistContainerPage) },
            { "ArtistDetailsPage", typeof(ArtistDetailsPage) },
            { "ContentBlock", typeof(ContentBlock) },
            { "BuyTicketBlock", typeof(BuyTicketBlock)}
        };

        public static Type ResolveContentType(string[] contentTypes)
        {
            // Reverse the content types array, as Content API
            // returns the whole type hierarchy and we want to
            // try for an exact match first.
            foreach (var type in contentTypes.Reverse())
            {
                if (_componentTypeMap.ContainsKey(type))
                    return _componentTypeMap[type];

            }

            return null;
        }
    }
}
