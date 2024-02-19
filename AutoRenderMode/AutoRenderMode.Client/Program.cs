using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RenderModes.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton<CounterService>();

await builder.Build().RunAsync();
