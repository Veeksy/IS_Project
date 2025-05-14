using IS_Project.Domain.Enums;
using MediatR;

namespace IS_Project.Application.UseCases.ProjectTask.Commands.Create;

public record CreateProjectTaskCommand : IRequest<Guid>
{
    public required string Name { get; init; }
    public string Description { get; init; } = default!;
    public decimal EstablishedTime { get; init; } = decimal.Zero;
    public decimal SpentTime { get; init; } = decimal.Zero;
    public Guid PerformerId { get; init; } = default!;
    public required Guid ProjectId { get; init; }
    public PriorityEnum Priority { get; init; } = PriorityEnum.Medium;
    public StatusEnum TaskStatus { get; init; } = StatusEnum.InWork;
}
