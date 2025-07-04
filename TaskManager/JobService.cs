namespace TaskManager;

public class JobService : IJobService
{
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
        throw new NotImplementedException();
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