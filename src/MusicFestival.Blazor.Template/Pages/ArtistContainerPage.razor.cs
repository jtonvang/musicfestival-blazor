using Microsoft.AspNetCore.Components;
using MusicFestival.Blazor.Template.Services;
using MusicFestival.Blazor.Template.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicFestival.Blazor.Template.Pages
{
    public class ArtistContainerPageBase : ComponentBase
    {
        [Inject]
        ContentApiService ApiService { get; set; }

        [Inject]
        protected StateService State { get; set; }

        [Inject]
        Task<Settings> GetSettings { get; set; }

        public ArtistContainerPageViewModel ViewModel { get; set; }

        public IEnumerable<ArtistDetailsPageViewModel> Artists { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ViewModel = State.CurrentViewModel as ArtistContainerPageViewModel;
            var artists = await ApiService.GetChildren(ViewModel.Url);
                        
            Artists = artists.ToList().Cast<ArtistDetailsPageViewModel>();
            await RemapArtistImages();
        }

        private async Task RemapArtistImages()
        {
            var settings = await GetSettings;
            
            foreach(var artist in Artists)
            {
                artist.ArtistPhoto = $"{settings.ApiBaseUrl}{artist.ArtistPhoto}";
            }
        }
        
    }
}
