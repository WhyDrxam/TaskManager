namespace Models;
/// <summary>
/// Класс Задачи
/// </summary>
public class Job
{
    /// <summary>
    /// Уникальный Id для каждой Задачи
    /// </summary>
    public Guid Id { get; private set; } = Guid.NewGuid();
    private string title;
/// <summary>
/// Св-во проверяет на пустое значение сеттер
/// </summary>
/// <exception cref="ArgumentException">Ошибка при пустом значении</exception>
    public string Title
    {
        get => title;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Неверное название");
            }
                title = value;
        }
    }
/// <summary>
/// Описание Задачи
/// </summary>
    public string? Description { get; private set; }
    /// <summary>
    /// Когда задача была создана
    /// </summary>
    public DateTime CreatedDate { get; } = DateTime.Now;
    /// <summary>
    /// дедлайн задачи
    /// </summary>
    public DateTime? DueDate { get; private set; }
    private int priority;
    /// <summary>
    /// Приоритетность задачи(значение не должнобыть меньше 0)
    /// </summary>
    /// <exception cref="ArgumentException">Ошибка при значении менее 0</exception>
    public int Priority
    {
        get => priority;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Ошибка");
            }

            priority = value;
        }
    }
    /// <summary>
    /// статус задачи(ToDo по умолчанию)
    /// </summary>
    public JobStatus Status { get; private set; } = JobStatus.ToDo;

    public override string ToString()
    {
        return $"Job {Id}: {Title} ({Status})";
    }
}