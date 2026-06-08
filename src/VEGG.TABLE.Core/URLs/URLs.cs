using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace VEGG.TABLE.Core.URLs;

//public static class URLs
//{
//    public static string APIUrl { get; }
//    public static string ClientUrl { get; }

//    static URLs()
//    {
//        var baseDir = Directory.GetCurrentDirectory();

//        var apiPath = Path.GetFullPath(
//            Path.Combine(baseDir, "..", "VEGG.TABLE.API", "Properties", "launchSettings.json"));

//        var jsonAPI = File.ReadAllText(apiPath);
//        using var docAPI = JsonDocument.Parse(jsonAPI);

//        APIUrl = docAPI.RootElement
//            .GetProperty("profiles")
//            .GetProperty("http")
//            .GetProperty("applicationUrl")
//            .GetString() ?? "http://localhost:5167";
//        APIUrl = "http://localhost:5167";

//        var clientPath = Path.GetFullPath(
//            Path.Combine(baseDir, "..", "VEGG.TABLE.Client", "Properties", "launchSettings.json"));

//        var jsonClient = File.ReadAllText(clientPath);
//        using var docClient = JsonDocument.Parse(jsonClient);

//        ClientUrl = docClient.RootElement
//            .GetProperty("profiles")
//            .GetProperty("http")
//            .GetProperty("applicationUrl")
//            .GetString() ?? "http://localhost:5215";
//        ClientUrl = "http://localhost:5215";
//    }
//}

