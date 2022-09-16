using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MorphShared;
using MorphWasm;
using MorphWasm.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// for MudBlazor
builder.Services.AddMudServices();

// add shared services and platform-specific services
builder.Services.AddMorphSharedServices(platformServices =>
{
    platformServices.AddShareService<ShareService>();
});

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
