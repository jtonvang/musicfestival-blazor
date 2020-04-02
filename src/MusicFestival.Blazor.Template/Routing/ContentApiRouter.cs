using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MusicFestival.Blazor.Template.Services;
using MusicFestival.Blazor.Template.Helpers;

namespace MusicFestival.Blazor.Template.Routing
{
    public class ContentApiRouter : IComponent, IHandleAfterRender, IDisposable
    {
        private RenderHandle _renderHandle;
        private bool _navigationInterceptionEnabled;
        private string _location;

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        INavigationInterception NavigationInterception { get; set; }

        [Inject]
        ILogger<ContentApiRouter> Logger { get; set; }

        [Inject]
        ContentApiService ApiService { get; set; }

        [Inject]
        StateService State { get; set; }

        [Parameter]
        public RenderFragment<RouteData> Found { get; set; }
        [Parameter]
        public RenderFragment NotFound { get; set; }


        private void HandleLocationChanged(object sender, LocationChangedEventArgs args)
        {
            _location = args.Location;
            Refresh();
        }

        private async void Refresh()
        {
            var relativeUri = NavigationManager.ToBaseRelativePath(_location);
            var parameters = ParseQueryString(relativeUri);

            SetEditParameters(parameters);

            if (relativeUri.IndexOf('?') > -1)
            {
                relativeUri = relativeUri.Substring(0, relativeUri.IndexOf('?'));
            }

            var segments = relativeUri.Trim().Split('/', StringSplitOptions.RemoveEmptyEntries);

            await ApiService.SetCurrentViewModel(relativeUri);

            var type = ContentTypeHelper.ResolveContentType(State.CurrentViewModel.ContentType);

            // parameters via URL currently not supported
            // no need for them in Music Festival anyway
            
            var routeData = new RouteData(type, new Dictionary<string, object>());

            _renderHandle.Render(Found(routeData));
        }

        private void SetEditParameters(Dictionary<string, object> parameters)
        {
            State.IsInEditMode = parameters.Any(p => p.Key == "epieditmode");
            State.IsEditable = parameters.Any(p => p.Key == "iseditable");
        }

        private Dictionary<string, object> ParseQueryString(string uri)
        {
            var querystring = new Dictionary<string, object>();

            foreach (string kvp in uri.Substring(uri.IndexOf("?") + 1).Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (kvp != "" && kvp.Contains("="))
                {
                    var pair = kvp.Split('=');
                    querystring.Add(pair[0], pair[1]);
                }
            }

            return querystring;
        }

        public void Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
            NavigationManager.LocationChanged += HandleLocationChanged;
            _location = NavigationManager.Uri;
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= HandleLocationChanged;
        }

        public Task OnAfterRenderAsync()
        {
            if (!_navigationInterceptionEnabled)
            {
                _navigationInterceptionEnabled = true;
                return NavigationInterception.EnableNavigationInterceptionAsync();
            }

            return Task.CompletedTask;
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);

            if (Found == null)
            {
                throw new InvalidOperationException($"The {nameof(ContentApiRouter)} component requires a value for the parameter {nameof(Found)}.");
            }

            if (NotFound == null)
            {
                throw new InvalidOperationException($"The {nameof(ContentApiRouter)} component requires a value for the parameter {nameof(NotFound)}.");
            }

            Refresh();

            return Task.CompletedTask;
        }
    }
}
