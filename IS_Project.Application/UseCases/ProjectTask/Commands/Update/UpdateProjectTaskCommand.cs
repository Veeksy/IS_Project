using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Domain.Enums;

namespace IS_Project.Application.UseCases.ProjectTask.Commands.Update;

public record UpdateProjectTaskCommand : IRequest<Model.ProjectTask>
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public string Description { get; init; } = default!;
    public decimal EstablishedTime { get; init; } = decimal.Zero;
    public decimal SpentTime { get; init; } = decimal.Zero;
    public Guid PerformerId { get; init; } = default!;
    public required Guid ProjectId { get; init; }
    public PriorityEnum Priority { get; init; } = PriorityEnum.Medium;
    public StatusEnum TaskStatus { get; set; } = StatusEnum.InWork;
}