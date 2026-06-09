using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using VEGG.TABLE.Client;
using VEGG.TABLE.Client.Services;
using VEGG.TABLE.Core.Entities;
using VEGG.TABLE.Client.Loaders;

string apiUrl = "http://localhost:5167";
//string ClientUrl = "http://localhost:5215";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Authentication services
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

//Addprduceloader
builder.Services.AddScoped<produceLoader>();
builder.Services.AddScoped<VEGG.TABLE.Client.Loaders.produceLoader>();


// Configure Global JSON options to handle Enums as Strings
var jsonOptions = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    Converters = { new JsonStringEnumConverter() }
};


// Public client
builder.Services.AddHttpClient("PublicAPI", client =>
    client.BaseAddress = new Uri(apiUrl))
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());

// Protected client (with AuthHandler)
builder.Services.AddTransient<AuthHandler>();
builder.Services.AddHttpClient("ProtectedAPI", client =>
    client.BaseAddress = new Uri(apiUrl))
    .AddHttpMessageHandler<AuthHandler>()
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler());

await builder.Build().RunAsync();





//var produces = File.ReadAllText(
//                "Resources/Produce.json");
////foreach (var produce in produces) {
////    Console.WriteLine(produce.Name);
////    };
//Console.WriteLine(produces);