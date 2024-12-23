using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using StevensPassCompanion.Services;

namespace StevensPassCompanion
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddMudServices();
            builder.Services.AddHttpClient();
            builder.Services.AddLogging();
            builder.Services.AddSingleton<WSDOTService>();
            builder.Services.AddSingleton<NOAAService>();

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["BaseAddress"] ?? builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
        }
    }
}
