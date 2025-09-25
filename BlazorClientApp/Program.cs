using BlazorClientApp.Components;
using BlazorClientApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container for interactive server components.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register an HTTP client for the Orders API.
// The base address is read from configuration key "ApiBaseUrl" if present,
// otherwise it falls back to "https://localhost:5001/" (adjust to your API URL).
builder.Services.AddHttpClient<IOrderApiService, OrderApiService>(client =>
{
    var apiBase = builder.Configuration["ApiBaseUrl"];
    client.BaseAddress = new Uri(!string.IsNullOrWhiteSpace(apiBase) ? apiBase : "https://localhost:5001/");
});

builder.Services.AddHttpClient<ICustomerApiService, CustomerApiService>(client =>
{
    var apiBase = builder.Configuration["ApiBaseUrl"];
    client.BaseAddress = new Uri(!string.IsNullOrWhiteSpace(apiBase) ? apiBase : "https://localhost:7001/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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
