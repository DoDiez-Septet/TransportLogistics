using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TransportLogisticUIWebApp.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

IConfiguration config = builder.Configuration;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(config);
builder.Services.AddHttpClient("GatewayApi", client => client.BaseAddress = new Uri("http://91.219.6.251:8001"));// config.GetSection("HttpHostBaseAddress").Value.ToString()));
builder.Services.AddMudServices();

await builder.Build().RunAsync();
