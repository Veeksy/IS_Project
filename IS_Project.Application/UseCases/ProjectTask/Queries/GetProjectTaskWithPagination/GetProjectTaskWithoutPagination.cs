using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Domain.Enums;

namespace IS_Project.Application.UseCases.ProjectTask.Queries.GetProjectTaskWithPagination;

public record GetProjectTaskWithoutPagination : IRequest<List<Model.ProjectTask>>
{
    public string? Name { get; init; } = default!;
    public Guid? PerformerId { get; set; } = default!;
    public Guid? ProjectId { get; set; } = default!;
    public PriorityEnum? Priority { get; set; } = default!;
    public StatusEnum? TaskStatus { get; set; } = default!;
}
