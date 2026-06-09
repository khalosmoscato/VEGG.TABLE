using System.Text.Json;
using System.Text.Json.Serialization;

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
builder.Services.AddHttpClient();

// Configure Global JSON options to handle Enums as Strings
var jsonOptions = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    Converters = { new JsonStringEnumConverter() }
};

// Public client
builder.Services.AddHttpClient("PublicAPI", client =>
    client.BaseAddress = new Uri("https://localhost:7277"))
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());

// Protected client (with AuthHandler)
builder.Services.AddTransient<AuthHandler>();
builder.Services.AddHttpClient("ProtectedAPI", client =>
    client.BaseAddress = new Uri("https://localhost:7277/"))
    .AddHttpMessageHandler<AuthHandler>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());

await builder.Build().RunAsync();