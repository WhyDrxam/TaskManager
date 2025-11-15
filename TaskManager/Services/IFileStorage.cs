using Models;

namespace Services;

public interface IFileStorage
{
    public void SaveTasks(List<Job> tasks, string filePath);

    public List<Job> LoadTasks(string filePath);
}