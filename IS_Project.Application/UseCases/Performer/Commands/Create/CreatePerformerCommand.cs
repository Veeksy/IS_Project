using MediatR;

namespace IS_Project.Application.UseCases.Performer.Commands.Create;

public record CreatePerformerCommand : IRequest<Guid>
{
    /// <summary>
    /// Имя исполнителя
    /// </summary>
    public required string FirstName { get; init; }
    /// <summary>
    /// Фамилия исполнителя
    /// </summary>
    public required string LastName { get; init; }
    /// <summary>
    /// Отчество исполнителя
    /// </summary>
    public string? MiddleName { get; init; } = null!;
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string? PhoneNumber { get; init; } = null!;
    /// <summary>
    /// Об исполнителе
    /// </summary>
    public string? AboutMe { get; init; } = null!;
}
