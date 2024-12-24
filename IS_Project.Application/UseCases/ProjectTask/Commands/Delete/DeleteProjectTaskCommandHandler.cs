using IS_Project.Application.Common.Data;
using IS_Project.Application.Common.Exceptions;
using MediatR;

namespace IS_Project.Application.UseCases.ProjectTask.Commands.Delete;

public class DeleteProjectTaskCommandHandler : IRequestHandler<DeleteProjectTaskCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProjectTaskCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task Handle(DeleteProjectTaskCommand request, CancellationToken cancellationToken)
    {
        var projectTask = await _context.ProjectTasks.FindAsync([request.Id], cancellationToken);

        if (projectTask is null)
            throw new NotFoundException(request.Id);

        _context.ProjectTasks.Remove(projectTask);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}