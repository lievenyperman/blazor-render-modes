using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RenderModes.Shared.Helpers;
using RenderModes.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Constants.BackendAPIBaseAddress) });
builder.Services.AddSingleton<CounterService>();

await builder.Build().RunAsync();
