using MorphMaui.Services;
using MorphShared;
using MudBlazor.Services;

namespace MorphMaui
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

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddMudServices();

            // add shared services and platform-specific services
            builder.Services.AddMorphSharedServices((platformServices) =>
            {
                platformServices.AddShareService<ShareService>();
            });

            builder.Services.AddSingleton(provider => ShakeService.Start());

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            return builder.Build();
        }
    }
}