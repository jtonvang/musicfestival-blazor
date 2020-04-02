using Microsoft.AspNetCore.Components;
using MusicFestival.Blazor.Template.Services;
using MusicFestival.Blazor.Template.ViewModels;
using System.Threading.Tasks;

namespace MusicFestival.Blazor.Template.Pages
{
    public class ArtistDetailsPageBase : ComponentBase
    {
        [Inject]
        protected StateService State { get; set; }

        [Inject]
        private Task<Settings> GetSettings { get; set; }

        public ArtistDetailsPageViewModel ViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var settings = await GetSettings;
            
            ViewModel = State.CurrentViewModel as ArtistDetailsPageViewModel;
            ViewModel.ArtistPhoto = $"{settings.ApiBaseUrl}{ViewModel.ArtistPhoto}";
        }
    }
}
