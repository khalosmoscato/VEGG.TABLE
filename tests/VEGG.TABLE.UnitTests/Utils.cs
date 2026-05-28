using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace RecordShop.Repository
{
    public class Utils
    {
        public static T DeserializeFromFile<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
        public static List<T> GetFileContent<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json);
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
}
