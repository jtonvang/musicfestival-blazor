using Microsoft.Extensions.Logging;
using MusicFestival.Blazor.Template.Json;
using MusicFestival.Blazor.Template.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicFestival.Blazor.Template.Services
{
    public class ContentApiService
    {
        private HttpClient _httpClient { get; set; }
        private ILogger _logger { get; set; }
        private StateService _stateService { get; set; }
        private Task<Settings> _getSettings { get; set; }
        
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new PageTypeConverter() } 
        };

        public ContentApiService(
            HttpClient httpClient,
            ILogger<ContentApiService> logger,
            StateService stateService,
            Task<Settings> settings)
        {
            _httpClient = httpClient;
            _logger = logger;
            _stateService = stateService;
            _getSettings = settings;
        }
                
        public async Task<bool> SetCurrentViewModel(string url)
        {
            var settings = await _getSettings;

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            
            var response = await _httpClient.GetAsync($"{settings.ApiBaseUrl}/{url}?expand=*");
            var data = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new PageTypeConverter(), new BlockTypeConverter() }
            };

            _stateService.CurrentViewModel = await JsonSerializer.DeserializeAsync<PageBaseViewModel>(data, options);
            
            return _stateService.CurrentViewModel != null;
        }


        public async Task<IEnumerable<ContentBaseViewModel>> GetChildren(string url)
        {
            var settings = await _getSettings;

            var response = await _httpClient.GetAsync($"{settings.ApiBaseUrl}/{url}/children");
            var data = await response.Content.ReadAsStreamAsync();
                        
            var children = await JsonSerializer.DeserializeAsync<PageBaseViewModel[]>(data, _options);

            return children;
        }
    }
}
