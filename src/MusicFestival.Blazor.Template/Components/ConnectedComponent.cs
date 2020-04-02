using Microsoft.AspNetCore.Components;
using MusicFestival.Blazor.Template.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicFestival.Blazor.Template.Components
{
    public class ConnectedComponent : ComponentBase
    {
        [Inject]
        protected StateService State { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            State.Notify += OnNotify;
        }

        public async Task OnNotify()
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

    }
}
