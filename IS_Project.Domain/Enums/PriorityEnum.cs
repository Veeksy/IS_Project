namespace IS_Project.Domain.Enums;

public enum PriorityEnum
{
    /// <summary>
    /// Нет приоритета или наинизший приоритет
    /// </summary>
    None = 0,
    /// <summary>
    /// Низкий приоритет задачи
    /// </summary>
    Low = 1,
    /// <summary>
    /// Средний приоритет задачи
    /// </summary>
    Medium = 2,
    /// <summary>
    /// Высокий приоритет задачи
    /// </summary>
    High = 3,
    /// <summary>
    /// Срочный, критический приоритет задачи
    /// </summary>
    Critical = 4,
}
