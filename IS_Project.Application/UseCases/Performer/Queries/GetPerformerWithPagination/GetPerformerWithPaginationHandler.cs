using IS_Project.Application.Common;
using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;

namespace IS_Project.Application.UseCases.Performer.Queries.GetPerformerWithPagination;

public class GetPerformerWithPaginationHandler : IRequestHandler<GetPerformerWithPagination, PaginatedList<Model.Performer>>
{
    private readonly IApplicationDbContext _context;

    public GetPerformerWithPaginationHandler(IApplicationDbContext context) => _context = context;
    

    public async Task<PaginatedList<Model.Performer>> Handle(GetPerformerWithPagination request, CancellationToken cancellationToken)
    {
        var query = _context.Performers.AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchFirstName))
            query.Where(x=> x.FirstName.Contains(request.SearchFirstName, 
                StringComparison.InvariantCultureIgnoreCase));
        if (!string.IsNullOrEmpty(request.SearchLastName))
            query.Where(x=> x.LastName.Contains(request.SearchLastName, 
                StringComparison.InvariantCultureIgnoreCase));
        if (!string.IsNullOrEmpty(request.SearchMiddleName))
            query.Where(x=> !string.IsNullOrEmpty(x.MiddleName) 
                && x.MiddleName.Contains(request.SearchMiddleName,
                StringComparison.InvariantCultureIgnoreCase));

        if (!string.IsNullOrEmpty(request.SearchPhone))
            query.Where(x=> !string.IsNullOrEmpty(x.PhoneNumber) 
                && x.PhoneNumber.Contains(request.SearchPhone));

        if (!string.IsNullOrEmpty(request.SearchAboutMe))
            query.Where(x => !string.IsNullOrEmpty(x.AboutMe) 
                && x.AboutMe.Contains(request.SearchAboutMe, 
                StringComparison.InvariantCultureIgnoreCase));

        return await query.Distinct().PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}