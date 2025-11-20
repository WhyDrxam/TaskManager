using System.Text;
using Models;
using System.Text.Json;

namespace Services;

public class FileStorage : IFileStorage
{
    JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true,
        IncludeFields = true,
        WriteIndented = true
    };
    public void SaveTasks(List<Job> tasks, string filePath)
    {
        
        
        var extension = Path.GetExtension(filePath);
        if (tasks ==  null || tasks.Count <= 0 )
        {
            throw new ArgumentNullException("Список не должен быть пустым!", nameof(tasks));
        }

        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException("Путь к папке не должен быть пустым", nameof(filePath));
        }

        if (extension != ".json")
        {
            throw new ArgumentException("Неверный формат файла, должен быть .json", nameof(extension));
        }
        
        using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(stream, tasks, options);
        }
    }

    public List<Job> LoadTasks(string filePath)
    {
        var extension = Path.GetExtension(filePath);
        if (extension != ".json")
        {
            throw new ArgumentException("Неверный формат файла, должен быть .json", nameof(extension));
        }
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException("Путь к папке не должен бть пустым", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Такого файла не сществует", nameof(filePath));
        }

        var fReader = File.ReadAllText(filePath);
        var content = JsonSerializer.Deserialize<List<Job>>(fReader, options); 
        return content ?? [];
    }
}