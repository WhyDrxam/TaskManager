namespace Models;
/// <summary>
/// Класс Задачи
/// </summary>
public class Job
{
    public Job()
    {
        Tags = new List<string>();
    }
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
    public DateTime? DueDate { get; set; }
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
/// <summary>
/// Категория задания
/// Значения: работа, для себя, для учебы
/// </summary>
    public JobCategory Category { get; private set; } = JobCategory.Personal;
/// <summary>
/// список хранения тегов
/// </summary>
    public List<string> Tags { get; set; }
/// <summary>
/// меняет категорию задчи
/// </summary>
/// <param name="category">новая категория задачи из доступных ктегорий</param>
    public void ChangeCategory(JobCategory NewCategory)
    {
        Category = NewCategory;
    }
    /// <summary>
    /// валидация изменения категории через число
    /// </summary>
    /// <param name="category">числовое представление категории</param>
    /// <exception cref="ArgumentException">ошибка если категорию отсутсвует</exception>
    public void ChangeCategory(int category)
    {
        bool isValid = Enum.IsDefined(typeof(JobCategory), category);
        if (!isValid)
        {
            throw new ArgumentException("Нет такого варианта!");
        }
        ChangeCategory((JobCategory)category);
    }
/// <summary>
/// валидация изменения категории через строку
/// </summary>
/// <param name="category">строковое представление категории</param>
/// <exception cref="ArgumentException">ошибка если категорию отсутсвует</exception>
    public void ChangeCategory(string category)
    {
        bool isValid = Enum.TryParse<JobCategory>(category, ignoreCase: true, out JobCategory newCategory);
        if (!isValid)
        {
            throw new ArgumentException("Нет такого варианта!");
        }
        ChangeCategory(newCategory);
    }

/// <summary>
/// добавляет тег в список Tags
/// </summary>
/// <param name="tag">строка тега который добавляется</param>
/// <exception cref="ArgumentException">ошибка если значение пустое или только из пробелов</exception>
    public void AddTag(string tag)
    {
        if (string.IsNullOrWhiteSpace(tag))
        {
            throw new ArgumentException("Значение не может быть пустым");
        }
        Tags.Add(tag);
    }
/// <summary>
/// вывод статус задания
/// </summary>
/// <returns>возвращает строку со статусом</returns>
    public override string ToString()
    {
        var tags = string.Join(",", Tags);
        return $"Job {Id}: {Title} ({Status}, Tags: {tags} )";
    }
}