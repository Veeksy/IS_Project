using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Domain.Enums;
using IS_Project.Application.Common;

namespace IS_Project.Application.UseCases.ProjectTask.Queries.GetProjectTaskWithPagination;

public record GetProjectTaskWithoutPagination : IRequest<PaginatedList<Model.ProjectTask>>
{
    public string? Name { get; init; } 
    public Guid? PerformerId { get; set; } 
    public Guid? ProjectId { get; set; } 
    public PriorityEnum? Priority { get; set; } 
    public StatusEnum? TaskStatus { get; set; }

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
