using IS_Project.Application.Common.Data;
using IS_Project.Application.Common.Exceptions;
using MediatR;

namespace IS_Project.Application.UseCases.Performer.Commands.Delete;

public class DeletePerformerCommandHandler : IRequestHandler<DeletePerformerCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePerformerCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task Handle(DeletePerformerCommand request, CancellationToken cancellationToken)
    {
        var performer = await _context.Performers.FindAsync([request.Id], cancellationToken);

        if (performer is null)
        {
            throw new NotFoundException(request.Id);
        }

        _context.Performers.Remove(performer);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
