using Models;

namespace Services;

public class FileManager
{
    private readonly IFileStorage _fileStorage;

    public FileManager(IFileStorage storage)
    {
        _fileStorage = storage;
    }

    public void SaveJobs(List<Job> jobs, string filePath)
    {
        _fileStorage.SaveTasks(jobs, filePath);
    }

    public List<Job> LoadJobs(string filePath)
    {
        return _fileStorage.LoadTasks(filePath);
    }
}