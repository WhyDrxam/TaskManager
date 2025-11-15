using Models;
using Services;

namespace TaskManager;

public class Program
{
    public static void Main(string[] args)
    {
        Job job = new Job();
        job.Title = "test";
        JobService service = new JobService();
        service.AddJob(job);
        
        
    }
    
}

