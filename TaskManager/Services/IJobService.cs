using Models;

namespace Services;


public interface IJobService
{
    List<Job> GetAllJobs();
    Job? GetJobById(Guid id);
    void AddJob(Job job);
    void UpdateJob(Guid id, out Job updatedJob);
    void DeleteJob(Job job);
    List<Job> GetJobByStatus(JobStatus status);
    Task SaveToFile();
    Task<List<Job>> LoadFromFile();
}