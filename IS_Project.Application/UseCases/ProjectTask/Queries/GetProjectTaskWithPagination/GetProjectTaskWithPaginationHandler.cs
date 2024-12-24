using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace IS_Project.Application.UseCases.ProjectTask.Queries.GetProjectTaskWithPagination;

public class GetProjectTaskWithPaginationHandler : IRequestHandler<GetProjectTaskWithoutPagination, List<Model.ProjectTask>>
{
    private readonly IApplicationDbContext _context;

    public GetProjectTaskWithPaginationHandler(IApplicationDbContext context) => _context = context;

    public async Task<List<Model.ProjectTask>> Handle(GetProjectTaskWithoutPagination request, CancellationToken cancellationToken)
    {
        var query = _context.ProjectTasks.AsQueryable();

        if (request.ProjectId is not null)
            query.Where(x=>x.ProjectId == request.ProjectId);

        if (request.PerformerId is not null)
            query.Where(x=>x.PerformerId == request.PerformerId);

        if (!string.IsNullOrEmpty(request.Name))
            query.Where(x=>x.Name.Contains(request.Name, 
                StringComparison.InvariantCultureIgnoreCase));

        if (request.TaskStatus is not null)
            query.Where(x=>x.TaskStatus == request.TaskStatus);

        if (request.Priority is not null)
            query.Where(x=>x.Priority == request.Priority);

        return await query.Distinct().ToListAsync(cancellationToken);
    }
}