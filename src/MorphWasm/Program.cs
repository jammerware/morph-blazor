using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MorphShared;
using MorphShared.Services;
using MorphWasm;
using MorphWasm.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// for MudBlazor
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = "mud-snackbar-location-top-center";
});

// add shared services and platform-specific services
builder.Services.AddMorphSharedServices(platformServices =>
{
    platformServices.AddShareService<ShareService>();
});

// our services
builder.Services.AddScoped<IClipboardService, ClipboardService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
