namespace IS_Project.Domain.Enums;
/// <summary>
/// Статусы задач
/// </summary>
public enum StatusEnum
{
    /// <summary>
    /// В работу
    /// </summary>
    InWork = 0,
    /// <summary>
    /// В работе
    /// </summary>
    InDevelop = 1,
    /// <summary>
    /// На проверке
    /// </summary>
    InReview = 2,
    /// <summary>
    /// Завершено
    /// </summary>
    Completed = 3,
    /// <summary>
    /// Отклонено
    /// </summary>
    Declined = 4,
}
