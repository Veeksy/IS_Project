using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;
using IS_Project.Application.Common;

namespace IS_Project.Application.UseCases.Project.Queries.GetProjectWithPagination;

public class GetProjectWithPaginationHandler : IRequestHandler<GetProjectWithPagination, PaginatedList<Model.Project>>
{
    private readonly IApplicationDbContext _context;

    public GetProjectWithPaginationHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<Model.Project>> Handle(GetProjectWithPagination request, CancellationToken cancellationToken)
    {
        var query = _context.Projects.AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchName))
            query.Where(x=>x.Name.Contains(request.SearchName, StringComparison.InvariantCultureIgnoreCase));

        if (!string.IsNullOrEmpty(request.SearchDescription))
            query.Where(x => !string.IsNullOrEmpty(x.Description) 
            && x.Description.Contains(request.SearchDescription, 
            StringComparison.InvariantCultureIgnoreCase));

        return await query.Distinct().PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
