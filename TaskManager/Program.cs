using Models;

namespace TaskManager;

public class Program
{
    public static void Main(string[] args)
    {
        Job job = new Job();
        job.ChangeCategory(JobCategory.Work);
        job.Title = "test";
        job.AddTag("TAGTAGTAG");
        Console.WriteLine(job);
    }
}