using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;
using Microsoft.EntityFrameworkCore;
using IS_Project.Application.Common.Exceptions;

namespace IS_Project.Application.UseCases.ProjectTask.Queries.GetProjectTask;

public class GetProjectTaskQueryHandler : IRequestHandler<GetProjectTaskQuery, Model.ProjectTask>
{
    private readonly IApplicationDbContext _context;

    public GetProjectTaskQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Model.ProjectTask> Handle(GetProjectTaskQuery request, CancellationToken cancellationToken)
    {
        var projectTask = await _context.ProjectTasks
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (projectTask is null)
            throw new NotFoundException(request.Id);

        return projectTask;
    }
}