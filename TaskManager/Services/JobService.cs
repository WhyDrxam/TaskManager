using Models;

namespace Services;
/// <summary>
/// класс реализующий IJobService
/// </summary>
public class JobService : IJobService
{
    private readonly List<Job> _jobs;
    public JobService()
    {
        _jobs = new List<Job>();
    }
    /// <summary>
    /// возвращает список всех задач
    /// </summary>
    /// <returns>список задач</returns>
    public List<Job> GetAllJobs()
    {
        return _jobs.ToList();
    }
/// <summary>
/// вернет задачу по уникальному номеру
/// </summary>
/// <param name="id">уникальный номер задачи</param>
/// <returns>задачу</returns>
    public Job? GetJobById(Guid id)
    {
        return _jobs.FirstOrDefault(j => j.Id.Equals(id));
    }
/// <summary>
/// добавляет в список задачу
/// </summary>
/// <param name="job">указывает какую задачу надо добавить в список</param>
/// <exception cref="ArgumentNullException">если задача нул, вадет ошибку</exception>
/// <exception cref="ArgumentException">нельзя добавить уже существующую задачу</exception>
    public void AddJob(Job job)
    {
        if (job == null)
        {
            throw new ArgumentNullException(nameof(job));
        }
        
        if (job.Id == Guid.Empty)
        {
            throw new ArgumentException("Задачи с пустым Id не должно быть!", nameof(job));
        }
        
        if (_jobs.Any(j => j.Id == job.Id))
        {
            throw new ArgumentException("Задача с таким номером уже существует!", nameof(job));
        }
        
        _jobs.Add(job);
        
    }

    /// <summary>
    /// Пытается обновить задачу с указанным ID
    /// </summary>
    /// <returns>true если задача была обновлена, false если задача не найдена</returns>
    
    public bool UpdateJob(Guid id, Job updatedJob)
    {
        if (updatedJob == null)
        {
            throw new ArgumentNullException(nameof(updatedJob));
        }

        var jobToUpdateIndex = _jobs.FindIndex(j => j.Id == id);
        if (jobToUpdateIndex == -1)
        {
            return false;
        }

        _jobs[jobToUpdateIndex] = updatedJob;
        return true;
    }
/// <summary>
/// Удаляет задачу по уникальному Id
/// </summary>
/// <param name="id">параметр по которому будет производиться поиск задачи</param>
/// <exception cref="ArgumentNullException">задача не найдена</exception>
    public void DeleteJob(Guid id)
    {
        var jobToDelete = _jobs.FirstOrDefault(j => j.Id == id);
        if (jobToDelete == null)
        {
            throw new ArgumentNullException("Задача не должна быть пустой!");
        }
        
        _jobs.Remove(jobToDelete);
      
    }
/// <summary>
/// возращает копию списка задач по статусу
/// </summary>
/// <param name="status">задачи с таким статусом будут возвращены</param>
/// <returns></returns>
    public List<Job> GetJobByStatus(JobStatus status)
    {
        return _jobs.Where(s => s.Status == status).ToList();
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