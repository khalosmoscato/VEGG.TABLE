using System.Text.Json;

using Microsoft.EntityFrameworkCore;

namespace VEGG.TABLE.UnitTests;

public class Utils
{
    public static T DeserializeFromFile<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json)!;
    }
    public static List<T> GetFileContent<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<T>>(json)!;
    }
    public static string ReSerialize<T>(List<T> input)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        return JsonSerializer.Serialize(input, options);
    }
    public static List<T> GetDbContent<T>(DBContext db)
    where T : class
    {
        return db.Set<T>().ToList();
    }


}