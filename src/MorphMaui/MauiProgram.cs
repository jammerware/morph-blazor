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
            builder.Services.AddSingleton(provider => SecureStorage.Default);
            builder.Services.AddSingleton<Task<SettingsService>>(async provider => await SettingsService.Create(SecureStorage.Default));

            // add shared services and platform-specific services
            builder.Services.AddMorphSharedServices((platformServices) =>
            {
                platformServices.AddShareService<ShareService>();
            });

            builder.Services.AddSingleton(provider => ShakeService.Start());

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            var buildThing = builder.Build();
            Console.Write("yo");

            return buildThing;
        }
    }
}