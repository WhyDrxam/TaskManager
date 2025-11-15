using System.Text;
using Models;
using System.Text.Json;

namespace Services;

public class FileStorage : IFileStorage
{
    public void SaveTasks(List<Job> tasks, string filePath)
    {
        if (tasks ==  null || tasks.Count <= 0 )
        {
            throw new ArgumentNullException("Список не должен быть пустым!", nameof(tasks));
        }

        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException("Путь к папке не должен быть пустым", nameof(filePath));
        }
        
        using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(stream, tasks);
        }
    }

    public List<Job> LoadTasks(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException("Путь к папке не должен бть пустым", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Такого файла не сществует", nameof(filePath));
        }

        var fReader = File.ReadAllText(filePath);
        var content = JsonSerializer.Deserialize<List<Job>>(fReader); 
        return content ?? [];
    }
}