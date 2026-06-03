using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using VEGG.TABLE.Client;
using VEGG.TABLE.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Authentication services
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

//// HttpClient configuration
//builder.Services.AddTransient<AuthHandler>();
//builder.Services.AddHttpClient("API", client =>
//    client.BaseAddress = new Uri("http://localhost:5167"))
//    .AddHttpMessageHandler<AuthHandler>();

// Public client
builder.Services.AddHttpClient("PublicAPI", client => client.BaseAddress = new Uri("http://localhost:5167"));

// Protected client (with AuthHandler)
builder.Services.AddTransient<AuthHandler>();
builder.Services.AddHttpClient("ProtectedAPI", client => client.BaseAddress = new Uri("http://localhost:5167"))
                .AddHttpMessageHandler<AuthHandler>();

await builder.Build().RunAsync();