using Microsoft.AspNetCore.Components;
using MusicFestival.Blazor.Template.ViewModels.Blocks;
using System.Threading.Tasks;

namespace MusicFestival.Blazor.Template.Components.Blocks
{
    public class ContentBlockBase : ComponentBase
    {   
        [Parameter]
        public ContentBlockViewModel ViewModel { get; set; }

        [Inject]
        private Task<Settings> _getSettings { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var settings = await _getSettings;            

            ViewModel.Image = $"{settings.ApiBaseUrl}{ViewModel.Image}";
        }

        protected string ImageAlignment(string direction)
        {
            return direction == "Right"
            ? "Grid--rowReverse"
            : string.Empty;
        }

    }
}
