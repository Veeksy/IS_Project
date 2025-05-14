using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;
using IS_Project.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IS_Project.Application.UseCases.Project.Commands.Update;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Model.Project>
{
    private readonly IApplicationDbContext _context;

    public UpdateProjectCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Model.Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var prj = await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (prj is null)
            throw new NotFoundException(request.Id);

        prj.Id = request.Id;

        _context.Projects.Update(prj);

        await _context.SaveChangesAsync(cancellationToken);

        return prj;
    }
}
