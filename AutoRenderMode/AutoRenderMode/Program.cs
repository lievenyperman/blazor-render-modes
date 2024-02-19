using AutoRenderMode.Components;
using RenderModes.Shared.Helpers;
using RenderModes.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<CounterService>();

builder.Services.AddHttpClient(Constants.HttpClientName, client =>
{
    client.BaseAddress = new Uri(Constants.BackendAPIBaseAddress);
});

//builder.Services.AddHttpClient().ConfigureHttpClientDefaults(client =>
//{
//    client.ConfigureHttpClient(httpClient =>
//    {
//        httpClient.BaseAddress = new("http://apiservice");
//    });
//});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AutoRenderMode.Client._Imports).Assembly);

app.Run();
