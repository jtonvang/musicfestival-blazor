using System;

namespace MusicFestival.Blazor.Template.ViewModels
{
    public class ArtistDetailsPageViewModel : PageBaseViewModel
    {
        public string ArtistName { get; set; }
        public string ArtistPhoto { get; set; }
        public string ArtistDescription { get; set; }
        public string ArtistGenre { get; set; }
        public DateTime PerformanceStartTime { get; set; }
        public DateTime PerformanceEndTime { get; set; }
        public string StageName { get; set; }
        public bool? ArtistIsHeadliner { get; set; }
    }
}
