using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MusicFestival.Blazor.Template.Services;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace MusicFestival.Blazor.Template
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();

            builder.Services.AddSingleton<ContentApiService, ContentApiService>();
            builder.Services.AddSingleton<StateService, StateService>();
            builder.Services.AddSingleton(async p =>
            {
                var httpClient = p.GetRequiredService<HttpClient>();

                return await httpClient.GetJsonAsync<Settings>("settings.json")
                    .ConfigureAwait(false);
            });

            await builder.Build().RunAsync();
        }
    }
}
