using RenderModes.Shared.Helpers;
using RenderModes.Shared.Services;
using ServerSide.Components;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddSingleton<ICounterService, CounterService2>();
builder.Services.AddScoped<ICounterService, CounterService>();

builder.Services.AddHttpClient(Constants.HttpClientName, client =>
{
    client.BaseAddress = new Uri(Constants.BackendAPIBaseAddress);
});

Debug.WriteLine("Program.cs executed...");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
