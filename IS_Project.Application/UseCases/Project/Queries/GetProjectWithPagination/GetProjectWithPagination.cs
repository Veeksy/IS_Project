using IS_Project.Application.Common;
using Model = IS_Project.Domain.Entities;
using MediatR;

namespace IS_Project.Application.UseCases.Project.Queries.GetProjectWithPagination;

public record GetProjectWithPagination : IRequest<PaginatedList<Model.Project>>
{
    public string? SearchName { get; init; }

    public string? SearchDescription { get; init; }

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
