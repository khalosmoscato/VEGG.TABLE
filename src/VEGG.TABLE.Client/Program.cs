using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using VEGG.TABLE.Client;
using VEGG.TABLE.Client.Services;

// APIURL
var baseDir = Directory.GetCurrentDirectory();
var APIPath = Path.GetFullPath(
    Path.Combine(baseDir, "..", "VEGG.TABLE.API", "Properties", "launchSettings.json"));
var jsonAPI = File.ReadAllText(APIPath);
using var docAPI = JsonDocument.Parse(jsonAPI);
var APIUrl = docAPI.RootElement
    .GetProperty("profiles")
    .GetProperty("http")
    .GetProperty("applicationUrl")
    .GetString();
// ClientURL
var clientPath = Path.GetFullPath(
    Path.Combine(baseDir, "..", "VEGG.TABLE.Client", "Properties", "launchSettings.json"));
var jsonClient = File.ReadAllText(clientPath);
using var docClient = JsonDocument.Parse(jsonClient);
var ClientUrl = docClient.RootElement
    .GetProperty("profiles")
    .GetProperty("http")
    .GetProperty("applicationUrl")
    .GetString();


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Authentication services
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

// Configure Global JSON options to handle Enums as Strings
var jsonOptions = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    Converters = { new JsonStringEnumConverter() }
};

// Public client
builder.Services.AddHttpClient("PublicAPI", client =>
    client.BaseAddress = new Uri(APIUrl))
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());

// Protected client (with AuthHandler)
builder.Services.AddTransient<AuthHandler>();
builder.Services.AddHttpClient("ProtectedAPI", client =>
    client.BaseAddress = new Uri(APIUrl))
    .AddHttpMessageHandler<AuthHandler>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());

await builder.Build().RunAsync();