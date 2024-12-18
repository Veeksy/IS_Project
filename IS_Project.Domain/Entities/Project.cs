namespace IS_Project.Domain.Entities;
/// <summary>
/// Проекты
/// </summary>
public class Project
{
    /// <summary>
    /// Id проекта
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование 
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Описание
    /// </summary>
    public required string Description { get; set; }
}
