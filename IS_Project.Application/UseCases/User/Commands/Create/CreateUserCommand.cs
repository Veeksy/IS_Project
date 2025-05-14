using MediatR;

namespace IS_Project.Application.UseCases.User.Commands.Create;

public record CreateUserCommand : IRequest<Guid>
{
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public Guid PerformerId { get; init; }
}
