namespace IS_Project.Domain.Entities;

/// <summary>
/// Исполнитель
/// </summary>
public class Performer
{
    /// <summary>
    /// айди исполнителя
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public required string LastName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; set; }
    /// <summary>
    /// Номер телефона(?) не знаю зачем
    /// </summary>
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// Какая-то пометка об исполнителе
    /// </summary>
    public string? AboutMe { get; set; }
}
