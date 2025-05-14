using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;

namespace IS_Project.Application.UseCases.Project.Commands.Create;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateProjectCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var newProject = new Model.Project() 
        { 
            Name = request.Name,
            Description = request.Description,
        };

        await _context.Projects.AddAsync(newProject, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return newProject.Id;
    }
}