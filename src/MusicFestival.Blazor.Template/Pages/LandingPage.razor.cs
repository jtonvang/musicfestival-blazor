using Microsoft.AspNetCore.Components;
using MusicFestival.Blazor.Template.Services;
using MusicFestival.Blazor.Template.ViewModels;
using System.Threading.Tasks;

namespace MusicFestival.Blazor.Template.Pages
{
    public class LandingPageBase : ComponentBase
    {
        [Inject]
        StateService State { get; set; }

        [Inject]
        Task<Settings> GetSettings { get; set; }

        public LandingPageViewModel ViewModel { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var settings = await GetSettings;

            ViewModel = State.CurrentViewModel as LandingPageViewModel;
            ViewModel.HeroImage = $"{settings.ApiBaseUrl}{ViewModel.HeroImage}";                        
        }

        public void OpenModal()
        {
            State.ModalShowing = true;
            StateHasChanged();
        }
    }
}
