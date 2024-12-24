using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;
using Microsoft.EntityFrameworkCore;
using IS_Project.Application.Common.Exceptions;

namespace IS_Project.Application.UseCases.Project.Queries.GetProject;

public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, Model.Project>
{
    private readonly IApplicationDbContext _context;

    public GetProjectQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Model.Project> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        var prj = await _context.Projects
            .FirstOrDefaultAsync(x=> x.Id == request.Id, cancellationToken);

        if (prj is null)
            throw new NotFoundException(request.Id);

        return prj;
    }
}
