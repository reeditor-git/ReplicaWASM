using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Replica.Client;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTM3OTIwOUAzMjMwMmUzNDJlMzBHWnV6OWRYb1dZdHJLd1VvQ1FXeTUxZlRtdFJhZ2hEdStqcGEveTRkNmxBPQ==");

await builder.Build().RunAsync();
