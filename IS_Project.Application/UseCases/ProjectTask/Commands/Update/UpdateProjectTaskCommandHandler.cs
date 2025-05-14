using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;
using Microsoft.EntityFrameworkCore;
using IS_Project.Application.Common.Exceptions;

namespace IS_Project.Application.UseCases.ProjectTask.Commands.Update;

public class UpdateProjectTaskCommandHandler : IRequestHandler<UpdateProjectTaskCommand, Model.ProjectTask>
{
    private readonly IApplicationDbContext _context;

    public UpdateProjectTaskCommandHandler(IApplicationDbContext context) => _context = context;
    
    public async Task<Model.ProjectTask> Handle(UpdateProjectTaskCommand request, CancellationToken cancellationToken)
    {
        var projectTask = await _context.ProjectTasks
            .FirstOrDefaultAsync(x=>x.Id == request.Id, cancellationToken);

        if (projectTask is null)
            throw new NotFoundException(request.Id);

        projectTask.Name = request.Name;
        projectTask.Description = request.Description;
        projectTask.ProjectId = request.ProjectId;
        projectTask.Priority = request.Priority;
        projectTask.EstablishedTime = request.EstablishedTime;
        projectTask.PerformerId = request.PerformerId;
        projectTask.SpentTime = request.SpentTime;
        projectTask.TaskStatus = request.TaskStatus;

        _context.ProjectTasks.Update(projectTask);

        await _context.SaveChangesAsync(cancellationToken);

        return projectTask;
    }
}
