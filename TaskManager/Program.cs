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
        job.AddTag("dfiugkjdfg");
        job.AddTag("dfiphjpofgkhngmnkmgn");
        Console.WriteLine(job);
    }
}