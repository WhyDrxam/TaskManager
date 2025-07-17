using Models;

namespace Services;

public class JobService : IJobService
{
    public JobService()
    {
        jobs = new List<Job>();
    }

    private List<Job> jobs;
    public List<Job> GetAllJobs()
    {
        throw new NotImplementedException();
    }

    public Job GetJobById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void AddJob(Job job)
    {
        jobs.Add(job);
    }

    public void UpdateJob(Job job)
    {
        throw new NotImplementedException();
    }

    public void DeleteJob(Job job)
    {
        throw new NotImplementedException();
    }

    public List<Job> GetJobByStatus(JobStatus status)
    {
        throw new NotImplementedException();
    }

    public Task SaveToFile()
    {
        throw new NotImplementedException();
    }

    public Task<List<Job>> LoadFromFile()
    {
        throw new NotImplementedException();
    }
}