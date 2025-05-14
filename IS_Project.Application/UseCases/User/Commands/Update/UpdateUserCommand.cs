using MediatR;

namespace IS_Project.Application.UseCases.User.Commands.Update;

public record UpdateUserCommand : IRequest<Guid>
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Role { get; init; }
}
