using jsInterop.JSInterop;
using jsInterop.RazorClassLibrary.Data;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace jsInterop.MauiClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services
                .AddMauiBlazorWebView();

            builder.Services
                .AddSingleton<WeatherForecastService>()
                .AddScoped(sp => new Interop(sp.GetRequiredService<IJSRuntime>()))
                ;

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}