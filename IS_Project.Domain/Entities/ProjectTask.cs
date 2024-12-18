using IS_Project.Domain.Enums;

namespace IS_Project.Domain.Entities;
/// <summary>
/// Задачи исполнителей (проекта)
/// </summary>
public class ProjectTask
{
    /// <summary>
    /// айди таски
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// Описание таски
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Время на работу
    /// </summary>
    public decimal EstablishedTime { get; set; } = decimal.Zero;
    /// <summary>
    /// Затраченное время
    /// </summary>
    public decimal SpentTime { get; set; } = decimal.Zero;
    /// <summary>
    /// айди исполнителя
    /// </summary>
    public Guid PerformerId { get; set; } = default!;
    /// <summary>
    /// айди проекта
    /// </summary>
    public required Guid ProjectId { get; set; }
    /// <summary>
    /// Статус задачи
    /// </summary>
    public StatusEnum TaskStatus { get; set; } = StatusEnum.InWork;
}
