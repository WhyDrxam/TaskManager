using Models;

namespace TaskManager;


public interface IJobService
{
    List<Job> GetAllJobs();
    Job GetJobById(Guid id);
    void AddJob(Job job);
    void UpdateJob(Job job);
    void DeleteJob(Job job);
    List<Job> GetJobByStatus(JobStatus status);
    Task SaveToFile();
    Task<List<Job>> LoadFromFile();
}