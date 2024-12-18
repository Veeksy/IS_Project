using IS_Project.Application.Common;
using Model = IS_Project.Domain.Entities;
using MediatR;

namespace IS_Project.Application.UseCases.Performer.Queries.GetPerformerWithPagination;

public record GetPerformerWithPagination : IRequest<PaginatedList<Model.Performer>>
{
    public string? SearchFirstName { get; init; }
    public string? SearchMiddleName { get; init; }
    public string? SearchLastName { get; init; }
    public string? SearchPhone { get; init; }
    public string? SearchAboutMe { get; init; }

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
