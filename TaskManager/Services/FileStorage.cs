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
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException("Путь к папке не должен быть пустым", nameof(filePath));
        }
        
        
        if (tasks ==  null || tasks.Count <= 0 )
        {
            throw new ArgumentNullException("Список не должен быть пустым!", nameof(tasks));
        }

        
        var extension = Path.GetExtension(filePath);
        if (extension != ".json")
        {
            throw new ArgumentException("Неверный формат файла, должен быть .json", nameof(extension));
        }

        FileInfo fileInfo = new FileInfo(filePath);
        using (var stream = fileInfo.Open( FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(stream, tasks, options);
        }
    }

    public List<Job> LoadTasks(string filePath)
    {
        
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException("Путь к папке не должен бть пустым", nameof(filePath));
        }

        if (!Path.Exists(filePath))
        {
            throw new ArgumentException("Указаный путь не существует", nameof(filePath));
        }

        
        var extension = Path.GetExtension(filePath);
        if (extension != ".json")
        {
            throw new ArgumentException($"Неверный формат файла, должен быть .json. Переданное расширение {extension}");
        }
        

        // if (!File.Exists(filePath))
        // {
        //     throw new FileNotFoundException("Такого файла не сществует", nameof(filePath));
        // }
        FileInfo fileInfo = new FileInfo(filePath);
        using (var stream = fileInfo.Open( FileMode.OpenOrCreate))
        {
            var content = JsonSerializer.Deserialize<List<Job>>(stream, options);
            return content ?? [];
        }
        
        // var fReader = File.ReadAllText(filePath);
        // var content = JsonSerializer.Deserialize<List<Job>>(fReader, options); 
        // return content ?? [];
    }
}