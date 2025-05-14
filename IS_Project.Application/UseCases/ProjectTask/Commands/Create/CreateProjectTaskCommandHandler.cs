using IS_Project.Application.Common.Data;
using Model = IS_Project.Domain.Entities;
using MediatR;

namespace IS_Project.Application.UseCases.ProjectTask.Commands.Create;

public class CreateProjectTaskCommandHandler : IRequestHandler<CreateProjectTaskCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    
    public CreateProjectTaskCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Guid> Handle(CreateProjectTaskCommand request, CancellationToken cancellationToken)
    {
        var projectTask = new Model.ProjectTask()
        {
            ProjectId = request.ProjectId,
            Name = request.Name,
            Priority = request.Priority,
            Description = request.Description,
            EstablishedTime = request.EstablishedTime,
            SpentTime = request.SpentTime,
            PerformerId = request.PerformerId,
            TaskStatus = request.TaskStatus,
        };

        await _context.ProjectTasks.AddAsync(projectTask, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return projectTask.Id;
    }
}