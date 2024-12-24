using Model = IS_Project.Domain.Entities;
using MediatR;

namespace IS_Project.Application.UseCases.Project.Commands.Update;

public record UpdateProjectCommand : IRequest<Model.Project>
{
    public required Guid Id { get; init; } 
    public required string ProjectName { get; init; }
    public string Description { get; init; } = string.Empty!;
}
