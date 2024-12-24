using IS_Project.Application.Common.Data;
using IS_Project.Application.Common.Exceptions;
using MediatR;

namespace IS_Project.Application.UseCases.Project.Commands.Delete
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProjectCommandHandler(IApplicationDbContext context) => _context = context; 

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.FindAsync([request.Id], cancellationToken);

            if (project is null)
            {
                throw new NotFoundException(request.Id);
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
