using MusicFestival.Blazor.Template.ViewModels.Blocks;
using System.Collections.Generic;

namespace MusicFestival.Blazor.Template.ViewModels
{
    public class LandingPageViewModel : PageBaseViewModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string HeroImage { get; set; }
        public PageLinkViewModel ArtistsLink {get;set;}
        public IEnumerable<BlockBaseViewModel> MainContentArea { get; set; }
        public IEnumerable<BlockBaseViewModel> FooterContentArea { get; set; }
        public BuyTicketBlockViewModel BuyTicketBlock { get; set; }
    }
}
