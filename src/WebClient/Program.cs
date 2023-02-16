using jsInterop.JSInterop;
using jsInterop.RazorClassLibrary.Data;
using jsInterop.WebClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddSingleton<WeatherForecastService>()
    .AddScoped(sp => new Interop(sp.GetRequiredService<IJSRuntime>()))
    ;

await builder.Build().RunAsync();
