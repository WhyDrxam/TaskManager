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
        

        if (_jobs.Any(j => j.Id == job.Id))
        {
            throw new ArgumentException("Задача с таким номером уже существует!", nameof(job));
        }

        if (job.Id != Guid.Empty)
        {
            _jobs.Add(job);
        }
        
    }

    /// <summary>
    /// Пытается обновить задачу с указанным ID
    /// </summary>
    /// <returns>true если задача была обновлена, false если задача не найдена</returns>
    
    public bool TryUpdateJob(Guid id, Job updatedJob)
    {
        if (updatedJob == null)
        {
            throw new ArgumentNullException(nameof(updatedJob));
        }

        var jobYoUpdateIndex = _jobs.FindIndex(j => j.Id == id);
        if (jobYoUpdateIndex == -1)
        {
            return false;
        }

        _jobs[jobYoUpdateIndex] = updatedJob;
        return true;
    }
/// <summary>
/// удаляет задач из списка задач
/// </summary>
/// <param name="job">задача которую надо удалить</param>
/// <exception cref="ArgumentNullException">если задача пуста, ошибка</exception>
    public void DeleteJob(Job job)
    {
        if (job == null)
        {
            throw new ArgumentNullException(nameof(job));
        }

        var jobToDelete = _jobs.FirstOrDefault(j => j.Id == job.Id);
        if (jobToDelete == null)
        {
            throw new ArgumentNullException(nameof(job));
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