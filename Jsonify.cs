using System.Text.Encodings.Web;
using System.Text.Json;

namespace WestCoastEducation;

public static class Jsonify
{
    private static readonly string _path =
        string.Concat(Environment.CurrentDirectory, "/Data/courses.json");

    public static void SaveCourses(List<Course> courses)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        var json = JsonSerializer.Serialize(courses, options);
        File.WriteAllText(_path, json);
    }

    public static List<Course> LoadCourses()
    {
        if (!File.Exists(_path))
        {
            return new List<Course>();
        }

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<List<Course>>(json, options) ?? new List<Course>();
    }
}