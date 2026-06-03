using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace VEGG.TABLE.Infrastructure.Data;

public static class Utils
{
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };
    public static async Task<T> DeserializeFromFileAsync<T>(string filePath)
    {
        if (!File.Exists(filePath)) return default;

        var fileInfo = new FileInfo(filePath);
        if (fileInfo.Length == 0) return default;
        try
        {
            using FileStream openStream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(openStream, _options);
        }
        catch (JsonException)
        {
            return default;
        }

    }
    public static async Task SerializeObjectsToFileAsync<T>(T data, string filePath)
    {
        using FileStream createStream = File.Create(filePath);
        await JsonSerializer.SerializeAsync(createStream, data, _options);
    }
}
