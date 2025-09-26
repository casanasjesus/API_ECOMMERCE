using BlazorClientApp.Components;
using BlazorClientApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IOrderApiService, OrderApiService>(client =>
{
    var apiBase = builder.Configuration["ApiBaseUrl"];
    client.BaseAddress = new Uri(!string.IsNullOrWhiteSpace(apiBase) ? apiBase : "https://localhost:5001/");
});

builder.Services.AddHttpClient<IProductApiService, ProductApiService>(client =>
{
    var apiBase = builder.Configuration["ApiBaseUrl"];
    client.BaseAddress = new Uri(!string.IsNullOrWhiteSpace(apiBase) ? apiBase : "https://localhost:6001/");
});

builder.Services.AddHttpClient<ICustomerApiService, CustomerApiService>(client =>
{
    var apiBase = builder.Configuration["ApiBaseUrl"];
    client.BaseAddress = new Uri(!string.IsNullOrWhiteSpace(apiBase) ? apiBase : "https://localhost:7001/");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
