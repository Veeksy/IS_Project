using MediatR;

namespace IS_Project.Application.UseCases.Project.Commands.Create;

public record CreateProjectCommand : IRequest<Guid>
{
    public required string Name { get; init; }
    public string Description { get; init; } = default!;
}
