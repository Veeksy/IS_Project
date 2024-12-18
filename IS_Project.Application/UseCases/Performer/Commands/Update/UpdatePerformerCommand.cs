using Model = IS_Project.Domain.Entities;
using MediatR;

namespace IS_Project.Application.UseCases.Performer.Commands.Update;

public record UpdatePerformerCommand : IRequest<Model.Performer>
{
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? MiddleName { get; init; }
    public string? PhoneNumber { get; init; }
    public string? AboutMe { get; init; }
}
